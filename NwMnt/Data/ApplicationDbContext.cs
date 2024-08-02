using Microsoft.EntityFrameworkCore;
using NwMnt.Models;
using System.Collections.Generic;

namespace NwMnt.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Report> Reports { get; set; }
        public DbSet<Alert> Alerts { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        public DbSet<Device> Devices { get; set; }
        public DbSet<Sensor> Sensors { get; set; }
        public DbSet<Measurement> Measurements
        {
            get;
            set;
        }

        internal async Task SaveChangesAsync()
        {
            await base.SaveChangesAsync();
        }

        internal object Entry(Device device)
        {
            return base.Entry(device);
        }
    }
}
