using ChromaComics.payment.Domain.Model.Aggregates;
using ChromaComics.ShoppingCarts.Domain.Models;
using ChromaComics.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;

namespace ChromaComics.Shared.Infrastructure.Persistence.EFC.Configuration
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<ShoppingCart> ShoppingCarts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                // Aquí puedes agregar una configuración por defecto si es necesario
            }

            builder.AddCreatedUpdatedInterceptor();
            base.OnConfiguring(builder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

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
            builder.UseSnakeCaseNamingConvention();
            builder.Entity<ShoppingCart>().ToTable("ShoppingCarts");
            builder.Entity<ShoppingCart>().HasKey(r => r.Id);
            builder.Entity<ShoppingCart>().Property(r => r.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<ShoppingCart>().Property(r => r.ProductId).IsRequired();
 
        }
    }
}