using Everest03.NET;
using FluentValidation.AspNetCore;
using Everest03.NET.Validators;
using Everest03.NET.AppServices;
using Everest03.NET.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddScoped<IValidator<Customer>, CustomersValidator>();
builder.Services.AddSingleton<ICustomerService, CustomerService>();   
builder.Services.AddTransient<ICustomerAppService, CustomerAppService>();
builder.Services.AddFluentValidationAutoValidation();
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
