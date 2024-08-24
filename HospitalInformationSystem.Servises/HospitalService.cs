/*using HospitalInformationSystem.Data.Repository;
using HospitalInformationSystem.DTO.DTO;
using HospitalInformationSystem.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalInformationSystem.Services
{
    public class HospitalService
    {
        IRepository<Hospital> _repository;

        public HospitalService(IRepository<Hospital> repository)
        {
            _repository = repository;
        }
        public void Add(HospitalDTO viewModel)
        {
            Hospital hospital = new()
            {
                Name = viewModel.Name,
                City = viewModel.City,
                Region = viewModel.Region,
                Street = viewModel.Street,
                Type = viewModel.Type,
            };
            _repository.Add(hospital);

        }



        public void Delete(int id)
        {
            if (id != 0)
            {
                _repository.Delete(id);
            }
        }


*//*
        public void Delete(string id)
        {
            if (id is not null)
            {
                _repository.Delete(id);
            }
        }*//*
        public void Update(HospitalDTO hospitalDTO)
        {
            Hospital hospital = new()
            {
                Name = hospitalDTO.Name,
                City = hospitalDTO.City,
                Region = hospitalDTO.Region,
                Street = hospitalDTO.Street,
                Type = hospitalDTO.Type


            };

            _repository.Update(hospital);
        }



        public IEnumerable<HospitalDTO> GetAll()
        {
            var hospitals = _repository.GetAll();

            List<HospitalDTO> result = [];
            foreach (var item in hospitals)
            {
                HospitalDTO viewModel = new()
                {
                    Name = item.Name,
                    City = item.City,
                    Region = item.Region,
                    Street = item.Street,
                    Type = item.Type,

                };
                result.Add(viewModel);
            }
            return result;

        }


        public HospitalDTO GetOneHos(int id)
        {
            var hospital = _repository.GetById(id);
            HospitalDTO viewModel = new()
            {
                Name = hospital.Name,
                City = hospital.City,
                Region = hospital.Region,
                Street = hospital.Street,
                Type = hospital.Type,

            };

            return viewModel;

        }

    }
}
*/