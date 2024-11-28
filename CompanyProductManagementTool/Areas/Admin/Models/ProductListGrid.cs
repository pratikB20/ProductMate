using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductMate.Areas.Admin.Models
{
    public class ProductListGrid
    {
        public int intProductId { get; set; }
        public string strProductName { get; set; }
        public string strDescription { get; set; }
        public DateTime dteCreateDate { get; set; }
        public string strCreatedBy { get; set; }
        public double dblProductPrice { get; set; }
        public string strStatus { get; set; }
    }
}
