using ClinicManagement.Models;
using System.Collections.Generic;

namespace ClinicManagement.Interfaces
{
    public interface IDoctorRepository
    {
        ICollection<Doctor> GetDoctors();
        ICollection<Doctor> GetDoctorsBySpeciality(string speciality);
        Doctor GetDoctorById(int id);
        void UpdateDoctor(Doctor doctor);
    }
}
