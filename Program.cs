using Microsoft.EntityFrameworkCore;
using PetFinderApi.Data;
using PetFinderApi.Data.Services;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using System;
using System.IO;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// builder.Services.AddDbContext<PetFinderContext>(options =>
//     options.UseSqlServer(builder.Configuration.GetConnectionString("petFinderContext") ??
//                          throw new InvalidOperationException("Connection string 'CDsContext' not found.")));
builder.Services.AddDbContext<PetFinderContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("azurePetFinderDb") ??
                         throw new InvalidOperationException("Connection string 'azurePetFinderDb' not found.")));

builder.Services.AddScoped<IWantingService, WantingService>();
builder.Services.AddScoped<ISightingService, SightingRepo>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("ReactJSDomain",
        policy => policy.WithOrigins("http://localhost:3000")
            .AllowAnyHeader()
            .AllowAnyMethod());
});
var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseCors("ReactJSDomain");

app.UseAuthorization();

app.MapControllers();

app.Run();
