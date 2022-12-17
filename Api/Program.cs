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

var _configuration = builder.Configuration;
var dbConnectionString = _configuration.GetConnectionString("DbMysql");
Console.WriteLine(dbConnectionString);

builder.Services.AddDbContext<CustomerContext>(options =>
    options.UseMySql(dbConnectionString,
    ServerVersion.AutoDetect(dbConnectionString)
));

/**Service Application*/
builder.Services.AddScoped<IAddCustomerService, AddCustomerService>();
builder.Services.AddScoped<IGetCustomersService, GetCustomersService>();
builder.Services.AddScoped<IUpdateCustomerService, UpdateCustomerService>();
builder.Services.AddScoped<IDeleteCustomerService, DeleteCustomerService>();

/**Repositories*/
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

/**Validators*/
builder.Services.AddTransient<IValidator<AddCustomerDto>, AddCustomerValidator>();
builder.Services.AddTransient<IValidator<UpdateCustomerDto>, UpdateCustomerValidator>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using var scope = app.Services.CreateScope();
await using var dbContext = scope.ServiceProvider.GetRequiredService<CustomerContext>();
await dbContext.Database.MigrateAsync();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
