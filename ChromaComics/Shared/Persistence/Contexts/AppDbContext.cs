using ChromaComics.Recommendations.Domain.Models;
using ChromaComics.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

namespace ChromaComics.Shared.Persistence.Contexts;

public class AppDbContext : DbContext
{
    
    public DbSet<Recommendation> Recommendations { get; set; }
    


    public AppDbContext(DbContextOptions options) : base(options)
    {
    }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Recommendation>().ToTable("Recommendation");
        builder.Entity<Recommendation>().HasKey(p => p.Id);
        builder.Entity<Recommendation>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        
        
        builder.UseSnakeCaseNamingConvention();
    }
}