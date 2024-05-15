using ClinicManagement.Interfaces;
using ClinicManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ClinicManagement.Controllers
{
    [Route("api/doctors")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorsController(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Doctor>))]
        public IActionResult GetDoctors()
        {
            var doctors = _doctorRepository.GetDoctors();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(doctors);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Doctor))]
        [ProducesResponseType(404)]
        public IActionResult GetDoctorById(int id)
        {
            var doctor = _doctorRepository.GetDoctorById(id);

            if (doctor == null)
                return NotFound();

            return Ok(doctor);
        }

        [HttpGet("specialities/{speciality}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Doctor>))]
        [ProducesResponseType(404)]
        public IActionResult GetDoctorsBySpeciality(string speciality)
        {
            var doctors = _doctorRepository.GetDoctorsBySpeciality(speciality);

            if (doctors == null)
                return NotFound();

            return Ok(doctors);
        }

        [HttpPut("{id}/experience")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateDoctorExperience(int id, [FromBody] int experience)
        {
            if (experience < 0)
            {
                ModelState.AddModelError("Experience", "Experience cannot be negative.");
                return BadRequest(ModelState);
            }

            var doctor = _doctorRepository.GetDoctorById(id);

            if (doctor == null)
                return NotFound();

            doctor.Experience = experience;
            _doctorRepository.UpdateDoctor(doctor);

            return Ok();
        }
    }
}
