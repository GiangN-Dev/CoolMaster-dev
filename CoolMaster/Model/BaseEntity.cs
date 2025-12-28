using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolMaster.Model
{
    public abstract class BaseEntity
    {
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; } // Ngày cập nhật cuối
        public bool IsDeleted { get; set; } = false; // Soft Delete: True = đã xóa
    }
}
