using ChromaComics.Comics.Domain.Models;
using ChromaComics.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

namespace ChromaComics.Shared.Persistence.Contexts;

public class AppDbContext : DbContext
{
    
    public DbSet<ShoppingCart> ShoppingCarts { get; set; }
    


    public AppDbContext(DbContextOptions options) : base(options)
    {
    }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<ShoppingCart>().ToTable("Carts");
        builder.Entity<ShoppingCart>().HasKey(p => p.Id);
        builder.Entity<ShoppingCart>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        
        
        builder.UseSnakeCaseNamingConvention();
    }
}