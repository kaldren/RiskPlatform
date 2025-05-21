using RiskPlatform.Shared.Domain;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System;
using RiskPlatform.Modules.Bots.Domain.ValueObjects;

namespace RiskPlatform.Modules.Bots.Domain.Entities;

//RunId(bigint, PK)
//BotId(FK → Bot)
//SubmittedBy(nvarchar) ⟶ e-mail / UPN
//SubmittedAt(datetime)
//Status(nvarchar) ⟶ “Pending”, “Running”, “Success”, “Fail”
//StartedAt, FinishedAt(datetime)
//ErrorMessage(nvarchar)

public class BotRun : EntityBase<int>
{
    public int BotId { get; set; }
    public Bot Bot { get; set; } = default!;
    public BotRunStatus Status { get; set; } = default!; // "running", "completed", "failed"
    // Start time in UTC
    public DateTime StartedAt { get; set; } = default!;
    // Finish time in UTC
    public DateTime EndedAt { get; set; } = default!;
}
