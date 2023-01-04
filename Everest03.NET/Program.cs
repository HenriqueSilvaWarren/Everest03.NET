using Everest03.NET;
using FluentValidation.AspNetCore;
using Everest03.NET.Validators;
using Everest03.NET.AppServices;
using Everest03.NET.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using Microsoft.Extensions.Hosting;
using FluentValidation.AspNetCore;
using FluentValidation;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthorization();
builder.Services.AddSingleton<AppService>();
builder.Services.AddSingleton<List<Customer>>();
builder.Services.AddControllers();
builder.Services.AddScoped<IValidator<Customer>, CustomersValidator>();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddSingleton<Service>();   
builder.Services.AddSingleton<CustomersValidator>();
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
