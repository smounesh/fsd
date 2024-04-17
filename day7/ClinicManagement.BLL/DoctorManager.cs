using ClinicManagement.DAL;
using System.Collections.Generic;

namespace ClinicManagement.BLL
{
    public class DoctorManager
    {
        private readonly DoctorRepository _doctorRepository;

        public DoctorManager(DoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public List<Doctor> GetAllDoctors()
        {
            return _doctorRepository.GetAll();
        }
    }
}
