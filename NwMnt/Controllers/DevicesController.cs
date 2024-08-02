using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NwMnt.Models;
using NwMnt.Services;
using NwMnt.ViewModels;

namespace NwMnt.Controllers
{
    public class DevicesController : Controller
    {
        private readonly DeviceService _deviceService;

        public DevicesController(DeviceService deviceService)
        {
            _deviceService = deviceService;
        }

        public async Task<IActionResult> Index()
        {
            var devices = await _deviceService.GetAllDevices();
            var deviceViewModels = devices.Select(d => new DeviceViewModel
            {
                Id = d.Id,
                Name = d.Name,
                IpAddress = d.IpAddress,
                Type = d.Type,
                Description = d.Description,
                Status = d.Status,
                LastUpdated = d.LastUpdated
                // ... (Các thuộc tính khác nếu có)
            });
            return View(deviceViewModels);
        }

        // GET: Devices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var device = await _deviceService.GetDeviceById(id);
            if (device == null)
            {
                return NotFound();
            }

            var deviceViewModel = new DeviceViewModel
            {
                Id = device.Id,
                Name = device.Name,
                IpAddress = device.IpAddress,
                Type = device.Type,
                Description = device.Description,
                Status = device.Status,
                LastUpdated = device.LastUpdated
                // ... (Các thuộc tính khác nếu có)
            };

            return View(deviceViewModel);
        }

        // GET: Devices/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Devices/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DeviceViewModel deviceViewModel)
        {
            if (ModelState.IsValid)
            {
                var device = new Device
                {
                    Name = deviceViewModel.Name,
                    IpAddress = deviceViewModel.IpAddress,
                    Type = deviceViewModel.Type,
                    Description = deviceViewModel.Description
                };

                await _deviceService.AddDevice(device);
                return RedirectToAction(nameof(Index));
            }
            return View(deviceViewModel);
        }

        // GET: Devices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var device = await _deviceService.GetDeviceById(id);
            if (device == null)
            {
                return NotFound();
            }

            var deviceViewModel = new DeviceViewModel
            {
                Id = device.Id,
                Name = device.Name,
                IpAddress = device.IpAddress,
                Type = device.Type,
                Description = device.Description
                // ... (Các thuộc tính khác nếu có)
            };

            return View(deviceViewModel);
        }

        // POST: Devices/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, DeviceViewModel deviceViewModel)
        {
            if (id != deviceViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var device = new Device
                    {
                        Id = deviceViewModel.Id,
                        Name = deviceViewModel.Name,
                        IpAddress = deviceViewModel.IpAddress,
                        Type = deviceViewModel.Type,
                        Description = deviceViewModel.Description
                    };

                    await _deviceService.UpdateDevice(device);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _deviceService.DeviceExists(deviceViewModel.Id))
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
            return View(deviceViewModel);
        }

        // GET: Devices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var device = await _deviceService.GetDeviceById(id);
            if (device == null)
            {
                return NotFound();
            }

            return View(device);
        }

        // POST: Devices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _deviceService.DeleteDevice(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
