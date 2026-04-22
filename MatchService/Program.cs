using Microsoft.EntityFrameworkCore;
using MatchService.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// add endpoints & swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//add in-memory DB
builder.Services.AddDbContext<MatchDbContext>(opt =>
    opt.UseInMemoryDatabase("MatchList"));

var app = builder.Build();

// Seed the database
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<MatchDbContext>();
    
    // Add initial data
    context.MatchList.Add(new TennisMatch { Id = 1, Players = [4,1], Score = "7-6(5), 6-3" });
    context.MatchList.Add(new TennisMatch { Id = 2, Players = [2,3], Score = "6-4, 3-6, 6-3" });
    context.MatchList.Add(new TennisMatch { Id = 2, Players = [4,2]});
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

app.Run();
