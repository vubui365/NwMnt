using Microsoft.EntityFrameworkCore;
using NwMnt.Data;
using NwMnt.Models;

namespace NwMnt.Repositories
{
    public class AlertRepository : IAlertRepository
    {
        private readonly ApplicationDbContext _context;

        public AlertRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Alert>> GetAllAlertsAsync()
        {
            return await _context.Alerts.Include(a => a.Device).Include(a => a.Sensor).ToListAsync();
        }

        public async Task<Alert> GetAlertByIdAsync(int id)
        {
            return await _context.Alerts.Include(a => a.Device).Include(a => a.Sensor).FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task AddAlertAsync(Alert alert)
        {
            _context.Alerts.Add(alert);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAlertAsync(Alert alert)
        {
            _context.Entry(alert).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAlertAsync(int id)
        {
            var alert = await _context.Alerts.FindAsync(id);
            if (alert != null)
            {
                _context.Alerts.Remove(alert);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> AlertExistsByIdAsync(int id)
        {
            return await _context.Alerts.AnyAsync(e => e.Id == id);
        }

        public async Task<Alert> GetAlertByNameAsync(string name) // Sửa kiểu tham số thành string
        {
            // Giả sử bạn có thuộc tính Name trong Alert
            return await _context.Alerts.FirstOrDefaultAsync(a => a.Name == name);
        }

        public async Task<bool> AlertExistsByNameAsync(string name)
        {
            return await _context.Alerts.AnyAsync(e => e.Name == name);
        }
    }
}
