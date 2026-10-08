using MiniSupermarket.Client;

namespace MiniSupermarket.WinForms
{
    public partial class FormMainShell : Form
    {
        private static readonly Color NavNormal = Color.FromArgb(24, 30, 48);
        private static readonly Color NavActive = Color.FromArgb(52, 73, 120);

        private Button? _activeButton;
        private Form? _currentChild;

        public FormMainShell()
        {
            InitializeComponent();
        }

        private void FormMainShell_Load(object? sender, EventArgs e)
        {
            // 1. Hiển thị thông tin người dùng đang đăng nhập
            string role = AuthSession.Role ?? string.Empty;
            string username = AuthSession.Username ?? "N/A";

            lblUserInfo.Text = $"Xin chào: {username} ({role})";
            lblUserInfo.Left = panelTopHeader.Width - lblUserInfo.Width - 20;

            // 2. Thực thi phân quyền & điều hướng màn hình mặc định
            ApplyRolePermissions(role);
            OpenDefaultScreenByRole(role);
        }

        /// <summary>
        /// Phân định quyền truy cập ẩn/hiện các nút trên thanh điều hướng Sidebar
        /// </summary>
        private void ApplyRolePermissions(string role)
        {
            if (string.IsNullOrWhiteSpace(role))
            {
                HandleInvalidRole();
                return;
            }

            switch (role.ToUpper())
            {
                case "ADMIN":
                    SetButtonVisibility(pos: true, category: true, product: true, customer: true, reports: true, userManage: true);
                    break;

                case "CASHIER":
                    SetButtonVisibility(pos: true, category: false, product: false, customer: true, reports: false, userManage: false);
                    break;

                case "WAREHOUSE":
                    SetButtonVisibility(pos: false, category: true, product: true, customer: false, reports: false, userManage: false);
                    break;

                default:
                    HandleInvalidRole();
                    break;
            }
        }

        private void SetButtonVisibility(bool pos, bool category, bool product, bool customer, bool reports, bool userManage)
        {
            if (btnPOS != null) btnPOS.Visible = pos;
            if (btnCategory != null) btnCategory.Visible = category;
            if (btnProduct != null) btnProduct.Visible = product;
            if (btnCustomer != null) btnCustomer.Visible = customer;
            if (btnReports != null) btnReports.Visible = reports;
            if (btnUserManage != null) btnUserManage.Visible = userManage;
        }

        private void HandleInvalidRole()
        {
            MessageBox.Show("Tài khoản chưa được cấp quyền hạn hợp lệ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            Close();
        }

        /// <summary>
        /// Điều hướng ngay vào màn hình mặc định đúng chuyên môn từng vai trò
        /// </summary>
        private void OpenDefaultScreenByRole(string role)
        {
            switch (role.ToUpper())
            {
                case "ADMIN":
                case "WAREHOUSE":
                    if (btnCategory != null)
                        OpenChildForm(new FormCategoryManagement(), "QUẢN LÝ DANH MỤC NHÓM HÀNG", btnCategory);
                    break;

                case "CASHIER":
                    if (btnCustomer != null)
                        OpenChildForm(new FormCustomerManagement(), "QUẢN LÝ KHÁCH HÀNG & TÍCH ĐIỂM", btnCustomer);
                    break;
            }
        }

        // ===== XỬ LÝ CÁC SỰ KIỆN CLICK NÚT ĐIỀU HƯỚNG =====
        private void btnCategory_Click(object? sender, EventArgs e)
        {
            OpenChildForm(new FormCategoryManagement(), "QUẢN LÝ DANH MỤC NHÓM HÀNG", btnCategory);
        }

        private void btnCustomer_Click(object? sender, EventArgs e)
        {
            OpenChildForm(new FormCustomerManagement(), "QUẢN LÝ KHÁCH HÀNG THÂN THIẾT", btnCustomer);
        }

        private void btnPOS_Click(object? sender, EventArgs e)
        {
            SetActiveButton(btnPOS);
            lblTitle.Text = "BÁN HÀNG (POS)";
            MessageBox.Show("Màn hình Quét mã vạch Barcode POS sẵn sàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ===== NHÚNG FORM CON VÀO PANEL MAIN =====
        private void OpenChildForm(Form child, string title, Button navButton)
        {
            SetActiveButton(navButton);
            lblTitle.Text = title;

            CloseCurrentChild();

            _currentChild = child;
            child.TopLevel = false;
            child.FormBorderStyle = FormBorderStyle.None;
            child.Dock = DockStyle.Fill;

            panelMainContent.Controls.Add(child);
            child.Show();
        }

        private void CloseCurrentChild()
        {
            if (_currentChild != null)
            {
                panelMainContent.Controls.Remove(_currentChild);
                _currentChild.Close();
                _currentChild.Dispose();
                _currentChild = null;
            }
        }

        private void SetActiveButton(Button btn)
        {
            if (_activeButton != null)
                _activeButton.BackColor = NavNormal;

            btn.BackColor = NavActive;
            _activeButton = btn;
        }

        // ===== ĐĂNG XUẤT =====
        private void btnLogout_Click(object? sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Bạn có chắc muốn đăng xuất phiên làm việc?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            // Clear phiên đăng nhập trong AuthSession
            AuthSession.Token = string.Empty;
            AuthSession.Role = string.Empty;
            AuthSession.Username = string.Empty;

            // Mở lại màn hình Login và đóng Shell
            FormLogin login = new FormLogin();
            login.Show();
            Close();
        }
    }
}