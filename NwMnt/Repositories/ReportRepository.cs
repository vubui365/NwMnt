using Microsoft.EntityFrameworkCore;
using NwMnt.Data;
using NwMnt.Models;

namespace NwMnt.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private readonly ApplicationDbContext _context;

        public ReportRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public List<Report> GetAllReports()
        {
            return _context.Reports.ToList();
        }

        public async Task<Report> GetReportByIdAsync(int id)
        {
            return await _context.Reports.FindAsync(id);
        }

        public async Task AddReportAsync(Report report)
        {
            _context.Reports.Add(report);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateReportAsync(Report report)
        {
            _context.Entry(report).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteReportAsync(int id)
        {
            var report = await _context.Reports.FindAsync(id);
            if (report != null)
            {
                _context.Reports.Remove(report);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ReportExistsAsync(int id)
        {
            return await _context.Reports.AnyAsync(e => e.Id == id);
        }
    }
}
