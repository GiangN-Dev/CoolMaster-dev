using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolMaster.Common
{
    // Class chứa dữ liệu phân trang chuẩn (Generic)
    public class PagedResult<T>
    {
        public IEnumerable<T> Items { get; set; } // Danh sách dữ liệu (DTO)
        public int TotalCount { get; set; }       // Tổng số bản ghi tìm thấy
        public int PageIndex { get; set; }        // Trang hiện tại
        public int PageSize { get; set; }         // Số dòng mỗi trang
        public int TotalPages { get; set; }       // Tổng số trang

        public PagedResult(IEnumerable<T> items, int count, int pageIndex, int pageSize)
        {
            Items = items;
            TotalCount = count;
            PageIndex = pageIndex;
            PageSize = pageSize;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        }
    }
}
