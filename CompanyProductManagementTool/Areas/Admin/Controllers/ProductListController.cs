using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductMate.Models;
using ProductMate.Areas.Admin.Models;
using System.Data;
using System.Data.SqlClient;
using ProductMate.DatabaseConnectivity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProductMate.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductListController : Controller
    {
        //Dependency Injection - Data Access Layer
        private IAppDataConnectivity _IAppDataConnectivity;

        public ProductListController(IAppDataConnectivity IAppDataConnectivity)
        {
            _IAppDataConnectivity = IAppDataConnectivity;
        }

        [Route("ProductList")]
        public IActionResult ProductList()
        {
            List<ProductListGrid> colProductListGrid = new List<ProductListGrid>();
            try
            {
                colProductListGrid = _IAppDataConnectivity.getAllProducts();
                return View(colProductListGrid);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete]
        [Route("DeleteProduct")]
        public ActionResult DeleteProduct(int intProductId)
        {
            bool IsDeleteCompleted = false;
            String message = string.Empty;
            try
            {
                IsDeleteCompleted = _IAppDataConnectivity.DeleteProduct(intProductId);
                if(IsDeleteCompleted) { message = "OK"; } else { message = "ERROR"; }
                return Json(new { message = message });
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
