using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailManagementTool.Models.Department
{
    public class DepartmentListItem
    {
        [Display(Name = "Department Id")]
        public int DepartmentId { get; set; }

        [Display(Name = "Department Number")]
        public string DepartmentNumber { get; set; }

        [Display(Name = "Department Name")]
        public string DepartmentName { get; set; }

        [Display(Name = "Department Promo")]
        public string DepartmentPromoDescription { get; set; }
    }
}
