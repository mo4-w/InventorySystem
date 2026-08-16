using InventorySystem.Core.Entities;
using System;
using System.Windows.Forms;

namespace InventorySystem.Desktop;

public partial class ProductEditDialog : Form
{
    public Product Product { get; private set; }

    public ProductEditDialog(Product? product = null)
    {
        InitializeComponent();
        Product = product ?? new Product();
    }

    private void ProductEditDialog_Load(object sender, EventArgs e)
    {
        // كود معالجة التعديل في حال الحاجه له مستقبلاً
    }
}