using System;
using System.Collections.Generic;
using System.Linq;

namespace ClinicManagement.DAL
{
    public class PatientRepository : IRepository<Patient>
    {
        private readonly List<Patient> _patients;

        public PatientRepository(List<Patient> initialData)
        {
            _patients = initialData ?? throw new ArgumentNullException(nameof(initialData));
        }

        public List<Patient> GetAll()
        {
            return _patients;
        }

        public Patient GetById(int id)
        {
            return _patients.Find(p => p.Id == id) ?? throw new KeyNotFoundException($"Patient with ID {id} not found");
        }

        public Patient Add(Patient entity)
        {
            _patients.Add(entity);
            return entity;
        }

        public Patient Update(Patient entity)
        {
            var patient = _patients.Find(p => p.Id == entity.Id);
            if (patient != null)
            {
                patient.Name = entity.Name;
            }
            return patient ?? throw new KeyNotFoundException($"Patient with ID {entity.Id} not found");
        }

        public void Delete(int id)
        {
            var patient = _patients.Find(p => p.Id == id);
            if (patient != null)
            {
                _patients.Remove(patient);
            }
            else
            {
                throw new KeyNotFoundException($"Patient with ID {id} not found");
            }
        }
    }
}
