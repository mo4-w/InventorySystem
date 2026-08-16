namespace InventorySystem.Desktop;

partial class RestockForm
{
    private System.ComponentModel.IContainer components = null;

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
        DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
        DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
        pnlTop = new Panel();
        lblTitle = new Label();
        pnlSupplier = new Panel();
        lblSupplier = new Label();
        txtSupplier = new TextBox();
        pnlInput = new Panel();
        lblProduct = new Label();
        cmbProducts = new ComboBox();
        lblQty = new Label();
        numQuantity = new NumericUpDown();
        lblCost = new Label();
        numPurchasePrice = new NumericUpDown();
        lblSalePrice = new Label();
        numSalePrice = new NumericUpDown();
        btnAddToCart = new Button();
        pnlCartContainer = new Panel();
        dgvCart = new DataGridView();
        pnlHistoryContainer = new Panel();
        dgvHistory = new DataGridView();
        pnlBottom = new Panel();
        lblTotal = new Label();
        lblTotalAmount = new Label();
        btnSave = new Button();
        btnPrint = new Button();
        btnDeleteRestock = new Button();
        pnlTop.SuspendLayout();
        pnlSupplier.SuspendLayout();
        pnlInput.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)numQuantity).BeginInit();
        ((System.ComponentModel.ISupportInitialize)numPurchasePrice).BeginInit();
        ((System.ComponentModel.ISupportInitialize)numSalePrice).BeginInit();
        pnlCartContainer.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvCart).BeginInit();
        pnlHistoryContainer.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvHistory).BeginInit();
        pnlBottom.SuspendLayout();
        SuspendLayout();
        // 
        // pnlTop
        // 
        pnlTop.BackColor = Color.FromArgb(15, 23, 42);
        pnlTop.Controls.Add(lblTitle);
        pnlTop.Dock = DockStyle.Top;
        pnlTop.Location = new Point(0, 0);
        pnlTop.Name = "pnlTop";
        pnlTop.Size = new Size(1000, 45);
        pnlTop.TabIndex = 0;
        // 
        // lblTitle
        // 
        lblTitle.Dock = DockStyle.Fill;
        lblTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        lblTitle.ForeColor = Color.White;
        lblTitle.Location = new Point(0, 0);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(1000, 45);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "📦 شراء وتزويد بضاعة يومية للمخزون (Restock)";
        lblTitle.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // pnlSupplier
        // 
        pnlSupplier.Controls.Add(lblSupplier);
        pnlSupplier.Controls.Add(txtSupplier);
        pnlSupplier.Dock = DockStyle.Top;
        pnlSupplier.Location = new Point(0, 45);
        pnlSupplier.Name = "pnlSupplier";
        pnlSupplier.Padding = new Padding(10, 5, 10, 5);
        pnlSupplier.Size = new Size(1000, 40);
        pnlSupplier.TabIndex = 1;
        // 
        // lblSupplier
        // 
        lblSupplier.AutoSize = true;
        lblSupplier.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblSupplier.Location = new Point(830, 10);
        lblSupplier.Name = "lblSupplier";
        lblSupplier.Size = new Size(133, 15);
        lblSupplier.TabIndex = 0;
        lblSupplier.Text = "المورد / المصدر (اختياري):";
        // 
        // txtSupplier
        // 
        txtSupplier.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        txtSupplier.Location = new Point(570, 7);
        txtSupplier.Name = "txtSupplier";
        txtSupplier.Size = new Size(250, 23);
        txtSupplier.TabIndex = 1;
        // 
        // pnlInput
        // 
        pnlInput.Controls.Add(lblProduct);
        pnlInput.Controls.Add(cmbProducts);
        pnlInput.Controls.Add(lblQty);
        pnlInput.Controls.Add(numQuantity);
        pnlInput.Controls.Add(lblCost);
        pnlInput.Controls.Add(numPurchasePrice);
        pnlInput.Controls.Add(lblSalePrice);
        pnlInput.Controls.Add(numSalePrice);
        pnlInput.Controls.Add(btnAddToCart);
        pnlInput.Dock = DockStyle.Top;
        pnlInput.Location = new Point(0, 85);
        pnlInput.Name = "pnlInput";
        pnlInput.Padding = new Padding(10);
        pnlInput.Size = new Size(1000, 65);
        pnlInput.TabIndex = 2;
        // 
        // lblProduct
        // 
        lblProduct.AutoSize = true;
        lblProduct.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblProduct.Location = new Point(930, 10);
        lblProduct.Name = "lblProduct";
        lblProduct.Size = new Size(45, 15);
        lblProduct.TabIndex = 0;
        lblProduct.Text = "الصنف:";
        // 
        // cmbProducts
        // 
        cmbProducts.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbProducts.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        cmbProducts.Location = new Point(760, 28);
        cmbProducts.Name = "cmbProducts";
        cmbProducts.Size = new Size(215, 23);
        cmbProducts.TabIndex = 1;
        // 
        // lblQty
        // 
        lblQty.AutoSize = true;
        lblQty.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblQty.Location = new Point(650, 10);
        lblQty.Name = "lblQty";
        lblQty.Size = new Size(84, 15);
        lblQty.TabIndex = 2;
        lblQty.Text = "الكمية المشتراه:";
        // 
        // numQuantity
        // 
        numQuantity.DecimalPlaces = 2;
        numQuantity.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        numQuantity.Location = new Point(650, 28);
        numQuantity.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
        numQuantity.Name = "numQuantity";
        numQuantity.Size = new Size(90, 23);
        numQuantity.TabIndex = 3;
        numQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
        // 
        // lblCost
        // 
        lblCost.AutoSize = true;
        lblCost.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblCost.Location = new Point(520, 10);
        lblCost.Name = "lblCost";
        lblCost.Size = new Size(104, 15);
        lblCost.TabIndex = 4;
        lblCost.Text = "سعر الشراء (إجباري):";
        // 
        // numPurchasePrice
        // 
        numPurchasePrice.DecimalPlaces = 2;
        numPurchasePrice.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        numPurchasePrice.Location = new Point(520, 28);
        numPurchasePrice.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
        numPurchasePrice.Name = "numPurchasePrice";
        numPurchasePrice.Size = new Size(110, 23);
        numPurchasePrice.TabIndex = 5;
        // 
        // lblSalePrice
        // 
        lblSalePrice.AutoSize = true;
        lblSalePrice.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblSalePrice.Location = new Point(390, 10);
        lblSalePrice.Name = "lblSalePrice";
        lblSalePrice.Size = new Size(102, 15);
        lblSalePrice.TabIndex = 6;
        lblSalePrice.Text = "سعر البيع (اختياري):";
        // 
        // numSalePrice
        // 
        numSalePrice.DecimalPlaces = 2;
        numSalePrice.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        numSalePrice.Location = new Point(390, 28);
        numSalePrice.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
        numSalePrice.Name = "numSalePrice";
        numSalePrice.Size = new Size(110, 23);
        numSalePrice.TabIndex = 7;
        // 
        // btnAddToCart
        // 
        btnAddToCart.BackColor = Color.FromArgb(37, 99, 235);
        btnAddToCart.FlatStyle = FlatStyle.Flat;
        btnAddToCart.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnAddToCart.ForeColor = Color.White;
        btnAddToCart.Location = new Point(230, 25);
        btnAddToCart.Name = "btnAddToCart";
        btnAddToCart.Size = new Size(130, 28);
        btnAddToCart.TabIndex = 8;
        btnAddToCart.Text = "إضافة للسلة ➕";
        btnAddToCart.UseVisualStyleBackColor = false;
        btnAddToCart.Click += btnAddToCart_Click;
        // 
        // pnlCartContainer
        // 
        pnlCartContainer.Controls.Add(dgvCart);
        pnlCartContainer.Dock = DockStyle.Top;
        pnlCartContainer.Location = new Point(0, 150);
        pnlCartContainer.Name = "pnlCartContainer";
        pnlCartContainer.Padding = new Padding(10);
        pnlCartContainer.Size = new Size(1000, 150);
        pnlCartContainer.TabIndex = 3;
        // 
        // dgvCart
        // 
        dgvCart.AllowUserToAddRows = false;
        dgvCart.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvCart.BackgroundColor = Color.White;
        dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle1.BackColor = SystemColors.Window;
        dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
        dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
        dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
        dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
        dgvCart.DefaultCellStyle = dataGridViewCellStyle1;
        dgvCart.Dock = DockStyle.Fill;
        dgvCart.Location = new Point(10, 10);
        dgvCart.Name = "dgvCart";
        dgvCart.ReadOnly = true;
        dgvCart.Size = new Size(980, 130);
        dgvCart.TabIndex = 0;
        // 
        // pnlHistoryContainer
        // 
        pnlHistoryContainer.Controls.Add(dgvHistory);
        pnlHistoryContainer.Dock = DockStyle.Fill;
        pnlHistoryContainer.Location = new Point(0, 300);
        pnlHistoryContainer.Name = "pnlHistoryContainer";
        pnlHistoryContainer.Padding = new Padding(10, 0, 10, 10);
        pnlHistoryContainer.Size = new Size(1000, 200);
        pnlHistoryContainer.TabIndex = 4;
        // 
        // dgvHistory
        // 
        dgvHistory.AllowUserToAddRows = false;
        dgvHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvHistory.BackgroundColor = Color.White;
        dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle2.BackColor = SystemColors.Window;
        dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
        dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
        dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
        dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
        dgvHistory.DefaultCellStyle = dataGridViewCellStyle2;
        dgvHistory.Dock = DockStyle.Fill;
        dgvHistory.Location = new Point(10, 0);
        dgvHistory.Name = "dgvHistory";
        dgvHistory.ReadOnly = true;
        dgvHistory.Size = new Size(980, 190);
        dgvHistory.TabIndex = 0;
        dgvHistory.CellDoubleClick += dgvHistory_CellDoubleClick;
        // 
        // pnlBottom
        // 
        pnlBottom.BackColor = Color.FromArgb(241, 245, 249);
        pnlBottom.Controls.Add(lblTotal);
        pnlBottom.Controls.Add(lblTotalAmount);
        pnlBottom.Controls.Add(btnSave);
        pnlBottom.Controls.Add(btnPrint);
        pnlBottom.Controls.Add(btnDeleteRestock);
        pnlBottom.Dock = DockStyle.Bottom;
        pnlBottom.Location = new Point(0, 500);
        pnlBottom.Name = "pnlBottom";
        pnlBottom.Size = new Size(1000, 55);
        pnlBottom.TabIndex = 5;
        // 
        // lblTotal
        // 
        lblTotal.AutoSize = true;
        lblTotal.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        lblTotal.Location = new Point(800, 15);
        lblTotal.Name = "lblTotal";
        lblTotal.Size = new Size(146, 20);
        lblTotal.TabIndex = 0;
        lblTotal.Text = "إجمالي التزويد الحالي:";
        // 
        // lblTotalAmount
        // 
        lblTotalAmount.AutoSize = true;
        lblTotalAmount.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        lblTotalAmount.ForeColor = Color.FromArgb(220, 38, 38);
        lblTotalAmount.Location = new Point(660, 13);
        lblTotalAmount.Name = "lblTotalAmount";
        lblTotalAmount.Size = new Size(73, 21);
        lblTotalAmount.TabIndex = 1;
        lblTotalAmount.Text = "0.00 ريال";
        // 
        // btnSave
        // 
        btnSave.BackColor = Color.FromArgb(16, 185, 129);
        btnSave.FlatStyle = FlatStyle.Flat;
        btnSave.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        btnSave.ForeColor = Color.White;
        btnSave.Location = new Point(10, 8);
        btnSave.Name = "btnSave";
        btnSave.Size = new Size(210, 38);
        btnSave.TabIndex = 2;
        btnSave.Text = "حفظ وتوريد للمخزون 💾";
        btnSave.UseVisualStyleBackColor = false;
        btnSave.Click += btnSaveRestock_Click;
        // 
        // btnPrint
        // 
        btnPrint.BackColor = Color.FromArgb(71, 85, 105);
        btnPrint.FlatStyle = FlatStyle.Flat;
        btnPrint.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        btnPrint.ForeColor = Color.White;
        btnPrint.Location = new Point(230, 8);
        btnPrint.Name = "btnPrint";
        btnPrint.Size = new Size(130, 38);
        btnPrint.TabIndex = 4;
        btnPrint.Text = "طباعة / PDF 🖨️";
        btnPrint.UseVisualStyleBackColor = false;
        btnPrint.Click += btnPrintInvoice_Click;
        // 
        // btnDeleteRestock
        // 
        btnDeleteRestock.BackColor = Color.FromArgb(239, 68, 68);
        btnDeleteRestock.FlatStyle = FlatStyle.Flat;
        btnDeleteRestock.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        btnDeleteRestock.ForeColor = Color.White;
        btnDeleteRestock.Location = new Point(370, 8);
        btnDeleteRestock.Name = "btnDeleteRestock";
        btnDeleteRestock.Size = new Size(160, 38);
        btnDeleteRestock.TabIndex = 3;
        btnDeleteRestock.Text = "حذف الفاتورة 🗑️";
        btnDeleteRestock.UseVisualStyleBackColor = false;
        btnDeleteRestock.Click += btnDeleteRestock_Click;
        // 
        // RestockForm
        // 
        ClientSize = new Size(1000, 555);
        Controls.Add(pnlHistoryContainer);
        Controls.Add(pnlCartContainer);
        Controls.Add(pnlInput);
        Controls.Add(pnlSupplier);
        Controls.Add(pnlTop);
        Controls.Add(pnlBottom);
        Name = "RestockForm";
        RightToLeft = RightToLeft.Yes;
        RightToLeftLayout = true;
        Text = "تزويد المشتريات والمخزون";
        Load += RestockForm_Load;
        pnlTop.ResumeLayout(false);
        pnlSupplier.ResumeLayout(false);
        pnlSupplier.PerformLayout();
        pnlInput.ResumeLayout(false);
        pnlInput.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)numQuantity).EndInit();
        ((System.ComponentModel.ISupportInitialize)numPurchasePrice).EndInit();
        ((System.ComponentModel.ISupportInitialize)numSalePrice).EndInit();
        pnlCartContainer.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvCart).EndInit();
        pnlHistoryContainer.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvHistory).EndInit();
        pnlBottom.ResumeLayout(false);
        pnlBottom.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private System.Windows.Forms.Panel pnlTop;
    private System.Windows.Forms.Label lblTitle;
    private System.Windows.Forms.Panel pnlSupplier;
    private System.Windows.Forms.Label lblSupplier;
    private System.Windows.Forms.TextBox txtSupplier;
    private System.Windows.Forms.Panel pnlInput;
    private System.Windows.Forms.Label lblProduct;
    private System.Windows.Forms.ComboBox cmbProducts;
    private System.Windows.Forms.Label lblQty;
    private System.Windows.Forms.NumericUpDown numQuantity;
    private System.Windows.Forms.Label lblCost;
    private System.Windows.Forms.NumericUpDown numPurchasePrice;
    private System.Windows.Forms.Label lblSalePrice;
    private System.Windows.Forms.NumericUpDown numSalePrice;
    private System.Windows.Forms.Button btnAddToCart;
    private System.Windows.Forms.Panel pnlCartContainer;
    private System.Windows.Forms.DataGridView dgvCart;
    private System.Windows.Forms.Panel pnlHistoryContainer;
    private System.Windows.Forms.DataGridView dgvHistory;
    private System.Windows.Forms.Panel pnlBottom;
    private System.Windows.Forms.Label lblTotal;
    private System.Windows.Forms.Label lblTotalAmount;
    private System.Windows.Forms.Button btnSave;
    private System.Windows.Forms.Button btnPrint;
    private System.Windows.Forms.Button btnDeleteRestock;
}







