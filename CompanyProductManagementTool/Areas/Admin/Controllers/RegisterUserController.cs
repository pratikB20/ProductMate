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
    public class RegisterUserController : Controller
    {
        [Route("RegisterUser")]
        public IActionResult RegisterUser()
        {
            AppDataConnectivity clsAppDataConnectivity = new AppDataConnectivity();          
            try
            {
                ViewBag.ddlOrganisation = (List<SelectListItem>)clsAppDataConnectivity.getOrganisations();
                ViewBag.ddlUserRole = (List<SelectListItem>)clsAppDataConnectivity.getUserRoles();
                return View();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                TempData.Keep();
            }
        }

        [HttpPost]
        [Route("SaveUser")]
        public IActionResult SaveUser(Users clsUsers)
        {
            AppDataConnectivity clsAppDataConnectivity = new AppDataConnectivity();
            Boolean IsUserAdded = false;
            String message = string.Empty;
            Users clsLoggedInUser = new Users();
            try
            {
                //Inserting the user into the system
                clsUsers.dteCreateDate = DateTime.Now;
                clsLoggedInUser = HttpContext.Session.GetObjectFromJson<Users>("User");
                clsUsers.intCreatedBy = clsLoggedInUser.intUsersId;

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
