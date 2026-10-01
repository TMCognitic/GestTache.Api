using GestTache.Api.Domain.Repositories;
using GestTache.Api.Domain.Services;
using Microsoft.Data.SqlClient;
using Scalar.AspNetCore;
using System.Data.Common;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddTransient<DbConnection>(sp => new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=GestTache;Integrated Security=True;Encrypt=True;Trust Server Certificate=True"));
builder.Services.AddScoped<ITacheRepository, TacheService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
