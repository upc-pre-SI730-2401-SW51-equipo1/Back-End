using ChromaComics.ShoppingCarts.Domain.Repositories;
using ChromaComics.ShoppingCarts.Domain.Services;
using ChromaComics.ShoppingCarts.Mapping;
using ChromaComics.ShoppingCarts.Services;
using ChromaComics.Shared.Persistence.Contexts;
using ChromaComics.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configurar DbContext con MySQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configurar AutoMapper
builder.Services.AddAutoMapper(typeof(ModelToResourceProfile), typeof(ResourceToModelProfile));

// Registrar servicios de aplicación y repositorios
builder.Services.AddScoped<IShoppingCartRepository, ShoppingCartRepository>();
builder.Services.AddScoped<IShoppingCartService, ShoppingCartService>();

// Agregar controladores
builder.Services.AddControllers();

// Agregar Endpoints API Explorer y Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurar el pipeline de solicitudes HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();