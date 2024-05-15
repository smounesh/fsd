using ClinicManagement.Contexts;
using ClinicManagement.Interfaces;
using ClinicManagement.Models;
using System.Collections.Generic;
using System.Linq;

namespace ClinicManagement.Repository
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly ClinicManagementContext _context;

        public DoctorRepository(ClinicManagementContext context)
        {
            _context = context;
        }

        public ICollection<Doctor> GetDoctors()
        {
            return _context.Doctors.OrderBy(d => d.Id).ToList();
        }

        public ICollection<Doctor> GetDoctorsBySpeciality(string speciality)
        {
            return _context.Doctors
                .Where(d => d.DoctorSpecialities.Any(ds => ds.Speciality.Name == speciality))
                .OrderBy(d => d.Id)
                .ToList();
        }

        public Doctor GetDoctorById(int id)
        {
            return _context.Doctors.Find(id);
        }

        public void UpdateDoctor(Doctor doctor)
        {
            _context.Doctors.Update(doctor);
            _context.SaveChanges();
        }
    }
}
