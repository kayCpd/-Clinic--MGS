using Clinic.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clinic.Persistence.Configurations
{
    internal class GPOfficeConfig : IEntityTypeConfiguration<GPOffice>
    {
        public void Configure(EntityTypeBuilder<GPOffice> builder)
        {
            builder.Property(prop => prop.Name)
            .HasMaxLength(150)
            .IsRequired();

        }
    }
}
