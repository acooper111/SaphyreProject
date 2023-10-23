using SaphyreProject.Server.Models;
using SaphyreProject.Shared.Models;
using LogLevel = SaphyreProject.Shared.Models.LogLevel;

namespace SaphyreProject.Server.Services;

public interface ILogService
{
    public void Error(string message, string source);
    public void Warning(string message, string source);
    public void Info(string message, string source);
}

public class LogService : ILogService
{
    private LogRepository logRepository = new();
    public LogService(LogRepository logRepository)
    {
        this.logRepository = logRepository;
    }
    public void Error(string message, string source)
    {
        var log = CreateLog(LogLevel.Error, message, source);
        logRepository.SaveLog(log);
    }
    
    public void Warning(string message, string source)
    {
        var log = CreateLog(LogLevel.Warning, message, source);
        logRepository.SaveLog(log);
    }
    
    public void Info( string message, string source)
    {
        var log = CreateLog(LogLevel.Info, message, source);
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