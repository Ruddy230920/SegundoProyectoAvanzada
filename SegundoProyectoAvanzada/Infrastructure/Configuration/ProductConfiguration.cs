using Microsoft.EntityFrameworkCore;
using SegundoProyectoAvanzada.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundoProyectoAvanzada.Infrastructure.Configuration
{
    public class ProductConfiguration: IEntityTypeConfiguration<Products>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Products> entity)
        {
            entity.HasKey(e => e.ProductID);

            entity.Property(e => e.ProductName)
                .IsRequired()
                .HasMaxLength(40);

            entity.Property(e => e.QuantityPerUnit)
                .HasMaxLength(20);

            entity.Property(e => e.UnitPrice)
                .HasColumnType("money")
                .HasMaxLength(15);

            entity.Property(e => e.UnitsInStock)
                .HasColumnType("smallint");

            entity.HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryID)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(p => p.Supplier)
                .WithMany(s => s.Products)
                .HasForeignKey(p => p.SupplierID)
                .OnDelete(DeleteBehavior.Cascade);


        }
    }
}
