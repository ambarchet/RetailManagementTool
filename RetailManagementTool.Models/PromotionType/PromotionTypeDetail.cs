using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailManagementTool.Models.PromotionType
{
    public class PromotionTypeDetail
    {
        [Display(Name = "Promotion Type Id")]
        public int PromotionTypeId { get; set; }

        public string Type { get; set; }
    }
}
