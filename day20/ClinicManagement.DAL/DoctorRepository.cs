using System.Collections.Generic;

namespace ClinicManagement.DAL
{
    public class DoctorRepository : IRepository<Doctor>
    {
        private readonly List<Doctor> _doctors;

        public DoctorRepository()
        {
            _doctors = new List<Doctor>
            {
                new Doctor { Id = 1, Name = "Dr. Shankar" },
                new Doctor { Id = 2, Name = "Dr. Mounesh" },
            };
        }

        public List<Doctor> GetAll()
        {
            return _doctors;
        }

        public Doctor GetById(int id)
        {
            return _doctors.Find(d => d.Id == id) ?? throw new KeyNotFoundException($"Doctor with ID {id} not found");
        }

        public Doctor Add(Doctor entity)
        {
            _doctors.Add(entity);
            return entity;
        }

        public Doctor Update(Doctor entity)
        {
            var doctor = _doctors.Find(d => d.Id == entity.Id);
            if (doctor != null)
            {
                doctor.Name = entity.Name;
            }
            return doctor ?? throw new KeyNotFoundException($"Doctor with ID {entity.Id} not found");
        }

        public void Delete(int id)
        {
            var doctor = _doctors.Find(d => d.Id == id);
            if (doctor != null)
            {
                _doctors.Remove(doctor);
            }
            else
            {
                throw new KeyNotFoundException($"Doctor with ID {id} not found");
            }
        }
    }
}
