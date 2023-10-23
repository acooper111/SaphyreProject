using SaphyreProject.Server.Models;
using SaphyreProject.Shared.Models;
using LogLevel = SaphyreProject.Shared.Models.LogLevel;

namespace SaphyreProject.Server.Services;

public interface ILogService
{
    public void SaveLog(LogLevel level, string message, string source);
}

public class LogService : ILogService
{
    private LogRepository logRepository = new();
    public LogService(LogRepository logRepository)
    {
        this.logRepository = logRepository;
    }
    public void SaveLog(LogLevel level, string message, string source)
    {
        var log = CreateLog(level, message, source);
        logRepository.SaveLog(log);
    }

    private Log CreateLog(LogLevel level, string message, string source)
    {
        Log log = new Log();
        log.LogLevel = level;
        log.LogMessage = message;
        log.Source = source;
        log.TimeStamp = DateTime.Now;

        return log;
    }
}