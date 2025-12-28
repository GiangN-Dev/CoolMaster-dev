using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoolMaster.Model;
// Hàng hóa

namespace CoolMaster.Model
{
    [Table("Products")]
    public class Product : BaseEntity
    {
        [Key] public int ProductId { get; set; }

        [Required][MaxLength(20)] public string Barcode { get; set; }
        [Required][MaxLength(100)] public string ProductName { get; set; }

        public decimal UnitPrice { get; set; }

        public int StockCounter { get; private set; }

        public int StockWarehouse { get; private set; }

        [NotMapped]
        public int TotalStock => StockWarehouse + StockCounter;

        [MaxLength(20)] public string Unit { get; set; }
        [MaxLength(50)] public string Brand { get; set; }
        public int WarrantyMonth { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        // Foreign Keys
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        // Danh sách lịch sử kho của sản phẩm này
        public virtual ICollection<InventoryLog> InventoryLogs { get; set; }

        public Product(string barcode, string name, decimal price, string unit, int initialStock)
        {
            Barcode = barcode;
            ProductName = name;
            UnitPrice = price;
            Unit = unit;
            StockWarehouse = initialStock;
            StockCounter = 0; // Mới nhập thì chưa ra quầy
        }

        public Product()
        {
        }


        public Product(string name, int stockWarehouse, int stockCounter, decimal price)
        {
            ProductName = name;
            StockWarehouse = stockWarehouse;
            StockCounter = stockCounter;
            UnitPrice = price;
        }

        // METHOD XỬ LÝ NGHIỆP VỤ (Logic luân chuyển hàng)

        // Hành động 1: Nhập hàng từ Nhà cung cấp (Xe tải chở hàng vô thẳng Kho)
        public void ImportToWarehouse(int quantity)
        {
            StockWarehouse += quantity;
        }

        // Hành động 2: Châm hàng (Lấy từ Kho đem ra Quầy trưng bày)
        public void TransferToCounter(int quantity)
        {
            if (StockWarehouse < quantity)
                throw new Exception("Kho không đủ hàng để châm ra quầy!");

            StockWarehouse -= quantity;
            StockCounter += quantity;
        }

        // Hành động 3: Bán hàng (Ưu tiên trừ ở Quầy trước)
        public void SellFromCounter(int quantity)
        {
            if (StockCounter < quantity)
                throw new Exception("Hàng ngoài quầy không đủ! Hãy châm thêm từ kho.");

            StockCounter -= quantity;
        }
    }
}
