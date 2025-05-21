using RiskPlatform.Shared.Domain;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Reflection.Metadata;
using System;

namespace RiskPlatform.Modules.Bots.Domain.Entities;
//RunFileId(bigint, PK)
//RunId(FK → BotRun)
//Role(nvarchar) ⟶ “Input”, “Output”, “Log”
//StoragePath(nvarchar) (Blob URL, SAS, etc.)
//FileName(nvarchar)
//FileType(nvarchar)
//SizeBytes(bigint)
//CreatedAt(datetime)

public class BotRunFile : EntityBase<int>
{
    public int BotRunId { get; set; }
    public BotRun BotRun { get; set; } = default!;
    public string FileName { get; set; }
    public string Url { get; set; } = default!;
}
