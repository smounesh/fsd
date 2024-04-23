using System;
using System.Collections.Generic;

namespace ClinicManagement.DAL
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly List<Appointment> _appointments;

        public AppointmentRepository(List<Appointment> initialData)
        {
            _appointments = initialData ?? throw new ArgumentNullException(nameof(initialData));
        }

        public List<Appointment> GetAll()
        {
            return _appointments;
        }

        public Appointment GetById(int id)
        {
            return _appointments.Find(a => a.Id == id) ?? throw new KeyNotFoundException($"Appointment with ID {id} not found");
        }

        public Appointment Add(Appointment entity)
        {
            _appointments.Add(entity);
            return entity;
        }

        public Appointment Update(Appointment entity)
        {
            var appointment = _appointments.Find(a => a.Id == entity.Id);
            if (appointment != null)
            {
                appointment.DoctorId = entity.DoctorId;
                appointment.PatientId = entity.PatientId;
            }
            return appointment ?? throw new KeyNotFoundException($"Appointment with ID {entity.Id} not found");
        }


        public void Delete(int id)
        {
            var appointment = _appointments.Find(a => a.Id == id);
            if (appointment != null)
            {
                _appointments.Remove(appointment);
            }
            else
            {
                throw new KeyNotFoundException($"Appointment with ID {id} not found");
            }
        }
    }
}
