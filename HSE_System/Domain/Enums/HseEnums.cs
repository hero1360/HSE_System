namespace HSE.Web.Domain.Enums
{
    public enum IncidentType { Injury = 1, NearMiss = 2, UnsafeCondition = 3, UnsafeAct = 4, Environmental = 5 }
    public enum IncidentSeverity { Low = 1, Medium = 2, High = 3, Critical = 4 }
    public enum IncidentStatus { Submitted = 1, UnderReview = 2, UnderInvestigation = 3, CAPAAssigned = 4, InProccess = 5, Closed = 6 }
    public enum ActionStatus { Pending = 1, InProgress = 2, Verified = 3, Overdue = 4 }
    public enum ActionPriority { Low = 1, Medium = 2, High = 3, Critical = 4 }
    public enum PermitType { HotWork = 1, ColdWork = 2, HeightWork = 3, ConfinedSpace = 4, Excavation = 5 }
    public enum PermitStatus { Draft = 1, PendingApproval = 2, Approved = 3, Closed = 4 }
    public enum WasteType { Hazardous = 1, NonHazardous = 2, Industrial = 3, Medical = 4, Recyclable = 5 }
    public enum DisposalMethod { Recycling = 1, Incineration = 2, Landfill = 3, SafeStorage = 4 }
}
