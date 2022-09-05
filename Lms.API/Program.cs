using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Lms.Data.Data;
using Lms.API.Entities;
using Lms.Core.Repositories;
using Lms.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<LmsAPIContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LmsAPIContext") ?? throw new InvalidOperationException("Connection string 'LmsAPIContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUoW, UoW>();

var app = builder.Build();

app.SeedDataAsync().GetAwaiter().GetResult();

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
