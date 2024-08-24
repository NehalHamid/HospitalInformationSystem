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
    public class StoreServices
    {
        IRepository<Store> _repository;

        public StoreServices(IRepository<Store> repository)
        {
            _repository = repository;
        }
        public void Add(StoreDTO viewModel)
        {
            Store store = new()
            {
                Type = viewModel.Type,
                Name = viewModel.Name,

            };
            _repository.Add(store);
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

     /*   public void Update(StoreDTO storeDTO)
        {
            Store service = new ()
            {

                Type = storeDTO.Type,
                Name = storeDTO.Name,


            };

            _repository.Update(service);

        }
*/
        public IEnumerable<StoreDTO> GetAll()
        {
            var rooms = _repository.GetAll();

            List<StoreDTO> result = [];
            foreach (var item in rooms)
            {
                StoreDTO viewModel = new()
                {

                    Type = item.Type,
                    Name = item.Name,


                };
                result.Add(viewModel);
            }
            return result;

        }


        public StoreDTO GetOneSer(int id)
        {
            var store = _repository.GetById(id);
            StoreDTO viewModel = new()
            {
                Type = store.Type,
                Name = store.Name
            };

            return viewModel;

        }

    }
}
