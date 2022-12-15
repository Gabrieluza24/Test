using Microsoft.EntityFrameworkCore;
using Infrastructure.Data.Context;
using Api.Services.Interface;
using Api.Services.Services;
using Infrastructure.Data.Repositories;
using Domain.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string ConectionString = "Server=localhost; Database=WebApi; User ID=root; Password=;";
builder.Services.AddDbContext<CustomerContext>(options =>
    options.UseMySql(ConectionString, ServerVersion.AutoDetect(ConectionString)));

builder.Services.AddScoped<IAddCustomerService, AddCustomerService>();
builder.Services.AddScoped<IGetCustomersService, GetCustomersService>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

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
