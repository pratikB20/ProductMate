using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductMate.Areas.Admin.Models
{
    public class OrganisationListGrid
    {
        public int intOrganisationId { get; set; }
        public string strOrganisationName { get; set; }
        public string strDelegateName { get; set; }
        public DateTime dteContractFromDate { get; set; }
        public DateTime dteContractToDate { get; set; }
        public DateTime dteCreateDate { get; set; }
        public string strCreatedBy { get; set; }
        public string strStatus { get; set; }
    }
}
