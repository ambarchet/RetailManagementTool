using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailManagementTool.Models.Promotion
{
    public class PromotionDetail
    {
        [Display(Name = "Promotion Id")]
        public int PromotionId { get; set; }

        [Display(Name = "Promotion Description")]
        public string PromotionDescription { get; set; }

        [Display(Name = "Promotion Type Id")]
        public int? PromoTypeId { get; set; }

        [Display(Name = "Promotion Type")]
        public string PromoType { get; set; }

        [Display(Name = "Promotion Value")]
        public decimal PromotionValue { get; set; }


    }
}
