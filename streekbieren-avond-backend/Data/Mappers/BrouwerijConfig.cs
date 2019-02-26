using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using streekbieren_avond_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static streekbieren_avond_backend.Models.Streekbier;

namespace streekbieren_avond_backend.Data.Mappers
{
    public class BrouwerijConfig : IEntityTypeConfiguration<BrouwerijClass>
    {
        public void Configure(EntityTypeBuilder<BrouwerijClass> builder)
        {
            //Table name
            builder.ToTable("Brouwerij");
            //Properties
            builder.HasKey(b => b.Naam);
            builder.Property(brouwerij => brouwerij.Naam).IsRequired();
        }
    }
}
