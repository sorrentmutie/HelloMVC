using DemoCorso.Core.Students;
using Microsoft.EntityFrameworkCore;

namespace HelloMVC.Data;

public class SchoolDbContext: DbContext
{
    public SchoolDbContext(DbContextOptions<SchoolDbContext> options)
        : base(options)
    {
        
    }
    public DbSet<Student> Students { get; set; } = null!;
    public DbSet<Course> Courses { get; set; } = null!;
    public DbSet<Enrollment> Enrollments { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>().ToTable("Studenti");
        modelBuilder.Entity<Course>().ToTable("Corsi");
        modelBuilder.Entity<Enrollment>().ToTable("Iscrizioni");

        modelBuilder.Entity<Student>().Property(s => s.FirstName).HasMaxLength(50);
        modelBuilder.Entity<Student>().Property(s => s.LastName).HasMaxLength(50);
        modelBuilder.Entity<Student>().Property(s => s.MiddleName).HasMaxLength(50);
        modelBuilder.Entity<Student>().Property(s => s.FirstName).IsRequired();
        modelBuilder.Entity<Student>().Property(s => s.LastName).IsRequired();

    }
}
