using ChromaComics.ShoppingCarts.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using ChromaComics.ShoppingCarts.Domain.Services;
using ChromaComics.ShoppingCarts.Persistence.Repositories;
using ChromaComics.ShoppingCarts.Services;
using ChromaComics.Shared.Domain.Repositories;
using ChromaComics.Shared.Infrastructure.Persistence.EFC.Configuration;
using ChromaComics.Shared.Infrastructure.Persistence.EFC.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
{
    if (connectionString != null)
    {
        if (builder.Environment.IsDevelopment())
            options.UseMySQL(connectionString)
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
        else if (builder.Environment.IsProduction())
            options.UseMySQL(connectionString)
                .LogTo(Console.WriteLine, LogLevel.Error)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();    
    }
});

builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Register repositories
builder.Services.AddScoped<IShoppingCartRepository, ShoppingCartRepository>();

// Register services
builder.Services.AddScoped<IShoppingCartService, ShoppingCartService>();

// Register Unit of Work
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();