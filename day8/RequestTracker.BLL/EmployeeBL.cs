using RequestTrackerDALLibrary;
using RequestTrakerModelLibrary;
using System;
using System.Collections.Generic;

namespace RequestTrackerBLL
{
    public class EmployeeBL
    {
        private readonly IRepository<int, Employee> _employeeRepository;

        public EmployeeBL()
        {
            _employeeRepository = new EmployeeRepository();
        }

        public int AddEmployee(Employee employee)
        {
            // You can add validation logic here if needed
            return _employeeRepository.Add(employee).Id;
        }

        public Employee GetEmployeeById(int id)
        {
            var employee = _employeeRepository.Get(id);
            if (employee == null)
            {
                throw new EmployeeNotFoundException();
            }
            return employee;
        }

        public List<Employee> GetEmployeesByDepartmentId(int departmentId)
        {
            throw new NotImplementedException();
        }

    }
}
