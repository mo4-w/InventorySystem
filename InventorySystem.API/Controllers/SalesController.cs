using InventorySystem.Core;
using InventorySystem.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventorySystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SalesController : ControllerBase
{
    private readonly AppDbContext _context;

    public SalesController(AppDbContext context)
    {
        _context = context;
    }

    // تسجيل مبيعات ميدانية
    [HttpPost]
    public async Task<IActionResult> CreateSale([FromBody] Sale sale)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            sale.SaleDate = DateTime.UtcNow;
            _context.Sales.Add(sale);

            foreach (var detail in sale.Details)
            {
                var product = await _context.Products.FindAsync(detail.ProductId);
                if (product != null)
                {
                    // خصم الكمية المباعة من المخزون
                    product.StockQuantity -= detail.Quantity;
                    product.LastUpdated = DateTime.UtcNow;
                }
            }

            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
            return Ok(new { message = "تم تسجيل عملية البيع بنجاح" });
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            return BadRequest(new { message = "حدث خطأ أثناء تسجيل البيع", error = ex.Message });
        }
    }

    // كشف ديون الزبائن (المبيعات بالأجل)
    [HttpGet("debts")]
    public async Task<IActionResult> GetCreditSales()
    {
        var debts = await _context.Sales
            .Where(s => s.PaymentType == PaymentType.Credit)
            .Include(s => s.Details)
            .ThenInclude(d => d.Product)
            .OrderByDescending(s => s.SaleDate)
            .ToListAsync();

        return Ok(debts);
    }

    // مطابقة جرد نهاية اليوم (Van Stock Reconciliation)
    [HttpPost("audit")]
    public async Task<IActionResult> SaveInventoryAudit([FromBody] List<InventoryAudit> audits)
    {
        foreach (var audit in audits)
        {
            audit.AuditDate = DateTime.UtcNow;
            _context.InventoryAudits.Add(audit);
        }

        await _context.SaveChangesAsync();
        return Ok(new { message = "تم حفظ مطابقة الجرد اليومي بنجاح" });
    }
}