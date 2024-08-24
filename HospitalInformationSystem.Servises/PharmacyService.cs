using HospitalInformationSystem.Data;
using HospitalInformationSystem.Data.Repository;
using HospitalInformationSystem.DTO;
using HospitalInformationSystem.DTO.DTO;
using HospitalInformationSystem.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HospitalInformationSystem.Services
{
    public class PharmacyService
    {

        IRepository<Pharmacy> _repository;
        ApplicationDbContext _context;

        public PharmacyService(IRepository<Pharmacy> repository,ApplicationDbContext context)
        {
            _repository = repository;
            _context = context;
        }

        public History GetHistory(string ID, DateOnly date)
        {
            var history = _context.History.FirstOrDefault(x => x.PatientNationalId == ID && DateOnly.FromDateTime(x.ExamenDate) == date);
            return history;
        }

        public HistoryDTO ShowMedication(History history)
        {
            Patient patient = _context.Patient.FirstOrDefault(x => x.NationalId == history.PatientNationalId);
            string patientName = patient.FullName;

            HistoryDTO historyDTO = new()
            {
                PatientNationalId = history.PatientNationalId,
                PatientName = patientName,
                Diagnosis = history.Diagnosis,
                Medicine = history.Medicine
            };

            return historyDTO;
        }

        public HistoryDTO GetPatientMedication(string ID, DateOnly date)
        {
            History history = GetHistory(ID, date);
            if (history != null)
            {
                HistoryDTO historyDTO = ShowMedication(history);
                return historyDTO;
            }
            return null;
        }


        /*
                public Historydto GetMedication(History history)
                {
                    Patient patient = _context.Patient.FirstOrDefault(x => x.NationalId == history.PatientNationalId);
                    string patientName = patient.FullName;

                    var history1 = _context.History.FirstOrDefault(x => x.PatientNationalId == patient.NationalId );


                    Historydto historydto =new()
                    {
                        Patientname=patientName,

                    }

                }*/


    }
}
