using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailManagementTool.Models.Promotion
{
    public class PromotionCreate
    {
        [Required]
        [MinLength(2, ErrorMessage = "Description must be at least 2 characters long.")]
        [MaxLength(50, ErrorMessage = "There are too many characters in this field.")]
        [Display(Name = "Promotion Description")]
        public string PromotionDescription { get; set; }

        [Display(Name = "Promotion Type")]
        public int? PromoTypeId { get; set; }

        [Display(Name = "Promotion Value")]
        public decimal PromotionValue { get; set; }
    }
}
