using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailManagementTool.Data
{
    public class Promotion
    {
        [Key]
        [Display(Name = "Promotion Id")]
        public int PromotionId { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Description must be at least 2 characters long.")]
        [MaxLength(50, ErrorMessage = "There are too many characters in this field.")]
        [Display(Name = "Promotion Description")]
        public string PromotionDescription { get; set; }

        [Display(Name = "Promotion Type")]
        [ForeignKey(nameof(PromoType))]
        public int? PromoTypeId { get; set; }
        public virtual PromotionType PromoType { get; set; }

        public decimal PromoValue { get; set; }
        
    }
}
