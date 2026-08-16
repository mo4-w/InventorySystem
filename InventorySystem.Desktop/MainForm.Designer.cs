using System.Drawing;
using System.Windows.Forms;

namespace InventorySystem.Desktop;

partial class MainForm
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
        pnlHeader = new Panel();
        lblTitle = new Label();
        lblUser = new Label();
        pnlSidebar = new Panel();
        tvMenu = new TreeView();
        lblBrand = new Label();
        pnlContent = new Panel();
        pnlHeader.SuspendLayout();
        pnlSidebar.SuspendLayout();
        SuspendLayout();
        // 
        // pnlHeader
        // 
        pnlHeader.BackColor = Color.FromArgb(243, 245, 249);
        pnlHeader.Controls.Add(lblTitle);
        pnlHeader.Controls.Add(lblUser);
        pnlHeader.Dock = DockStyle.Top;
        pnlHeader.Location = new Point(0, 0);
        pnlHeader.Name = "pnlHeader";
        pnlHeader.Padding = new Padding(20, 10, 20, 10);
        pnlHeader.Size = new Size(1280, 70);
        pnlHeader.TabIndex = 2;
        // 
        // lblTitle
        // 
        lblTitle.AutoSize = true;
        lblTitle.Dock = DockStyle.Right;
        lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
        lblTitle.ForeColor = Color.FromArgb(30, 41, 59);
        lblTitle.Location = new Point(1085, 10);
        lblTitle.Name = "lblTitle";
        lblTitle.Padding = new Padding(0, 10, 20, 0);
        lblTitle.Size = new Size(175, 40);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "🏠 لوحة التحكم";
        // 
        // lblUser
        // 
        lblUser.AutoSize = true;
        lblUser.Dock = DockStyle.Left;
        lblUser.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        lblUser.ForeColor = Color.FromArgb(76, 123, 217);
        lblUser.Location = new Point(20, 10);
        lblUser.Name = "lblUser";
        lblUser.Padding = new Padding(20, 15, 0, 0);
        lblUser.Size = new Size(121, 35);
        lblUser.TabIndex = 1;
        lblUser.Text = "جاري التحميل...";
        // 
        // pnlSidebar
        // 
        pnlSidebar.BackColor = Color.FromArgb(248, 250, 252);
        pnlSidebar.Controls.Add(tvMenu);
        pnlSidebar.Controls.Add(lblBrand);
        pnlSidebar.Dock = DockStyle.Left;
        pnlSidebar.Location = new Point(0, 70);
        pnlSidebar.Name = "pnlSidebar";
        pnlSidebar.Padding = new Padding(15);
        pnlSidebar.Size = new Size(277, 730);
        pnlSidebar.TabIndex = 1;
        pnlSidebar.Paint += pnlSidebar_Paint;
        // 
        // tvMenu
        // 
        tvMenu.BackColor = Color.FromArgb(248, 250, 252);
        tvMenu.BorderStyle = BorderStyle.None;
        tvMenu.Dock = DockStyle.Fill;
        tvMenu.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        tvMenu.ForeColor = Color.FromArgb(30, 41, 59);
        tvMenu.FullRowSelect = true;
        tvMenu.ItemHeight = 45;
        tvMenu.Location = new Point(15, 60);
        tvMenu.Name = "tvMenu";
        tvMenu.RightToLeftLayout = true;
        tvMenu.ShowLines = false;
        tvMenu.Size = new Size(247, 655);
        tvMenu.TabIndex = 0;
        tvMenu.AfterSelect += TvMenu_AfterSelect;
        // 
        // lblBrand
        // 
        lblBrand.Dock = DockStyle.Top;
        lblBrand.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
        lblBrand.ForeColor = Color.FromArgb(100, 116, 139);
        lblBrand.Location = new Point(15, 15);
        lblBrand.Name = "lblBrand";
        lblBrand.Size = new Size(247, 45);
        lblBrand.TabIndex = 1;
        lblBrand.Text = "Van Sales System";
        lblBrand.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // pnlContent
        // 
        pnlContent.BackColor = Color.FromArgb(243, 245, 249);
        pnlContent.Dock = DockStyle.Fill;
        pnlContent.Location = new Point(277, 70);
        pnlContent.Name = "pnlContent";
        pnlContent.Padding = new Padding(15);
        pnlContent.Size = new Size(1003, 730);
        pnlContent.TabIndex = 0;
        // 
        // MainForm
        // 
        BackColor = Color.FromArgb(243, 245, 249);
        ClientSize = new Size(1280, 800);
        Controls.Add(pnlContent);
        Controls.Add(pnlSidebar);
        Controls.Add(pnlHeader);
        Name = "MainForm";
        RightToLeft = RightToLeft.Yes;
        RightToLeftLayout = true;
        StartPosition = FormStartPosition.CenterScreen;
        Text = "نظام المبيعات والجرد اليومي - Van Sales System";
        pnlHeader.ResumeLayout(false);
        pnlHeader.PerformLayout();
        pnlSidebar.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private Panel pnlHeader;
    private Label lblTitle;
    private Label lblUser;
    private Panel pnlSidebar;
    private Label lblBrand;
    private TreeView tvMenu;
    private Panel pnlContent;
}