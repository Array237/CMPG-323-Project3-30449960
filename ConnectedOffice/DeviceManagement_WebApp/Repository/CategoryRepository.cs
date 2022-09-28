using DeviceManagement_WebApp.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using DeviceManagement_WebApp.Models;
using System.Linq;
using System;

namespace DeviceManagement_WebApp.Repository
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ConnectedOfficeContext context) : base(context)
        {
        }

    }
}
