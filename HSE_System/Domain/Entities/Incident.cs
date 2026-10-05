using HSE.Web.Domain.Enums;

namespace HSE.Web.Domain.Entities
{
    public class Incident
    {
        public int Id { get; set; }
        public string TrackingCode { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public DateTime IncidentDate { get; set; } = DateTime.Now;
        public IncidentType Type { get; set; }
        public IncidentSeverity Severity { get; set; }
        public IncidentStatus Status { get; set; } = IncidentStatus.Submitted;
        public string Description { get; set; } = string.Empty;
        public string ReportedByUserName { get; set; } = "اپراتور سامانه";
        public int LostWorkDays { get; set; } = 0;
        public IncidentInvestigation? Investigation { get; set; }
        public ICollection<CorrectiveAction> CorrectiveActions { get; set; } = new List<CorrectiveAction>();
    }

    public class IncidentInvestigation
    {
        public int Id { get; set; }
        public int IncidentId { get; set; }
        public Incident Incident { get; set; } = null!;
        public string DirectCause { get; set; } = string.Empty;
        public string RootCause { get; set; } = string.Empty;
        public string MethodUsed { get; set; } = "5Whys";
        public string? Why1 { get; set; }
        public string? Why2 { get; set; }
        public string? Why3 { get; set; }
    }

    public class CorrectiveAction
    {
        public int Id { get; set; }
        public int IncidentId { get; set; }
        public Incident Incident { get; set; } = null!;
        public string Title { get; set; } = string.Empty;
        public string AssignedToUserName { get; set; } = string.Empty;
        public DateTime TargetDate { get; set; }
        public ActionPriority Priority { get; set; }
        public ActionStatus Status { get; set; } = ActionStatus.Pending;
    }

    public class WorkPermit
    {
        public int Id { get; set; }
        public string PermitNumber { get; set; } = string.Empty;
        public PermitType Type { get; set; }
        public PermitStatus Status { get; set; } = PermitStatus.Draft;
        public string Location { get; set; } = string.Empty;
        public string WorkDescription { get; set; } = string.Empty;
        public DateTime ValidFrom { get; set; } = DateTime.Now;
        public DateTime ValidTo { get; set; } = DateTime.Now.AddDays(1);
    }

    public class WasteLog
    {
        public int Id { get; set; }
        public string WasteName { get; set; } = string.Empty;
        public WasteType Type { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; } = "Kg";
        public string SourceLocation { get; set; } = string.Empty;
        public DateTime GenerationDate { get; set; } = DateTime.Now;
        public DisposalMethod DisposalMethod { get; set; }
    }
}
