using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductMate.Models
{
    public class UserRole
    {
        public int intUserRoleId { get; set; }
        public string strRoleName { get; set; }
        public string strDescription { get; set; }
        public DateTime dteCreateDate { get; set; }
        public int intCreatedBy { get; set; }
        public int intStatus { get; set; }
    }
}
