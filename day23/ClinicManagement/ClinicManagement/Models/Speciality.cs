﻿namespace ClinicManagement.Models
{
    public class Speciality
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<DoctorSpeciality> DoctorSpecialities { get; set; }
    }
}