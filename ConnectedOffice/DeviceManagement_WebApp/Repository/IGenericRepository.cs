using DeviceManagement_WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DeviceManagement_WebApp.Repository
{   
    public interface IGenericRepository<T> where T : class
    {
        T GetById(Guid id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
        Task<int> saveAs();
        void Update(T item);
        bool Find(Guid id);
        Task<T> findAs(Guid id);
        public Task<List<T>> ToList();
    }
}
