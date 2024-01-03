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
    options.UseSqlServer(builder.Configuration.GetConnectionString("Server=DESKTOP-9BTG6A8\\Viacheslav;Database=Theatre_test;Trusted_Connection=True;TrustServerCertificate=True; MultipleActiveResultSets = true;"));
});

builder.Services.AddControllers();

builder.Services.AddScoped<IPerformanceService, PerformanceService>();
builder.Services.AddScoped<IHoleService, HoleService>();
builder.Services.AddScoped<ITheatreService, TheatreService>();
builder.Services.AddScoped<ITicketService, TicketService>();


builder.Services.AddScoped<IPerformanceRepository, PerformanceRepository>();
builder.Services.AddScoped<IHoleServices, HoleRepository>();

builder.Services.AddScoped<ITheatreRepository, TheatreRepository>();
builder.Services.AddScoped<ITicketRepository, TicketRepository>();

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
