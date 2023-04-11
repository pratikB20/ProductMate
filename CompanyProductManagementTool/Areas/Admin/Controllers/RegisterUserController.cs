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
    public class RegisterUserController : Controller
    {
        [Route("RegisterUser")]
        public IActionResult RegisterUser()
        {
            AppDataConnectivity clsAppDataConnectivity = new AppDataConnectivity();

            ViewBag.ddlOrganisation = (List<SelectListItem>)clsAppDataConnectivity.getOrganisations();
            ViewBag.ddlUserRole = (List<SelectListItem>)clsAppDataConnectivity.getUserRoles();
            return View();
        }
    }
}
