using NUnit.Framework;
using ClinicManagement.DAL;
using ClinicManagement.BLL;
using System.Collections.Generic;

namespace ClinicManagement.BLLTest
{
    [TestFixture]
    public class DoctorManagerTests
    {
        private DoctorManager _doctorManager;
        private DoctorRepository _doctorRepository;

        [SetUp]
        public void Setup()
        {
            // Initialize DoctorRepository with initial data
            var initialData = new List<Doctor>
            {
                new Doctor { Id = 1, Name = "Dr. Smith" },
                new Doctor { Id = 2, Name = "Dr. Johnson" },
                // Add more initial data as needed
            };
            _doctorRepository = new DoctorRepository(initialData);

            // Initialize DoctorManager with DoctorRepository
            _doctorManager = new DoctorManager(_doctorRepository);
        }

        [Test]
        public void GetAllDoctors_ReturnsListOfDoctors()
        {
            // Act
            var result = _doctorManager.GetAllDoctors();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count); // Assuming there are two doctors in the initial data
        }

        [Test]
        public void GetDoctorById_ExistingId_ReturnsDoctor()
        {
            // Act
            var result = _doctorManager.GetDoctorById(1); // Assuming ID 1 exists in the initial data

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Id);
            Assert.AreEqual("Dr. Smith", result.Name);
        }

        [Test]
        public void GetDoctorById_NonExistingId_ReturnsNull()
        {
            // Act
            var result = _doctorManager.GetDoctorById(999); // Assuming ID 999 does not exist

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public void AddDoctor_NewDoctor_AddsToRepository()
        {
            // Arrange
            var newDoctor = new Doctor { Id = 3, Name = "Dr. Brown" };

            // Act
            _doctorManager.AddDoctor(newDoctor);

            // Assert
            var addedDoctor = _doctorRepository.GetById(3); // Assuming ID 3 is added
            Assert.IsNotNull(addedDoctor);
            Assert.AreEqual(3, addedDoctor.Id);
            Assert.AreEqual("Dr. Brown", addedDoctor.Name);
        }

        [Test]
        public void UpdateDoctor_ExistingDoctor_UpdatesInRepository()
        {
            // Arrange
            var doctorToUpdate = new Doctor { Id = 1, Name = "Dr. John Smith" };

            // Act
            _doctorManager.UpdateDoctor(doctorToUpdate);

            // Assert
            var updatedDoctor = _doctorRepository.GetById(1);
            Assert.IsNotNull(updatedDoctor);
            Assert.AreEqual(1, updatedDoctor.Id);
            Assert.AreEqual("Dr. John Smith", updatedDoctor.Name);
        }

        [Test]
        public void DeleteDoctor_ExistingId_RemovesFromRepository()
        {
            // Act
            _doctorManager.DeleteDoctor(2); // Assuming ID 2 exists

            // Assert
            Assert.Throws<KeyNotFoundException>(() => _doctorRepository.GetById(2));
        }
    }
}
