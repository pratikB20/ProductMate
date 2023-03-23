using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductMate.Models
{
    public class Users
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
        public int intOrganisationId { get; set; }
        public int intUserRoleId { get; set; }
        public Boolean blnStatus { get; set; }
    }
}
