using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailManagementTool.Data
{
    public class Product
    {
        [Key]
        [Display(Name = "Product Id")]
        public int ProductId { get; set; }

        [Display(Name = "Department")]
        [ForeignKey(nameof(ProductDepartment))]
        public int? ProductDepartmentId { get; set; }
        public virtual Department ProductDepartment { get; set; }

        [Required]
        [MinLength(7, ErrorMessage = "Style must be at least 7 characters long.")]
        [MaxLength(50, ErrorMessage = "There are too many characters in this field.")]
        public string Style { get; set; }

        [Required]
        [MinLength(7, ErrorMessage = "SKU must be at least 7 characters long.")]
        [MaxLength(50, ErrorMessage = "There are too many characters in this field.")]
        public string SKU { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Name must be at least 2 characters long.")]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Field must be at least 2 characters long.")]
        [MaxLength(10, ErrorMessage = "There are too many characters in this field.")]
        public string Color { get; set; }

        // public SizeSelections Size { get; set; }
        [Required]
        [Display(Name = "Size")]
        [ForeignKey(nameof(ProductSize))]
        public int? ProductSizeId { get; set; }
        public virtual Size ProductSize { get; set; }


        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Ticket Price")]
        public decimal TicketPrice { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Sales Price")]
        public decimal SalesPrice { get; set; }

        [Display(Name = "Promotion")]
        [ForeignKey(nameof(ProductPromotion))]
        public int? ProductPromotionId { get; set; }
        public virtual Promotion ProductPromotion { get; set; }

        [Display(Name = "Zone Location")]
        [ForeignKey(nameof(ProductZone))]
        public int? ProductZoneId { get; set; }
        public virtual Zone ProductZone { get; set; }

    }
}
