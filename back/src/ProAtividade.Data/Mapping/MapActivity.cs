using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProAtividade.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProAtividade.Data.Mapping
{
    public class MapActivity : IEntityTypeConfiguration<Activity>
    {
        public void Configure(EntityTypeBuilder<Activity> builder)
        {
            builder.ToTable("Activities");

            builder.Property(a => a.Title)
                .HasColumnType("varchar(100)");

            builder.Property(a => a.Description)
                .HasColumnType("varchar(250)");

        }
    }
}