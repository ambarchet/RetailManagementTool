using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailManagementTool.Data
{
    public class Size
    {
        [Key]
        [Display(Name = "Size Id")]
        public int SizeId { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "There are too many characters in this field.")]
        [Display(Name = "Department Number")]
        public string SizeName { get; set; }
    }
}
