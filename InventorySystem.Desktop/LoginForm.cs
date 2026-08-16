using InventorySystem.Core;
using Microsoft.EntityFrameworkCore;
using System.Windows.Forms;

namespace InventorySystem.Desktop;

public partial class LoginForm : Form
{
    private readonly AppDbContext _dbContext;

    public LoginForm(AppDbContext dbContext)
    {
        _dbContext = dbContext;
        InitializeComponent(); // استدعاء مكونات التصميم من Designer.cs
    }

    private async void BtnLogin_Click(object? sender, EventArgs e)
    {
        string username = txtUsername.Text.Trim();
        string password = txtPassword.Text.Trim();

        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            lblError.Text = "يرجى إدخال اسم المستخدم وكلمة المرور";
            return;
        }

        btnLogin.Enabled = false;
        lblError.Text = "جاري التحقق...";

        try
        {
            // استعلام حقيقي من قاعدة البيانات PostgreSQL
            var user = await _dbContext.Users
                .FirstOrDefaultAsync(u => u.Username == username && u.IsActive);

            if (user == null || user.PasswordHash != password)
            {
                lblError.Text = "اسم المستخدم أو كلمة المرور غير صحيحة";
                btnLogin.Enabled = true;
                return;
            }

            // تخزين بيانات المستخدم في الجلسة الحالية
            UserSession.UserId = user.Id;
            UserSession.FullName = user.FullName;
            UserSession.Username = user.Username;
            UserSession.Role = user.Role;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        catch (Exception ex)
        {
            lblError.Text = $"خطأ بالاتصال: {ex.Message}";
            btnLogin.Enabled = true;
        }
    }
}