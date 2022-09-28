using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Threading.Tasks;

namespace DeviceManagement_WebApp.Repository
{
    public class DeviceRepository : GenericRepository<Device>, IDeviceRepository
    {
        public DeviceRepository(ConnectedOfficeContext context) : base(context)
        {
        }

        public IIncludableQueryable<Device,Zone> IncludeDevice()
        {
            var temp = _context.Device.Include(d => d.Category).Include(d => d.Zone);
            return temp;
        }

        public async Task<Device> DeviceDetails(Guid id)
        {
            var temp = await _context.Device.Include(d => d.Category).Include(d => d.Zone).FirstOrDefaultAsync(m => m.DeviceId == id);
            return temp;
        }

    }
}
