using Microsoft.EntityFrameworkCore;
using MiniSupermarket.API.Models;

namespace MiniSupermarket.API.Data
{
    public class SupermarketDbContext : DbContext
    {
        public SupermarketDbContext(DbContextOptions<SupermarketDbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Cấu hình bảng Customers
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(c => c.RewardPoints).HasDefaultValue(0);
                entity.Property(c => c.MembershipRank).HasDefaultValue("Chuẩn");
                entity.HasIndex(c => c.PhoneNumber).IsUnique();
            });

            // 1. SEED DATA: 30 CATEGORIES (Danh mục hàng hóa Phố Thị)
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Bánh kẹo & Đồ ăn vặt", Description = "Snack, bánh quy, kẹo dẻo" },
                new Category { CategoryId = 2, CategoryName = "Nước giải khát & Trà", Description = "Nước ngọt, nước khoáng, trà lon" },
                new Category { CategoryId = 3, CategoryName = "Sữa & Sản phẩm từ sữa", Description = "Sữa tươi, sữa chua, phô mai, bơ" },
                new Category { CategoryId = 4, CategoryName = "Mì gói & Thực phẩm ăn liền", Description = "Mì, phở, cháo gói, hủ tiếu ăn liền" },
                new Category { CategoryId = 5, CategoryName = "Gia vị & Dầu ăn", Description = "Nước mắm, hạt nêm, dầu ăn, nước tương" },
                new Category { CategoryId = 6, CategoryName = "Gạo, Bột & Khô", Description = "Gạo thơm, bột mỹ, miến, bún khô" },
                new Category { CategoryId = 7, CategoryName = "Đồ đóng hộp & Chế biến sẵn", Description = "Cá hộp, thịt hộp, xúc xích, pate" },
                new Category { CategoryId = 8, CategoryName = "Hóa mỹ phẩm & Vệ sinh cá nhân", Description = "Dầu gội, sữa tắm, kem đánh răng, xà phòng" },
                new Category { CategoryId = 9, CategoryName = "Chăm sóc nhà cửa", Description = "Nước lau sàn, nước rửa chén, bột giặt" },
                new Category { CategoryId = 10, CategoryName = "Khăn giấy & Tã bỉm", Description = "Giấy vệ sinh, khăn giấy khô/ướt, tã em bé" },
                new Category { CategoryId = 11, CategoryName = "Thực phẩm đông lạnh", Description = "Cá viên, bò viên, chả giò, há cảo" },
                new Category { CategoryId = 12, CategoryName = "Kem & Đồ lạnh", Description = "Kem que, kem hộp, đá viên đóng túi" },
                new Category { CategoryId = 13, CategoryName = "Bia & Đồ uống có cồn", Description = "Bia lon, rượu nhẹ, cồn thực phẩm" },
                new Category { CategoryId = 14, CategoryName = "Cà phê & Cacao", Description = "Cà phê hòa tan, cà phê rang xay, bột cacao" },
                new Category { CategoryId = 15, CategoryName = "Trái cây tươi Phố Thị", Description = "Táo, chuối, cam, dưa hấu theo mùa" },
                new Category { CategoryId = 16, CategoryName = "Rau củ & Nấm tươi", Description = "Rau cải, cà chua, khoai tây, nấm rơm" },
                new Category { CategoryId = 17, CategoryName = "Thực phẩm tươi sống", Description = "Thịt heo, thịt gà, trứng gia cầm" },
                new Category { CategoryId = 18, CategoryName = "Hạt & Đồ khô ăn kiêng", Description = "Hạt điều, hạnh nhân, yến mạch, granola" },
                new Category { CategoryId = 19, CategoryName = "Bánh tươi Phố Thị", Description = "Bánh mì sandwich, bánh giò, bánh bao" },
                new Category { CategoryId = 20, CategoryName = "Đồ dùng gia đình nhỏ", Description = "Màng bọc thực phẩm, túi bóng, đũa muỗng" },
                new Category { CategoryId = 21, CategoryName = "Văn phòng phẩm tạp hóa", Description = "Bút, tập học sinh, băng keo, kéo" },
                new Category { CategoryId = 22, CategoryName = "Chăm sóc thú cưng", Description = "Thức ăn cho chó mèo, cát vệ sinh" },
                new Category { CategoryId = 23, CategoryName = "Sản phẩm Mẹ & Bé", Description = "Sữa bột, bình sữa, rơ lưỡi, ty giả" },
                new Category { CategoryId = 24, CategoryName = "Thuốc không kê đơn & Y tế", Description = "Khẩu y tế, bông gòn, dầu gió, C sủi" },
                new Category { CategoryId = 25, CategoryName = "Đồ kim khí & Điện gia dụng", Description = "Pin AA/AAA, bóng đèn, ổ cắm, băng keo điện" },
                new Category { CategoryId = 26, CategoryName = "Trà thảo mộc & Đông y", Description = "Trà atiso, trà hoa cúc, mủ trôm, hạt chia" },
                new Category { CategoryId = 27, CategoryName = "Nước mát Phố Thị", Description = "Nước nha đam, sâm mát, rau má đóng chai" },
                new Category { CategoryId = 28, CategoryName = "Đồ ăn vặt truyền thống", Description = "Bánh tráng trộn, cơm cháy, mứt tép" },
                new Category { CategoryId = 29, CategoryName = "Thời trang & Phụ kiện nhỏ", Description = "Khẩu trang vải, tất chân, áo mưa tiện lợi" },
                new Category { CategoryId = 30, CategoryName = "Đồ lưu niệm & Quà tặng Phố Thị", Description = "Túi vải Phố Thị, thiệp mừng, gấu bông nhỏ" }
            );

            // 2. SEED DATA: 30 PRODUCTS (Sản phẩm bán lẻ Phố Thị)
            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 1, CategoryId = 1, ProductName = "Bánh Lay's Vị Tự Nhiên 63g", Price = 12000, StockQuantity = 150, Barcode = "893456789001" },
                new Product { ProductId = 2, CategoryId = 1, ProductName = "Kẹo Dẻo Haribo Goldbears 80g", Price = 25000, StockQuantity = 80, Barcode = "893456789002" },
                new Product { ProductId = 3, CategoryId = 2, ProductName = "Nước Ngọt Coca-Cola Lon 320ml", Price = 10000, StockQuantity = 300, Barcode = "893456789003" },
                new Product { ProductId = 4, CategoryId = 2, ProductName = "Trà Green Tea C2 Vị Chanh 360ml", Price = 8000, StockQuantity = 250, Barcode = "893456789004" },
                new Product { ProductId = 5, CategoryId = 3, ProductName = "Sữa Tươi Vinamilk Ít Đường 1L", Price = 38000, StockQuantity = 90, Barcode = "893456789005" },
                new Product { ProductId = 6, CategoryId = 3, ProductName = "Sữa Chua TH True Milk Lốc 4 Hộp", Price = 28000, StockQuantity = 110, Barcode = "893456789006" },
                new Product { ProductId = 7, CategoryId = 4, ProductName = "Mì Hảo Hảo Vị Tôm Chua Cay 75g", Price = 4500, StockQuantity = 500, Barcode = "893456789007" },
                new Product { ProductId = 8, CategoryId = 4, ProductName = "Phở Bò Đệ Nhất Gói 120g", Price = 8500, StockQuantity = 200, Barcode = "893456789008" },
                new Product { ProductId = 9, CategoryId = 5, ProductName = "Nước Mắm Nam Ngư Đệ Nhất 900ml", Price = 42000, StockQuantity = 75, Barcode = "893456789009" },
                new Product { ProductId = 10, CategoryId = 5, ProductName = "Dầu Ăn Tường An Cooking Oil 1L", Price = 52000, StockQuantity = 60, Barcode = "893456789010" },
                new Product { ProductId = 11, CategoryId = 6, ProductName = "Gạo ST25 Phố Thị Túi 5kg", Price = 180000, StockQuantity = 40, Barcode = "893456789011" },
                new Product { ProductId = 12, CategoryId = 7, ProductName = "Cá Sốt Cà Ba Cô Gái Hộp 155g", Price = 19000, StockQuantity = 120, Barcode = "893456789012" },
                new Product { ProductId = 13, CategoryId = 8, ProductName = "Dầu Gội Sunsilk Mềm Mượt 650g", Price = 135000, StockQuantity = 35, Barcode = "893456789013" },
                new Product { ProductId = 14, CategoryId = 9, ProductName = "Nước Rửa Chén Sunlight Chanh 750ml", Price = 32000, StockQuantity = 85, Barcode = "893456789014" },
                new Product { ProductId = 15, CategoryId = 10, ProductName = "Giấy Vệ Sinh Pulppy 10 Cuộn", Price = 75000, StockQuantity = 65, Barcode = "893456789015" },
                new Product { ProductId = 16, CategoryId = 11, ProductName = "Chả Giò Cầu Tre Nhân Thịt 500g", Price = 65000, StockQuantity = 45, Barcode = "893456789016" },
                new Product { ProductId = 17, CategoryId = 12, ProductName = "Kem Merino Đậu Đỏ Que 60g", Price = 12000, StockQuantity = 100, Barcode = "893456789017" },
                new Product { ProductId = 18, CategoryId = 13, ProductName = "Bia Tiger Lon 330ml", Price = 18500, StockQuantity = 400, Barcode = "893456789018" },
                new Product { ProductId = 19, CategoryId = 14, ProductName = "Cà Phê G7 3in1 Hộp 18 Gói", Price = 58000, StockQuantity = 95, Barcode = "893456789019" },
                new Product { ProductId = 20, CategoryId = 15, ProductName = "Cam Sành Miền Tây (1kg)", Price = 25000, StockQuantity = 50, Barcode = "893456789020" },
                new Product { ProductId = 21, CategoryId = 16, ProductName = "Cà Chua Đà Lạt Fresh (500g)", Price = 15000, StockQuantity = 40, Barcode = "893456789021" },
                new Product { ProductId = 22, CategoryId = 17, ProductName = "Trứng Gà Tươi Vĩnh Thành Đạt (Hộp 10 quả)", Price = 31000, StockQuantity = 100, Barcode = "893456789022" },
                new Product { ProductId = 23, CategoryId = 18, ProductName = "Hạt Điều Rang Salted Phố Thị 200g", Price = 68000, StockQuantity = 55, Barcode = "893456789023" },
                new Product { ProductId = 24, CategoryId = 19, ProductName = "Bánh Mì Sandwich Kinh Đô 275g", Price = 22000, StockQuantity = 30, Barcode = "893456789024" },
                new Product { ProductId = 25, CategoryId = 20, ProductName = "Màng Bọc Thực Phẩm Lasms 30cm", Price = 35000, StockQuantity = 70, Barcode = "893456789025" },
                new Product { ProductId = 26, CategoryId = 21, ProductName = "Bút Cầu Gel Thiên Long 0.5mm", Price = 6000, StockQuantity = 200, Barcode = "893456789026" },
                new Product { ProductId = 27, CategoryId = 22, ProductName = "Pate Cho Mèo Whiskas Vị Cá Biển 85g", Price = 16000, StockQuantity = 80, Barcode = "893456789027" },
                new Product { ProductId = 28, CategoryId = 24, ProductName = "Khẩu Trang Y Tế 4 Lớp Phố Thị (Hộp 50 cái)", Price = 35000, StockQuantity = 150, Barcode = "893456789028" },
                new Product { ProductId = 29, CategoryId = 25, ProductName = "Pin AA Panasonic Hyper Vỉ 4 Viên", Price = 20000, StockQuantity = 110, Barcode = "893456789029" },
                new Product { ProductId = 30, CategoryId = 28, ProductName = "Cơm Cháy Chà Bông Phố Thị 150g", Price = 28000, StockQuantity = 90, Barcode = "893456789030" }
            );

            // 3. SEED DATA: 30 CUSTOMERS (Khách hàng thân thiết Phố Thị)
            modelBuilder.Entity<Customer>().HasData(
                new Customer { CustomerId = 1, CustomerName = "Nguyễn Văn A", PhoneNumber = "0901122334", MembershipRank = "Vàng", RewardPoints = 150, Address = "12 Nguyễn Trãi, Q.1, TP.HCM" },
                new Customer { CustomerId = 2, CustomerName = "Trần Thị B", PhoneNumber = "0918877665", MembershipRank = "Bạc", RewardPoints = 50, Address = "45 Lê Lợi, Q.1, TP.HCM" },
                new Customer { CustomerId = 3, CustomerName = "Lê Văn C", PhoneNumber = "0983344556", MembershipRank = "Chuẩn", RewardPoints = 10, Address = "88 CMT8, Q.3, TP.HCM" },
                new Customer { CustomerId = 4, CustomerName = "Phạm Hoàng Dũng", PhoneNumber = "0934567891", MembershipRank = "Kim Cương", RewardPoints = 520, Address = "102 Võ Văn Tần, Q.3, TP.HCM" },
                new Customer { CustomerId = 5, CustomerName = "Hoàng Thị Mai", PhoneNumber = "0978123456", MembershipRank = "Vàng", RewardPoints = 210, Address = "15 Lý Tự Trọng, Q.1, TP.HCM" },
                new Customer { CustomerId = 6, CustomerName = "Vũ Đình Trọng", PhoneNumber = "0965432187", MembershipRank = "Chuẩn", RewardPoints = 0, Address = "23 Trần Hưng Đạo, Q.5, TP.HCM" },
                new Customer { CustomerId = 7, CustomerName = "Đặng Thu Thảo", PhoneNumber = "0923456789", MembershipRank = "Bạc", RewardPoints = 85, Address = "67 Nguyễn Thị Minh Khai, Q.3, TP.HCM" },
                new Customer { CustomerId = 8, CustomerName = "Bùi Anh Tuấn", PhoneNumber = "0945678912", MembershipRank = "Chuẩn", RewardPoints = 25, Address = "120 Điện Biên Phủ, Bình Thạnh, TP.HCM" },
                new Customer { CustomerId = 9, CustomerName = "Đỗ Kim Ngân", PhoneNumber = "0912345678", MembershipRank = "Vàng", RewardPoints = 180, Address = "89 Hai Bà Trưng, Q.1, TP.HCM" },
                new Customer { CustomerId = 10, CustomerName = "Hồ Văn Khoa", PhoneNumber = "0987654321", MembershipRank = "Bạc", RewardPoints = 95, Address = "34 Hoàng Văn Thụ, Phú Nhuận, TP.HCM" },
                new Customer { CustomerId = 11, CustomerName = "Ngoạn Thị Bích", PhoneNumber = "0909988776", MembershipRank = "Chuẩn", RewardPoints = 5, Address = "56 Xô Viết Nghệ Tĩnh, Bình Thạnh, TP.HCM" },
                new Customer { CustomerId = 12, CustomerName = "Dương Quốc Bảo", PhoneNumber = "0933221100", MembershipRank = "Kim Cương", RewardPoints = 610, Address = "11 Sư Vạn Hạnh, Q.10, TP.HCM" },
                new Customer { CustomerId = 13, CustomerName = "Lý Mỹ Linh", PhoneNumber = "0977665544", MembershipRank = "Bạc", RewardPoints = 70, Address = "223 Ba Tháng Hai, Q.10, TP.HCM" },
                new Customer { CustomerId = 14, CustomerName = "Huỳnh Minh Trí", PhoneNumber = "0944556677", MembershipRank = "Chuẩn", RewardPoints = 15, Address = "44 Phan Đăng Lưu, Phú Nhuận, TP.HCM" },
                new Customer { CustomerId = 15, CustomerName = "Phan Thị Mỹ", PhoneNumber = "0911223344", MembershipRank = "Vàng", RewardPoints = 300, Address = "78 Lê Văn Sỹ, Q.3, TP.HCM" },
                new Customer { CustomerId = 16, CustomerName = "Ngô Thành Nam", PhoneNumber = "0988990011", MembershipRank = "Chuẩn", RewardPoints = 0, Address = "90 Nguyễn Trãi, Q.5, TP.HCM" },
                new Customer { CustomerId = 17, CustomerName = "Trịnh Khánh Vy", PhoneNumber = "0931122334", MembershipRank = "Bạc", RewardPoints = 60, Address = "101 Nguyễn Đình Chiểu, Q.3, TP.HCM" },
                new Customer { CustomerId = 18, CustomerName = "Đinh Văn Hùng", PhoneNumber = "0961122334", MembershipRank = "Chuẩn", RewardPoints = 30, Address = "12 Đinh Tiên Hoàng, Q.1, TP.HCM" },
                new Customer { CustomerId = 19, CustomerName = "Lương Hải Yến", PhoneNumber = "0921122334", MembershipRank = "Vàng", RewardPoints = 250, Address = "55 Pasteur, Q.1, TP.HCM" },
                new Customer { CustomerId = 20, CustomerName = "Mai Văn Hải", PhoneNumber = "0951122334", MembershipRank = "Chuẩn", RewardPoints = 12, Address = "88 Nam Kỳ Khởi Nghĩa, Q.1, TP.HCM" },
                new Customer { CustomerId = 21, CustomerName = "Cao Thị Hương", PhoneNumber = "0971122334", MembershipRank = "Bạc", RewardPoints = 90, Address = "202 Bùi Viện, Q.1, TP.HCM" },
                new Customer { CustomerId = 22, CustomerName = "Tạ Quang Khải", PhoneNumber = "0941122334", MembershipRank = "Chuẩn", RewardPoints = 8, Address = "333 Nguyễn Oanh, Gò Vấp, TP.HCM" },
                new Customer { CustomerId = 23, CustomerName = "Trương Tấn Phát", PhoneNumber = "0919988776", MembershipRank = "Kim Cương", RewardPoints = 800, Address = "150 Quang Trung, Gò Vấp, TP.HCM" },
                new Customer { CustomerId = 24, CustomerName = "Thái Thị Ánh", PhoneNumber = "0989988776", MembershipRank = "Vàng", RewardPoints = 190, Address = "66 Phạm Văn Đồng, Thủ Đức, TP.HCM" },
                new Customer { CustomerId = 25, CustomerName = "Lâm Văn Thanh", PhoneNumber = "0939988776", MembershipRank = "Chuẩn", RewardPoints = 2, Address = "12 Võ Văn Ngân, Thủ Đức, TP.HCM" },
                new Customer { CustomerId = 26, CustomerName = "Đào Thúy Hằng", PhoneNumber = "0969988776", MembershipRank = "Bạc", RewardPoints = 55, Address = "88 Kha Vạn Cân, Thủ Đức, TP.HCM" },
                new Customer { CustomerId = 27, CustomerName = "Vương Đình Tấn", PhoneNumber = "0929988776", MembershipRank = "Chuẩn", RewardPoints = 18, Address = "45 Lê Văn Việt, Q.9, TP.HCM" },
                new Customer { CustomerId = 28, CustomerName = "Nguyễn Ngọc Ánh", PhoneNumber = "0959988776", MembershipRank = "Vàng", RewardPoints = 230, Address = "77 Đỗ Xuân Hợp, Q.9, TP.HCM" },
                new Customer { CustomerId = 29, CustomerName = "Trần Bảo Lâm", PhoneNumber = "0979988776", MembershipRank = "Chuẩn", RewardPoints = 0, Address = "12 Nguyễn Duy Trinh, Q.2, TP.HCM" },
                new Customer { CustomerId = 30, CustomerName = "Lê Thị Hồng", PhoneNumber = "0949988776", MembershipRank = "Kim Cương", RewardPoints = 950, Address = "01 Thảo Điền, Q.2, TP.HCM" }
            );

            // 4. SEED DATA: 30 ROLES (Chức danh & Vai trò Phố Thị)
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, RoleName = "Admin", Description = "Quản trị viên toàn hệ thống, toàn quyền thao tác" },
                new Role { Id = 2, RoleName = "Cashier", Description = "Nhân viên thu ngân, chuyên trách bán hàng tại quầy POS" },
                new Role { Id = 3, RoleName = "Warehouse", Description = "Nhân viên quản lý kho, nhập hàng và kiểm kê" },
                new Role { Id = 4, RoleName = "StoreManager", Description = "Quản lý cửa hàng Phố Thị, giám sát vận hành chung" },
                new Role { Id = 5, RoleName = "AssistantManager", Description = "Trợ lý quản lý cửa hàng Phố Thị" },
                new Role { Id = 6, RoleName = "InventoryManager", Description = "Quản lý tồn kho và kế hoạch dự trữ" },
                new Role { Id = 7, RoleName = "PurchasingStaff", Description = "Nhân viên thu mua hàng hóa tạp hóa" },
                new Role { Id = 8, RoleName = "PurchasingManager", Description = "Trưởng phòng thu mua, duyệt đơn nhập hàng" },
                new Role { Id = 9, RoleName = "Accountant", Description = "Nhân viên kế toán, thu chi và hóa đơn" },
                new Role { Id = 10, RoleName = "ChiefAccountant", Description = "Kế toán trưởng Phố Thị" },
                new Role { Id = 11, RoleName = "SalesStaff", Description = "Nhân viên bán hàng & tư vấn trực tiếp" },
                new Role { Id = 12, RoleName = "FloorSupervisor", Description = "Giám sát sảnh và gian hàng Phố Thị" },
                new Role { Id = 13, RoleName = "CustomerService", Description = "Nhân viên chăm sóc & giải quyết khiếu nại" },
                new Role { Id = 14, RoleName = "CRMManager", Description = "Quản lý chương trình khách hàng thân thiết" },
                new Role { Id = 15, RoleName = "MarketingStaff", Description = "Nhân viên marketing & chương trình khuyến mãi" },
                new Role { Id = 16, RoleName = "MarketingManager", Description = "Trưởng phòng tiếp thị & truyền thông Phố Thị" },
                new Role { Id = 17, RoleName = "ITSupport", Description = "Nhân viên hỗ trợ kỹ thuật POS và hệ thống" },
                new Role { Id = 18, RoleName = "SysAdmin", Description = "Quản trị viên hạ tầng mạng & cơ sở dữ liệu" },
                new Role { Id = 19, RoleName = "SecurityGuard", Description = "Nhân viên bảo vệ & giữ xe cửa hàng" },
                new Role { Id = 20, RoleName = "DeliveryStaff", Description = "Nhân viên giao hàng Phố Thị Express" },
                new Role { Id = 21, RoleName = "LogisticsManager", Description = "Quản lý vận chuyển & giao nhận" },
                new Role { Id = 22, RoleName = "HRStaff", Description = "Nhân viên nhân sự & chấm công" },
                new Role { Id = 23, RoleName = "HRManager", Description = "Trưởng phòng nhân sự & tuyển dụng" },
                new Role { Id = 24, RoleName = "Merchandiser", Description = "Nhân viên trưng bày & sắp xếp kệ hàng" },
                new Role { Id = 25, RoleName = "QualityControl", Description = "Kiểm định chất lượng & hạn sử dụng (HSD)" },
                new Role { Id = 26, RoleName = "AuditStaff", Description = "Nhân viên kiểm toán nội bộ & thất thoát" },
                new Role { Id = 27, RoleName = "ShiftLeader", Description = "Trưởng ca làm việc Phố Thị" },
                new Role { Id = 28, RoleName = "DataAnalyst", Description = "Chuyên viên phân tích doanh thu & xu hướng" },
                new Role { Id = 29, RoleName = "EcomStaff", Description = "Nhân viên quản lý đơn hàng online" },
                new Role { Id = 30, RoleName = "GeneralManager", Description = "Giám đốc điều hành chuỗi Tạp hóa Phố Thị" }
            );
        }
    }
}