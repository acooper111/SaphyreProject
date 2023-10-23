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
}
