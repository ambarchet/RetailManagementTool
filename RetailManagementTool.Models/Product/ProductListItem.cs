using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailManagementTool.Models.Product
{
    public class ProductListItem
    {
        [Display(Name = "Product Id")]
        public int ProductId { get; set; }

        [Display(Name = "Department")]
        public string DepartmentNumber { get; set; }

        public string Style { get; set; }

        public string SKU { get; set; }

        [Display(Name = "Name")]
        public string ProductName { get; set; }

        [Display(Name = "Zone")]
        public string ZoneName { get; set; }

        [Display(Name = "Promotion")]
        public string PromotionDescription { get; set; }

        [Display(Name = "Promotion Id")]
        public int? PromotionId { get; set; }


    }
}
