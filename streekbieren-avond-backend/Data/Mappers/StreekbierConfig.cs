using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using streekbieren_avond_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace streekbieren_avond_backend.Data.Mappers
{
    public class StreekbierConfig : IEntityTypeConfiguration<Streekbier>
    {
        public void Configure(EntityTypeBuilder<Streekbier> builder)
        {
            builder.ToTable("Streekbier");
            builder.HasKey(b => b.Naam);
            builder.Property(bier => bier.Naam).IsRequired();
            builder.Property(bier => bier.Percentage).IsRequired();
            builder.HasOne(b => b.Brouwerij).WithMany().IsRequired().OnDelete(DeleteBehavior.Cascade);
        }
    }
}
