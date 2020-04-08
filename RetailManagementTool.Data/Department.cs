using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailManagementTool.Data
{
    public class Department
    {
        [Key]
        [Display(Name = "Department Id")]
        public int DepartmentId { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Field must be at least 2 characters long.")]
        [MaxLength(50, ErrorMessage = "There are too many characters in this field.")]
        [Display(Name = "Department Number")]
        public string DepartmentNumber { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Name must be at least 2 characters long.")]
        [MaxLength(50, ErrorMessage = "There are too many characters in this field.")]
        [Display(Name = "Department Name")]
        public string DepartmentName { get; set; }

        [Display(Name = "Promotion")]
        [ForeignKey(nameof(DepartmentPromotion))]
        public int? DepartmentPromotionId { get; set; }
        public virtual Promotion DepartmentPromotion { get; set; }
        public virtual ICollection<Product> ProductsInDepartment { get; set; }

    }
}
