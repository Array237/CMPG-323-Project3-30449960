using DeviceManagement_WebApp.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using DeviceManagement_WebApp.Models;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;

namespace DeviceManagement_WebApp.Repository
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ConnectedOfficeContext context) : base(context)
        {
        }

        //return first or default value if no value is found
        public async Task<Category> FirstOrDef(Guid id)
        {
            return await _context.Category.FirstOrDefaultAsync(m => m.CategoryId == id);
        }

    }
}
