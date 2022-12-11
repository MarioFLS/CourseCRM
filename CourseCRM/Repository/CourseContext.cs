using CourseCRM.Models;
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=127.0.0.1;Database=course;User=SA;Password=Password12!;Encrypt=False");

        }

    }
}
