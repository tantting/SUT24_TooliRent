using Microsoft.EntityFrameworkCore;
using SUT24_TooliRent.Domain.Entities;
    
namespace SUT24_TooliRent.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<DbContext> options) : base(options)
    {
    }

    public DbSet<Tool> Tools { get; set; }
    public DbSet<Member> Members { get; set; }
    public DbSet<Booking> Bookings { get; set; }    
    }