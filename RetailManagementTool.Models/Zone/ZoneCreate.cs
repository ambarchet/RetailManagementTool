using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailManagementTool.Models.Zone
{
    public class ZoneCreate
    {
        [Required]
        [MinLength(2, ErrorMessage = "Name must be at least 2 characters long.")]
        [MaxLength(50, ErrorMessage = "There are too many characters in this field.")]
        [Display(Name = "Zone Name")]
        public string ZoneName { get; set; }
    }
}