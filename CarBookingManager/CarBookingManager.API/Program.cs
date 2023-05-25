global using CarBookingManager.API.Exceptions;
global using CarBookingManager.API.Validators;

using CarBookingManager.API;
using CarBookingManager.API.Data;
using CarBookingManager.API.Repositories.CarRepository;
using CarBookingManager.API.Repositories.CustomerRepository;
using CarBookingManager.API.Repositories.ReservationRepository;
using CarBookingManager.API.Services.CarService;
using CarBookingManager.API.Services.CustomerService;
using CarBookingManager.API.Services.ReservationService;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<ExceptionHandlingMiddleware>();
builder.Services.AddControllers().AddFluentValidation();

builder.Services.AddValidatorsFromAssemblyContaining<CustomerRequestValidator>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddScoped<ICarRepository,CarRepository>();
builder.Services.AddScoped<ICustomerRepository,CustomerRepository>();
builder.Services.AddScoped<IReservationRepository,ReservationRepository>();

builder.Services.AddScoped<ICarService,CarService>();
builder.Services.AddScoped<IReservationService,ReservationService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseAuthorization();

app.MapControllers();

app.Run();
