using HospitalInformationSystem.Data.Repository;
using HospitalInformationSystem.Data;
using HospitalInformationSystem.DTO.DTO;
using HospitalInformationSystem.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace HospitalInformationSystem.Services
{
    public class XRayService
    {
        IRepository<Requests> _repository;
        public static ApplicationDbContext _context;
        public static HistoryService _historyService;




        public XRayService(IRepository<Requests> repository, ApplicationDbContext context, HistoryService historyService)
        {
            _repository = repository;
            _context = context;
            _historyService= historyService;

        }


        public List<Requests> ShowXRays()
        {
            List<Requests> allReq = _context.Requests.ToList();
            List<Requests> result = [];
            foreach (var item in allReq)
            {
                if (item.Name == "XRay")
                {
                    result.Add(item);
                }               
            };
            return result;

        }

        public async Task<string> WriteFile(HttpContext httpContext, XRay ray)
        {
            Patient patient = _context.Patient.Where(x => x.NationalId.Equals(ray.NID)).FirstOrDefault();
            int patientid = patient.Id;

            Doctor doctor = _context.Doctor.Where(x => x.FullName.Equals(ray.DoctorName)).FirstOrDefault();
            int doctorid = doctor.Id;

            var file = ray.img;
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



    }
}
