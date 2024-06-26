﻿using PizzaHut.Exceptions;
using PizzaHut.Interfaces;
using PizzaHut.Models;
using PizzaHut.Repositories;

namespace PizzaHut.Services
{
    public class EmployeeBasicService : IEmployeeService
    {
        private readonly IReposiroty<int, Employee> _repository;

        public EmployeeBasicService(IReposiroty<int,Employee> reposiroty)
        {
            _repository = reposiroty;
        }
        public async Task<Employee> GetEmployeeByPhone(string phoneNumber)
        {
            var employee = (await _repository.Get()).FirstOrDefault(e => e.Phone == phoneNumber);
            if (employee == null)
                throw new NoSuchEmployeeException();
            return employee;

        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            var employees = await _repository.Get();
            if (employees.Count() == 0)
                throw new NoEmployeesFoundException();
            return employees;
        }

        public async Task<Employee> UpdateEmployeePhone(int id, string phoneNumber)
        {
            var employee = await _repository.Get(id);
            if (employee == null)
                throw new NoSuchEmployeeException();
            employee.Phone = phoneNumber;
            employee = await _repository.Update(employee);
            return employee;
        }
    }
}
