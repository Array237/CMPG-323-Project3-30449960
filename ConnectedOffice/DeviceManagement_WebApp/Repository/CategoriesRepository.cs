using DeviceManagement_WebApp.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using DeviceManagement_WebApp.Models;
using System.Linq;

namespace DeviceManagement_WebApp.Repository
{
    public class CategoriesRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoriesRepository(ConnectedOfficeContext context) : base(context)
        {
        }

        // GET: Categories
        public List<Category> GetAll()
        {
            return _context.Category.ToList();
        }
    }
}
