using HospitalInformationSystem.Models.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HospitalInformationSystem.Data.Repository
{
    public interface IRepository<T>
    {

        IEnumerable<T> GetAll();

        IEnumerable<T> Search(Expression<Func<T, bool>> expression);

        string Delete(int id);      
        //string Update(string id,T entity);
        string Add(T entity);

        T GetById(int id);
       //  void SaveChanges();


    }
}






/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HospitalInformationSystem.Data.Repository
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> Search(Expression<Func<T, bool>> expression);

*//*        void Delete(int id);
*//*        
        void Delete(string id);
        void Update(T entity);
        void Add(T entity);
        T GetById(int id);
        void SaveChanges();


    }
}
*/