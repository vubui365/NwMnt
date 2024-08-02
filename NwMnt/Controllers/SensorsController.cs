using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NwMnt.Models;
using NwMnt.Services;
using NwMnt.ViewModels;

namespace NwMnt.Controllers
{
    public class SensorsController : Controller
    {
        private readonly SensorService _sensorService;
        private readonly DeviceService _deviceService;

        public SensorsController(SensorService sensorService, DeviceService deviceService)
        {
            _sensorService = sensorService;
            _deviceService = deviceService;
        }

        // GET: Sensors
        public async Task<IActionResult> Index()
        {
            var sensors = await _sensorService.GetAllSensors();
            var sensorViewModels = sensors.Select(s => new SensorViewModel
            {
                Id = s.Id,
                Name = s.Name,
                Oid = s.Oid,
                DataType = s.DataType,
                Unit = s.Unit,
                DeviceId = s.DeviceId,
                DeviceName = s.Device?.Name,
                Threshold = s.Threshold // Truy cập thuộc tính Threshold
            });
            return View(sensorViewModels);
        }

        // GET: Sensors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sensor = await _sensorService.GetSensorById(id ?? 0);
            if (sensor == null)
            {
                return NotFound();
            }

            var sensorViewModel = new SensorViewModel
            {
                Id = sensor.Id,
                Name = sensor.Name,
                Oid = sensor.Oid,
                DataType = sensor.DataType,
                Unit = sensor.Unit,
                DeviceId = sensor.DeviceId,
                DeviceName = sensor.Device?.Name,
                Threshold = sensor.Threshold 
            };

            return View(sensorViewModel);
        }

        // GET: Sensors/Create
        public async Task<IActionResult> Create() 
        {
            ViewData["DeviceId"] = new SelectList(await _deviceService.GetAllDevices(), "Id", "Name");
            return View();
        }

        // POST: Sensors/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SensorViewModel sensorViewModel)
        {
            if (ModelState.IsValid)
            {
                var sensor = new Sensor
                {
                    Name = sensorViewModel.Name,
                    Oid = sensorViewModel.Oid,
                    DataType = sensorViewModel.DataType,
                    Unit = sensorViewModel.Unit,
                    DeviceId = sensorViewModel.DeviceId,
                    Threshold = sensorViewModel.Threshold // Gán giá trị Threshold
                };

                await _sensorService.AddSensor(sensor);
                return RedirectToAction(nameof(Index));
            }
            ViewData["DeviceId"] = new SelectList(await _deviceService.GetAllDevices(), "Id", "Name", sensorViewModel.DeviceId); // Đợi kết quả
            return View(sensorViewModel);
        }

        // GET: Sensors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sensor = await _sensorService.GetSensorById(id ?? 0);
            if (sensor == null)
            {
                return NotFound();
            }

            var sensorViewModel = new SensorViewModel
            {
                Id = sensor.Id,
                Name = sensor.Name,
                Oid = sensor.Oid,
                DataType = sensor.DataType,
                Unit = sensor.Unit,
                DeviceId = sensor.DeviceId,
                Threshold = sensor.Threshold // Truy cập thuộc tính Threshold
            };

            ViewData["DeviceId"] = new SelectList(await _deviceService.GetAllDevices(), "Id", "Name", sensorViewModel.DeviceId); // Đợi kết quả
            return View(sensorViewModel);
        }

        // POST: Sensors/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SensorViewModel sensorViewModel)
        {
            if (id != sensorViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var sensor = new Sensor // Chỉ khai báo một lần
                    {
                        Id = sensorViewModel.Id,
                        Name = sensorViewModel.Name,
                        Oid = sensorViewModel.Oid,
                        DataType = sensorViewModel.DataType,
                        Unit = sensorViewModel.Unit, // Lấy giá trị từ sensorViewModel
                        DeviceId = sensorViewModel.DeviceId,
                        Threshold = sensorViewModel.Threshold
                    };

                    await _sensorService.UpdateSensor(sensor);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _sensorService.SensorExists(sensorViewModel.Id))
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
            ViewData["DeviceId"] = new SelectList(await _deviceService.GetAllDevices(), "Id", "Name", sensorViewModel.DeviceId);
            return View(sensorViewModel);
        }

        // GET: Sensors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sensor = await _sensorService.GetSensorById(id ?? 0);
            if (sensor == null)
            {
                return NotFound();
            }

            return View(sensor);
        }

        // POST: Sensors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _sensorService.DeleteSensor(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
