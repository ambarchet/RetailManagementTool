using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailManagementTool.Models.Product
{
    public class ProductDetail
    {
        [Display(Name = "Product Id")]
        public int ProductId { get; set; }

        [Display(Name = "Department Id")]
        public int? DepartmentId { get; set; }

        [Display(Name = "Department")]
        public string DepartmentNumber { get; set; }

        public string Style { get; set; }

        public string SKU { get; set; }

        public string Color { get; set; }

        [Display(Name = "Size Id")]
        public int? SizeId { get; set; }

        public string Size { get; set; }

        [Display(Name = "Name")]
        public string ProductName { get; set; }

        [Display(Name = "Ticket Price")]
        [DataType(DataType.Currency)]
        public decimal TicketPrice { get; set; }

        [Display(Name = "Promotion Id")]
        public int? PromotionId { get; set; }

        [Display(Name = "Promotion")]
        public string PromotionDescription { get; set; }

        [Display(Name = "Sales Price")]
        [DataType(DataType.Currency)]
        public decimal SalesPrice { get; set; }

        [Display(Name = "Zone Name")]
        public int? ZoneId { get; set; }

        [Display(Name = "Zone")]
        public string ZoneName { get; set; }


        [Display(Name = "Individual Sales Price")]
        [DataType(DataType.Currency)]
        public decimal IndividualSalesPrice { get; set; }


    }
}
