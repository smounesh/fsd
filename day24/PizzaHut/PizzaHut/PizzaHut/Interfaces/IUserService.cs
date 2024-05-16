using PizzaHut.Models;
using PizzaHut.Models.DTO;

namespace PizzaHut.Interfaces
{
    public interface IUserService
    {
        public Task<Employee> Login(UserLoginDTO loginDTO);
        public Task<Employee> Register(EmployeeUserDTO employeeDTO);
    }
}
