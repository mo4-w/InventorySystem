// المنتجات
using System;
using System.Collections.Generic;

namespace InventorySystem.Core.Entities;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public decimal PurchasePrice { get; set; }
    public decimal SalePrice { get; set; }
    public decimal StockQuantity { get; set; }
    public DateTime LastUpdated { get; set; } = DateTime.UtcNow;

    public ICollection<SaleDetail> SaleDetails { get; set; } = new List<SaleDetail>();
    public ICollection<RestockDetail> RestockDetails { get; set; } = new List<RestockDetail>();
}



/*using InventorySystem.Desktop;
using System;
using System.Collections.Generic;

namespace InventorySystem.Core.Entities;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public decimal PurchasePrice { get; set; } // سعر الشراء الحالي/الأخير
    public decimal SalePrice { get; set; }     // سعر البيع المقترح
    public decimal StockQuantity { get; set; } // الكمية الحالية المتوفرة
    public DateTime LastUpdated { get; set; } = DateTime.UtcNow;

    public ICollection<SaleDetail> SaleDetails { get; set; } = new List<SaleDetail>();
    public ICollection<RestockDetail> RestockDetails { get; set; } = new List<RestockDetail>();
}*/