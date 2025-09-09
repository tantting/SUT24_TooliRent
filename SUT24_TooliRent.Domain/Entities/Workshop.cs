namespace SUT24_TooliRent.Domain.Entities;

public class Workshop
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    // Navigation properties
    public ICollection<Tool> Tools { get; set; } = new List<Tool>();

    // Auditering
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
}