using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductMate.Areas.Admin.Models
{
    public class RoleListGrid
    {
        public int intUserRolesId { get; set; }
        public string strRoleName { get; set; }
        public string strDescription { get; set; }
        public DateTime dteCreateDate { get; set; }
        public string strCreatedBy { get; set; }
        public string strStatus { get; set; }
    }
}
