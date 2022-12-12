﻿using CourseCRM.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseCRM.Repository
{
    public class CourseContext : DbContext
    {
        public CourseContext() { }
        public CourseContext(DbContextOptions<CourseContext> options) : base(options) { }

        public DbSet<Lead> Leads { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<Enrollment> Enrollment { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Lead>()
                .HasIndex(u => u.Email)
                .IsUnique();
            builder.Entity<Lead>()
                .HasIndex(u => u.Cpf)
                .IsUnique();

            builder.Entity<Course>().HasData(
                new Course()
                {
                    Id = 1,
                    Name = "C#"
                },
                new Course()
                {
                    Id = 2,
                    Name = "dotNet"
                },
                new Course()
                {
                    Id = 3,
                    Name = "JavaScript"
                },
                new Course()
                {
                    Id = 4,
                    Name = "React"
                }
                );
                
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=127.0.0.1;Database=course;User=SA;Password=Password12!;Encrypt=False");

        }

    }
}
