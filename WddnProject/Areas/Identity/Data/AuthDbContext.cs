﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WDDNProject.Areas.Identity.Data;
using WDDNProject.Models;

namespace WDDNProject.Data
{
    public class AuthDbContext : IdentityDbContext<AppUser>
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Exam>()
                    .HasOne<AppUser>(a => a.AppUser)
                    .WithMany(e => e.Exams)
                    .HasForeignKey(a => a.AppEmail);
            builder.Entity<AppUser>()
                   .HasMany<Exam>(a => a.Exams)
                   .WithOne(e => e.AppUser)
                   .OnDelete();
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Exam> Exams { get; set; }
    }
}