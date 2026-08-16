using System.Drawing;
using System.Windows.Forms;

namespace InventorySystem.Desktop;

partial class LoginForm
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
        pnlCard = new Panel();
        lblTitle = new Label();
        lblSub = new Label();
        lblUserTag = new Label();
        txtUsername = new TextBox();
        lblPassTag = new Label();
        txtPassword = new TextBox();
        lblError = new Label();
        btnLogin = new Button();
        pnlCard.SuspendLayout();
        SuspendLayout();

        // 
        // LoginForm
        // 
        ClientSize = new Size(420, 520);
        Controls.Add(pnlCard);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        Name = "LoginForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "تسجيل الدخول - Van Sales System";
        RightToLeft = RightToLeft.Yes;
        RightToLeftLayout = true;
        BackColor = UITheme.AppBackground;

        // 
        // pnlCard
        // 
        pnlCard.BackColor = UITheme.CardBackground;
        pnlCard.Controls.Add(btnLogin);
        pnlCard.Controls.Add(lblError);
        pnlCard.Controls.Add(txtPassword);
        pnlCard.Controls.Add(lblPassTag);
        pnlCard.Controls.Add(txtUsername);
        pnlCard.Controls.Add(lblUserTag);
        pnlCard.Controls.Add(lblSub);
        pnlCard.Controls.Add(lblTitle);
        pnlCard.Location = new Point(35, 30);
        pnlCard.Name = "pnlCard";
        pnlCard.Padding = new Padding(20);
        pnlCard.Size = new Size(350, 420);

        // 
        // lblTitle
        // 
        lblTitle.Dock = DockStyle.Top;
        lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
        lblTitle.ForeColor = UITheme.DarkHeaderCard;
        lblTitle.Height = 40;
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(310, 40);
        lblTitle.Text = "تسجيل الدخول";
        lblTitle.TextAlign = ContentAlignment.MiddleCenter;

        // 
        // lblSub
        // 
        lblSub.Dock = DockStyle.Top;
        lblSub.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
        lblSub.ForeColor = UITheme.TextMuted;
        lblSub.Height = 30;
        lblSub.Name = "lblSub";
        lblSub.Size = new Size(310, 30);
        lblSub.Text = "مرحباً بك، يرجى إدخال بياناتك";
        lblSub.TextAlign = ContentAlignment.MiddleCenter;

        // 
        // lblUserTag
        // 
        lblUserTag.AutoSize = true;
        lblUserTag.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblUserTag.ForeColor = UITheme.TextDark;
        lblUserTag.Location = new Point(20, 90);
        lblUserTag.Name = "lblUserTag";
        lblUserTag.Size = new Size(100, 23);
        lblUserTag.Text = "اسم المستخدم:";

        // 
        // txtUsername
        // 
        txtUsername.Font = new Font("Segoe UI", 11F);
        txtUsername.Location = new Point(20, 115);
        txtUsername.Name = "txtUsername";
        txtUsername.Size = new Size(290, 32);

        // 
        // lblPassTag
        // 
        lblPassTag.AutoSize = true;
        lblPassTag.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblPassTag.ForeColor = UITheme.TextDark;
        lblPassTag.Location = new Point(20, 160);
        lblPassTag.Name = "lblPassTag";
        lblPassTag.Size = new Size(90, 23);
        lblPassTag.Text = "كلمة المرور:";

        // 
        // txtPassword
        // 
        txtPassword.Font = new Font("Segoe UI", 11F);
        txtPassword.Location = new Point(20, 185);
        txtPassword.Name = "txtPassword";
        txtPassword.PasswordChar = '●';
        txtPassword.Size = new Size(290, 32);

        // 
        // lblError
        // 
        lblError.AutoSize = true;
        lblError.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblError.ForeColor = Color.Red;
        lblError.Location = new Point(20, 225);
        lblError.Name = "lblError";
        lblError.Size = new Size(0, 20);

        // 
        // btnLogin
        // 
        btnLogin.BackColor = UITheme.PrimaryBlue;
        btnLogin.Cursor = Cursors.Hand;
        btnLogin.FlatAppearance.BorderSize = 0;
        btnLogin.FlatStyle = FlatStyle.Flat;
        btnLogin.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        btnLogin.ForeColor = Color.White;
        btnLogin.Location = new Point(20, 260);
        btnLogin.Name = "btnLogin";
        btnLogin.Size = new Size(290, 45);
        btnLogin.Text = "تسجيل الدخول";
        btnLogin.UseVisualStyleBackColor = false;
        btnLogin.Click += BtnLogin_Click;

        pnlCard.ResumeLayout(false);
        pnlCard.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private Panel pnlCard;
    private Label lblTitle;
    private Label lblSub;
    private Label lblUserTag;
    private TextBox txtUsername;
    private Label lblPassTag;
    private TextBox txtPassword;
    private Label lblError;
    private Button btnLogin;
}