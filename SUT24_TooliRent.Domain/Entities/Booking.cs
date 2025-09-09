using SUT24_TooliRent.Domain.Enum;

namespace SUT24_TooliRent.Domain.Entities;

public class Booking
{
    public int Id { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int MemberId { get; set; }
    public int ToolId { get; set; }
    public BookingStatus Status { get; set; }

    // Navigation properties
    public Member Member { get; set; }
    public Tool Tool { get; set; }

    // Auditering
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
}