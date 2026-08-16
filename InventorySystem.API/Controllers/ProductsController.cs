using InventorySystem.Core;
using InventorySystem.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventorySystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly AppDbContext _context;

    public ProductsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
    {
        return await _context.Products.ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Product>> CreateProduct(Product product)
    {
        product.LastUpdated = DateTime.UtcNow;
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetProducts), new { id = product.Id }, product);
    }


    // شراء وتزويد بضاعة يومية (دمج الكميات وتحديث سعر الشراء)
    [HttpPost("restock")]
    public async Task<IActionResult> RestockProducts([FromBody] RestockHeader restock)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            restock.RestockDate = DateTime.UtcNow;
            _context.RestockHeaders.Add(restock); // تعديل Restocks إلى RestockHeaders

            foreach (var detail in restock.Details)
            {
                var product = await _context.Products.FindAsync(detail.ProductId);
                if (product != null)
                {
                    // تجميع الكمية فوق الكمية المتبقية وتحديث سعر التكلفة الأخير
                    product.StockQuantity += detail.Quantity;
                    product.PurchasePrice = detail.PurchasePrice; // تعديل UnitPurchasePrice إلى PurchasePrice
                    product.LastUpdated = DateTime.UtcNow;
                }
            }

            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
            return Ok(new { message = "تم تزويد البضاعة وتحديث المخزون بنجاح" });
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            return BadRequest(new { message = "حدث خطأ أثناء عملية التزويد", error = ex.Message });
        }
    }



    // شراء وتزويد بضاعة يومية (دمج الكميات وتحديث سعر الشراء)
    /*[HttpPost("restock")]
    public async Task<IActionResult> RestockProducts([FromBody] Restock restock)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            restock.RestockDate = DateTime.UtcNow;
            _context.Restocks.Add(restock);

            foreach (var detail in restock.Details)
            {
                var product = await _context.Products.FindAsync(detail.ProductId);
                if (product != null)
                {
                    // تجميع الكمية فوق الكمية المتبقية وتحديث سعر التكلفة الأخير
                    product.StockQuantity += detail.Quantity;
                    product.PurchasePrice = detail.UnitPurchasePrice;
                    product.LastUpdated = DateTime.UtcNow;
                }
            }

            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
            return Ok(new { message = "تم تزويد البضاعة وتحديث المخزون بنجاح" });
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            return BadRequest(new { message = "حدث خطأ أثناء عملية التزويد", error = ex.Message });
        }
    }*/
}