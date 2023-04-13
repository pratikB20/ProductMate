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

        [HttpPost]
        [Route("SaveUser")]
        public IActionResult SaveUser(Users clsUsers)
        {
            AppDataConnectivity clsAppDataConnectivity = new AppDataConnectivity();
            Boolean IsUserAdded = false;
            String message = string.Empty;
            try
            {
                //Inserting the user into the system
                clsUsers.dteCreateDate = DateTime.Now;
                clsUsers.intCreatedBy = 1;

                IsUserAdded = clsAppDataConnectivity.SaveUser(clsUsers);
                if (IsUserAdded)
                {
                    message = "OK";
                }
                else
                {
                    message = "ERROR";
                }

                return Json(new { message = message });
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
        }
    }
}
