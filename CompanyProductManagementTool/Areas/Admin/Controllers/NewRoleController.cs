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
    public class NewRoleController : Controller
    {
        //Dependency Injection - Data Access Layer
        private IAppDataConnectivity _IAppDataConnectivity;

        public NewRoleController(IAppDataConnectivity IAppDataConnectivity)
        {
            _IAppDataConnectivity = IAppDataConnectivity;
        }

        [Route("NewRole")]
        public IActionResult NewRole()
        {
            UserRole clsUserRole = new UserRole();
            int intUserRoleId = 0;
            try
            {
                if((string)TempData["ACTION"] != null)
                {
                    TempData["ACTION"] = "Update";
                    intUserRoleId = (int)TempData["UserRoleID"];
                    clsUserRole = _IAppDataConnectivity.GetUserRoleDetailsByUserRoleId(intUserRoleId);
                    TempData["UserRoleID"] = intUserRoleId;
                    //Set values
                    ViewBag.strRoleName = clsUserRole.strRoleName;
                    ViewBag.strDescription = clsUserRole.strDescription;

                    return View();
                }
                else
                {
                    //TempData["ACTION"] = "Save"; //Commented due to null issue while 2nd time coming to this page due to this save action
                    //Set Null values
                    ViewBag.strRoleName = null;
                    ViewBag.strDescription = null;

                    return View();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [Route("SaveUserRole")]
        public IActionResult SaveUserRole(UserRole clsUserRole)
        {
            Boolean IsUserRoleAdded = false;
            String message = string.Empty;
            Users clsLoggedInUser = new Users();
            try
            {
                //Inserting the user into the system
                clsUserRole.dteCreateDate = DateTime.Now;
                clsLoggedInUser = HttpContext.Session.GetObjectFromJson<Users>("User");
                clsUserRole.intCreatedBy = clsLoggedInUser.intUsersId;

                IsUserRoleAdded = _IAppDataConnectivity.SaveUserRole(clsUserRole);
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
        }

        [HttpPut]
        [Route("UpdateSelectedUserRole")]
        public IActionResult UpdateSelectedUserRole(UserRole clsUserRole)
        {
            Boolean IsUserRoleUpdated = false;
            string message = string.Empty;
            try
            {
                clsUserRole.dteCreateDate = DateTime.Now;
                clsUserRole.intUserRoleId = (int)TempData["UserRoleID"];
                IsUserRoleUpdated = _IAppDataConnectivity.UpdateUserRole(clsUserRole);
                if (IsUserRoleUpdated)
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
        }
    }
}
