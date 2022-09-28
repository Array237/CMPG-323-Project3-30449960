using DeviceManagement_WebApp.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeviceManagement_WebApp.Repository
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        public Task<Category> FirstOrDef(Guid id);
    }
}
