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
    public class RoomService
    {
        IRepository<Room> _repository;

        public RoomService(IRepository<Room> repository)
        {
            _repository = repository;
        }

        public void Add(RoomDTO viewModel)
        {
            Room room = new()
            {
                Type = viewModel.Type,
                NumberOfBeds = viewModel.NumberOfBeds,
                NightPrice = viewModel.NightPrice,
            };
            _repository.Add(room);
        }


        public void Delete(int id)
        {
            if (id != 0)
            {
                _repository.Delete(id);
            }
        }


/*        public void Delete(string id)
        {
            if (id is not null)
            {
                _repository.Delete(id);
            }
        }*/

        /*public void Update(RoomDTO roomDTO)
        {
            Room room = new ()
            {
                Type = roomDTO.Type,
                NumberOfBeds = roomDTO.NumberOfBeds,
                NightPrice = roomDTO.NightPrice,

            };

            _repository.Update(room);

        }*/

        public IEnumerable<RoomDTO> GetAll()
        {
            var rooms = _repository.GetAll();

            List<RoomDTO> result = [];
            foreach (var item in rooms)
            {
                RoomDTO viewModel = new()
                {
                    Type = item.Type,
                    NumberOfBeds = item.NumberOfBeds,
                    NightPrice = item.NightPrice,

                };
                result.Add(viewModel);
            }
            return result;

        }


        public RoomDTO GetOneRoo(int id)
        {
            var room = _repository.GetById(id);
            RoomDTO viewModel = new()
            {
                Type = room.Type,
                NumberOfBeds = room.NumberOfBeds,
                NightPrice = room.NightPrice,
            };

            return viewModel;

        }


    }
   
}
