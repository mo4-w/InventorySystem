using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventorySystem.Desktop;

public partial class MainForm : Form
{
    private readonly HttpClient _httpClient;

    // إنشاء HttpClient يدعم HTTPS ويتجاهل فحص SSL التطويري
    private static HttpClient CreateHttpsClient()
    {
        var handler = new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
        };

        return new HttpClient(handler)
        {
            BaseAddress = new Uri("https://localhost:7191/")
        };
    }

    public MainForm(HttpClient httpClient)
    {
        InitializeComponent();
        _httpClient = httpClient ?? CreateHttpsClient();
        Load += MainForm_Load;
    }

    public MainForm() : this(CreateHttpsClient())
    {
    }

    private async void MainForm_Load(object? sender, EventArgs e)
    {
        lblUser.Text = $"المستخدم: {UserSession.FullName} ({UserSession.Role})";
        await LoadNavigationMenuAsync();
    }

    private async Task LoadNavigationMenuAsync()
    {
        try
        {
            tvMenu.Nodes.Clear();
            var menuItems = await _httpClient.GetFromJsonAsync<List<MenuItemDto>>("api/menus");

            if (menuItems != null)
            {
                foreach (var item in menuItems.Where(m => m.ParentId == null))
                {
                    var parentNode = new TreeNode(item.Title) { Tag = item.RouteOrFormName };

                    var children = menuItems.Where(c => c.ParentId == item.Id).OrderBy(c => c.OrderIndex);
                    foreach (var child in children)
                    {
                        var childNode = new TreeNode(child.Title) { Tag = child.RouteOrFormName };
                        parentNode.Nodes.Add(childNode);
                    }

                    tvMenu.Nodes.Add(parentNode);
                }

                tvMenu.ExpandAll();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"خطأ أثناء تحميل قائمة الملاحة عبر HTTPS: {ex.Message}", "خطأ اتصالات", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void TvMenu_AfterSelect(object sender, TreeViewEventArgs e)
    {
        if (e.Node?.Tag is string formName && !string.IsNullOrEmpty(formName))
        {
            OpenChildForm(formName);
        }
    }

    private void OpenChildForm(string formName)
    {
        pnlContent.Controls.Clear();

        Form? childForm = formName switch
        {
            "ProductsForm" => new ProductsForm(_httpClient),
            "RestockForm" => new RestockForm(_httpClient),
            _ => null
        };

        if (childForm != null)
        {
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(childForm);
            pnlContent.Tag = childForm;
            childForm.Show();
            lblTitle.Text = $"📌 {childForm.Text}";
        }
    }

    private void pnlSidebar_Paint(object sender, PaintEventArgs e) { }
}

public class MenuItemDto
{
    public int Id { get; set; }
    public int? ParentId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? RouteOrFormName { get; set; }
    public int OrderIndex { get; set; }
}






/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventorySystem.Desktop;

public partial class MainForm : Form
{
    private readonly HttpClient _httpClient;

    // 1. استقبال الـ HttpClient بدلاً من AppDbContext
    public MainForm(HttpClient httpClient)
    {
        InitializeComponent();
        _httpClient = httpClient ?? new HttpClient { BaseAddress = new Uri("https://localhost:7191/") };
        Load += MainForm_Load;
    }

    // Constructor افتراضي للـ Visual Studio Designer
    public MainForm() : this(new HttpClient { BaseAddress = new Uri("https://localhost:7191/") })
    {
    }

    private async void MainForm_Load(object? sender, EventArgs e)
    {
        // عرض اسم المستخدم الحالي
        lblUser.Text = $"المستخدم: {UserSession.FullName} ({UserSession.Role})";

        // تحميل القائمة الجانبية من الـ API
        await LoadNavigationMenuAsync();
    }

    private async Task LoadNavigationMenuAsync()
    {
        try
        {
            tvMenu.Nodes.Clear();

            // جلب القوائم من الـ API بدلاً من قاعدة البيانات المباشرة
            var menuItems = await _httpClient.GetFromJsonAsync<List<MenuItemDto>>("api/menu");

            if (menuItems != null)
            {
                foreach (var item in menuItems.Where(m => m.ParentId == null))
                {
                    var parentNode = new TreeNode(item.Title) { Tag = item.RouteOrFormName };

                    var children = menuItems.Where(c => c.ParentId == item.Id).OrderBy(c => c.OrderIndex);
                    foreach (var child in children)
                    {
                        var childNode = new TreeNode(child.Title) { Tag = child.RouteOrFormName };
                        parentNode.Nodes.Add(childNode);
                    }

                    tvMenu.Nodes.Add(parentNode);
                }

                tvMenu.ExpandAll();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"خطأ أثناء تحميل قائمة الملاحة من الـ API: {ex.Message}", "خطأ اتصالات", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    // حدث النقر على عناصر القائمة الجانبية
    private void TvMenu_AfterSelect(object sender, TreeViewEventArgs e)
    {
        if (e.Node?.Tag is string formName && !string.IsNullOrEmpty(formName))
        {
            OpenChildForm(formName);
        }
    }

    // فتح الواجهة الفرعية داخل اللوحة الرئيسية pnlContent
    private void OpenChildForm(string formName)
    {
        pnlContent.Controls.Clear();

        // تمرير الـ _httpClient حصراً لجميع الواجهات الفرعية
        Form? childForm = formName switch
        {
            "ProductsForm" => new ProductsForm(_httpClient),
            "RestockForm" => new RestockForm(_httpClient),
            _ => null
        };

        if (childForm != null)
        {
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(childForm);
            pnlContent.Tag = childForm;
            childForm.Show();
            lblTitle.Text = $"📌 {childForm.Text}";
        }
    }

    private void pnlSidebar_Paint(object sender, PaintEventArgs e) { }
}

// DTO الخاص بنقل بيانات القوائم عبر الـ API
public class MenuItemDto
{
    public int Id { get; set; }
    public int? ParentId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? RouteOrFormName { get; set; }
    public int OrderIndex { get; set; }
}*/