using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using CoolMaster.Model;

namespace CoolMaster
{
    public class CoolMasterContext : DbContext
    {
        // Chuỗi kết nối tên là "CoolMasterConnString"
        public CoolMasterContext() : base("name=CoolMasterConnString")
        {
           
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserOTP> UserOTPs { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<InventoryLog> InventoryLogs { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<ServiceTicket> ServiceTickets { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Cấu hình độ chính xác cho tiền tệ (18 số, 2 số lẻ)
            modelBuilder.Entity<Product>()
                .Property(p => p.UnitPrice)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Order>()
                .Property(p => p.TotalAmount)
                .HasPrecision(18, 2);

            modelBuilder.Entity<OrderDetail>()
                .Property(p => p.SalePrice)
                .HasPrecision(18, 2);

            modelBuilder.Entity<ServiceTicket>()
                .Property(p => p.EstimatedCost)
                .HasPrecision(18, 2);


            modelBuilder.Entity<Product>()
           .HasIndex(p => p.Barcode)
           .IsUnique();
            // .HasFilter("IsDeleted = 0"); // Chỉ check trùng với các dòng chưa xóa
        }
    }

}
