using ClinicManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagement.Contexts
{
    public class ClinicManagementContext : DbContext
    {
        public ClinicManagementContext(DbContextOptions<ClinicManagementContext> options) : base(options)
        {

        }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Speciality> Specialities { get; set; }
        public DbSet<DoctorSpeciality> DoctorSpecialities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DoctorSpeciality>()
                .HasKey(ds => new { ds.DoctorId, ds.SpecialityId });

            modelBuilder.Entity<DoctorSpeciality>()
                .HasOne(ds => ds.Doctor)
                .WithMany(d => d.DoctorSpecialities)
                .HasForeignKey(ds => ds.DoctorId);

            modelBuilder.Entity<DoctorSpeciality>()
                .HasOne(ds => ds.Speciality)
                .WithMany(s => s.DoctorSpecialities)
                .HasForeignKey(ds => ds.SpecialityId);

            // Seed initial data
            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            // Seed Doctors
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor { Id = 1, Name = "Dr. Smith", Experience = 10 },
                new Doctor { Id = 2, Name = "Dr. Johnson", Experience = 8 },
                new Doctor { Id = 3, Name = "Dr. Lee", Experience = 15 },
                new Doctor { Id = 4, Name = "Dr. Patel", Experience = 12 },
                new Doctor { Id = 5, Name = "Dr. Garcia", Experience = 7 },
                new Doctor { Id = 6, Name = "Dr. Tanaka", Experience = 20 },
                new Doctor { Id = 7, Name = "Dr. Müller", Experience = 18 },
                new Doctor { Id = 8, Name = "Dr. Dupont", Experience = 5 },
                new Doctor { Id = 9, Name = "Dr. Rossi", Experience = 14 },
                new Doctor { Id = 10, Name = "Dr. Sato", Experience = 11 }
            );

            // Seed Specialities
            modelBuilder.Entity<Speciality>().HasData(
                new Speciality { Id = 1, Name = "Cardiology" },
                new Speciality { Id = 2, Name = "Dermatology" },
                new Speciality { Id = 3, Name = "Pediatrics" },
                new Speciality { Id = 4, Name = "Orthopedics" },
                new Speciality { Id = 5, Name = "Oncology" },
                new Speciality { Id = 6, Name = "Neurology" },
                new Speciality { Id = 7, Name = "Gynecology" },
                new Speciality { Id = 8, Name = "Psychiatry" },
                new Speciality { Id = 9, Name = "Gastroenterology" },
                new Speciality { Id = 10, Name = "Ophthalmology" }
            );

            // Seed DoctorSpecialities
            modelBuilder.Entity<DoctorSpeciality>().HasData(
                new DoctorSpeciality { DoctorId = 1, SpecialityId = 1 },
                new DoctorSpeciality { DoctorId = 2, SpecialityId = 2 },
                new DoctorSpeciality { DoctorId = 3, SpecialityId = 3 },
                new DoctorSpeciality { DoctorId = 4, SpecialityId = 4 },
                new DoctorSpeciality { DoctorId = 5, SpecialityId = 5 },
                new DoctorSpeciality { DoctorId = 6, SpecialityId = 6 },
                new DoctorSpeciality { DoctorId = 7, SpecialityId = 7 },
                new DoctorSpeciality { DoctorId = 8, SpecialityId = 8 },
                new DoctorSpeciality { DoctorId = 9, SpecialityId = 9 },
                new DoctorSpeciality { DoctorId = 10, SpecialityId = 10 }
            );
        }
    }
}
