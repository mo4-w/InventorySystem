using System.ComponentModel.DataAnnotations.Schema;

namespace InventorySystem.Core.Entities;

public class InventoryAudit
{
    public int Id { get; set; }
    public DateTime AuditDate { get; set; } = DateTime.UtcNow;
    public int ProductId { get; set; }
    public decimal SystemQuantity { get; set; }
    public decimal ActualQuantity { get; set; }

    [NotMapped]
    public decimal VarianceQuantity
    {
        get => ActualQuantity - SystemQuantity;
        private set { }
    }

    public decimal VarianceValue { get; set; }

    public Product? Product { get; set; }
}