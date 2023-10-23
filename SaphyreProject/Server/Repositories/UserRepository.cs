using Microsoft.EntityFrameworkCore;
using SaphyreProject.Shared.Models;

namespace SaphyreProject.Server.Models;


public partial class UserRepository : DbContext
{
    public UserRepository()
    {
    }
    public UserRepository(DbContextOptions<UserRepository> options)
        : base(options)
    {
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
                throw new ArgumentNullException();
            }
        }
        catch
        {
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
                throw new ArgumentNullException();
            }
        }
        catch
        {
            throw;
        }
    }
}
