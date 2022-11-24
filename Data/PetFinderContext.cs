using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PetFinderApi.Models;

namespace PetFinderApi.Data
{
    public class PetFinderContext : DbContext
    {
        public PetFinderContext (DbContextOptions<PetFinderContext> options)
            : base(options)
        {
        }

        public DbSet<PetFinderApi.Models.Cat> Cat { get; set; } = default!;

        public DbSet<PetFinderApi.Models.Person> Person { get; set; } = default!;

        public DbSet<PetFinderApi.Models.Wanting> Wanting { get; set; } = default!;

        public DbSet<PetFinderApi.Models.Sighting> Sighting { get; set; } = default!;

    }
}
