using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace DeviceManagement_WebApp.Repository
{
    public class ZoneRepository : GenericRepository<Zone>, IZoneRepository
    {
        public ZoneRepository(ConnectedOfficeContext context) : base(context)
        {
        }

        //return first or default value if no value is found
        public async Task<Zone> FirstOrDef(Guid id)
        {
            return await _context.Zone.FirstOrDefaultAsync(m => m.ZoneId == id);
        }

    }
}
