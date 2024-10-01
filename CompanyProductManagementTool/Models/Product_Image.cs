using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductMate.Models
{
    public class Product_Image
    {
        public int intProductImageId { get; set; }
        public string strProductImageName { get; set; }
        public byte[] bytProductImageData { get; set; }
        public int intProductId { get; set; }
    }
}
