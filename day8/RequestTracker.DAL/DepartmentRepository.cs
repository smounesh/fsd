using RequestTrakerModelLibrary;
using System.Collections.Generic;
using System.Linq;

namespace RequestTrackerDALLibrary
{
    public class DepartmentRepository : IRepository<int, Department>
    {
        private readonly List<Department> _departments;
        private int _nextId = 1;

        public DepartmentRepository()
        {
            _departments = new List<Department>();
        }

        public Department Add(Department entity)
        {
            entity.Id = _nextId++;
            _departments.Add(entity);
            return entity;
        }

        public Department Update(Department entity)
        {
            var existingDepartment = _departments.FirstOrDefault(d => d.Id == entity.Id);
            if (existingDepartment != null)
            {
                existingDepartment.Name = entity.Name;
            }
            return existingDepartment;
        }

        public Department Get(int id)
        {
            return _departments.FirstOrDefault(d => d.Id == id);
        }

        public List<Department> GetAll()
        {
            return _departments.ToList();
        }


        public void Remove(int id)
        {
            var departmentToRemove = _departments.FirstOrDefault(d => d.Id == id);
            if (departmentToRemove != null)
            {
                _departments.Remove(departmentToRemove);
            }
        }


        public Department GetDepartmentByName(string departmentName)
        {
            return _departments.FirstOrDefault(d => d.Name == departmentName);
        }
    }
}
