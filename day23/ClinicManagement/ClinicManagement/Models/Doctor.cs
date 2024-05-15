using System.Security.Principal;

namespace ClinicManagement.Models
{
    public class Doctor
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Experience { get; set; }

        public ICollection<DoctorSpeciality> DoctorSpecialities { get; set; }
    }
}
