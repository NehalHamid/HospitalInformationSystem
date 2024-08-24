using HospitalInformationSystem.Data;
using HospitalInformationSystem.Data.Repository;
using HospitalInformationSystem.DTO.DTO;
using HospitalInformationSystem.Models.Models;
using NPOI.SS.Formula.Eval;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Action = HospitalInformationSystem.Models.Models.Action;

namespace HospitalInformationSystem.Services
{
    public class NurseService
    {
        IRepository<Nurse> _repository;
        public static ApplicationDbContext _context;

        public NurseService(IRepository<Nurse> repository, ApplicationDbContext context)
        {
            _repository = repository;
            _context = context;
        }



        public IEnumerable<NurseDTO> GetAll()
        {
            var nurses = _repository.GetAll();

            List<NurseDTO> result = [];
            foreach (var item in nurses)
            {
                NurseDTO viewModel = new()
                {
                    FullName = item.FullName,
                    Email = item.Email,
                    Password = item.Password,
                    NationalId = item.NationalId,
                    Phone = item.Phone,
                    TimeSlot = item.TimeSlot,
                    Salary = item.Salary

                };
                result.Add(viewModel);
            }
            return result;

        }


        public NurseDTO ShowProfile(string type,string ID)
        {
            Nurse nurse = _context.Nurse.FirstOrDefault(x => x.NationalId == ID);

                NurseDTO result = new()
                {
                    FullName = nurse.FullName,
                    Email = nurse.Email,
                    Password = nurse.Password,
                    NationalId = nurse.NationalId,
                    Phone = nurse.Phone
                };
                return result;






        }

        public static List<Medication> Medications()
        {

                List<Medication> medications = _context.Medications.ToList();

                return medications;
            

        }



        public string AddAction(Action action)
        {

                Actions action1 = new()
                {
                    NurseNatinalId = action.nurseID,
                    PatientNationalId = action.nationalID,
                    Notes = action.notes,
                    AddedAt=DateTime.Now

                };
                _context.Actions.Add(action1);
                _context.SaveChanges();
                return "Action Added Successfully";


        }


        public List<ShiftsDTO> GetAllShifts()
        {

                List<Nurse> nurses = _repository.GetAll().ToList();
                List<ShiftsDTO> shifts = [];
                foreach (var item in nurses)
                {
                    ShiftsDTO newShift = new()
                    {
                        Name = item.FullName,
                        Shift = item.TimeSlot
                    };
                    shifts.Add(newShift);
                };

                return shifts;


        }



    }
}
