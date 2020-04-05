using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailManagementTool.Models.Size
{
    public class SizeListItem
    {
        [Display(Name = "Size Id")]
        public int SizeId { get; set; }

        [Display(Name = "Size Name")]
        public string SizeName { get; set; }
    }
}
