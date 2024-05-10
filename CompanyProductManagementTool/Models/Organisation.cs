using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductMate.Models
{
    public class Organisation
    {
        public int intOranisationId { get; set; }
        public string strOrganisationName { get; set; }
        public int intDelegateId { get; set; }
        public DateTime dteContractFromDate { get; set; }
        public DateTime dteContractToDate { get; set; }
        public DateTime dteCreateDate { get; set; }
        public int intCreatedBy { get; set; }
        public int intOrganisationStatus { get; set; }
        public int intStatus { get; set; }
    }
}
