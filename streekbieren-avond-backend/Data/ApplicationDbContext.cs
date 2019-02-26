using Microsoft.EntityFrameworkCore;
using streekbieren_avond_backend.Data.Mappers;
using streekbieren_avond_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace streekbieren_avond_backend.Data
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<Streekbier> Streekbieren { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new StreekbierConfig());
            modelBuilder.ApplyConfiguration(new BrouwerijConfig());
        }
        //onmodelcreating, applyconfig
    }
}
