using InventorySystem.Core;
using InventorySystem.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventorySystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RestockController : ControllerBase
{
    private readonly AppDbContext _context;

    public RestockController(AppDbContext context)
    {
        _context = context;
    }

    // 1. جلب سجل الفواتير
    [HttpGet]
    public async Task<IActionResult> GetRestockHeaders()
    {
        try
        {
            var headers = await _context.RestockHeaders
                .OrderByDescending(h => h.RestockDate)
                .Select(h => new RestockHeaderDto
                {
                    Id = h.Id,
                    SupplierName = h.SupplierName ?? "غير محدد",
                    TotalAmount = h.TotalAmount,
                    RestockDate = h.RestockDate
                })
                .ToListAsync();

            return Ok(headers);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"خطأ سيرفر عند جلب السجل: {ex.Message}");
        }
    }

    // 2. جلب تفاصيل فاتورة معينة
    [HttpGet("{id}")]
    public async Task<IActionResult> GetRestockDetails(int id)
    {
        try
        {
            var details = await _context.RestockDetails
                .Include(d => d.Product)
                .Where(d => d.RestockHeaderId == id)
                .Select(d => new RestockDetailDto
                {
                    ProductId = d.ProductId,
                    ProductName = d.Product != null ? d.Product.Name : string.Empty,
                    Quantity = d.Quantity,
                    PurchasePrice = d.PurchasePrice
                })
                .ToListAsync();

            return Ok(details);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"خطأ سيرفر عند جلب التفاصيل: {ex.Message}");
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateRestock([FromBody] CreateRestockDto dto)
    {
        if (dto == null || dto.Items == null || !dto.Items.Any())
            return BadRequest("بيانات الفاتورة فارغة");

        using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            decimal total = dto.Items.Sum(x => x.Quantity * x.PurchasePrice);

            var header = new RestockHeader
            {
                SupplierName = string.IsNullOrWhiteSpace(dto.SupplierName) ? "غير محدد" : dto.SupplierName,
                TotalAmount = total,
                RestockDate = DateTime.UtcNow
            };

            _context.RestockHeaders.Add(header);
            await _context.SaveChangesAsync(); // حفظ رأس الفاتورة للحصول على Id

            foreach (var item in dto.Items)
            {
                var detail = new RestockDetail
                {
                    RestockHeaderId = header.Id,
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    PurchasePrice = item.PurchasePrice
                };
                _context.RestockDetails.Add(detail);

                // تحديث كمية المخزون في جدول المنتجات
                var product = await _context.Products.FindAsync(item.ProductId);
                if (product != null)
                {
                    // تحويل صريح للكمية لتتوافق مع decimal
                    product.StockQuantity += (decimal)item.Quantity;
                    product.LastUpdated = DateTime.UtcNow;
                }
            }

            await _context.SaveChangesAsync();
            await transaction.CommitAsync();

            return Ok(new { Message = "تم حفظ الفاتورة وتحديث المخزون بنجاح", HeaderId = header.Id });
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();

            // إرجاع تفاصيل الخطأ الداخلي الدقيقة لسهولة التتبع
            var innerError = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            return StatusCode(500, $"حدث خطأ أثناء الحفظ: {innerError}");
        }
    }

    // 4. حذف فاتورة وتسوية الكميات
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRestock(int id)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            var header = await _context.RestockHeaders
                .Include(h => h.Details)
                .FirstOrDefaultAsync(h => h.Id == id);

            if (header == null)
                return NotFound("الفاتورة غير موجودة");

            foreach (var detail in header.Details)
            {
                var product = await _context.Products.FindAsync(detail.ProductId);
                if (product != null)
                {
                    product.StockQuantity -= (decimal)detail.Quantity;
                }
            }

            _context.RestockHeaders.Remove(header);
            await _context.SaveChangesAsync();
            await transaction.CommitAsync();

            return Ok(new { Message = "تم حذف الفاتورة وتعديل المخزون بنجاح" });
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            var innerError = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            return StatusCode(500, $"حدث خطأ أثناء الحذف: {innerError}");
        }
    }
}

// الـ DTOs المعيارية
public class RestockHeaderDto
{
    public int Id { get; set; }
    public string SupplierName { get; set; } = string.Empty;
    public decimal TotalAmount { get; set; }
    public DateTime RestockDate { get; set; }
}

public class RestockDetailDto
{
    public int ProductId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal PurchasePrice { get; set; }
}

public class CreateRestockDto
{
    public string SupplierName { get; set; } = string.Empty;
    public List<RestockDetailDto> Items { get; set; } = new();
}