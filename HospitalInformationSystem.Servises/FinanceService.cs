using HospitalInformationSystem.Data.Repository;
using HospitalInformationSystem.DTO.DTO;
using HospitalInformationSystem.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalInformationSystem.Services
{
    public class FinanceService
    {
        IRepository<Finance> _repository;

        public FinanceService(IRepository<Finance> repository)
        {
            _repository = repository;
        }
        public void Add(FinanceDTO viewModel)
        {
            Finance finance = new()
            {
                TotalCost = viewModel.TotalCost,
                TotalRevenues = viewModel.TotalRevenues,
                NetProfit = viewModel.NetProfit,
                DetailedCosts = viewModel.DetailedCosts,
                DetailedRevenues = viewModel.DetailedRevenues,
                ScheduleDate = viewModel.ScheduleDate
            };
            _repository.Add(finance);

        }
        public IEnumerable<FinanceDTO> GetAll()
        {
            var finance = _repository.GetAll();

            List<FinanceDTO> result = [];
            foreach (var item in finance)
            {
                FinanceDTO viewModel = new()
                {
                    TotalCost = item.TotalCost,
                    TotalRevenues = item.TotalRevenues,
                    NetProfit = item.NetProfit,
                    DetailedCosts = item.DetailedCosts,
                    DetailedRevenues = item.DetailedRevenues,
                    ScheduleDate = item.ScheduleDate

                };
                result.Add(viewModel);
            }
            return result;

        }



        public FinanceDTO GetOneFin(int id)
        {
            var finance = _repository.GetById(id);
            FinanceDTO viewModel = new()
            {
                TotalCost = finance.TotalCost,
                TotalRevenues = finance.TotalRevenues,
                NetProfit = finance.NetProfit,
                DetailedCosts = finance.DetailedCosts,
                DetailedRevenues = finance.DetailedRevenues,
                ScheduleDate = finance.ScheduleDate

            };

            return viewModel;

        }


    }
}
