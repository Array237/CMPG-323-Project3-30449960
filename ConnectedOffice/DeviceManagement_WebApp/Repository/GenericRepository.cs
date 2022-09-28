using DeviceManagement_WebApp.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DeviceManagement_WebApp.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ConnectedOfficeContext _context;
        
        public GenericRepository(ConnectedOfficeContext context)
        {
            _context = context;
        }
        
        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }
        
        public void AddRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
        }
        
        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression);
        }
        
        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }
        
        public T GetById(Guid id)
        {
            return _context.Set<T>().Find(id);
        }
        
        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
        
        public void RemoveRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }

        public void saveAs()
        {
            _context.SaveChangesAsync();
        }

        public void Update(T item)
        {
            _context.Update(item);
        }

        public bool Find(Guid id)
        {
            return GetById(id) != null;
        }

        public async Task<T> findAs(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

    }
}
