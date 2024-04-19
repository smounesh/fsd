using RequestTrackerDALLibrary;
using RequestTrakerModelLibrary;
using System;
using System.Collections.Generic;

namespace RequestTrackerBLL
{
    public class DepartmentBL : IDepartmentService
    {
        private readonly IRepository<int, Department> _departmentRepository;

        public DepartmentBL()
        {
            _departmentRepository = new DepartmentRepository();
        }

        public int AddDepartment(Department department)
        {
            var existingDepartment = _departmentRepository.GetDepartmentByName(department.Name);
            if (existingDepartment != null)
            {
                throw new DuplicateDepartmentNameException();
            }
            return _departmentRepository.Add(department).Id;
        }

        public Department ChangeDepartmentName(string departmentOldName, string departmentNewName)
        {
            var department = _departmentRepository.GetDepartmentByName(departmentOldName);
            if (department == null)
            {
                throw new DepartmentNotFoundException();
            }
            department.Name = departmentNewName;
            return _departmentRepository.Update(department);
        }

        public Department GetDepartmentById(int id)
        {
            var department = _departmentRepository.Get(id);
            if (department == null)
            {
                throw new DepartmentNotFoundException();
            }
            return department;
        }

        public Department GetDepartmentByName(string departmentName)
        {
            var department = _departmentRepository.GetDepartmentByName(departmentName);
            if (department == null)
            {
                throw new DepartmentNotFoundException();
            }
            return department;
        }

        public int GetDepartmentHeadId(int departmentId)
        {
            var employeesInDepartment = _employeeRepository.GetAll().Where(e => e.DepartmentId == departmentId);
            var departmentHead = employeesInDepartment.FirstOrDefault(e => e.IsDepartmentHead);
            if (departmentHead != null)
            {
                return departmentHead.Id;
            }
            throw new DepartmentHeadNotFoundException();
        }

        public List<Department> GetDepartmentList()
        {
            return _departmentRepository.GetAll();
        }
    }
}
