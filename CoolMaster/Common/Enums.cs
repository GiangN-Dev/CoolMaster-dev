using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolMaster.Common
{
    public enum OrderStatus
    {
        Pending = 0,    // Chờ xử lý
        Completed = 1,  // Đã hoàn thành
        Cancelled = 2   // Đã hủy
    }

    public enum PaymentMethod
    {
        Cash = 0,           // Tiền mặt
        BankTransfer = 1,   // Chuyển khoản
        Card = 2            // Quẹt thẻ
    }

    // Enum thống nhất cho toàn bộ hệ thống
    public enum InventoryChangeType
    {
        Import = 0,              // Nhập hàng từ nhà cung cấp
        Sale = 1,                // Bán hàng (xuất kho cho khách)
        TransferToCounter = 2,   // Chuyển hàng từ kho ra quầy
        Return = 3,              // Khách trả hàng (nhập lại)
        Damage = 4,              // Hàng hư hỏng/mất mát (xuất khỏi kho)
        AuditAdjustment = 5      // Điều chỉnh tồn kho sau kiểm kê
    }

    public enum TicketStatus
    {
        Received = 0,
        Processing = 1,
        Completed = 2,
        Cancelled = 3
    }
}