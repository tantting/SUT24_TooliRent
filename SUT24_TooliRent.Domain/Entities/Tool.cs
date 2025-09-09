using SUT24_TooliRent.Domain.Enum;

namespace SUT24_TooliRent.Domain.Entities;

public class Tool
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsAvailable { get; set; }
    public int WorkshopId { get; set; }
    public bool DemandsCertification { get; set; }
    public ToolCondition Condition { get; set; }

    // Navigation properties
    public Workshop Workshop { get; set; }
    public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    public ICollection<Certification> Certifications { get; set; } = new List<Certification>();

    // Auditering
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
}