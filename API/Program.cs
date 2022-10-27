using System.Net.Mime;
using System.Reflection;
using Application;
using Application.DTOs;
using Application.Interfaces;
using Application.Validators;
using AutoMapper;
using Domain;
using Domain.Interfaces;
using FluentValidation;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.SwaggerUI;

var builder = WebApplication.CreateBuilder(args);

Console.WriteLine("initializing");

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());


var mapper = new MapperConfiguration(configuration =>
{
    configuration.CreateMap<PostProductDTO, Product>();
}).CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlite(
    "Data source=db.db"
    ));


builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors(options => {
	options.AllowAnyOrigin();
	options.AllowAnyHeader();
	options.AllowAnyMethod();
});
    
}




app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
