using Microsoft.Identity.Client;

namespace SaphyreProject.Shared.Models;

public class Log
{
    public Guid LogId { get; set; } = Guid.NewGuid();
    public DateTime TimeStamp { get; set; }
    public string LogMessage { get; set; } = null!;
    public LogLevel LogLevel { get; set; }
    public string Source { get; set; } = null!;
}

public enum LogLevel
{
    Info = 0,
    Warning = 1,
    Error = 2
}