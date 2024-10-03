using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductMate.Models
{
    public class Product
    {
        public int intProductId { get; set; }
        public string strProductName { get; set; }
        public string strDescription { get; set; }
        public DateTime dteCreateDate { get; set; }
        public int intCreatedBy { get; set; }
        public double dblProductPrice { get; set; }
        public int intStatus { get; set; }
    }
}
