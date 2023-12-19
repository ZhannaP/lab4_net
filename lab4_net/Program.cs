using BLL.Services;
using DAL.Repositories.Interfaces;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.IdentityModel.Tokens.Jwt;
using BLL;
using DAL.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(Mapper));
builder.Services.AddDbContext<TheatreContext>(options =>
{
    //options.UseSqlServer(builder.Configuration.GetConnectionString(""));
});

builder.Services.AddControllers();

builder.Services.AddScoped<IPerformanceService, PerformanceService>();

builder.Services.AddScoped<IPerformanceRepository, PerformanceRepository>();
builder.Services.AddScoped<IHoleRepository, HoleRepository>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
