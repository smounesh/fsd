using System.Collections.Generic;
using ClinicManagement.DAL;

namespace ClinicManagement.BLL
{
    public class PatientManager
    {
        private readonly IRepository<Patient> _patientRepository;

        public PatientManager(IRepository<Patient> patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public List<Patient> GetAllPatients()
        {
            return _patientRepository.GetAll();
        }

        public Patient GetPatientById(int id)
        {
            return _patientRepository.GetById(id);
        }

        public Patient AddPatient(Patient patient)
        {
            return _patientRepository.Add(patient);
        }

        public Patient UpdatePatient(Patient patient)
        {
            return _patientRepository.Update(patient);
        }

        public void DeletePatient(int id)
        {
            _patientRepository.Delete(id);
        }
    }
}
