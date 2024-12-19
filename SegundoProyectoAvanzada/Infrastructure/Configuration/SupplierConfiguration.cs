using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SegundoProyectoAvanzada.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundoProyectoAvanzada.Infrastructure.Configuration
{
   public class SupplierConfiguration:IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> entity)
        {
            entity.HasKey(e => e.SupplierID);

            entity.Property(e => e.CompanyName)
                .IsRequired()
                .HasMaxLength(40);

            entity.Property(e => e.ContactName)
                .HasMaxLength(30);

            entity.Property(e => e.ContactTitle)
                .HasMaxLength(30);

            entity.Property(e => e.Address)
                .HasMaxLength(60);

            entity.Property(e => e.City)
                .HasMaxLength(15);

            entity.Property(e => e.Country)
                .HasMaxLength(15);

            entity.Property(e => e.Phone)
                .HasMaxLength(24);
        }
    }
}
