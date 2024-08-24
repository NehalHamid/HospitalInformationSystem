using HospitalInformationSystem.Data.Repository;
using HospitalInformationSystem.DTO;
using HospitalInformationSystem.DTO.DTO;
using HospitalInformationSystem.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalInformationSystem.Services
{
    public class ReportService

    {
        IRepository<Report> _repository;
        public ReportService(IRepository<Report> repository)
        {
            _repository = repository;
        }
        public void Add(ReportDTO viewModel)
        {
            Report report = new()
            {
                Name = viewModel.Name,
                Result = viewModel.Result,
            };
            _repository.Add(report);
        }
        public IEnumerable<ReportDTO> GetAll()
        {
            var reports = _repository.GetAll();

            List<ReportDTO> result = [];
            foreach (var item in reports)
            {
                ReportDTO viewModel = new()
                {
                    Name = item.Name,
                    Result = item.Result,


                };
                result.Add(viewModel);
            }
            return result;

        }


        public ReportDTO GetOneRep(int id)
        {
            var report = _repository.GetById(id);
            ReportDTO viewModel = new()
            {

                Name = report.Name,
                Result = report.Result,
            };

            return viewModel;

        }

    }
    
}
