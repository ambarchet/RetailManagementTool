using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailManagementTool.Models.Size
{
    public class SizeEdit
    {
        [Required]
        [Display(Name = "Size Id")]
        public int SizeId { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Name must be at least 2 characters long.")]
        [MaxLength(50, ErrorMessage = "There are too many characters in this field.")]
        [Display(Name = "Size Name")]
        public string SizeName { get; set; }
    }
}
