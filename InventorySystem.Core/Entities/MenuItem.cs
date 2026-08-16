//القوائم
namespace InventorySystem.Core.Entities;

public class MenuItem
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Icon { get; set; } = string.Empty;
    public string? RouteOrFormName { get; set; }
    public int? ParentId { get; set; }
    public bool IsActive { get; set; } = true;
    public int OrderIndex { get; set; }

    // العلاقات الشجرية (Parent / Children)
    public MenuItem? Parent { get; set; }
    public ICollection<MenuItem> Children { get; set; } = new List<MenuItem>();
}