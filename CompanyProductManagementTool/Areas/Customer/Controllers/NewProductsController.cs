using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Routing;

namespace ProductMate.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class NewProductsController : Controller
    {
        [Route("NewProducts")]
        public IActionResult NewProducts()
        {
            return View();
        }
    }
}