/*namespace InventorySystem.Desktop;

partial class RestockForm
{
    private System.ComponentModel.IContainer components = null;

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
        DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
        DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
        pnlTop = new Panel();
        lblTitle = new Label();
        pnlSupplier = new Panel();
        lblSupplier = new Label();
        txtSupplier = new TextBox();
        pnlInput = new Panel();
        lblProduct = new Label();
        cmbProducts = new ComboBox();
        lblQty = new Label();
        numQuantity = new NumericUpDown();
        lblCost = new Label();
        numPurchasePrice = new NumericUpDown();
        lblSalePrice = new Label();
        numSalePrice = new NumericUpDown();
        btnAddToCart = new Button();
        pnlCartContainer = new Panel();
        dgvCart = new DataGridView();
        pnlHistoryContainer = new Panel();
        dgvHistory = new DataGridView();
        pnlBottom = new Panel();
        lblTotal = new Label();
        lblTotalAmount = new Label();
        btnSave = new Button();
        btnDeleteRestock = new Button();
        pnlTop.SuspendLayout();
        pnlSupplier.SuspendLayout();
        pnlInput.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)numQuantity).BeginInit();
        ((System.ComponentModel.ISupportInitialize)numPurchasePrice).BeginInit();
        ((System.ComponentModel.ISupportInitialize)numSalePrice).BeginInit();
        pnlCartContainer.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvCart).BeginInit();
        pnlHistoryContainer.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvHistory).BeginInit();
        pnlBottom.SuspendLayout();
        SuspendLayout();
        // 
        // pnlTop
        // 
        pnlTop.BackColor = Color.FromArgb(15, 23, 42);
        pnlTop.Controls.Add(lblTitle);
        pnlTop.Dock = DockStyle.Top;
        pnlTop.Location = new Point(0, 0);
        pnlTop.Name = "pnlTop";
        pnlTop.Size = new Size(1000, 45);
        pnlTop.TabIndex = 0;
        // 
        // lblTitle
        // 
        lblTitle.Dock = DockStyle.Fill;
        lblTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        lblTitle.ForeColor = Color.White;
        lblTitle.Location = new Point(0, 0);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(1000, 45);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "📦 شراء وتزويد بضاعة يومية للمخزون (Restock)";
        lblTitle.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // pnlSupplier
        // 
        pnlSupplier.Controls.Add(lblSupplier);
        pnlSupplier.Controls.Add(txtSupplier);
        pnlSupplier.Dock = DockStyle.Top;
        pnlSupplier.Location = new Point(0, 45);
        pnlSupplier.Name = "pnlSupplier";
        pnlSupplier.Padding = new Padding(10, 5, 10, 5);
        pnlSupplier.Size = new Size(1000, 40);
        pnlSupplier.TabIndex = 1;
        // 
        // lblSupplier
        // 
        lblSupplier.AutoSize = true;
        lblSupplier.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblSupplier.Location = new Point(830, 10);
        lblSupplier.Name = "lblSupplier";
        lblSupplier.Size = new Size(133, 15);
        lblSupplier.TabIndex = 0;
        lblSupplier.Text = "المورد / المصدر (اختياري):";
        // 
        // txtSupplier
        // 
        txtSupplier.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        txtSupplier.Location = new Point(570, 7);
        txtSupplier.Name = "txtSupplier";
        txtSupplier.Size = new Size(250, 23);
        txtSupplier.TabIndex = 1;
        // 
        // pnlInput
        // 
        pnlInput.Controls.Add(lblProduct);
        pnlInput.Controls.Add(cmbProducts);
        pnlInput.Controls.Add(lblQty);
        pnlInput.Controls.Add(numQuantity);
        pnlInput.Controls.Add(lblCost);
        pnlInput.Controls.Add(numPurchasePrice);
        pnlInput.Controls.Add(lblSalePrice);
        pnlInput.Controls.Add(numSalePrice);
        pnlInput.Controls.Add(btnAddToCart);
        pnlInput.Dock = DockStyle.Top;
        pnlInput.Location = new Point(0, 85);
        pnlInput.Name = "pnlInput";
        pnlInput.Padding = new Padding(10);
        pnlInput.Size = new Size(1000, 65);
        pnlInput.TabIndex = 2;
        // 
        // lblProduct
        // 
        lblProduct.AutoSize = true;
        lblProduct.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblProduct.Location = new Point(930, 10);
        lblProduct.Name = "lblProduct";
        lblProduct.Size = new Size(45, 15);
        lblProduct.TabIndex = 0;
        lblProduct.Text = "الصنف:";
        // 
        // cmbProducts
        // 
        cmbProducts.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbProducts.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        cmbProducts.Location = new Point(760, 28);
        cmbProducts.Name = "cmbProducts";
        cmbProducts.Size = new Size(215, 23);
        cmbProducts.TabIndex = 1;
        // 
        // lblQty
        // 
        lblQty.AutoSize = true;
        lblQty.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblQty.Location = new Point(650, 10);
        lblQty.Name = "lblQty";
        lblQty.Size = new Size(84, 15);
        lblQty.TabIndex = 2;
        lblQty.Text = "الكمية المشتراه:";
        // 
        // numQuantity
        // 
        numQuantity.DecimalPlaces = 2;
        numQuantity.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        numQuantity.Location = new Point(650, 28);
        numQuantity.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
        numQuantity.Name = "numQuantity";
        numQuantity.Size = new Size(90, 23);
        numQuantity.TabIndex = 3;
        numQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
        // 
        // lblCost
        // 
        lblCost.AutoSize = true;
        lblCost.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblCost.Location = new Point(520, 10);
        lblCost.Name = "lblCost";
        lblCost.Size = new Size(104, 15);
        lblCost.TabIndex = 4;
        lblCost.Text = "سعر الشراء (إجباري):";
        // 
        // numPurchasePrice
        // 
        numPurchasePrice.DecimalPlaces = 2;
        numPurchasePrice.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        numPurchasePrice.Location = new Point(520, 28);
        numPurchasePrice.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
        numPurchasePrice.Name = "numPurchasePrice";
        numPurchasePrice.Size = new Size(110, 23);
        numPurchasePrice.TabIndex = 5;
        // 
        // lblSalePrice
        // 
        lblSalePrice.AutoSize = true;
        lblSalePrice.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblSalePrice.Location = new Point(390, 10);
        lblSalePrice.Name = "lblSalePrice";
        lblSalePrice.Size = new Size(102, 15);
        lblSalePrice.TabIndex = 6;
        lblSalePrice.Text = "سعر البيع (اختياري):";
        // 
        // numSalePrice
        // 
        numSalePrice.DecimalPlaces = 2;
        numSalePrice.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        numSalePrice.Location = new Point(390, 28);
        numSalePrice.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
        numSalePrice.Name = "numSalePrice";
        numSalePrice.Size = new Size(110, 23);
        numSalePrice.TabIndex = 7;
        // 
        // btnAddToCart
        // 
        btnAddToCart.BackColor = Color.FromArgb(37, 99, 235);
        btnAddToCart.FlatStyle = FlatStyle.Flat;
        btnAddToCart.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnAddToCart.ForeColor = Color.White;
        btnAddToCart.Location = new Point(230, 25);
        btnAddToCart.Name = "btnAddToCart";
        btnAddToCart.Size = new Size(130, 28);
        btnAddToCart.TabIndex = 8;
        btnAddToCart.Text = "إضافة للسلة ➕";
        btnAddToCart.UseVisualStyleBackColor = false;
        btnAddToCart.Click += btnAddToCart_Click;
        // 
        // pnlCartContainer
        // 
        pnlCartContainer.Controls.Add(dgvCart);
        pnlCartContainer.Dock = DockStyle.Top;
        pnlCartContainer.Location = new Point(0, 150);
        pnlCartContainer.Name = "pnlCartContainer";
        pnlCartContainer.Padding = new Padding(10);
        pnlCartContainer.Size = new Size(1000, 150);
        pnlCartContainer.TabIndex = 3;
        // 
        // dgvCart
        // 
        dgvCart.AllowUserToAddRows = false;
        dgvCart.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvCart.BackgroundColor = Color.White;
        dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle1.BackColor = SystemColors.Window;
        dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
        dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
        dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
        dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
        dgvCart.DefaultCellStyle = dataGridViewCellStyle1;
        dgvCart.Dock = DockStyle.Fill;
        dgvCart.Location = new Point(10, 10);
        dgvCart.Name = "dgvCart";
        dgvCart.ReadOnly = true;
        dgvCart.Size = new Size(980, 130);
        dgvCart.TabIndex = 0;
        // 
        // pnlHistoryContainer
        // 
        pnlHistoryContainer.Controls.Add(dgvHistory);
        pnlHistoryContainer.Dock = DockStyle.Fill;
        pnlHistoryContainer.Location = new Point(0, 300);
        pnlHistoryContainer.Name = "pnlHistoryContainer";
        pnlHistoryContainer.Padding = new Padding(10, 0, 10, 10);
        pnlHistoryContainer.Size = new Size(1000, 200);
        pnlHistoryContainer.TabIndex = 4;
        // 
        // dgvHistory
        // 
        dgvHistory.AllowUserToAddRows = false;
        dgvHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvHistory.BackgroundColor = Color.White;
        dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle2.BackColor = SystemColors.Window;
        dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
        dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
        dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
        dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
        dgvHistory.DefaultCellStyle = dataGridViewCellStyle2;
        dgvHistory.Dock = DockStyle.Fill;
        dgvHistory.Location = new Point(10, 0);
        dgvHistory.Name = "dgvHistory";
        dgvHistory.ReadOnly = true;
        dgvHistory.Size = new Size(980, 190);
        dgvHistory.TabIndex = 0;
        dgvHistory.CellDoubleClick += dgvHistory_CellDoubleClick;
        // 
        // pnlBottom
        // 
        pnlBottom.BackColor = Color.FromArgb(241, 245, 249);
        pnlBottom.Controls.Add(lblTotal);
        pnlBottom.Controls.Add(lblTotalAmount);
        pnlBottom.Controls.Add(btnSave);
        pnlBottom.Controls.Add(btnDeleteRestock);
        pnlBottom.Dock = DockStyle.Bottom;
        pnlBottom.Location = new Point(0, 500);
        pnlBottom.Name = "pnlBottom";
        pnlBottom.Size = new Size(1000, 55);
        pnlBottom.TabIndex = 5;
        // 
        // lblTotal
        // 
        lblTotal.AutoSize = true;
        lblTotal.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        lblTotal.Location = new Point(800, 15);
        lblTotal.Name = "lblTotal";
        lblTotal.Size = new Size(146, 20);
        lblTotal.TabIndex = 0;
        lblTotal.Text = "إجمالي التزويد الحالي:";
        // 
        // lblTotalAmount
        // 
        lblTotalAmount.AutoSize = true;
        lblTotalAmount.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        lblTotalAmount.ForeColor = Color.FromArgb(220, 38, 38);
        lblTotalAmount.Location = new Point(660, 13);
        lblTotalAmount.Name = "lblTotalAmount";
        lblTotalAmount.Size = new Size(73, 21);
        lblTotalAmount.TabIndex = 1;
        lblTotalAmount.Text = "0.00 ريال";
        // 
        // btnSave
        // 
        btnSave.BackColor = Color.FromArgb(16, 185, 129);
        btnSave.FlatStyle = FlatStyle.Flat;
        btnSave.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        btnSave.ForeColor = Color.White;
        btnSave.Location = new Point(10, 8);
        btnSave.Name = "btnSave";
        btnSave.Size = new Size(230, 38);
        btnSave.TabIndex = 2;
        btnSave.Text = "حفظ وتوريد البضاعة للمخزون 💾";
        btnSave.UseVisualStyleBackColor = false;
        btnSave.Click += btnSaveRestock_Click;
        // 
        // btnDeleteRestock
        // 
        btnDeleteRestock.BackColor = Color.FromArgb(239, 68, 68);
        btnDeleteRestock.FlatStyle = FlatStyle.Flat;
        btnDeleteRestock.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        btnDeleteRestock.ForeColor = Color.White;
        btnDeleteRestock.Location = new Point(250, 8);
        btnDeleteRestock.Name = "btnDeleteRestock";
        btnDeleteRestock.Size = new Size(180, 38);
        btnDeleteRestock.TabIndex = 3;
        btnDeleteRestock.Text = "حذف الفاتورة المحددة 🗑️";
        btnDeleteRestock.UseVisualStyleBackColor = false;
        btnDeleteRestock.Click += btnDeleteRestock_Click;
        // 
        // RestockForm
        // 
        ClientSize = new Size(1000, 555);
        Controls.Add(pnlHistoryContainer);
        Controls.Add(pnlCartContainer);
        Controls.Add(pnlInput);
        Controls.Add(pnlSupplier);
        Controls.Add(pnlTop);
        Controls.Add(pnlBottom);
        Name = "RestockForm";
        RightToLeft = RightToLeft.Yes;
        RightToLeftLayout = true;
        Text = "تزويد المشتريات والمخزون";
        Load += RestockForm_Load;
        pnlTop.ResumeLayout(false);
        pnlSupplier.ResumeLayout(false);
        pnlSupplier.PerformLayout();
        pnlInput.ResumeLayout(false);
        pnlInput.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)numQuantity).EndInit();
        ((System.ComponentModel.ISupportInitialize)numPurchasePrice).EndInit();
        ((System.ComponentModel.ISupportInitialize)numSalePrice).EndInit();
        pnlCartContainer.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvCart).EndInit();
        pnlHistoryContainer.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvHistory).EndInit();
        pnlBottom.ResumeLayout(false);
        pnlBottom.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private System.Windows.Forms.Panel pnlTop;
    private System.Windows.Forms.Label lblTitle;
    private System.Windows.Forms.Panel pnlSupplier;
    private System.Windows.Forms.Label lblSupplier;
    private System.Windows.Forms.TextBox txtSupplier;
    private System.Windows.Forms.Panel pnlInput;
    private System.Windows.Forms.Label lblProduct;
    private System.Windows.Forms.ComboBox cmbProducts;
    private System.Windows.Forms.Label lblQty;
    private System.Windows.Forms.NumericUpDown numQuantity;
    private System.Windows.Forms.Label lblCost;
    private System.Windows.Forms.NumericUpDown numPurchasePrice;
    private System.Windows.Forms.Label lblSalePrice;
    private System.Windows.Forms.NumericUpDown numSalePrice;
    private System.Windows.Forms.Button btnAddToCart;
    private System.Windows.Forms.Panel pnlCartContainer;
    private System.Windows.Forms.DataGridView dgvCart;
    private System.Windows.Forms.Panel pnlHistoryContainer;
    private System.Windows.Forms.DataGridView dgvHistory;
    private System.Windows.Forms.Panel pnlBottom;
    private System.Windows.Forms.Label lblTotal;
    private System.Windows.Forms.Label lblTotalAmount;
    private System.Windows.Forms.Button btnSave;
    private System.Windows.Forms.Button btnDeleteRestock;
}*/
