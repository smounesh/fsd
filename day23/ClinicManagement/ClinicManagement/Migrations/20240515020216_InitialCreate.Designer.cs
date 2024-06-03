﻿// <auto-generated />
using ClinicManagement.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ClinicManagement.Migrations
{
    [DbContext(typeof(ClinicManagementContext))]
    [Migration("20240515020216_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.30")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ClinicManagement.Models.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Experience")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("ClinicManagement.Models.DoctorSpeciality", b =>
                {
                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<int>("SpecialityId")
                        .HasColumnType("int");

                    b.HasKey("DoctorId", "SpecialityId");

                    b.HasIndex("SpecialityId");

                    b.ToTable("DoctorSpecialities");
                });

            modelBuilder.Entity("ClinicManagement.Models.Speciality", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Specialities");
                });

            modelBuilder.Entity("ClinicManagement.Models.DoctorSpeciality", b =>
                {
                    b.HasOne("ClinicManagement.Models.Doctor", "Doctor")
                        .WithMany("DoctorSpecialities")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClinicManagement.Models.Speciality", "Speciality")
                        .WithMany("DoctorSpecialities")
                        .HasForeignKey("SpecialityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Speciality");
                });

            modelBuilder.Entity("ClinicManagement.Models.Doctor", b =>
                {
                    b.Navigation("DoctorSpecialities");
                });

            modelBuilder.Entity("ClinicManagement.Models.Speciality", b =>
                {
                    b.Navigation("DoctorSpecialities");
                });
#pragma warning restore 612, 618
        }
    }
}