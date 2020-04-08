using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailManagementTool.Models.Product
{
    public class ProductPromoEdit
    {
        [Display(Name = "Promotion Id")]
        public IEnumerable<ProductListItem> ProductsInDepartment { get; set; }

        [Display(Name = "Promotion Id")]
        public int? PromotionId { get; set; }
    }
}
