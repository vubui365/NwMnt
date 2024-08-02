using Microsoft.AspNetCore.Mvc;

using NwMnt.Models;

namespace NwMnt.Repositories
{
    public interface IAlertRepository
    {
        Task<List<Alert>> GetAllAlertsAsync();
        Task<Alert> GetAlertByIdAsync(int id);
        Task AddAlertAsync(Alert alert);
        Task UpdateAlertAsync(Alert alert);
        Task DeleteAlertAsync(int id);
        Task<bool> AlertExistsByIdAsync(int id);
        Task<Alert> GetAlertByNameAsync(string name);
        Task<bool> AlertExistsByNameAsync(string name);
    }
}

