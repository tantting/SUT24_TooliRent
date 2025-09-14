using Microsoft.EntityFrameworkCore;
using SUT24_TooliRent.Domain.Entities;
    
namespace SUT24_TooliRent.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<DbContext> options) : base(options)
    {
    }

    public DbSet<Workshop> Workshops { get; set; }
    public DbSet<Tool> Tools { get; set; }
    public DbSet<Member> Members { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<Certification> Certifications { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    base.OnModelCreating(modelBuilder);

    // ==========================
    // Tool entity
    // ==========================
    modelBuilder.Entity<Tool>(entity =>
    {
        entity.HasKey(t => t.Id); 
        entity.Property(t => t.Name).IsRequired().HasMaxLength(100);
        entity.Property(t => t.Description).HasMaxLength(500);
        entity.HasIndex(t => t.Name);

        // Explicit delete behavior för Workshop → Tool
        entity.HasOne(t => t.Workshop)
              .WithMany(w => w.Tools)
              .HasForeignKey(t => t.WorkshopId)
              .OnDelete(DeleteBehavior.Restrict);

        // Auditering - tracks when  data is created or changed.
        entity.Property(t => t.CreatedDate).HasDefaultValueSql("GETDATE()");
        entity.Property(t => t.UpdatedDate).HasDefaultValueSql("GETDATE()");
    });

    // ==========================
    // Member entity
    // ==========================
    modelBuilder.Entity<Member>(entity =>
    {
        entity.HasKey(m => m.Id);
        entity.Property(m => m.FirstName).IsRequired().HasMaxLength(50);
        entity.Property(m => m.LastName).IsRequired().HasMaxLength(50);
        entity.Property(m => m.Email).IsRequired().HasMaxLength(100);
        entity.HasIndex(m => m.Email).IsUnique();

        // Auditering
        entity.Property(m => m.CreatedDate).HasDefaultValueSql("GETDATE()");
        entity.Property(m => m.UpdatedDate).HasDefaultValueSql("GETDATE()");
    });

    // ==========================
    // Booking entity
    // ==========================
    modelBuilder.Entity<Booking>(entity =>
    {
        entity.HasKey(b => b.Id);
        entity.Property(b => b.StartDate).IsRequired();
        entity.Property(b => b.EndDate).IsRequired();
        entity.Property(b => b.Status).IsRequired();

        // Explicit delete behavior
        entity.HasOne(b => b.Member)
              .WithMany(m => m.Bookings)
              .HasForeignKey(b => b.MemberId)
              .OnDelete(DeleteBehavior.Restrict);

        entity.HasOne(b => b.Tool)
              .WithMany(t => t.Bookings)
              .HasForeignKey(b => b.ToolId)
              .OnDelete(DeleteBehavior.Restrict);

        // Auditering
        entity.Property(b => b.CreatedDate).HasDefaultValueSql("GETDATE()");
        entity.Property(b => b.UpdatedDate).HasDefaultValueSql("GETDATE()");
    });

    // ==========================
    // Certification entity
    // ==========================
    modelBuilder.Entity<Certification>(entity =>
    {
        entity.HasKey(c => c.Id);
        entity.Property(c => c.CertificationDate).IsRequired();
        entity.Property(c => c.ExpirationDate).IsRequired();
        entity.Property(c => c.Type).IsRequired();

        // Explicit delete behavior
        entity.HasOne(c => c.Member)
              .WithMany(m => m.Certifications)
              .HasForeignKey(c => c.MemberId)
              .OnDelete(DeleteBehavior.Cascade);

        entity.HasOne(c => c.Tool)
              .WithMany(t => t.Certifications)
              .HasForeignKey(c => c.ToolId)
              .OnDelete(DeleteBehavior.Cascade);

        // Auditering
        entity.Property(c => c.CreatedDate).HasDefaultValueSql("GETDATE()");
        entity.Property(c => c.UpdatedDate).HasDefaultValueSql("GETDATE()");
    });

    // ==========================
    // Workshop entity
    // ==========================
    modelBuilder.Entity<Workshop>(entity =>
    {
        entity.HasKey(w => w.Id);
        entity.Property(w => w.Name).IsRequired().HasMaxLength(100);
        entity.Property(w => w.Description).HasMaxLength(500);

        // Auditering
        entity.Property(w => w.CreatedDate).HasDefaultValueSql("GETDATE()");
        entity.Property(w => w.UpdatedDate).HasDefaultValueSql("GETDATE()");
    });
    
        // Seed data
        SeedData(modelBuilder); 
    }

    private void SeedData(ModelBuilder modelBuilder)
    {
        throw new NotImplementedException();
    }
}