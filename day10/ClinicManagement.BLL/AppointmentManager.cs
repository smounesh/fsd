using ClinicManagement.DAL;

namespace ClinicManagement.BLL
{
    public class AppointmentManager
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly DoctorManager _doctorManager;
        private readonly PatientManager _patientManager;

        public AppointmentManager(IAppointmentRepository appointmentRepository, DoctorManager doctorManager, PatientManager patientManager)
        {
            _appointmentRepository = appointmentRepository;
            _doctorManager = doctorManager;
            _patientManager = patientManager;
        }

        public void BookAppointment(int doctorId, int patientId, DateTime appointmentDateTime)
        {
            // Check if the doctor exists
            var doctor = _doctorManager.GetDoctorById(doctorId);
            if (doctor == null)
            {
                throw new KeyNotFoundException($"Doctor with ID {doctorId} not found.");
            }

            // Check if the patient exists
            var patient = _patientManager.GetPatientById(patientId);
            if (patient == null)
            {
                throw new KeyNotFoundException($"Patient with ID {patientId} not found.");
            }

            // Check if the appointmentDateTime is available for the doctor (You can implement this logic here)

            // Create a new appointment
            Appointment appointment = new Appointment
            {
                DoctorId = doctorId,
                PatientId = patientId,
                AppointmentDateTime = appointmentDateTime
            };

            // Add the appointment to the repository
            _appointmentRepository.Add(appointment);
        }
    }
}
