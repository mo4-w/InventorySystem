// المصروفات ومطابقة الجرد
namespace InventorySystem.Core.Entities;

public class    Expense
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty; // مثل: وقود، صيانة، عمولة
    public decimal Amount { get; set; }
    public DateTime ExpenseDate { get; set; } = DateTime.UtcNow;
    public string? Notes { get; set; }
}