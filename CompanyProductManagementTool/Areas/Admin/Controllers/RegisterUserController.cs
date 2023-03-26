using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductMate.Models;
using System.Web.Mvc.Ajax;
using ProductMate.DatabaseConnectivity;

namespace ProductMate.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RegisterUserController : Controller
    {
        [Route("RegisterUser")]
        public IActionResult RegisterUser()
        {
            AppDataConnectivity clsAppDataConnectivity = new AppDataConnectivity();

            ViewBag.ddlOrganisation = clsAppDataConnectivity.getOrganisations();
            ViewBag.ddlRole = null;
            return View();
        }
    }
}
