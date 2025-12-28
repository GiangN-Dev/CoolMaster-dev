using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using CoolMaster.Common;
using CoolMaster.Model;
using System;

namespace CoolMaster
{
    // Tạo DB
    public class CoolMasterInitializer : DropCreateDatabaseIfModelChanges<CoolMasterContext>
    {
        protected override void Seed(CoolMasterContext context)
        {
            // --- 1. USERS (NHÂN VIÊN) ---
            string defaultPasswordHash = SecurityHelper.HashPassword("123456");

            var users = new List<User>
            {
                new User { StaffCode = "N001", Password = defaultPasswordHash, FullName = "Nguyễn Quản Lý", Role = "Quản lý", Email = "chientoc495@gmail.com", Address = "TP.HCM", PhoneNumber = "0909000001" },
                new User { StaffCode = "N002", Password = defaultPasswordHash, FullName = "Trần Thu Ngân", Role = "Thu ngân", Email = "thungan@coolmaster.com", Address = "Hà Nội", PhoneNumber = "0909000002" },
                new User { StaffCode = "N003", Password = defaultPasswordHash, FullName = "Lê Thủ Kho", Role = "Thủ kho", Email = "kho@coolmaster.com", Address = "Đà Nẵng", PhoneNumber = "0909000003" },
                new User { StaffCode = "N004", Password = defaultPasswordHash, FullName = "Phạm Kỹ Thuật", Role = "Kỹ thuật", Email = "kythuat@coolmaster.com", Address = "Cần Thơ", PhoneNumber = "0909000004" },
                new User { StaffCode = "N005", Password = defaultPasswordHash, FullName = "Võ Kế Toán", Role = "Kế toán", Email = "ketoan@coolmaster.com", Address = "Hải Phòng", PhoneNumber = "0909000005" }
            };
            context.Users.AddRange(users);
            context.SaveChanges(); // Lưu để lấy ID dùng bên dưới

            // --- 2. SUPPLIERS (NHÀ CUNG CẤP) ---
            var suppliers = new List<Supplier>
            {
                new Supplier { SupplierName = "Công ty TNHH Daikin Vietnam", ContactPerson = "Mr. Nhật", Phone = "02899998888", Address = "KCN Tân Bình, TP.HCM" },
                new Supplier { SupplierName = "Samsung Vina Electronics", ContactPerson = "Ms. Han", Phone = "1800588889", Address = "Quận 1, TP.HCM" },
                new Supplier { SupplierName = "Panasonic Vietnam", ContactPerson = "Ms. Thảo", Phone = "18001111", Address = "KCN Thăng Long, Hà Nội" },
                new Supplier { SupplierName = "LG Electronics", ContactPerson = "Mr. Kim", Phone = "18001503", Address = "Hải Phòng" },
                new Supplier { SupplierName = "Điện Lạnh Hưng Phát", ContactPerson = "Chú Tư", Phone = "0939123456", Address = "Cần Thơ" }
            };
            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            if (!context.Customers.Any())
            {
                var customers = new List<Customer>
                {
                    new Customer { FullName = "Nguyễn Văn Khách", PhoneNumber = "0912345678", Address = "Quận 1, TP.HCM" },
                    new Customer { FullName = "Trần Thị Mua Hàng", PhoneNumber = "0987654321", Address = "Quận 3, TP.HCM" },
                    new Customer { FullName = "Lê Đại Gia (VIP)", PhoneNumber = "0999888777", Address = "Biệt thự Vincom, TP.HCM" },
                    new Customer { FullName = "Công ty Xây Dựng Số 1", PhoneNumber = "02838889999", Address = "KCN Tân Tạo" },
                    new Customer { FullName = "Phạm Văn E", PhoneNumber = "0901112222", Address = "Bình Thạnh, TP.HCM" },
                    new Customer { FullName = "Hoàng Thị F", PhoneNumber = "0903334444", Address = "Gò Vấp, TP.HCM" },
                    new Customer { FullName = "Coffee House (Chuỗi)", PhoneNumber = "02871087108", Address = "Nhiều chi nhánh" },
                    new Customer { FullName = "Phan Văn Hưng", PhoneNumber = "0912000111", Address = "Quận 1, TP.HCM" },
                    new Customer { FullName = "Trương Thị Lan", PhoneNumber = "0912000112", Address = "Quận 3, TP.HCM" },
                    new Customer { FullName = "Đặng Văn Minh", PhoneNumber = "0912000113", Address = "Quận 5, TP.HCM" },
                    new Customer { FullName = "Võ Thị Thu", PhoneNumber = "0912000114", Address = "Quận 7, TP.HCM" },
                    new Customer { FullName = "Bùi Văn Khánh", PhoneNumber = "0912000115", Address = "Thủ Đức, TP.HCM" },
                    new Customer { FullName = "Hồ Thị Mai", PhoneNumber = "0912000116", Address = "Bình Thạnh, TP.HCM" },
                    new Customer { FullName = "Dương Văn Lâm", PhoneNumber = "0912000117", Address = "Gò Vấp, TP.HCM" },
                    new Customer { FullName = "Ngô Thị Ngọc", PhoneNumber = "0912000118", Address = "Phú Nhuận, TP.HCM" },
                    new Customer { FullName = "Lý Văn Kiệt", PhoneNumber = "0912000119", Address = "Tân Bình, TP.HCM" },
                    new Customer { FullName = "Phạm Thị Tuyết", PhoneNumber = "0912000120", Address = "Bình Tân, TP.HCM" },
                    new Customer { FullName = "Khách vãng lai", PhoneNumber = "0000000000", Address = "Tại quầy" }
                };
                context.Customers.AddRange(customers);
                context.SaveChanges();
            }

            // --- 4. CATEGORIES (DANH MỤC) ---
            var categories = new List<Category>
            {
                new Category { CategoryName = "Máy Lạnh", Description = "Máy lạnh treo tường, âm trần, tủ đứng" },
                new Category { CategoryName = "Tủ Lạnh", Description = "Tủ lạnh Side-by-side, Inverter, Tủ đông" },
                new Category { CategoryName = "Máy Giặt", Description = "Máy giặt lồng ngang, lồng đứng, máy sấy" },
                new Category { CategoryName = "Gia Dụng", Description = "Quạt, Nồi cơm, Lò vi sóng" },
                new Category { CategoryName = "Vật Tư - Linh Kiện", Description = "Gas, Ống đồng, Remote, Board mạch" }
            };
            context.Categories.AddRange(categories);
            context.SaveChanges();

            var catMayLanh = categories.First(c => c.CategoryName == "Máy Lạnh").CategoryId;
            var catTuLanh = categories.First(c => c.CategoryName == "Tủ Lạnh").CategoryId;
            var catMayGiat = categories.First(c => c.CategoryName == "Máy Giặt").CategoryId;
            var catGiaDung = categories.First(c => c.CategoryName == "Gia Dụng").CategoryId;
            var catVatTu = categories.First(c => c.CategoryName == "Vật Tư - Linh Kiện").CategoryId;

            var products = new List<Product>
            {
                // Máy Lạnh (6 SP)
                new Product("Máy lạnh Daikin Inverter 1HP", 20, 2, 9500000) { Barcode = "DK1HP001", Brand = "Daikin", Unit = "Bộ", WarrantyMonth = 24, CategoryId = catMayLanh, ImageUrl = "maylanh1" },
                new Product("Máy lạnh Daikin Inverter 1.5HP", 15, 1, 11500000) { Barcode = "DK15HP02", Brand = "Daikin", Unit = "Bộ", WarrantyMonth = 24, CategoryId = catMayLanh, ImageUrl = "maylanh2" },
                new Product("Máy lạnh Panasonic 1HP Nanoe-X", 10, 2, 10200000) { Barcode = "PA1HP003", Brand = "Panasonic", Unit = "Bộ", WarrantyMonth = 24, CategoryId = catMayLanh, ImageUrl = "maylanh3"},
                new Product("Máy lạnh Toshiba Inverter 1HP", 12, 0, 8900000) { Barcode = "TO1HP004", Brand = "Toshiba", Unit = "Bộ", WarrantyMonth = 24, CategoryId = catMayLanh, ImageUrl = "maylanh4"},
                new Product("Máy lạnh LG Dual Cool 1.5HP", 8, 1, 9800000) { Barcode = "LG15HP05", Brand = "LG", Unit = "Bộ", WarrantyMonth = 24, CategoryId = catMayLanh, ImageUrl = "maylanh5"},
                new Product("Máy lạnh Casper 1HP (Giá rẻ)", 30, 5, 5500000) { Barcode = "CA1HP006", Brand = "Casper", Unit = "Bộ", WarrantyMonth = 36, CategoryId = catMayLanh, ImageUrl = "maylanh6" },

                // Tủ Lạnh (4 SP)
                new Product("Tủ lạnh Samsung Inverter 380L", 5, 1, 14200000) { Barcode = "SS380L01", Brand = "Samsung", Unit = "Cái", WarrantyMonth = 24, CategoryId = catTuLanh, ImageUrl = "tulanh1"},
                new Product("Tủ lạnh Hitachi Inverter 450L", 4, 1, 18500000) { Barcode = "HI450L02", Brand = "Hitachi", Unit = "Cái", WarrantyMonth = 24, CategoryId = catTuLanh, ImageUrl = "tulanh2" },
                new Product("Tủ đông Sanaky 280L", 10, 0, 6500000) { Barcode = "SNK280L3", Brand = "Sanaky", Unit = "Cái", WarrantyMonth = 12, CategoryId = catTuLanh, ImageUrl = "tulanh3" },
                new Product("Tủ lạnh mini Aqua 90L", 20, 2, 2800000) { Barcode = "AQ90L04", Brand = "Aqua", Unit = "Cái", WarrantyMonth = 24, CategoryId = catTuLanh, ImageUrl = "tulanh4" },

                // Máy Giặt (4 SP)
                new Product("Máy giặt LG AI DD 9kg", 8, 1, 8900000) { Barcode = "LG9KG01", Brand = "LG", Unit = "Cái", WarrantyMonth = 24, CategoryId = catMayGiat, ImageUrl = "maygiat1"},
                new Product("Máy giặt Electrolux Inverter 10kg", 6, 1, 10900000) { Barcode = "EL10KG02", Brand = "Electrolux", Unit = "Cái", WarrantyMonth = 24, CategoryId = catMayGiat, ImageUrl = "maygiat2"},
                new Product("Máy giặt Toshiba lồng đứng 8kg", 15, 2, 5200000) { Barcode = "TO8KG03", Brand = "Toshiba", Unit = "Cái", WarrantyMonth = 24, CategoryId = catMayGiat, ImageUrl = "maygiat3" },
                new Product("Máy sấy quần áo Electrolux 8kg", 5, 0, 9500000) { Barcode = "ES8KG04", Brand = "Electrolux", Unit = "Cái", WarrantyMonth = 24, CategoryId = catMayGiat, ImageUrl = "maygiat4" },

                // Vật Tư (6 SP)
                new Product("Gas R32 (Bình 3kg)", 50, 10, 850000) { Barcode = "GASR32", Brand = "Refrigerant", Unit = "Bình", WarrantyMonth = 6, CategoryId = catVatTu, ImageUrl = "gas1" },
                new Product("Gas R410A (Bình 3kg)", 30, 5, 750000) { Barcode = "GASR410", Brand = "Refrigerant", Unit = "Bình", WarrantyMonth = 6, CategoryId = catVatTu, ImageUrl = "gas2" },
                new Product("Ống đồng Thái Lan 6/10", 200, 50, 150000) { Barcode = "ODTL610", Brand = "LH", Unit = "Mét", WarrantyMonth = 12, CategoryId = catVatTu, ImageUrl = "ongdong" },
                new Product("Tụ điện 35uF", 100, 20, 85000) { Barcode = "CAP35", Brand = "Noname", Unit = "Cái", WarrantyMonth = 3, CategoryId = catVatTu, ImageUrl = "tudien" },
                new Product("CB Panasonic 20A", 200, 50, 65000) { Barcode = "CB20A", Brand = "Panasonic", Unit = "Cái", WarrantyMonth = 12, CategoryId = catVatTu, ImageUrl = "cb" },
                new Product("Remote đa năng", 50, 10, 120000) { Barcode = "REMOTE01", Brand = "Chunghop", Unit = "Cái", WarrantyMonth = 6, CategoryId = catVatTu, ImageUrl = "remote" }
            };
            context.Products.AddRange(products);
            context.SaveChanges();

            var adminUser = users.First(u => u.Role == "Quản lý");
            var defaultSupplier = suppliers.First(); 
            var logs = new List<InventoryLog>();

            foreach (var p in products)
            {
                if (p.TotalStock > 0)
                {
                    logs.Add(new InventoryLog
                    {
                        ProductId = p.ProductId,
                        SupplierId = defaultSupplier.SupplierId,
                        QuantityChange = p.TotalStock,
                        StockBefore = 0,
                        StockAfter = p.TotalStock,
                        ChangeType = InventoryChangeType.Import,
                        ReferenceId = "PN_INIT_" + DateTime.Now.ToString("yyyyMMdd"),
                        Note = "Nhập hàng tồn kho khởi tạo",
                        CreatedByUserId = adminUser.UserId,
                        CreatedAt = DateTime.Now.AddMonths(-1) 
                    });
                }
            }
            context.InventoryLogs.AddRange(logs);
            context.SaveChanges();

            if (context.Orders.Count() < 10)
            {
                var staff = context.Users.FirstOrDefault(u => u.Role == "Thu ngân");
                var allCustomersForOrder = context.Customers.ToList();
                var allProductsForOrder = context.Products.ToList();


                Product GetP(string code) => allProductsForOrder.FirstOrDefault(p => p.Barcode == code);

                var newOrders = new List<Order>();

                if (allCustomersForOrder.Count >= 15)
                {

                    newOrders.Add(CreateOrder(allCustomersForOrder[8], staff, new DateTime(2025, 7, 15, 9, 30, 0), OrderStatus.Completed, PaymentMethod.Cash,
                    new[] { (GetP("DK1HP001"), 1), (GetP("ODTL610"), 5) }));

                    newOrders.Add(CreateOrder(allCustomersForOrder[9], staff, new DateTime(2025, 7, 20, 14, 0, 0), OrderStatus.Completed, PaymentMethod.BankTransfer,
                        new[] { (GetP("SS380L01"), 1) }));

                    newOrders.Add(CreateOrder(allCustomersForOrder[10], staff, new DateTime(2025, 8, 5, 10, 15, 0), OrderStatus.Completed, PaymentMethod.Cash,
                        new[] { (GetP("LG9KG01"), 1), (GetP("ES8KG04"), 1) }));

                    newOrders.Add(CreateOrder(allCustomersForOrder[11], staff, new DateTime(2025, 8, 25, 16, 45, 0), OrderStatus.Cancelled, PaymentMethod.Cash,
                        new[] { (GetP("PA1HP003"), 1) }));

                    newOrders.Add(CreateOrder(allCustomersForOrder[12], staff, new DateTime(2025, 9, 2, 8, 30, 0), OrderStatus.Completed, PaymentMethod.BankTransfer,
                        new[] { (GetP("HI450L02"), 1) }));

                    newOrders.Add(CreateOrder(allCustomersForOrder[13], staff, new DateTime(2025, 9, 12, 11, 20, 0), OrderStatus.Completed, PaymentMethod.Cash,
                        new[] { (GetP("GASR32"), 2), (GetP("CAP35"), 5) }));

                    newOrders.Add(CreateOrder(allCustomersForOrder[14], staff, new DateTime(2025, 9, 28, 15, 10, 0), OrderStatus.Completed, PaymentMethod.Card,
                        new[] { (GetP("CA1HP006"), 2) }));

                    newOrders.Add(CreateOrder(allCustomersForOrder[8], staff, new DateTime(2025, 10, 10, 9, 0, 0), OrderStatus.Completed, PaymentMethod.Cash,
                        new[] { (GetP("TO1HP004"), 1) }));

                    newOrders.Add(CreateOrder(allCustomersForOrder[9], staff, new DateTime(2025, 10, 31, 19, 30, 0), OrderStatus.Completed, PaymentMethod.BankTransfer,
                        new[] { (GetP("SNK280L3"), 1) }));

                    newOrders.Add(CreateOrder(allCustomersForOrder[10], staff, new DateTime(2025, 11, 11, 10, 0, 0), OrderStatus.Completed, PaymentMethod.Cash,
                        new[] { (GetP("LG15HP05"), 1), (GetP("REMOTE01"), 1) }));

                    newOrders.Add(CreateOrder(allCustomersForOrder[11], staff, new DateTime(2025, 11, 20, 14, 15, 0), OrderStatus.Completed, PaymentMethod.BankTransfer,
                        new[] { (GetP("DK15HP02"), 1) }));

                    newOrders.Add(CreateOrder(allCustomersForOrder[12], staff, new DateTime(2025, 11, 29, 16, 0, 0), OrderStatus.Completed, PaymentMethod.Cash,
                        new[] { (GetP("AQ90L04"), 5) }));

                    newOrders.Add(CreateOrder(allCustomersForOrder[13], staff, new DateTime(2025, 12, 5, 8, 45, 0), OrderStatus.Completed, PaymentMethod.BankTransfer,
                        new[] { (GetP("EL10KG02"), 1) }));

                    newOrders.Add(CreateOrder(allCustomersForOrder[14], staff, new DateTime(2025, 12, 24, 18, 0, 0), OrderStatus.Completed, PaymentMethod.Cash,
                        new[] { (GetP("GASR410"), 1), (GetP("CB20A"), 10) }));

                    context.Orders.AddRange(newOrders);
                    context.SaveChanges();
                }
            }
            if (context.ServiceTickets.Count() < 9)
            {
                var allCustomersForTicket = context.Customers.ToList(); // Đặt tên khác để tránh trùng
                var technicians = context.Users.Where(u => u.Role == "Kỹ thuật").ToList();

                if (!technicians.Any()) technicians.Add(context.Users.FirstOrDefault());

                var tickets = new List<ServiceTicket>();

                // Phiếu 1
                tickets.Add(new ServiceTicket
                {
                    CustomerId = allCustomersForTicket[0].CustomerId, // Dùng biến mới
                    TechnicianId = null,
                    DeviceName = "Tủ lạnh Sanyo 180L",
                    SerialNumber = "SA-2021-001",
                    IssueDescription = "Ngăn mát không lạnh",
                    TicketStatus = TicketStatus.Received,
                    CreatedDate = DateTime.Now.AddHours(-2),
                    EstimatedCost = 0
                });

                tickets.Add(new ServiceTicket
                {
                    CustomerId = allCustomersForTicket[1].CustomerId,
                    TechnicianId = technicians[0].UserId,
                    DeviceName = "Máy lạnh Toshiba 1.5HP",
                    SerialNumber = "TO-998877",
                    IssueDescription = "Chảy nước",
                    TicketStatus = TicketStatus.Processing,
                    CreatedDate = DateTime.Now.AddDays(-1),
                    EstimatedCost = 250000
                });
                context.ServiceTickets.AddRange(tickets);
                context.SaveChanges();
            }
            base.Seed(context);
        }

        private Order CreateOrder(Customer cust, User staff, DateTime date, OrderStatus status, PaymentMethod payment, (Product p, int qty)[] items)
        {
            var order = new Order
            {
                CustomerId = cust.CustomerId,
                StaffId = staff?.UserId ?? 1,
                CreatedAt = date,
                OrderStatus = status,
                PaymentMethod = payment,
                Note = "Đơn hàng tự động",
                OrderDetails = new List<OrderDetail>()
            };

            foreach (var item in items)
            {
                if (item.p != null)
                {
                    order.OrderDetails.Add(new OrderDetail
                    {
                        ProductId = item.p.ProductId,
                        Quantity = item.qty,
                        SalePrice = item.p.UnitPrice
                    });
                }
            }
            // Tính tổng
            order.TotalAmount = order.OrderDetails.Sum(d => d.SubTotal);
            return order;
        }
    }
}
