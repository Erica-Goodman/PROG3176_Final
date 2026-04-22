using Microsoft.EntityFrameworkCore;
using PlayerService.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// add endpoints & swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//add in-memory DB
builder.Services.AddDbContext<PlayerDbContext>(opt =>
    opt.UseInMemoryDatabase("PlayerList"));

var app = builder.Build();

// Seed the database
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<PlayerDbContext>();
    
    // Add initial data
    context.Players.Add(new Player { Id = 1, Name = "Carlos Alcaraz", Country = "Spain" });
    context.Players.Add(new Player { Id = 2, Name = "Félix Auger-Aliassime", Country = "Canada" });
    context.Players.Add(new Player { Id = 3, Name = "Daniil Medvedev"});
    context.Players.Add(new Player { Id = 4, Name = "Jannik Sinner", Country = "Italy" });
    context.SaveChanges();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapGet("/hello", () => "Test");

app.Run();
