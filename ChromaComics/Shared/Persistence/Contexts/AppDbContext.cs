using ChromaComics.Comics.Domain.Models;
using Microsoft.EntityFrameworkCore;
using ChromaComics.IAM.Domain.Model.Aggregates;
using ChromaComics.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;

namespace ChromaComics.Shared.Persistence.Contexts;

public class AppDbContext : DbContext
{
    
    public DbSet<ShoppingCart> ShoppingCarts { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Comic> Comics { get; set; }
    public DbSet<Recommendation> Recommendations { get; set; }

    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
	
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        base.OnConfiguring(builder);
        // Enable Audit Fields Interceptors
        builder.AddCreatedUpdatedInterceptor();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<ShoppingCart>().ToTable("Carts");
        builder.Entity<ShoppingCart>().HasKey(p => p.Id);
        builder.Entity<ShoppingCart>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        
        builder.Entity<Category>().ToTable("Categories");
        builder.Entity<Category>().HasKey(p => p.Id);
        builder.Entity<Category>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Category>().Property(p => p.Name).IsRequired().HasMaxLength(30);
        
        builder.Entity<Comic>().ToTable("Comics");
        builder.Entity<Comic>().HasKey(p => p.Id);
        builder.Entity<Comic>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Comic>().Property(p => p.Title).IsRequired().HasMaxLength(50);
        builder.Entity<Comic>().Property(p => p.Description).HasMaxLength(120);

	
        builder.Entity<Recommendation>().ToTable("Recommendation");
        builder.Entity<Recommendation>().HasKey(p => p.Id);
        builder.Entity<Recommendation>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();

        builder.Entity<User>().HasKey(u => u.Id);
        builder.Entity<User>().Property(u => u.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<User>().Property(u => u.Username).IsRequired();
        builder.Entity<User>().Property(u => u.PasswordHash).IsRequired();
        
        // Relationships
        builder.Entity<Category>()
            .HasMany(p => p.Comics)
            .WithOne(p => p.Category)
            .HasForeignKey(p => p.CategoryId);
        

        builder.UseSnakeCaseNamingConvention();     
    }
}