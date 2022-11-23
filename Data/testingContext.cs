using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using testing.Data.Entities;

namespace testing.Data
{
    public class testingContext : DbContext
    {
        public testingContext (DbContextOptions<testingContext> options)
            : base(options)
        {
        }

        public DbSet<testing.Data.Entities.Cat> Cat { get; set; } = default!;

        public DbSet<testing.Data.Entities.Person> Person { get; set; } = default!;
    }
}
