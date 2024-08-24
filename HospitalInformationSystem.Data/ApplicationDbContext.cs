using HospitalInformationSystem.Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalInformationSystem.DTO.DTO;
using Tests = HospitalInformationSystem.Models.Models.Tests;

namespace HospitalInformationSystem.Data
{
    public partial class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Department> Department { get; set; }
       

        public virtual DbSet<Doctor> Doctor { get; set; }

        public virtual DbSet<DoctorHospital> DoctorHospital { get; set; }

        public virtual DbSet<DoctorPatient> DoctorPatient { get; set; }

        public virtual DbSet<Employee> Employee { get; set; }

        public virtual DbSet<HospitalFeedBack> HospitalFeedback { get; set; }
        public virtual DbSet<DoctorFeedBack> DoctorFeedback { get; set; }


        public virtual DbSet<Finance> Finance { get; set; }

        public virtual DbSet<History> History { get; set; }

        public virtual DbSet<Hospital> Hospital { get; set; }

        public virtual DbSet<HospitalDepartment> HospitalDepartment { get; set; }

        public virtual DbSet<HospitalService> HospitalService { get; set; }

        public virtual DbSet<Drugs> Medicine { get; set; }

        public virtual DbSet<MedicineStore> MedicineStore { get; set; }

        public virtual DbSet<MedicinesAndItem> MedicinesAndItem { get; set; }

        public virtual DbSet<Nurse> Nurse { get; set; }

        public virtual DbSet<Patient> Patient { get; set; }

        public virtual DbSet<PatientHospital> PatientHospital { get; set; }

        public virtual DbSet<PatientNurse> PatientNurse { get; set; }

        public virtual DbSet<PatientRoom> PatientRoom { get; set; }

        public virtual DbSet<PatientService> PatientService { get; set; }

        public virtual DbSet<Pharmacy> Pharmacy { get; set; }

        public virtual DbSet<Report> Report { get; set; }

        public virtual DbSet<Room> Room { get; set; }

        public virtual DbSet<Service> Service { get; set; }

        public virtual DbSet<Store> Store { get; set; }
        public virtual DbSet<XRays> Xrays { get; set; }
        public virtual DbSet<Tests> Tests { get; set; }
        public virtual DbSet<Reservations> Reservations { get; set; }
        public virtual DbSet<Requests> Requests { get; set; }
        public virtual DbSet<Clinics> Clinics { get; set; }
        public virtual DbSet<FeedBack> FeedBacks { get; set; }
        public virtual DbSet<Medication> Medications { get; set; }
        public virtual DbSet<Actions> Actions { get; set; }
        public virtual DbSet<Transfer> Transfers { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=NEHALHAMID;Initial Catalog=HIS;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            }
        }


    }

}
