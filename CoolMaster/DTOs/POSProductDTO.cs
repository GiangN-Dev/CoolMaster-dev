using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CoolMaster.DTOs
{
    // DTO hiển thị danh sách sản phẩm trên giao diện POS
    public class POSProductDTO
    {
        public int ProductId { get; set; }
        public string Barcode { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int StockCounter { get; set; } // Chỉ quan tâm tồn ở quầy
        public string ImageUrl { get; set; }
        public string Unit { get; set; }
        public string CategoryName { get; set; }
    }

    // DTO cho từng dòng trong giỏ hàng (Grid)
    public class CartItemDTO : INotifyPropertyChanged
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }

        private string _customerName;
        public string CustomerName
        {
            get => _customerName;
            set { _customerName = value; OnPropertyChanged(); }
        }

        private int _quantity;
        public int Quantity
        {
            get => _quantity;
            set
            {
                if (_quantity != value)
                {
                    _quantity = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(TotalPrice)); // Tự cập nhật tổng tiền khi SL thay đổi
                }
            }
        }

        public decimal UnitPrice { get; set; }

        public decimal TotalPrice => Quantity * UnitPrice;

        public int CurrentStock { get; set; } // Tồn kho hiện tại để validate

        // Hỗ trợ Binding cập nhật UI tức thì
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }

    // DTO gửi yêu cầu thanh toán
    public class CheckoutRequestDTO
    {
        public int? CustomerId { get; set; }
        public int StaffId { get; set; }
        public List<CartItemDTO> Items { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal Discount { get; set; } // Nếu có giảm giá
    }
}
