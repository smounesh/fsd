using RequestTrakerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RequestTrackerDALLibrary
{
    public class EmployeeRepository : IRepository<int, Employee>
    {
        private readonly List<Employee> _employees;
        private int _nextId = 1;

        public EmployeeRepository()
        {
            _employees = new List<Employee>();
        }

        public Employee Add(Employee entity)
        {
            entity.Id = _nextId++;
            _employees.Add(entity);
            return entity;
        }

        public Employee Update(Employee entity)
        {
            var existingEmployee = _employees.FirstOrDefault(e => e.Id == entity.Id);
            if (existingEmployee != null)
            {
                existingEmployee.Name = entity.Name;
                existingEmployee.DepartmentId = entity.DepartmentId;
                existingEmployee.IsDepartmentHead = entity.IsDepartmentHead;
            }
            return existingEmployee;
        }

        public Employee Get(int id)
        {
            return _employees.FirstOrDefault(e => e.Id == id);
        }

        public List<Employee> GetAll()
        {
            return _employees.ToList();
        }

        public void Remove(int id)
        {
            var employeeToRemove = _employees.FirstOrDefault(e => e.Id == id);
            if (employeeToRemove != null)
            {
                _employees.Remove(employeeToRemove);
            }
        }
    }
}
