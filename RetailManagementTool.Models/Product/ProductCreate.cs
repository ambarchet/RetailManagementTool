using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailManagementTool.Models.Product
{
    public class ProductCreate
    {
        [Display(Name = "Department")]
        public string DepartmentNumber { get; set; }

        [Required]
        [MinLength(7, ErrorMessage = "Style must be at least 7 characters long.")]
        [MaxLength(50, ErrorMessage = "There are too many characters in this field.")]
        public string Style { get; set; }

        [Required]
        [MinLength(7, ErrorMessage = "SKU must be at least 7 characters long.")]
        [MaxLength(50, ErrorMessage = "There are too many characters in this field.")]
        public string SKU { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Field must be at least 2 characters long.")]
        [MaxLength(10, ErrorMessage = "There are too many characters in this field.")]
        public string Color { get; set; }

        [Required]
        [MaxLength(25, ErrorMessage = "There are too many characters in this field.")]
        public string SizeName { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Name must be at least 2 characters long.")]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Ticket Price")]
        public decimal TicketPrice { get; set; }

        [Required]
        [Display(Name = "Sales Price")]
        [DataType(DataType.Currency)]
        public decimal SalesPrice { get; set; }

        [Display(Name = "Promotion")]
        public string PromotionDescription { get; set; }

        [Display(Name = "Zone")]
        [MaxLength(50, ErrorMessage = "There are too many characters in this field.")]

        public string ZoneName { get; set; }
    }
}
