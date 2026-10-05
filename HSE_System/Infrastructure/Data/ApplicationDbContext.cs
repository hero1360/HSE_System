using Microsoft.EntityFrameworkCore;
using HSE.Web.Domain.Entities;

namespace HSE.Web.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Incident> Incidents { get; set; }
        public DbSet<IncidentInvestigation> IncidentInvestigations { get; set; }
        public DbSet<CorrectiveAction> CorrectiveActions { get; set; }
        public DbSet<WorkPermit> WorkPermits { get; set; }
        public DbSet<WasteLog> WasteLogs { get; set; }
    }
}
