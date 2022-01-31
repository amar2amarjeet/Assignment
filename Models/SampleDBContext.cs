using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPI.Models
{
    public class SampleDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<State> States { get; set; }

        public DbSet<City> Cities { get; set; }

        public SampleDBContext(DbContextOptions<SampleDBContext> options)
            : base(options)
        {
            
        }


    }
}