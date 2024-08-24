using HospitalInformationSystem.Data;
using HospitalInformationSystem.Data.Repository;
using HospitalInformationSystem.DTO;
using HospitalInformationSystem.DTO.DTO;
using HospitalInformationSystem.Models.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace HospitalInformationSystem.Services
{
    public class TestService
    {
        IRepository<Requests> _repository;
        ApplicationDbContext _context;
        public static HistoryService _historyService;


        public TestService(IRepository<Requests> repository, ApplicationDbContext context, HistoryService historyService)
        {
            _repository = repository;
            _context = context;
            _historyService = historyService;

        }

        public List<Requests> ShowTests()
        {
            List<Requests> allReq = _context.Requests.ToList();
            List<Requests> result = [];
            foreach (var item in allReq)
            {
                if (item.Name == "Test")
                {
                    result.Add(item);
                }
            };
            return result;

        }

        /* public async Task<string> WriteFile(HttpContext httpContext, Test test)
         {
             Patient patient = _context.Patient.Where(x => x.NationalId.Equals(test.NID)).FirstOrDefault();
             int patientid = patient.Id;

             Doctor doctor = _context.Doctor.Where(x => x.FullName.Equals(test.DoctorName)).FirstOrDefault();
             int doctorid = doctor.Id;

             var file = test.img;
             string filename = "";
             try
             {
                 var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
                 filename = DateTime.Now.Ticks.ToString() + extension;

                 var filepath = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\Files");

                 if (!Directory.Exists(filepath))
                 {
                     Directory.CreateDirectory(filepath);
                 }

                 var exactpath = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\Files", filename);
                 using (var stream = new FileStream(exactpath, FileMode.Create))
                 {
                     await file.CopyToAsync(stream);
                 }
             }
             catch (Exception)
             {
             }
             var Xray = $"{httpContext.Request.Scheme}://{httpContext.Request.Host}/Resources/{filename}";
             _historyService.Add(patientid, doctorid, null, null, Xray, null);
             return Xray;



         }
 */

        public async Task<string> WriteFile(HttpContext httpContext, string patientId, Test test)
        {
            try
            {
                Patient patient = _context.Patient.FirstOrDefault(x => x.NationalId == patientId);
                if (patient == null)
                {
                    throw new Exception("Patient not found");
                }

                int patientIdInt = patient.Id;

                var file = test.img;
                string filename = "";
                try
                {
                    var extension = "." + file.FileName.Split('.').Last();
                    filename = DateTime.Now.Ticks.ToString() + extension;

                    var filepath = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\Files");

                    if (!Directory.Exists(filepath))
                    {
                        Directory.CreateDirectory(filepath);
                    }

                    var exactpath = Path.Combine(filepath, filename);
                    using (var stream = new FileStream(exactpath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"File processing error: {ex.Message}");
                    throw;
                }

                var xrayUrl = $"{httpContext.Request.Scheme}://{httpContext.Request.Host}/Upload/Files/{filename}";
                Doctor doctor = _context.Doctor.Where(x => x.FullName.Equals(test.DoctorName)).FirstOrDefault();
                int doctorid = doctor.Id;

                _historyService.Add(patientIdInt, doctorid, null, null, xrayUrl, null);
                return xrayUrl;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in WriteFile method: {ex.Message}");
                throw;
            }
        }
    }
}
