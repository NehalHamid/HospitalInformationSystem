using HospitalInformationSystem.DTO;
using HospitalInformationSystem.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HospitalInformationSystem.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseModel
    {

        ApplicationDbContext _context;



        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public string Add(T entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
            return "Successfully Added";
        }

       public string Delete(int id)
        {

           var item = GetById(id);
            
            if (item != null)
            {
                _context.Remove(item);
                _context.SaveChangesAsync();
            }

            return "Successfully Deleted";


        }

        public  IEnumerable<T> Search(Expression<Func<T, bool>> expression)
        {
            var items = _context.Set<T>().Where(expression);
            return  items.ToList(); ;
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();

        }

        public T GetById(int id)
        {
            var item = _context.Set<T>().FirstOrDefault(x => x.Id==id);

            return item;
        }

  

        //save Data to Database

/*
        public string Update(string id,T entity)
        {
            var existingEntity = _context.Set<T>().FirstOrDefault(x => x.NationalId==id);
            _context.Entry(existingEntity).CurrentValues.SetValues(entity);
            _context.Update(entity);
            _context.SaveChanges();
            return "Successfully Updated";


        }*/



    }
}
















/*
using HospitalInformationSystem.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HospitalInformationSystem.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseModel
    {

        ApplicationDbContext _context;



        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(T entity)
        {
            _context.Add(entity);
            //_context.SaveChanges();
            SaveChanges();
        }

*//*
        public void Delete(int id)
        {
            var item = GetById(id);
            if (item != null)
            {
                _context.Remove(item);
                //_context.SaveChanges();
                SaveChanges();
            }
        }      *//*  
       
        public void Delete(string id)
        {
            //سؤال
            var item = GetById(int.Parse(id));
            if (item != null)
            {
                _context.Remove(item);
                //_context.SaveChanges();
                SaveChanges();
            }
        }

        public IEnumerable<T> Search(Expression<Func<T, bool>> expression)
        {
            var items = _context.Set<T>().Where(expression);
            return items;
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            var item = _context.Set<T>().FirstOrDefault(x => x.Id == id);

            return item;

        }
        //save Data to Database
        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _context.Update(entity);
            SaveChanges();

        }



    }
}*/
