using NwMnt.Models;

namespace NwMnt.Repositories
{
    public interface IReportRepository
    {
        List<Report> GetAllReports();
        Task<Report> GetReportByIdAsync(int id);
        Task AddReportAsync(Report report);
        Task UpdateReportAsync(Report report);
        Task DeleteReportAsync(int id);
        Task<bool> ReportExistsAsync(int id);
    }
}
