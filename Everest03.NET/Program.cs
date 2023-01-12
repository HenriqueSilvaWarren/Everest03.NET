using AppServices.Dtos;
using AppServices.Interfaces;
using AppServices.Services;
using AppServices.Validators;
using DomainModels.Entities;
using DomainServices.Interfaces;
using DomainServices.Services;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddScoped<IValidator<CreateCustomerDto>, CreateCustomersValidator>();
builder.Services.AddScoped<IValidator<UpdateCustomerDto>, UpdateCustomersValidator>();
builder.Services.AddSingleton<ICustomerService, CustomerService>();   
builder.Services.AddTransient<ICustomerAppService, CustomerAppService>();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddAutoMapper(Assembly.Load(nameof(AppServices)));
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
