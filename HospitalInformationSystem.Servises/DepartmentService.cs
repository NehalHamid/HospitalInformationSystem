using HospitalInformationSystem.Data.Repository;
using HospitalInformationSystem.Models.Models;
using HospitalInformationSystem.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalInformationSystem.DTO.DTO;
using HospitalInformationSystem.Data;

namespace HospitalInformationSystem.Services
{
    public class DepartmentService
    {
        IRepository<Department> _repository;
        public static ApplicationDbContext _context;

        public DepartmentService(IRepository<Department> repository, ApplicationDbContext context)
        {
            _repository = repository;
            _context = context;
        }

        public void Add(DepartmentDTO department)
        {
            Department dept = new()
            {
                Name = department.Name.ToString(),
            };
            _repository.Add(dept);
        }
        public void Delete(int id)
        {
            if (id != 0)
            {
                _repository.Delete(id);
            }
        }

       /* public void Update(DepartmentDTO departmentDTO)
        {
            DepartmentDTO department = new DepartmentDTO();
            _repository.Update(department);
        }
*/
    public List<DepartmentDTO> GetAll()
    {
        var departments = _context.Department.ToList();
        List<DepartmentDTO> result = [];
        foreach (var dept in departments)
        {
            DepartmentDTO viewModel = new()
            {
                Name = dept.Name
            };
            result.Add(viewModel);
        }
        return result;

    }

    /*public DepartmentDTO GetOneDep(int id)
    {
        var department = _repository.GetById(id);
        DepartmentDTO viewModel = new()
        {
            Name = department.Name,

        };

        return viewModel;

    }

    public IEnumerable<DepartmentDTO> SearchByName(string Name)
    {
        List<DepartmentDTO> result = [];

        var departments = _repository.
            Search(expression: x => x.Name.Contains(Name));
        foreach (var item in departments)
        {
            DepartmentDTO department = new()
            {
                Name = item.Name,

            };
            result.Add(department);
        }
        return result;
    }*/



}
}
