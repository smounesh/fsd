using Microsoft.EntityFrameworkCore;
using PizzaHut.Models;
using System;
using System.Reflection.Emit;

namespace PizzaHut.Contexts
{
    public class PizzaHutContext : DbContext
    {
        public PizzaHutContext(DbContextOptions<PizzaHutContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee() { Id = 101, Name = "Ramu", DateOfBirth = new DateTime(2000, 2, 12), Phone = "9876543321", Image = "" },
                new Employee() { Id = 102, Name = "Somu", DateOfBirth = new DateTime(2002, 3, 24), Phone = "9988776655", Image = "" }
            );

            modelBuilder.Entity<Pizza>().HasData(
                new Pizza() { PizzaId = 1, Name = "Margherita", Description = "Classic Margherita Pizza", Price = 8.99m, AvailableStock = 0 },
                new Pizza() { PizzaId = 2, Name = "Pepperoni", Description = "Pepperoni Pizza", Price = 10.99m, AvailableStock = 0 }
            );
        }
    }
}