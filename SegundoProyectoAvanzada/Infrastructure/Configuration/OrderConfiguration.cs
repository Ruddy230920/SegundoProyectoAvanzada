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
    public class OrderConfiguration:IEntityTypeConfiguration<Orders>
    {
        public void Configure(EntityTypeBuilder<Orders> builder)
        {
            // Clave primaria
            builder.HasKey(o => o.OrderID);

            // Claves foráneas
            builder.HasOne(o => o.Customers)
                   .WithMany(c => c.Orders)
                   .HasForeignKey(o => o.CustomerID);

            builder.HasOne(o => o.Employees)
                   .WithMany(e => e.Orders)
                   .HasForeignKey(o => o.EmployeeID);

            builder.HasOne(o => o.Shippers)
                   .WithMany(s => s.Orders)
                   .HasForeignKey(o => o.ShipVia);

            // Columnas
            builder.Property(o => o.OrderDate)
                   .HasColumnType("datetime")
                   .IsRequired(false);

            builder.Property(o => o.RequiredDate)
                   .HasColumnType("datetime")
                   .IsRequired(false);

            builder.Property(o => o.ShippedDate)
                   .HasColumnType("datetime")
                    .IsRequired(false);

            builder.Property(o => o.Freight)
                   .HasColumnType("money")
                   .IsRequired(false);

            builder.Property(o => o.ShipName)
                   .HasMaxLength(40)
                   .IsRequired(false);

            builder.Property(o => o.ShipAddress)
                   .HasMaxLength(60)
                   .IsRequired(false);

            builder.Property(o => o.ShipCity)
                   .HasMaxLength(15)
                   .IsRequired(false);

            builder.Property(o => o.ShipRegion)
                   .HasMaxLength(15)
                   .IsRequired(false);

            builder.Property(o => o.ShipPostalCode)
                   .HasMaxLength(10)
                   .IsRequired(false);

            builder.Property(o => o.ShipCountry)
                   .HasMaxLength(15)
                   .IsRequired(false);
        }
    }
}
