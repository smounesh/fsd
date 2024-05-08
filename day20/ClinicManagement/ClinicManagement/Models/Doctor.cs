using System;
using System.Collections.Generic;

namespace ClinicManagement.Models;

public partial class Doctor
{
    public int DoctorId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Specialization { get; set; } = null!;

    public int YearsOfExperience { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public string Email { get; set; } = null!;
}
