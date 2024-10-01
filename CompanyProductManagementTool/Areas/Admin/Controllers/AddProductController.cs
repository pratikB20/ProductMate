//IMP Session namespace to import whenever wanted to use session variables.
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductMate.Models;
using System.Data;
using System.Data.SqlClient;
using ProductMate.DatabaseConnectivity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProductMate.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AddProductController : Controller
    {
        //Dependency Injection - Data Access Layer
        private IAppDataConnectivity _IAppDataConnectivity;

        public AddProductController(IAppDataConnectivity IAppDataConnectivity)
        {
            _IAppDataConnectivity = IAppDataConnectivity;
        }

        [Route("AddProduct")]
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        [Route("SaveProduct")]
        public IActionResult SaveProduct(Product clsProduct)
        {
            Boolean IsProductAdded = false;
            int intSavedProductId =0;
            string message = string.Empty;
            Users clsLoggedInUser = new Users();
            try
            {
                //Inserting the Product into the system
                clsProduct.dteCreateDate = DateTime.Now;
                clsLoggedInUser = HttpContext.Session.GetObjectFromJson<Users>("User");
                clsProduct.intCreatedBy = clsLoggedInUser.intUsersId;

                IsProductAdded = _IAppDataConnectivity.SaveProduct(clsProduct);

                message = (IsProductAdded) ? "OK" : "ERROR";

                return Json(new { message = message });
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

    }
}
