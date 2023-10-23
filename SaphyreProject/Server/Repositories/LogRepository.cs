using Microsoft.EntityFrameworkCore;
using SaphyreProject.Shared.Models;

namespace SaphyreProject.Server.Models;

public class LogRepository : DbContext
{
    public LogRepository()
    {
    }
    public LogRepository(DbContextOptions<LogRepository> options)
        : base(options)
    {
    }

    public virtual DbSet<Log> Logs { get; set; } = null!;
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Log>(entity =>
        {
            entity.ToTable("Logs");
            entity.Property(e => e.LogId)
                .IsUnicode(false);
            entity.Property(e => e.LogLevel)
                .IsUnicode(false);
            entity.Property(e => e.LogMessage)
                .IsUnicode(false);
            entity.Property(e => e.Source)
                .IsUnicode(false);
            entity.Property(e => e.TimeStamp).HasColumnName("LogTimestamp")
                .IsUnicode(false);
        });
    }
    public void SaveLog(Log log)
    {
        try
        {
            this.Logs.Add(log);
            this.SaveChanges();
        }
        catch
        {
            throw;
        }
    }
}