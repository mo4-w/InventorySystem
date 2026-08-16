using InventorySystem.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventorySystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MenusController : ControllerBase
{
    private readonly AppDbContext _context;

    public MenusController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetMenuItems()
    {
        try
        {
            var menus = await _context.MenuItems
                .Where(m => m.IsActive)
                .OrderBy(m => m.OrderIndex)
                .Select(m => new MenuItemDto
                {
                    Id = m.Id,
                    ParentId = m.ParentId,
                    Title = m.Title,
                    RouteOrFormName = m.RouteOrFormName,
                    OrderIndex = m.OrderIndex
                })
                .ToListAsync();

            return Ok(menus);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"خطأ في السيرفر: {ex.Message}");
        }
    }
}

public class MenuItemDto
{
    public int Id { get; set; }
    public int? ParentId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? RouteOrFormName { get; set; }
    public int OrderIndex { get; set; }
}