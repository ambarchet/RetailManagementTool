using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailManagementTool.Models.PromotionType
{
    public class PromotionTypeEdit
    {
        [Required]
        [Display(Name = "Promotion Type Id")]
        public int PromotionTypeId { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Name must be at least 2 characters long.")]
        [MaxLength(50, ErrorMessage = "There are too many characters in this field.")]
        public string Type { get; set; }
    }
}
