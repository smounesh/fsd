using System;
using System.Collections.Generic;
using ClinicManagement.BLL;
using ClinicManagement.DAL;

namespace ClinicManagement.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Clinic Management System");

            // Example of using BLL and DAL
            var doctorRepository = new DoctorRepository(new List<Doctor>());
            var doctorManager = new DoctorManager(doctorRepository);

            var patientRepository = new PatientRepository(new List<Patient>());
            var patientManager = new PatientManager(patientRepository);

            var appointmentRepository = new AppointmentRepository(new List<Appointment>());
            var appointmentManager = new AppointmentManager(appointmentRepository, doctorManager, patientManager);



            while (true)
            {
                Console.WriteLine("\nOptions:");
                Console.WriteLine("1. Add Doctor");
                Console.WriteLine("2. Update Doctor");
                Console.WriteLine("3. Delete Doctor");
                Console.WriteLine("4. List Doctors");
                Console.WriteLine("5. Add Patient");
                Console.WriteLine("6. Update Patient");
                Console.WriteLine("7. Delete Patient");
                Console.WriteLine("8. List Patients");
                Console.WriteLine("9. Book Appointment");
                Console.WriteLine("10. Exit");

                Console.Write("\nEnter option: ");
                var option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        // Add Doctor
                        Console.Write("Enter Doctor Name: ");
                        var doctorName = Console.ReadLine();
                        var newDoctor = new Doctor { Name = doctorName };
                        doctorManager.AddDoctor(newDoctor);
                        Console.WriteLine("Doctor added successfully.");
                        break;

                    case "2":
                        // Update Doctor
                        Console.Write("Enter Doctor ID to update: ");
                        if (!int.TryParse(Console.ReadLine(), out int updateDoctorId))
                        {
                            Console.WriteLine("Invalid input for Doctor ID.");
                            break;
                        }

                        try
                        {
                            var updateDoctor = doctorManager.GetDoctorById(updateDoctorId);
                            if (updateDoctor != null)
                            {
                                Console.Write("Enter new Doctor Name: ");
                                var updatedName = Console.ReadLine();
                                updateDoctor.Name = updatedName;
                                doctorManager.UpdateDoctor(updateDoctor);
                                Console.WriteLine("Doctor updated successfully.");
                            }
                            else
                            {
                                Console.WriteLine("Doctor not found.");
                            }
                        }
                        catch (KeyNotFoundException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case "3":
                        // Delete Doctor
                        Console.Write("Enter Doctor ID to delete: ");
                        if (!int.TryParse(Console.ReadLine(), out int deleteDoctorId))
                        {
                            Console.WriteLine("Invalid input for Doctor ID.");
                            break;
                        }

                        try
                        {
                            doctorManager.DeleteDoctor(deleteDoctorId);
                            Console.WriteLine("Doctor deleted successfully.");
                        }
                        catch (KeyNotFoundException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;


                    case "4":
                        // List Doctors
                        var doctors = doctorManager.GetAllDoctors();
                        Console.WriteLine("List of Doctors:");
                        foreach (var doctor in doctors)
                        {
                            Console.WriteLine($"ID: {doctor.Id}, Name: {doctor.Name}");
                        }
                        break;

                    case "5":
                        // Add Patient
                        Console.Write("Enter Patient Name: ");
                        var patientName = Console.ReadLine();
                        var newPatient = new Patient(0, patientName); // Assuming the ID is 0 as it's autogenerated
                        patientManager.AddPatient(newPatient);
                        Console.WriteLine("Patient added successfully.");
                        break;

                    case "6":
                        // Update Patient
                        Console.Write("Enter Patient ID to update: ");
                        if (!int.TryParse(Console.ReadLine(), out int updatePatientId))
                        {
                            Console.WriteLine("Invalid input for Patient ID.");
                            break;
                        }

                        try
                        {
                            var updatePatient = patientManager.GetPatientById(updatePatientId);
                            if (updatePatient != null)
                            {
                                Console.Write("Enter new Patient Name: ");
                                var updatedName = Console.ReadLine();
                                updatePatient.Name = updatedName;
                                patientManager.UpdatePatient(updatePatient);
                                Console.WriteLine("Patient updated successfully.");
                            }
                            else
                            {
                                Console.WriteLine("Patient not found.");
                            }
                        }
                        catch (KeyNotFoundException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                    case "7":
                        // Delete Patient
                        Console.Write("Enter Patient ID to delete: ");
                        if (!int.TryParse(Console.ReadLine(), out int deletePatientId))
                        {
                            Console.WriteLine("Invalid input for Patient ID.");
                            break;
                        }

                        try
                        {
                            patientManager.DeletePatient(deletePatientId);
                            Console.WriteLine("Patient deleted successfully.");
                        }
                        catch (KeyNotFoundException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;


                    case "8":
                        // List Patients
                        var patients = patientManager.GetAllPatients();
                        Console.WriteLine("List of Patients:");
                        foreach (var patient in patients)
                        {
                            Console.WriteLine($"ID: {patient.Id}, Name: {patient.Name}");
                        }
                        break;
                
                    case "9":
                        // Book Appointment
                        Console.Write("Enter Doctor ID: ");
                        if (!int.TryParse(Console.ReadLine(), out int doctorId))
                        {
                            Console.WriteLine("Invalid input for Doctor ID.");
                            break;
                        }

                        Console.Write("Enter Patient ID: ");
                        if (!int.TryParse(Console.ReadLine(), out int patientId))
                        {
                            Console.WriteLine("Invalid input for Patient ID.");
                            break;
                        }

                        Console.Write("Enter Appointment Date and Time (yyyy-MM-dd HH:mm:ss): ");
                        if (!DateTime.TryParse(Console.ReadLine(), out DateTime appointmentDateTime))
                        {
                            Console.WriteLine("Invalid input for Appointment Date and Time.");
                            break;
                        }

                        try
                        {
                            appointmentManager.BookAppointment(doctorId, patientId, appointmentDateTime);
                            Console.WriteLine("Appointment booked successfully.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Failed to book appointment: {ex.Message}");
                        }
                        break;


                    case "10":
                        // Exit
                        Console.WriteLine("Exiting...");
                        return;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
    }
}
