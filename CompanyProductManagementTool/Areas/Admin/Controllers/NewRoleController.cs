﻿//IMP Session namespace to import whenever wanted to use session variables.
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
    public class NewRoleController : Controller
    {
        [Route("NewRole")]
        public IActionResult NewRole()
        {
            try
            {
                return View();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
        }

        [HttpPost]
        [Route("SaveUserRole")]
        public IActionResult SaveUserRole(UserRole clsUserRole)
        {
            AppDataConnectivity clsAppDataConnectivity = new AppDataConnectivity();
            Boolean IsUserRoleAdded = false;
            String message = string.Empty;
            Users clsLoggedInUser = new Users();
            try
            {
                //Inserting the user into the system
                clsUserRole.dteCreateDate = DateTime.Now;
                clsLoggedInUser = HttpContext.Session.GetObjectFromJson<Users>("User");
                clsUserRole.intCreatedBy = clsLoggedInUser.intUsersId;

                IsUserRoleAdded = clsAppDataConnectivity.SaveUserRole(clsUserRole);
                if (IsUserRoleAdded)
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
