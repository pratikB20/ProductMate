using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductMate.Areas.Admin.Models
{
    public class DelegateListGrid
    {
        public int intDelegateId { get; set; }
        public string strDelegateName { get; set; }
        public string strDelegateContact { get; set; }
        public string strDelegateEmailId { get; set; }
        public DateTime dteCreateDate { get; set; }
        public string strCreatedBy { get; set; }
        public string strStatus { get; set; }
    }
}
