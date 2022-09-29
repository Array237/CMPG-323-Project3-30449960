using DeviceManagement_WebApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        
        //Recieves a genereic datatype and adds it to corret datatype
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
        
        //get all items in specific datatype and returns a list
        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }
        
        //looks for a datatype by its ID and returns it 
        public T GetById(Guid id)
        {
            return _context.Set<T>().Find(id);
        }
        
        //Removes a specific instace of a datatype
        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
        
        public void RemoveRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }

        //Saves any changes made in context to database
        public async Task<int> saveAs()
        {
            return await _context.SaveChangesAsync();
        }

        //Updates an instance of a datatype 
        public void Update(T item)
        {
            _context.Update(item);
        }

        //Finds device by id
        public bool Find(Guid id)
        {
            return GetById(id) != null;
        }

        //Finds and works with entity without making request to database
        public async Task<T> findAs(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        //Returns a list asynchronously
        public async Task<List<T>> ToList()
        {
            return await _context.Set<T>().ToListAsync();
        }

    }
}
