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
    public class ServiceService
    {
        IRepository<Service> _repository;
        public ServiceService(IRepository<Service> repository)
        {
            _repository = repository;
        }

        public void Add(ServiceDTO viewModel)
        {
            Service service = new()
            {
                Name = viewModel.Name,
            };
            _repository.Add(service);
        }



        public void Delete(int id)
        {
            if (id != 0)
            {
                _repository.Delete(id);
            }
        }


/*
        public void Delete(string id)
        {
            if (id is not null)
            {
                _repository.Delete(id);
            }
        }*/

       /* public void Update(ServiceDTO serviceDTO)
        {
            Service service = new ()
            {
                Name = serviceDTO.Name

            };

            _repository.Update(service);

        }
*/

        public IEnumerable<ServiceDTO> GetAll()
        {
            var rooms = _repository.GetAll();

            List<ServiceDTO> result = [];
            foreach (var item in rooms)
            {
                ServiceDTO viewModel = new()
                {
                    Name = item.Name

                };
                result.Add(viewModel);
            }
            return result;

        }


        public ServiceDTO GetOneSer(int id)
        {
            var service = _repository.GetById(id);
            ServiceDTO viewModel = new()
            {
                Name = service.Name
            };

            return viewModel;

        }


    }


}
