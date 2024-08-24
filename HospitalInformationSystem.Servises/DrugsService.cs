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
    public class DrugsService
    {
        IRepository<Drugs> _repository;

        public DrugsService(IRepository<Drugs> repository)
        {
            _repository = repository;
        }
        public void Add(DrugsDTO viewModel)
        {
            Drugs drug = new()
            {
                MedicineName = viewModel.MedicineName,
                DateOfDrugApproval = viewModel.DateOfDrugApproval,
                FromInternalPharmacy = viewModel.FromInternalPharmacy,
            };
            _repository.Add(drug);

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
/*
        public void Update(DrugsDTO drugsDTO)
        {
            Drugs drugs = new()
            {
                MedicineName = drugsDTO.MedicineName,
                DateOfDrugApproval = drugsDTO.DateOfDrugApproval,
                FromInternalPharmacy = drugsDTO.FromInternalPharmacy



            };

            _repository.Update(drugs);
        }
*/

        public IEnumerable<DrugsDTO> GetAll()
        {
            var drugs = _repository.GetAll();

            List<DrugsDTO> result = [];
            foreach (var item in drugs)
            {
                DrugsDTO viewModel = new()
                {
                    MedicineName = item.MedicineName,
                    DateOfDrugApproval = item.DateOfDrugApproval,
                    FromInternalPharmacy = item.FromInternalPharmacy,

                };
                result.Add(viewModel);
            }
            return result;

        }

        public DrugsDTO GetOneDrug(int id)
        {
            var drug = _repository.GetById(id);
            DrugsDTO viewModel = new()
            {
                MedicineName = drug.MedicineName,
                DateOfDrugApproval = drug.DateOfDrugApproval,
                FromInternalPharmacy = drug.FromInternalPharmacy,

            };

            return viewModel;

        }


    }
}
