using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductMate.Areas.Admin.Models
{
    public class UserListGrid
    {
        public int intUsersId { get; set; }
        public string strFirstName { get; set; }
        public string strLastName { get; set; }
        public string strContact { get; set; }
        public string strEmailId { get; set; }
        public string strUsername { get; set; }
        public string strPassword { get; set; }
        public DateTime dteCreateDate { get; set; }
        public string strCreatedBy { get; set; }
        public string strOrganisation { get; set; }
        public string strUserRole { get; set; }
        public string strStatus { get; set; }
    }
}
