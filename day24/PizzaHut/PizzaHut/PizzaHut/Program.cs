using Microsoft.EntityFrameworkCore;
using PizzaHut.Contexts;
using PizzaHut.Interfaces;
using PizzaHut.Models;
using PizzaHut.Repositories;
using PizzaHut.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region contexts
builder.Services.AddDbContext<PizzaHutContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection"))
);
#endregion

#region repositories
builder.Services.AddScoped<IReposiroty<int, Employee>, EmployeeRepository>();
builder.Services.AddScoped<IReposiroty<int, User>, UserRepository>();
builder.Services.AddScoped<IReposiroty<int, Pizza>, PizzaRepository>();
builder.Services.AddScoped<IReposiroty<int, Order>, OrderRepository>();
#endregion

#region services
builder.Services.AddScoped<IEmployeeService, EmployeeBasicService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPizzaService, PizzaService>();
builder.Services.AddScoped<IOrderService, OrderService>();
#endregion


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
