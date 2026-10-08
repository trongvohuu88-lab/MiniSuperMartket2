using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace MiniSupermarket.WinForms
{
    // 1. Lưu phiên đăng nhập hiện tại
    public static class SessionManager
    {
        public static string Token { get; set; } = string.Empty;
        public static string CurrentUsername { get; set; } = string.Empty;
        public static string CurrentRole { get; set; } = string.Empty;
        public static string? JwtToken { get; internal set; }

        // Phương thức xóa thông tin phiên khi đăng xuất
        public static void Clear()
        {
            Token = string.Empty;
            CurrentUsername = string.Empty;
            CurrentRole = string.Empty;
        }
    }

    // 2. Service gọi API tập trung
    public static class ApiClientService
    {
        // ⚠️ Kiểm tra và chỉnh cổng localhost cho khớp với launchSettings.json của dự án API
        private static readonly HttpClient _client = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:7292/api/")
        };

        // Hàm gọi API đăng nhập lấy Token và lưu vào SessionManager
        public static async Task<bool> LoginAsync(string username, string password)
        {
            var loginObj = new { Username = username, Password = password };
            var response = await _client.PostAsJsonAsync("auth/login", loginObj);

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                using var doc = JsonDocument.Parse(jsonString);

                // Gán dữ liệu vào SessionManager
                SessionManager.Token = doc.RootElement.GetProperty("token").GetString() ?? string.Empty;
                SessionManager.CurrentRole = doc.RootElement.GetProperty("role").GetString() ?? string.Empty;
                SessionManager.CurrentUsername = username;

                return true;
            }
            return false;
        }

        // Hàm gọi API lấy dữ liệu có gắn kèm Bearer Token bảo mật
        public static async Task<string> GetDataWithTokenAsync(string endpoint)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", SessionManager.Token);
            var response = await _client.GetAsync(endpoint);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                throw new Exception("Phiên làm việc hết hạn hoặc không có quyền truy cập!");
            }
            throw new Exception("Lỗi khi gọi dữ liệu từ Server.");
        }
    }
}