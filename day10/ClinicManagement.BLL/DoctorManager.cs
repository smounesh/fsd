using System.Collections.Generic;
using ClinicManagement.DAL;

namespace ClinicManagement.BLL
{
    public class DoctorManager
    {
        private readonly IRepository<Doctor> _doctorRepository;

        public DoctorManager(IRepository<Doctor> doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public List<Doctor> GetAllDoctors()
        {
            return _doctorRepository.GetAll();
        }

        public Doctor GetDoctorById(int id)
        {
            try
            {
                return _doctorRepository.GetById(id);
            }
            catch (KeyNotFoundException)
            {
                return null; // Return null if the doctor with the specified id is not found
            }
        }

        public Doctor AddDoctor(Doctor doctor)
        {
            return _doctorRepository.Add(doctor);
        }

        public Doctor UpdateDoctor(Doctor doctor)
        {
            return _doctorRepository.Update(doctor);
        }

        public void DeleteDoctor(int id)
        {
            _doctorRepository.Delete(id);
        }
    }
}
