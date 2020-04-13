using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailManagementTool.Models.Product
{
    public class ProductEditDetail
    {
        [Display(Name = "Product Id")]
        public int ProductId { get; set; }

        [Display(Name = "Department Id")]
        public int? DepartmentId { get; set; }

        [Display(Name = "Department")]
        public string DepartmentNumber { get; set; }

        public string Style { get; set; }

        public string SKU { get; set; }

        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        public string Color { get; set; }

        [Display(Name = "Size")]
        public int? SizeId { get; set; }

        public string Size { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Ticket Price")]
        public decimal TicketPrice { get; set; }

        [Display(Name = "Promotion")]
        public int? PromotionId { get; set; }

        [Display(Name = "Promotion")]
        public string PromotionDescription { get; set; }

        [Display(Name = "Zone")]
        public int? ZoneId { get; set; }

        [Display(Name = "Zone")]
        public string ZoneName { get; set; }

    }
}

