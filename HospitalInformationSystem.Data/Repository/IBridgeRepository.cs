using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HospitalInformationSystem.Data.Repository
{
    public interface IBridgeRepository<T> 
    {
       IEnumerable< T> Search(Expression<Func<T, bool>> expression);
        void Add(T entity);
        T GetById(Expression<Func<T, bool>> expression);
        void Remove(T entity);
        void Update(T entity);
        void SaveChanges();




    }
}
