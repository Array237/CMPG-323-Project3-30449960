using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using DeviceManagement_WebApp.Repository;

namespace DeviceManagement_WebApp.Controllers
{
    public class DevicesController : Controller
    {
        private readonly IDeviceRepository _deviceRepo;
        private readonly ICategoryRepository _categoryRepo;
        private readonly IZoneRepository _zoneRepo;

        public DevicesController(IDeviceRepository deviceRepo, ICategoryRepository categoryRepo, IZoneRepository zoneRepo)
        {
            _deviceRepo = deviceRepo;
            _categoryRepo = categoryRepo;
            _zoneRepo = zoneRepo;
        }

        // GET: Devices
        public async Task<IActionResult> Index()
        {
            var connectedOfficeContext = _deviceRepo.IncludeDevice();
            return View(await connectedOfficeContext.ToListAsync());
        }

        // GET: Devices/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var device = await _deviceRepo.DeviceDetails((Guid)id);
            if (device == null)
            {
                return NotFound();
            }

            return View(device);
        }

        // GET: Devices/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_categoryRepo.GetAll(), "CategoryId", "CategoryName");
            ViewData["ZoneId"] = new SelectList(_zoneRepo.GetAll(), "ZoneId", "ZoneName");
            return View();
        }

        // POST: Devices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DeviceId,DeviceName,CategoryId,ZoneId,Status,IsActive,DateCreated")] Device device)
        {
            device.DeviceId = Guid.NewGuid();
            _deviceRepo.Add(device);
            await _deviceRepo.saveAs();
            return RedirectToAction(nameof(Index));


        }

        // GET: Devices/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var device = deviceRepo.GetById((Guid)id);
            var device = await _deviceRepo.findAs((Guid)id);
            if (device == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_categoryRepo.GetAll(), "CategoryId", "CategoryName", device.CategoryId);
            ViewData["ZoneId"] = new SelectList(_zoneRepo.GetAll(), "ZoneId", "ZoneName", device.ZoneId);
            return View(device);
        }

        // POST: Devices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("DeviceId,DeviceName,CategoryId,ZoneId,Status,IsActive,DateCreated")] Device device)
        {
            if (id != device.DeviceId)
            {
                return NotFound();
            }
            try
            {
                _deviceRepo.Update(device);
                await _deviceRepo.saveAs();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeviceExists(device.DeviceId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));

        }

        // GET: Devices/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var device = await _deviceRepo.DeviceDetails((Guid)id);
            if (device == null)
            {
                return NotFound();
            }

            return View(device);
        }

        // POST: Devices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var device = await _deviceRepo.findAs(id);
            _deviceRepo.Remove(device);
            await _deviceRepo.saveAs();
            return RedirectToAction(nameof(Index));
        }

        private bool DeviceExists(Guid id)
        {
            return _zoneRepo.Find(id);
        }
    }
}
