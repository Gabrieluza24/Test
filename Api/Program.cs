using FluentValidation;
using Domain.Interfaces;
using Api.Dtos.Customers;
using Api.Dtos.Validators;
using Api.Services.Services;
using Api.Services.Interface;
using Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data.Repositories;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(
    options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
    policy =>
    {
        policy.WithOrigins("http://localhost:4200")
        .WithMethods("PUT", "DELETE", "GET", "POST")
        .AllowAnyHeader();
    });
});

// Add services to the container.
string ConectionString = "Server=localhost; Database=WebApi; User ID=root; Password=;";
builder.Services.AddDbContext<CustomerContext>(options =>
    options.UseMySql(ConectionString, ServerVersion.AutoDetect(ConectionString)));

builder.Services.AddScoped<IAddCustomerService, AddCustomerService>();
builder.Services.AddScoped<IGetCustomersService, GetCustomersService>();
builder.Services.AddScoped<IUpdateCustomerService, UpdateCustomerService>();
builder.Services.AddScoped<IDeleteCustomerService, DeleteCustomerService>();

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

builder.Services.AddTransient<IValidator<AddCustomerDto>, AddCustomerValidator>();
builder.Services.AddTransient<IValidator<UpdateCustomerDto>, UpdateCustomerValidator>();

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

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
