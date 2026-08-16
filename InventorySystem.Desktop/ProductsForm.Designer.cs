namespace InventorySystem.Desktop;

partial class ProductsForm
{
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.Panel pnlTop;
    private System.Windows.Forms.Panel pnlAddProduct;
    private System.Windows.Forms.Panel pnlSearch;
    private System.Windows.Forms.TextBox txtProductName;
    private System.Windows.Forms.Button btnAddProduct;
    private System.Windows.Forms.TextBox txtSearch;
    private System.Windows.Forms.Label lblSearch;
    private System.Windows.Forms.Label lblAddProduct;
    private System.Windows.Forms.DataGridView dgvProducts;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
        DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
        pnlTop = new Panel();
        pnlAddProduct = new Panel();
        lblAddProduct = new Label();
        txtProductName = new TextBox();
        btnAddProduct = new Button();
        pnlSearch = new Panel();
        lblSearch = new Label();
        txtSearch = new TextBox();
        dgvProducts = new DataGridView();
        pnlTop.SuspendLayout();
        pnlAddProduct.SuspendLayout();
        pnlSearch.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
        SuspendLayout();
        // 
        // pnlTop
        // 
        pnlTop.Controls.Add(pnlAddProduct);
        pnlTop.Controls.Add(pnlSearch);
        pnlTop.Dock = DockStyle.Top;
        pnlTop.Location = new Point(10, 9);
        pnlTop.Name = "pnlTop";
        pnlTop.Size = new Size(780, 106);
        pnlTop.TabIndex = 0;
        // 
        // pnlAddProduct
        // 
        pnlAddProduct.Controls.Add(lblAddProduct);
        pnlAddProduct.Controls.Add(txtProductName);
        pnlAddProduct.Controls.Add(btnAddProduct);
        pnlAddProduct.Dock = DockStyle.Top;
        pnlAddProduct.Location = new Point(0, 0);
        pnlAddProduct.Name = "pnlAddProduct";
        pnlAddProduct.Size = new Size(780, 53);
        pnlAddProduct.TabIndex = 0;
        // 
        // lblAddProduct
        // 
        lblAddProduct.AutoSize = true;
        lblAddProduct.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblAddProduct.Location = new Point(680, 18);
        lblAddProduct.Name = "lblAddProduct";
        lblAddProduct.Size = new Size(68, 15);
        lblAddProduct.TabIndex = 0;
        lblAddProduct.Text = "اسم الصنف:";
        // 
        // txtProductName
        // 
        txtProductName.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        txtProductName.Location = new Point(350, 15);
        txtProductName.Name = "txtProductName";
        txtProductName.Size = new Size(320, 23);
        txtProductName.TabIndex = 1;
        // 
        // btnAddProduct
        // 
        btnAddProduct.BackColor = Color.FromArgb(41, 128, 185);
        btnAddProduct.FlatStyle = FlatStyle.Flat;
        btnAddProduct.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnAddProduct.ForeColor = Color.White;
        btnAddProduct.Location = new Point(200, 13);
        btnAddProduct.Name = "btnAddProduct";
        btnAddProduct.Size = new Size(130, 26);
        btnAddProduct.TabIndex = 2;
        btnAddProduct.Text = "إضافة الصنف";
        btnAddProduct.UseVisualStyleBackColor = false;
        btnAddProduct.Click += btnAddProduct_Click;
        // 
        // pnlSearch
        // 
        pnlSearch.Controls.Add(lblSearch);
        pnlSearch.Controls.Add(txtSearch);
        pnlSearch.Dock = DockStyle.Bottom;
        pnlSearch.Location = new Point(0, 53);
        pnlSearch.Name = "pnlSearch";
        pnlSearch.Size = new Size(780, 53);
        pnlSearch.TabIndex = 1;
        // 
        // lblSearch
        // 
        lblSearch.AutoSize = true;
        lblSearch.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblSearch.Location = new Point(680, 18);
        lblSearch.Name = "lblSearch";
        lblSearch.Size = new Size(32, 15);
        lblSearch.TabIndex = 0;
        lblSearch.Text = "بحث:";
        // 
        // txtSearch
        // 
        txtSearch.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        txtSearch.Location = new Point(350, 15);
        txtSearch.Name = "txtSearch";
        txtSearch.Size = new Size(320, 23);
        txtSearch.TabIndex = 1;
        txtSearch.TextChanged += txtSearch_TextChanged;
        // 
        // dgvProducts
        // 
        dgvProducts.AllowUserToAddRows = false;
        dgvProducts.AllowUserToDeleteRows = false;
        dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle2.BackColor = SystemColors.Window;
        dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
        dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
        dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
        dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
        dgvProducts.DefaultCellStyle = dataGridViewCellStyle2;
        dgvProducts.Dock = DockStyle.Fill;
        dgvProducts.Location = new Point(10, 115);
        dgvProducts.MultiSelect = false;
        dgvProducts.Name = "dgvProducts";
        dgvProducts.ReadOnly = true;
        dgvProducts.RightToLeft = RightToLeft.Yes;
        dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvProducts.Size = new Size(780, 273);
        dgvProducts.TabIndex = 1;
        // 
        // ProductsForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 397);
        Controls.Add(dgvProducts);
        Controls.Add(pnlTop);
        Name = "ProductsForm";
        Padding = new Padding(10, 9, 10, 9);
        RightToLeft = RightToLeft.Yes;
        RightToLeftLayout = true;
        Text = "تعريف المنتجات والتصنيفات";
        Load += ProductsForm_Load;
        pnlTop.ResumeLayout(false);
        pnlAddProduct.ResumeLayout(false);
        pnlAddProduct.PerformLayout();
        pnlSearch.ResumeLayout(false);
        pnlSearch.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
        ResumeLayout(false);
    }

    #endregion
}