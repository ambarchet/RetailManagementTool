using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailManagementTool.Models.Zone
{
    public class ZoneDetail
    {
        [Display(Name = "Zone Id")]
        public int ZoneId { get; set; }

        [Display(Name = "Zone Name")]
        public string ZoneName { get; set; }
    }
}
