using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoolMaster.Common;
// Phiếu báo hành/sửa chữa

namespace CoolMaster.Model
{
    [Table("ServiceTickets")]
    public class ServiceTicket : BaseEntity
    {
        [Key]
        public int TicketId { get; set; } // Tên ID cụ thể

        [Required]
        [MaxLength(100)]
        public string DeviceName { get; set; } // Tên thiết bị khách gửi (VD: Daikin Inverter 1HP)

        [MaxLength(50)]
        public string SerialNumber { get; set; } // Số serial máy (nếu có)

        [Required]
        public string IssueDescription { get; set; } // Mô tả lỗi (VD: Máy không lạnh, kêu to)

        public string Diagnosis { get; set; } // Kỹ thuật chẩn đoán nguyên nhân

        public string Solution { get; set; } // Hướng khắc phục

        public decimal EstimatedCost { get; set; } // Chi phí dự kiến

        [Required]
        public TicketStatus TicketStatus { get; set; } // Received, Processing, Completed, Cancelled

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime? CompletedDate { get; set; }

        // --- Foreign Keys ---
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }

        public int? TechnicianId { get; set; } // Kỹ thuật viên phụ trách
        [ForeignKey("TechnicianId")]
        public virtual User Technician { get; set; }
    }
}
