﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SegundoProyectoAvanzada.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegundoProyectoAvanzada.Infrastructure.Configuration
{
    public class EmployeeConfiguration:IEntityTypeConfiguration<Employees>
    {
        public void Configure(EntityTypeBuilder<Employees> builder)
        {
            builder.HasKey(e => e.EmployeeID); 

            builder.Property(e => e.LastName)
                   .IsRequired()
                   .HasMaxLength(20);

            builder.Property(e => e.FirstName)
                   .IsRequired()
                   .HasMaxLength(10);

            builder.Property(e => e.Title)
                   .HasMaxLength(30);

            builder.Property(e => e.TitleOfCourtesy)
                   .HasMaxLength(25);

            builder.Property(e => e.BirthDate);

            builder.Property(e => e.HireDate);

            builder.Property(e => e.Address)
                   .HasMaxLength(60);

            builder.Property(e => e.City)
                   .HasMaxLength(15);

            builder.Property(e => e.Region)
                   .HasMaxLength(15);

            builder.Property(e => e.PostalCode)
                   .HasMaxLength(10);

            builder.Property(e => e.Country)
                   .HasMaxLength(15);

            builder.Property(e => e.HomePhone)
                   .HasMaxLength(24);

            builder.Property(e => e.Extension)
                   .HasMaxLength(4);

            

            builder.Property(e => e.Notes);

            builder.Property(e => e.PhotoPath)
                   .HasMaxLength(255);


        
            builder.HasMany(e => e.Orders)
                   .WithOne(o => o.Employees)
                   .HasForeignKey(o => o.EmployeeID);
        }
    }
}
