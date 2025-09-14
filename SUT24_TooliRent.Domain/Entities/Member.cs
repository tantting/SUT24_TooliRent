using Microsoft.AspNetCore.Identity;

namespace SUT24_TooliRent.Domain.Entities;

public class Member
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public DateTime DateOfBirth { get; set; }
    public DateTime MembershipStartDate { get; set; }
    public DateTime? MembershipEndDate { get; set; }
    public bool IsActive { get; set; }
    public string PasswordHash { get; set; }
    public string PasswordSalt { get; set; }
    public string Role { get; set; } 
    
    public string IdentityUserId { get; set; }   // FK till IdentityUser

    // Navigation properties
    public IdentityUser IdentityUser { get; set; } 
    public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    public ICollection<Certification> Certifications { get; set; } = new List<Certification>();

    // Auditering
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
}