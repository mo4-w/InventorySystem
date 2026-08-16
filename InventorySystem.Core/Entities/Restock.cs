using System;
using System.Collections.Generic;

namespace InventorySystem.Core.Entities;

public class RestockHeader
{
    public int Id { get; set; }
    public string? SupplierName { get; set; }
    public DateTime RestockDate { get; set; } = DateTime.Now;
    public decimal TotalAmount { get; set; }

    public ICollection<RestockDetail> Details { get; set; } = new List<RestockDetail>();
}


public class RestockDetail
{
    public int Id { get; set; }

    public int RestockHeaderId { get; set; }
    public RestockHeader? RestockHeader { get; set; }

    public int ProductId { get; set; }
    public Product? Product { get; set; }

    // تغيير النوع إلى decimal أو int حسب استخدامك في الشاشة
    // إذا كانت الكمية تحتوي كسورًا اجعلها decimal، وإلا فاجعلها int
    public int Quantity { get; set; }

    // توحيد اسم الخاصية إلى PurchasePrice كما تحتاجه الشاشات والـ Controller
    public decimal PurchasePrice { get; set; }
}


/*public class RestockDetail
{
    public int Id { get; set; }
    public int RestockHeaderId { get; set; }
    public RestockHeader? RestockHeader { get; set; }

    public int ProductId { get; set; }
    public decimal Quantity { get; set; }
    public decimal PurchasePrice { get; set; }

    public decimal TotalPrice => Quantity * PurchasePrice;

    public Product? Product { get; set; }
}*/




/*namespace InventorySystem.Desktop;

public class RestockHeader
{
    public int Id { get; set; }
    public string? SupplierName { get; set; }
    public DateTime RestockDate { get; set; } = DateTime.Now;
    public decimal TotalAmount { get; set; }

    // تعديل list إلى List بحرف L كبير
    public List<RestockDetail> Details { get; set; } = new();
}

public class RestockDetail
{
    public int Id { get; set; }
    public int RestockHeaderId { get; set; }
    public RestockHeader? RestockHeader { get; set; }

    public int ProductId { get; set; }
    public decimal Quantity { get; set; }
    public decimal PurchasePrice { get; set; }

    // إضافة الخاصية المحسوبة كي لا يظهر عليها خطأ في AppDbContext
    public decimal TotalPrice => Quantity * PurchasePrice;
}*/