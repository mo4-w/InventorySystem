using InventorySystem.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace InventorySystem.Core;

public static class DbInitializer
{
    public static async Task SeedAsync(AppDbContext context)
    {
        // 1. تطبيق المهاجرات تلقائياً إن لم تكن مطبقة
        //await context.Database.MigrateAsync();

        // 2. إدخال مستخدم الأدمن الافتراضي إذا كان جدول المستخدمين فارغاً
        if (!await context.Users.AnyAsync())
        {
            var adminUser = new User
            {
                FullName = "مدير النظام",
                Username = "admin",
                PasswordHash = "admin123", // سنقوم بتشفيرها لاحقاً عبر BCrypt
                Role = "Admin",
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };

            await context.Users.AddAsync(adminUser);
            await context.SaveChangesAsync();
        }

        // 3. إدخال القوائم الافتراضية إذا كان جدول القوائم فارغاً
        if (!await context.MenuItems.AnyAsync())
        {
            var parentMenu1 = new MenuItem { Title = "إدارة المخزون والتزويد", Icon = "Box", OrderIndex = 1 };
            var parentMenu2 = new MenuItem { Title = "المبيعات والتحصيل", Icon = "ShoppingCart", OrderIndex = 2 };
            var parentMenu3 = new MenuItem { Title = "الجرد والمطابقة", Icon = "ClipboardCheck", OrderIndex = 3 };
            var parentMenu4 = new MenuItem { Title = "المصروفات والأرباح", Icon = "DollarSign", OrderIndex = 4 };

            context.MenuItems.AddRange(parentMenu1, parentMenu2, parentMenu3, parentMenu4);
            await context.SaveChangesAsync();

            context.MenuItems.AddRange(
                new MenuItem { Title = "تعريف المنتجات والتصنيفات", RouteOrFormName = "ProductsForm", ParentId = parentMenu1.Id, OrderIndex = 1 },
                new MenuItem { Title = "تزويد / شراء بضاعة يومية", RouteOrFormName = "RestockForm", ParentId = parentMenu1.Id, OrderIndex = 2 },
                new MenuItem { Title = "شاشة البيع الميداني", RouteOrFormName = "SalesForm", ParentId = parentMenu2.Id, OrderIndex = 1 },
                new MenuItem { Title = "كشوفات مبيعات الأجل والديون", RouteOrFormName = "CreditSalesForm", ParentId = parentMenu2.Id, OrderIndex = 2 },
                new MenuItem { Title = "المقبوضات النقدية والتحصيل", RouteOrFormName = "CashSalesForm", ParentId = parentMenu2.Id, OrderIndex = 3 },
                new MenuItem { Title = "مطابقة جرد السيارة (End of Day)", RouteOrFormName = "VanAuditForm", ParentId = parentMenu3.Id, OrderIndex = 1 },
                new MenuItem { Title = "تسجيل المصروفات اليومية", RouteOrFormName = "ExpensesForm", ParentId = parentMenu4.Id, OrderIndex = 1 },
                new MenuItem { Title = "تقرير الأرباح اليومية الصافية", RouteOrFormName = "DailyProfitForm", ParentId = parentMenu4.Id, OrderIndex = 2 }
            );

            await context.SaveChangesAsync();
        }
    }
}