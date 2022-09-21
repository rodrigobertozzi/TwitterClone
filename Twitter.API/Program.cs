using Microsoft.EntityFrameworkCore;
using Twitter.Core.Repositories;
using Twitter.Infrastructure;
using Twitter.Infrastructure.Persistance.Repositories;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("TwitterCs");
builder.Services.AddDbContext<TwitterDbContext>(option => option.UseSqlServer(connectionString));

builder.Services.AddScoped<ITweetRepository, TweetRepository>();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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
