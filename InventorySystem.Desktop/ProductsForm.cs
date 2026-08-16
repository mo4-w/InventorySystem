using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventorySystem.Desktop;

public partial class ProductsForm : Form
{
    private readonly HttpClient _httpClient;

    // 1. استقبال الـ HttpClient حصراً بدلاً من AppDbContext
    public ProductsForm(HttpClient httpClient)
    {
        InitializeComponent();
        _httpClient = httpClient ?? new HttpClient { BaseAddress = new Uri("https://localhost:7191/") };
    }

    // Constructor افتراضي للـ Designer
    public ProductsForm() : this(new HttpClient { BaseAddress = new Uri("https://localhost:7191/") })
    {
    }
    
    private async void ProductsForm_Load(object sender, EventArgs e)
    {
        await LoadProductsAsync();
    }

    // جلب الاصناف وتصفيتها عبر الـ API
    private async Task LoadProductsAsync(string? filter = null)
    {
        try
        {
            string requestUri = string.IsNullOrWhiteSpace(filter)
                ? "api/products"
                : $"api/products?search={Uri.EscapeDataString(filter)}";

            var products = await _httpClient.GetFromJsonAsync<List<ProductResponseDto>>(requestUri);

            if (products != null)
            {
                var displayList = products.Select(p => new
                {
                    p.Id,
                    اسم_الصنف = p.Name,
                    الكمية_المتاحة_بالمخزون = p.StockQuantity,
                    //سعر_التكلفة_الأخير = p.PurchasePrice,
                    آخر_تحديث = p.LastUpdated.ToString("yyyy-MM-dd HH:mm")
                }).ToList();

                dgvProducts.DataSource = displayList;

                if (dgvProducts.Columns["Id"] != null)
                    dgvProducts.Columns["Id"].Visible = false;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"خطأ أثناء جلب المنتجات من الـ API: {ex.Message}", "خطأ اتصالات", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    // إضافة صنف جديد عن طريق إرسال POST Request للـ API
    private async void btnAddProduct_Click(object sender, EventArgs e)
    {
        string name = txtProductName.Text.Trim();

        if (string.IsNullOrWhiteSpace(name))
        {
            MessageBox.Show("يرجى إدخال اسم الصنف أولاً.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            var newProduct = new
            {
                Name = name,
                StockQuantity = 0,
                PurchasePrice = 0,
                SalePrice = 0
            };

            var response = await _httpClient.PostAsJsonAsync("api/products", newProduct);

            if (response.IsSuccessStatusCode)
            {
                txtProductName.Clear();
                MessageBox.Show("تم إضافة الصنف بنجاح عبر الـ API!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadProductsAsync();
            }
            else
            {
                string errorMsg = await response.Content.ReadAsStringAsync();
                MessageBox.Show($"فشل إضافة الصنف: {errorMsg}", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"حدث خطأ أثناء التواصل مع الـ API: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async void txtSearch_TextChanged(object sender, EventArgs e)
    {
        await LoadProductsAsync(txtSearch.Text);
    }
}

// الـ DTO المخصص لاستقبال بيانات الاصناف من الـ API
public class ProductResponseDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int StockQuantity { get; set; }
    public decimal PurchasePrice { get; set; }
    public decimal SalePrice { get; set; }
    public DateTime LastUpdated { get; set; }
}






/*using InventorySystem.Core;
using InventorySystem.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventorySystem.Desktop;

public partial class ProductsForm : Form
{
    private readonly AppDbContext _dbContext;

    public ProductsForm(AppDbContext dbContext)
    {
        InitializeComponent();
        _dbContext = dbContext;
    }

    private async void ProductsForm_Load(object sender, EventArgs e)
    {
        await LoadProductsAsync();
    }

    private async Task LoadProductsAsync(string? filter = null)
    {
        var query = _dbContext.Products.AsNoTracking();

        if (!string.IsNullOrWhiteSpace(filter))
        {
            query = query.Where(p => p.Name.Contains(filter));
        }

        var products = await query
            .OrderBy(p => p.Name)
            .Select(p => new
            {
                p.Id,
                اسم_الصنف = p.Name,
                الكمية_المتاحة_بالمخزون = p.StockQuantity,
                سعر_التكلفة_الأخير = p.PurchasePrice,
                آخر_تحديث = p.LastUpdated.ToString("yyyy-MM-dd HH:mm")
            })
            .ToListAsync();

        dgvProducts.DataSource = products;

        if (dgvProducts.Columns["Id"] != null)
            dgvProducts.Columns["Id"].Visible = false;
    }

    private async void btnAddProduct_Click(object sender, EventArgs e)
    {
        string name = txtProductName.Text.Trim();

        if (string.IsNullOrWhiteSpace(name))
        {
            MessageBox.Show("يرجى إدخال اسم الصنف أولاً.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        // التأكد من عدم تكرار الصنف
        bool exists = await _dbContext.Products.AnyAsync(p => p.Name.ToLower() == name.ToLower());
        if (exists)
        {
            MessageBox.Show("هذا الصنف مضاف مسبقاً في النظام.", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        // إضافة الصنف بكمية صفرية
        var product = new Product
        {
            Name = name,
            StockQuantity = 0,
            PurchasePrice = 0,
            SalePrice = 0,
            LastUpdated = DateTime.UtcNow
        };

        _dbContext.Products.Add(product);
        await _dbContext.SaveChangesAsync();

        txtProductName.Clear();
        MessageBox.Show("تم إضافة الصنف بنجاح كمادة جديدة في النظام!", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
        await LoadProductsAsync();
    }

    private async void txtSearch_TextChanged(object sender, EventArgs e)
    {
        await LoadProductsAsync(txtSearch.Text);
    }
}*/