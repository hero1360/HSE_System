using Microsoft.EntityFrameworkCore;
using HSE.Web.Domain.Entities;
using HSE.Web.Infrastructure.Data;

namespace HSE.Web.Services
{
    public interface IHseService
    {
        Task<List<Incident>> GetAllIncidentsAsync();
        Task<Incident?> GetIncidentByIdAsync(int id);
        Task<Incident> CreateIncidentAsync(Incident incident);
        Task AddInvestigationAsync(IncidentInvestigation inv);
        Task AddCorrectiveActionAsync(CorrectiveAction ca);
        Task<List<WorkPermit>> GetAllWorkPermitsAsync();
        Task<List<WasteLog>> GetAllWasteLogsAsync();
    }

    public class HseService : IHseService
    {
        private readonly ApplicationDbContext _db;
        public HseService(ApplicationDbContext db) { _db = db; }

        public async Task<List<Incident>> GetAllIncidentsAsync() => await _db.Incidents.Include(i => i.CorrectiveActions).ToListAsync();
        public async Task<Incident?> GetIncidentByIdAsync(int id) => await _db.Incidents.Include(i => i.Investigation).Include(i => i.CorrectiveActions).FirstOrDefaultAsync(i => i.Id == id);
        public async Task<Incident> CreateIncidentAsync(Incident incident)
        {
            incident.TrackingCode = $"INC-{DateTime.Now:yyyyMMdd}-{Guid.NewGuid().ToString()[..4].ToUpper()}";
            _db.Incidents.Add(incident);
            await _db.SaveChangesAsync();
            return incident;
        }
        public async Task AddInvestigationAsync(IncidentInvestigation inv)
        {
            _db.IncidentInvestigations.Add(inv);
            var inc = await _db.Incidents.FindAsync(inv.IncidentId);
            if (inc != null) inc.Status = Domain.Enums.IncidentStatus.UnderInvestigation;
            await _db.SaveChangesAsync();
        }
        public async Task AddCorrectiveActionAsync(CorrectiveAction ca)
        {
            _db.CorrectiveActions.Add(ca);
            var inc = await _db.Incidents.FindAsync(ca.IncidentId);
            if (inc != null) inc.Status = Domain.Enums.IncidentStatus.CAPAAssigned;
            await _db.SaveChangesAsync();
        }
        public async Task<List<WorkPermit>> GetAllWorkPermitsAsync() => await _db.WorkPermits.ToListAsync();
        public async Task<List<WasteLog>> GetAllWasteLogsAsync() => await _db.WasteLogs.ToListAsync();
    }
}
