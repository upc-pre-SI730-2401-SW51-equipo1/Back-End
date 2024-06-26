using ChromaComics.Comics.Domain.Model.Aggregates;
using ChromaComics.Comics.Domain.Model.Entities;
using ChromaComics.IAM.Domain.Model.Aggregates;
using ChromaComics.payment.Domain.Model.Aggregates;
using ChromaComics.Recommendations.Models;
using ChromaComics.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using ChromaComics.ShoppingCarts.Domain.Models;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;

namespace ChromaComics.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Recommendation> Recommendations { get; set; }
    public DbSet<ShoppingCart> ShoppingCarts { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        base.OnConfiguring(builder);
        // Enable Audit Fields Interceptors
        builder.AddCreatedUpdatedInterceptor();
    }
    

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        
        // IAM Context
        
        builder.Entity<User>().HasKey(u => u.Id);
        builder.Entity<User>().Property(u => u.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<User>().Property(u => u.Username).IsRequired();
        builder.Entity<User>().Property(u => u.PasswordHash).IsRequired();
        builder.Entity<Category>().HasKey(c => c.Id);
        builder.Entity<Category>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Category>().Property(c => c.Name).IsRequired().HasMaxLength(30);
        
        builder.Entity<Comic>().HasKey(t => t.Id);
        builder.Entity<Comic>().Property(t => t.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Comic>().Property(t => t.Title).IsRequired().HasMaxLength(50);
        builder.Entity<Comic>().Property(t => t.Summary).HasMaxLength(240);

        builder.Entity<Asset>().HasDiscriminator(a => a.Type);
        builder.Entity<Asset>().HasKey(p => p.Id);
        builder.Entity<Asset>().HasDiscriminator<string>("asset_type")
            .HasValue<Asset>("asset_base")
            .HasValue<ImageAsset>("asset_image")
            .HasValue<VideoAsset>("asset_video")
            .HasValue<ReadableContentAsset>("asset_readable_content");

        builder.Entity<Asset>().OwnsOne(i => i.AssetIdentifier,
            ai =>
            {
                ai.WithOwner().HasForeignKey("Id");
                ai.Property(p => p.Identifier).HasColumnName("AssetIdentifier");
            });
        builder.Entity<ImageAsset>().Property(p => p.ImageUri).IsRequired();
        builder.Entity<VideoAsset>().Property(p => p.VideoUri).IsRequired();
        builder.Entity<Comic>().HasMany(t => t.Assets);
        
        // Category Relationships
        builder.Entity<Category>()
            .HasMany(c => c.Comics)
            .WithOne(t => t.Category)
            .HasForeignKey(t => t.CategoryId)
            .HasPrincipalKey(t => t.Id);
        
        //payment Context
        builder.Entity<Billing>().ToTable("Billings");
        builder.Entity<Billing>().HasKey(f => f.Id);
        builder.Entity<Billing>().Property(f => f.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Billing>().OwnsOne(p => p.Name,
            n =>
            {
                n.WithOwner().HasForeignKey("Id");
                n.Property(p => p.FirstName).HasColumnName("FirstName").IsRequired();
                n.Property(p => p.LastName).HasColumnName("LastName").IsRequired();
            });

        builder.Entity<Billing>().OwnsOne(p => p.Email,
            e =>
            {
                e.WithOwner().HasForeignKey("Id");
                e.Property(a => a.Address).HasColumnName("EmailAddress").IsRequired(false);
            });
        builder.Entity<Billing>().OwnsOne(p => p.Address,
            a =>
            {
                a.WithOwner().HasForeignKey("Id");
                a.Property(s => s.Street).HasColumnName("AddressStreet").IsRequired(false);;
                a.Property(s => s.Number).HasColumnName("AddressNumber").IsRequired(false);;
                a.Property(s => s.City).HasColumnName("AddressCity").IsRequired(false);;
                a.Property(s => s.PostalCode).HasColumnName("AddressPostalCode").IsRequired(false);;
                a.Property(s => s.Country).HasColumnName("AddressCountry").IsRequired(false);;
            });
        builder.Entity<Billing>().Property(f => f.PhoneNumber).IsRequired();
        builder.Entity<Billing>().Property(f => f.Status).IsRequired();
        builder.Entity<Billing>().OwnsOne(p => p.Shopping,
            e =>
            {
                e.WithOwner().HasForeignKey("Id");
                e.Property(a => a.ShoppingId).HasColumnName("ShoppingId").IsRequired(false);
                e.Property(a => a.TotalPrice).HasColumnName("TotalPrice").IsRequired(false);
            });
        
        // Apply SnakeCase Naming Convention
        // Apply SnakeCase Naming Convention
        builder.UseSnakeCaseNamingConvention();
        builder.Entity<Recommendation>().ToTable("Recommendations");
        builder.Entity<Recommendation>().HasKey(r => r.Id);
        builder.Entity<Recommendation>().Property(r => r.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Recommendation>().Property(r => r.BookTitle).IsRequired();
        builder.Entity<Recommendation>().Property(r => r.Description).IsRequired();
        builder.Entity<Recommendation>().Property(r => r.Genre).IsRequired();
        builder.Entity<Recommendation>().Property(r => r.Author).IsRequired();
        builder.Entity<ShoppingCart>().ToTable("ShoppingCarts");
        builder.Entity<ShoppingCart>().HasKey(r => r.Id);
        builder.Entity<ShoppingCart>().Property(r => r.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<ShoppingCart>().Property(r => r.ProductId).IsRequired();
    }
}