using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SUT24_TooliRent.Infrastructure.Auth;

public class AuthDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
{
    public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
    {
        
    }
}