using HospitalInformationSystem.Data;
using HospitalInformationSystem.Data.Repository;
using HospitalInformationSystem.DTO.DTO;
using HospitalInformationSystem.Models.Models;
using NPOI.HSSF.Record.AutoFilter;
using Org.BouncyCastle.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalInformationSystem.Services
{
    public class HistoryService
    {
        IRepository<History> _repository;
        HistoryDTO historyDTO = new HistoryDTO();
        ApplicationDbContext _context;

       public HistoryService(IRepository<History> repository, ApplicationDbContext context)
        {
            _repository = repository;
            _context = context;
        }
        public void Add(int patientid,int? doctorid,List<string> medicine=null ,string diagnosis=null,string xray=null,string test=null)
        {

            Patient patient = _context.Patient.Where(x => x.Id == patientid).FirstOrDefault();
            int PatientId = patient.Id;

                Doctor doctor = _context.Doctor.Where(x => x.Id == doctorid).FirstOrDefault();
                int DoctorId = doctor.Id;

                History history = new()
                {
                    DoctorId = DoctorId,
                    PatientId = PatientId,
                    DoctorNationalId = doctor.NationalId,
                    PatientNationalId = patient.NationalId,
                    Diagnosis = diagnosis,
                    XRay = xray,
                    Test = test,
                    ExamenDate = DateTime.Now,
                    Medicine = new List<string>()
                };
                //medicine
                if (medicine != null)
                {
                    foreach (var item in medicine)
                    {
                        history.Medicine.Add(item);

                    }
                }

                _repository.Add(history);
                _context.SaveChanges();
          

        }

    


        public HistoryDTO GetOneHis(string id)
        {
            var history = _context.History.FirstOrDefault(x=>x.PatientNationalId== id);
            HistoryDTO viewModel = new()
            {
                PatientNationalId = history.PatientNationalId,
                DoctorNationalId= history.DoctorNationalId,
                Diagnosis = history.Diagnosis,
                XRay = history.XRay,
                DoctorId = history.DoctorId,
                ExamenDate = history.ExamenDate

            };

            List<string> medicines = [];
            foreach (var item in history.Medicine)
            {
                medicines.Add(item);
            };

            viewModel.Medicine = medicines;

            return viewModel;

        }



    }
}
