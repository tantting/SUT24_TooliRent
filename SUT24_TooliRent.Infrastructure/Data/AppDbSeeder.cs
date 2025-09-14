using SUT24_TooliRent.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using SUT24_TooliRent.Domain.Enum;

namespace SUT24_TooliRent.Infrastructure.Data;

public class AppDbSeeder
{
    public static void Seed(AppDbContext context, UserManager<IdentityUser> userManager)
    {
        context.Database.EnsureCreated();

        // --- Workshops ---
        if (!context.Workshops.Any())
        {
            context.Workshops.AddRange(
                new Workshop
                {
                    Name = "Träverkstad", Description = "Verktyg för träbearbetning", CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                },
                new Workshop
                {
                    Name = "Metallverkstad", Description = "Verktyg för metallbearbetning", CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                }
            );
            context.SaveChanges();
        }

        // --- Tools ---
        if (!context.Tools.Any())
        {
            context.Tools.AddRange(
                new Tool
                {
                    Name = "Hammare", Description = "Standard hammare för träarbete", IsAvailable = true,
                    WorkshopId = 1, Condition = ToolCondition.Good, DemandsCertification = false,
                    CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now
                },
                new Tool
                {
                    Name = "Cirkelsåg", Description = "Elektrisk såg för trä", IsAvailable = true, WorkshopId = 1,
                    Condition = ToolCondition.New, DemandsCertification = true, CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                },
                new Tool
                {
                    Name = "Svets", Description = "Bågsvets för metall", IsAvailable = true, WorkshopId = 2,
                    Condition = ToolCondition.Good, DemandsCertification = true, CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                }
            );
            context.SaveChanges();
        }

        // --- Members ---
        if (!context.Members.Any())
        {
            // Hämta IdentityUsers
            var adminUser = userManager.FindByEmailAsync("admin@tooli.se").Result;
            var memberEmail = "member@tooli.se";
            IdentityUser memberUser;
            if (userManager.FindByEmailAsync(memberEmail).Result == null)
            {
                memberUser = new IdentityUser { UserName = memberEmail, Email = memberEmail, EmailConfirmed = true };
                userManager.CreateAsync(memberUser, "Member123!").Wait();
                userManager.AddToRoleAsync(memberUser, "Member").Wait();
            }
            else
            {
                memberUser = userManager.FindByEmailAsync(memberEmail).Result;
            }

            context.Members.AddRange(
                new Member
                {
                    FirstName = "Bertil",
                    LastName = "Berg",
                    IdentityUserId = adminUser.Id,
                    MembershipStartDate = DateTime.Now.AddYears(-2),
                    IsActive = true,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                },
                new Member
                {
                    FirstName = "Anna",
                    LastName = "Andersson",
                    IdentityUserId = memberUser.Id,
                    MembershipStartDate = DateTime.Now.AddYears(-1),
                    IsActive = true,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                }
            );
            context.SaveChanges();
        }

        // --- Bookings ---
        if (!context.Bookings.Any())
        {
            context.Bookings.AddRange(
                new Booking
                {
                    MemberId = 1, ToolId = 1, StartDate = DateTime.Now.AddDays(-2), EndDate = DateTime.Now.AddDays(2),
                    Status = BookingStatus.CheckedOut, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now
                },
                new Booking
                {
                    MemberId = 2, ToolId = 2, StartDate = DateTime.Now.AddDays(1), EndDate = DateTime.Now.AddDays(3),
                    Status = BookingStatus.Reserved, CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now
                }
            );
            context.SaveChanges();
        }

        // --- Certifications ---
        if (!context.Certifications.Any())
        {
            context.Certifications.AddRange(
                new Certification
                {
                    MemberId = 2, ToolId = 2, CertificationDate = DateTime.Now.AddMonths(-3),
                    ExpirationDate = DateTime.Now.AddMonths(9), Type = CertificationType.General,
                    CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now
                }
            );
            context.SaveChanges();
        }
    }
}