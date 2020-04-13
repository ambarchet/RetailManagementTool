using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailManagementTool.Models.Role
{
    public class RoleListItem
    {
        [Display(Name = "Role Name")]
        public string RoleName { get; set; }

    }
}
