using Lab_01.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab_01.Data.Context
{
    public class StudentContext : DbContext
    {
        public StudentContext() { }
        public StudentContext(DbContextOptions option): base(option)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().
                HasIndex(p => p.Phone)
                .IsUnique();

            modelBuilder.Entity<Student>().
                HasIndex(p => p.Image)
                .IsUnique();
        }
      
    public DbSet<Student> students { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}
