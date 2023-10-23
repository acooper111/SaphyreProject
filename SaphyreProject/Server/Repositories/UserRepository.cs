using Microsoft.EntityFrameworkCore;
using SaphyreProject.Server.Services;
using SaphyreProject.Shared.Models;
using LogLevel = SaphyreProject.Shared.Models.LogLevel;

namespace SaphyreProject.Server.Models;


public partial class UserRepository : DbContext
{
    private ILogService logService;
    public UserRepository(ILogService logService)
    {
        this.logService = logService;
    }
    public UserRepository(DbContextOptions<UserRepository> options, ILogService logService)
        : base(options)
    {
        this.logService = logService;
    }
    public virtual DbSet<User> Users { get; set; } = null!;
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("users");
            entity.Property(e => e.Userid).HasColumnName("Userid");
            entity.Property(e => e.Username)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
        });
        OnModelCreatingPartial(modelBuilder);
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    public List<User> GetUserDetails()
    {
        try
        {
            return this.Users.ToList();
        }
        catch
        {
            logService.SaveLog(LogLevel.Error, "Error getting User details", "UserRepository.cs");
            throw;
        }
    }

    public void AddUser(User user)
    {
        try
        {
            this.Users.Add(user);
            this.SaveChanges();
        }
        catch
        {
            logService.SaveLog(LogLevel.Error, "Error adding User", "UserRepository.cs");
            throw;
        }
    }

    public void UpdateUserDetails(User user)
    {
        try
        {
            this.Entry(user).State = EntityState.Modified;
            this.SaveChanges();
        }
        catch
        {
            logService.SaveLog(LogLevel.Error, "Error updating User detail", "UserRepository.cs");
            throw;
        }
    }

    public User GetUser(Guid id)
    {
        try
        {
            User? user = this.Users.Find(id);
            if (user != null)
            {
                return user;
            }
            else
            {
                logService.SaveLog(LogLevel.Error, "Could not find User in DB", "UserRepository.cs");
                throw new ArgumentNullException();
            }
        }
        catch
        {
            logService.SaveLog(LogLevel.Error, "Error getting User detail", "UserRepository.cs");
            throw;
        }
    }

    public void DeleteUser(Guid id)
    {
        try
        {
            User? user = this.Users.Find(id);
            if (user != null)
            {
                this.Users.Remove(user);
                this.SaveChanges();
            }
            else
            {
                logService.SaveLog(LogLevel.Error, "Could not find User in DB for deletion", "UserRepository.cs");
                throw new ArgumentNullException();
            }
        }
        catch
        {
            logService.SaveLog(LogLevel.Error, "Error getting User details for deletion", "UserRepository.cs");
            throw;
        }
    }
}
