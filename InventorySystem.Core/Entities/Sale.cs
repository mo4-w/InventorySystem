using System.ComponentModel.DataAnnotations.Schema;

namespace InventorySystem.Core.Entities;

public enum PaymentType
{
    Cash = 1,
    Credit = 2
}

public class Sale
{
    public int Id { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public DateTime SaleDate { get; set; } = DateTime.UtcNow;
    public PaymentType PaymentType { get; set; }
    public decimal TotalAmount { get; set; }
    public bool IsDebtSettlement { get; set; } = false;
    public string? Notes { get; set; }

    public ICollection<SaleDetail> Details { get; set; } = new List<SaleDetail>();
}

public class SaleDetail
{
    public int Id { get; set; }
    public int SaleId { get; set; }
    public int ProductId { get; set; }
    public decimal Quantity { get; set; }
    public decimal UnitPrice { get; set; }

    [NotMapped]
    public decimal TotalPrice
    {
        get => Quantity * UnitPrice;
        private set { }
    }

    public Sale? Sale { get; set; }
    public Product? Product { get; set; }
}