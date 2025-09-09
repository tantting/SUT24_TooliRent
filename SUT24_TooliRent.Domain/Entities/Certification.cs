using SUT24_TooliRent.Domain.Enum;

namespace SUT24_TooliRent.Domain.Entities;

public class Certification
{
    public int Id { get; set; }
    public int ToolId { get; set; }
    public int MemberId { get; set; } 
    public DateTime CertificationDate { get; set; }
    public DateTime ExpirationDate { get; set; }
    public CertificationType Type { get; set; }

    // Navigation properties
    public Tool Tool { get; set; }
    public Member Member { get; set; }

    // Auditering
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
}