using Api.Application.Commands;
using Api.Application.Queries;
using Api.Domain.Repositories;
using Api.Infrastructure.Persistence.Repositories;
using Api.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Agregar DbContext con MySQL
//builder.Services.AddDbContext<AppDbContext>(options =>
//    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), 
//    ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))));

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer("Server=localhost,1433;Database=master;User Id=sa;Password=TuPassword123;TrustServerCertificate=True;"));

// Inyección de dependencias
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<GetUserByIdQuery>();
builder.Services.AddScoped<CreateUserCommand>();

// Agregar controladores
builder.Services.AddControllers();

// Configurar Swagger (Opcional)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurar Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
