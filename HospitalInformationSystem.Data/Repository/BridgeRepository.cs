using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace HospitalInformationSystem.Data.Repository
{
    public class BridgeRepository<T> : IBridgeRepository<T> where T : class
    {
        ApplicationDbContext _context;
        public BridgeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Add(entity);
            SaveChanges();
        }

        
        public IEnumerable< T> Search(Expression<Func<T, bool>> expression)
        {
           var items= _context.Set<T>().Where(expression);
            return items;
        }
        public T GetById(Expression<Func<T, bool>> expression)
        {
            var item = _context.Set<T>().FirstOrDefault(expression );

            return item;

        }


        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Remove(T entity)
        {
           _context.Remove(entity);
            SaveChanges();
        }

        public void Update(T entity)
        {
           _context.Update(entity);
            SaveChanges();
        }
    }
}
