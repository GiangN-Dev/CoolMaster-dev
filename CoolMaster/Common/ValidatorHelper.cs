using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolMaster.Common
{
    public static class ValidatorHelper
    {
        public static void ValidateObject<T>(T obj)
        {
            var context = new ValidationContext(obj, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, context, results, true);

            if (!isValid)
            {
                // Gom tất cả lỗi thành 1 chuỗi để hiển thị
                string errorMsg = string.Join("\n", results.Select(r => r.ErrorMessage));
                throw new System.Exception(errorMsg); // Throw lỗi để tầng Form bắt
            }
        }
    }

    // Sử dụng:
    /*
    public async Task CreateProduct(Product product)
    {
        // Gọi hàm này đầu tiên
        ValidatorHelper.ValidateObject(product); 
    
        // Logic tiếp theo...
        await _productRepo.AddAsync(product);
    }
     */
}
