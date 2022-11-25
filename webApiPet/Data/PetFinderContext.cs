using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PetFinderApi.Data.Entities;

namespace PetFinderApi.Data
{
    public class PetFinderContext : DbContext
    {
        public PetFinderContext (DbContextOptions<PetFinderContext> options)
            : base(options)
        {
        }

        public DbSet<PetFinderApi.Data.Entities.Cat> Cat { get; set; } = default!;

        public DbSet<PetFinderApi.Data.Entities.Person> Person { get; set; } = default!;

        public DbSet<PetFinderApi.Data.Entities.Wanting> Wanting { get; set; } = default!;
    }
}
