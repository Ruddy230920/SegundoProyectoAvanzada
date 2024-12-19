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
    public class ShipperConfiguration:IEntityTypeConfiguration<Shippers>
    {
        public void Configure(EntityTypeBuilder<Shippers> builder)
        {
            builder.HasKey(s => s.ShipperID); 

            builder.Property(s => s.CompanyName)
                   .IsRequired()
                   .HasMaxLength(40);

            builder.Property(s => s.Phone)
                   .HasMaxLength(24);

           
            builder.HasMany(s => s.Orders)
                   .WithOne(o => o.Shippers)
                   .HasForeignKey(o => o.ShipVia);
        }
    }
}
