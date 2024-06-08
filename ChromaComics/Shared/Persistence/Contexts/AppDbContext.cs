using ChromaComics.Comics.Domain.Models;
using ChromaComics.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

namespace ChromaComics.Shared.Persistence.Contexts;

public class AppDbContext : DbContext
{
    
    public DbSet<Category> Categories { get; set; }
    
    public DbSet<Comic> Comics { get; set; }


    public AppDbContext(DbContextOptions options) : base(options)
    {
    }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Category>().ToTable("Categories");
        builder.Entity<Category>().HasKey(p => p.Id);
        builder.Entity<Category>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Category>().Property(p => p.Name).IsRequired().HasMaxLength(30);
        
        // Relationships
        builder.Entity<Category>()
            .HasMany(p => p.Comics)
            .WithOne(p => p.Category)
            .HasForeignKey(p => p.CategoryId);
        
        builder.Entity<Comic>().ToTable("Comics");
        builder.Entity<Comic>().HasKey(p => p.Id);
        builder.Entity<Comic>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Comic>().Property(p => p.Title).IsRequired().HasMaxLength(50);
        builder.Entity<Comic>().Property(p => p.Description).HasMaxLength(120);
        
        
        // Apply Snake Case Naming Convention
        
        builder.UseSnakeCaseNamingConvention();
    }
}