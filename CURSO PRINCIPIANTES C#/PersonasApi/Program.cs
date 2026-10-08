using Microsoft.EntityFrameworkCore;
using PersonasApi.Models;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("HeroContext") ?? throw new InvalidOperationException("Connection string 'HeroContext' not found.");

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<HeroContext>(opt =>
opt.UseInMemoryDatabase("HeroList"));
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
