namespace MiniSupermarket.WinForms
{
    partial class FormMainShell
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            panelSidebar = new Panel();
            panelBottom = new Panel();
            btnLogout = new Button();
            btnUserManage = new Button();
            btnReports = new Button();
            btnCustomer = new Button();
            btnProduct = new Button();
            btnCategory = new Button();
            btnPOS = new Button();
            lblLogo = new Label();
            panelTopHeader = new Panel();
            lblUserInfo = new Label();
            lblTitle = new Label();
            panelMainContent = new Panel();
            panelSidebar.SuspendLayout();
            panelBottom.SuspendLayout();
            panelTopHeader.SuspendLayout();
            SuspendLayout();
            // 
            // panelSidebar
            // 
            panelSidebar.BackColor = Color.FromArgb(24, 30, 48);
            panelSidebar.Controls.Add(panelBottom);
            panelSidebar.Controls.Add(btnUserManage);
            panelSidebar.Controls.Add(btnReports);
            panelSidebar.Controls.Add(btnCustomer);
            panelSidebar.Controls.Add(btnProduct);
            panelSidebar.Controls.Add(btnCategory);
            panelSidebar.Controls.Add(btnPOS);
            panelSidebar.Controls.Add(lblLogo);
            panelSidebar.Dock = DockStyle.Left;
            panelSidebar.Location = new Point(0, 0);
            panelSidebar.Name = "panelSidebar";
            panelSidebar.Size = new Size(230, 720);
            panelSidebar.TabIndex = 2;
            // 
            // panelBottom
            // 
            panelBottom.Controls.Add(btnLogout);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 660);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new Size(230, 60);
            panelBottom.TabIndex = 0;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.FromArgb(24, 30, 48);
            btnLogout.Cursor = Cursors.Hand;
            btnLogout.Dock = DockStyle.Fill;
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 57, 43);
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI", 10.5F);
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(0, 0);
            btnLogout.Name = "btnLogout";
            btnLogout.Padding = new Padding(20, 0, 0, 0);
            btnLogout.Size = new Size(230, 60);
            btnLogout.TabIndex = 0;
            btnLogout.Text = "🚪  Đăng xuất";
            btnLogout.TextAlign = ContentAlignment.MiddleLeft;
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnUserManage
            // 
            btnUserManage.Location = new Point(0, 0);
            btnUserManage.Name = "btnUserManage";
            btnUserManage.Size = new Size(75, 23);
            btnUserManage.TabIndex = 1;
            btnUserManage.Click += btnNav_Click;
            // 
            // btnReports
            // 
            btnReports.Location = new Point(0, 0);
            btnReports.Name = "btnReports";
            btnReports.Size = new Size(75, 23);
            btnReports.TabIndex = 2;
            btnReports.Click += btnNav_Click;
            // 
            // btnCustomer
            // 
            btnCustomer.Location = new Point(0, 0);
            btnCustomer.Name = "btnCustomer";
            btnCustomer.Size = new Size(75, 23);
            btnCustomer.TabIndex = 3;
            btnCustomer.Click += btnNav_Click;
            // 
            // btnProduct
            // 
            btnProduct.Location = new Point(0, 0);
            btnProduct.Name = "btnProduct";
            btnProduct.Size = new Size(75, 23);
            btnProduct.TabIndex = 4;
            btnProduct.Click += btnNav_Click;
            // 
            // btnCategory
            // 
            btnCategory.Location = new Point(0, 0);
            btnCategory.Name = "btnCategory";
            btnCategory.Size = new Size(75, 23);
            btnCategory.TabIndex = 5;
            btnCategory.Click += btnNav_Click;
            // 
            // btnPOS
            // 
            btnPOS.Location = new Point(0, 0);
            btnPOS.Name = "btnPOS";
            btnPOS.Size = new Size(75, 23);
            btnPOS.TabIndex = 6;
            btnPOS.Click += btnNav_Click;
            // 
            // lblLogo
            // 
            lblLogo.Dock = DockStyle.Top;
            lblLogo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblLogo.ForeColor = Color.White;
            lblLogo.Location = new Point(0, 0);
            lblLogo.Name = "lblLogo";
            lblLogo.Size = new Size(230, 70);
            lblLogo.TabIndex = 7;
            lblLogo.Text = "\U0001f6d2 MiniMart POS";
            lblLogo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelTopHeader
            // 
            panelTopHeader.BackColor = Color.White;
            panelTopHeader.Controls.Add(lblUserInfo);
            panelTopHeader.Controls.Add(lblTitle);
            panelTopHeader.Dock = DockStyle.Top;
            panelTopHeader.Location = new Point(230, 0);
            panelTopHeader.Name = "panelTopHeader";
            panelTopHeader.Size = new Size(1050, 60);
            panelTopHeader.TabIndex = 1;
            // 
            // lblUserInfo
            // 
            lblUserInfo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblUserInfo.AutoSize = true;
            lblUserInfo.Font = new Font("Segoe UI", 10F);
            lblUserInfo.Location = new Point(1690, 20);
            lblUserInfo.Name = "lblUserInfo";
            lblUserInfo.Size = new Size(77, 19);
            lblUserInfo.TabIndex = 0;
            lblUserInfo.Text = "Xin chào: ...";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(24, 30, 48);
            lblTitle.Location = new Point(20, 14);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(248, 25);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "BÀN LÀM VIỆC HỆ THỐNG";
            // 
            // panelMainContent
            // 
            panelMainContent.BackColor = Color.FromArgb(244, 245, 247);
            panelMainContent.Dock = DockStyle.Fill;
            panelMainContent.Location = new Point(230, 60);
            panelMainContent.Name = "panelMainContent";
            panelMainContent.Size = new Size(1050, 660);
            panelMainContent.TabIndex = 0;
            // 
            // FormMainShell
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1280, 720);
            Controls.Add(panelMainContent);
            Controls.Add(panelTopHeader);
            Controls.Add(panelSidebar);
            MinimumSize = new Size(1000, 600);
            Name = "FormMainShell";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Hệ thống Quản lý Bán lẻ & Tồn kho Siêu thị Mini";
            Load += FormMainShell_Load;
            panelSidebar.ResumeLayout(false);
            panelBottom.ResumeLayout(false);
            panelTopHeader.ResumeLayout(false);
            panelTopHeader.PerformLayout();
            ResumeLayout(false);
        }

        // Cấu hình chung cho các nút điều hướng trong sidebar
        private static void ConfigureNavButton(Button btn, string name, string text)
        {
            btn.BackColor = Color.FromArgb(24, 30, 48);
            btn.Cursor = Cursors.Hand;
            btn.Dock = DockStyle.Top;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(40, 50, 78);
            btn.Font = new Font("Segoe UI", 10.5F);
            btn.ForeColor = Color.White;
            btn.Height = 45;
            btn.Name = name;
            btn.Padding = new Padding(20, 0, 0, 0);
            btn.Text = text;
            btn.TextAlign = ContentAlignment.MiddleLeft;
            btn.UseVisualStyleBackColor = false;
        }

        #endregion

        private Panel panelSidebar;
        private Panel panelTopHeader;
        private Panel panelMainContent;
        private Panel panelBottom;
        private Label lblLogo;
        private Label lblTitle;
        private Label lblUserInfo;
        private Button btnPOS;
        private Button btnCategory;
        private Button btnProduct;
        private Button btnCustomer;
        private Button btnReports;
        private Button btnUserManage;
        private Button btnLogout;
    }
}