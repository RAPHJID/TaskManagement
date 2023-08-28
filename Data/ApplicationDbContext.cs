using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public DbSet<Task> Tasks { get; set; }
    public DbSet<Project> Projects { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            // Configuring the database 
            optionsBuilder.UseSqlServer("Server=localhost; Database=Assessement; User id=SA; Password=JidKim7804; Encrypt=True; TrustServerCertificate=True");
        }
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
}

