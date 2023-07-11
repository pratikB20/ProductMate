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
    public class RegisterUserController : Controller
    {
        [Route("RegisterUser")]
        public IActionResult RegisterUser()
        {
            AppDataConnectivity clsAppDataConnectivity = new AppDataConnectivity();
            Users clsUser = new Users();
            int intUsersId = 0;
            try
            {
                if((string)TempData["ACTION"] != null)
                {
                    TempData["ACTION"] = "Update";
                    intUsersId = (int)TempData["UserID"];
                    ViewBag.ddlOrganisation = (List<SelectListItem>)clsAppDataConnectivity.getOrganisations();
                    ViewBag.ddlUserRole = (List<SelectListItem>)clsAppDataConnectivity.getUserRoles();
                    clsUser = clsAppDataConnectivity.GetUserDetailsByUsersId(intUsersId);
                    TempData["UserID"] = intUsersId;
                    //Set Values
                    ViewBag.strFirstName = clsUser.strFirstName;
                    ViewBag.strLastName = clsUser.strLastName;
                    ViewBag.strContact = clsUser.strContact;
                    ViewBag.strEmailId = clsUser.strEmailId;
                    ViewBag.strUsername = clsUser.strUsername;
                    ViewBag.strPassword = clsUser.strPassword;
                    ViewBag.intOrganisationId = clsUser.intOrganisationId;
                    ViewBag.intUserRoleId = clsUser.intUserRoleId;
                    ViewBag.intStatus = clsUser.intStatus;
                    return View();
                }
                else
                {
                    //TempData["ACTION"] = "Save"; //Commented due to null issue while 2nd time coming to this page due to this save action
                    ViewBag.ddlOrganisation = (List<SelectListItem>)clsAppDataConnectivity.getOrganisations();
                    ViewBag.ddlUserRole = (List<SelectListItem>)clsAppDataConnectivity.getUserRoles();
                    //Set Null Values
                    ViewBag.strFirstName = null;
                    ViewBag.strLastName = null;
                    ViewBag.strContact = null;
                    ViewBag.strEmailId = null;
                    ViewBag.strUsername = null;
                    ViewBag.strPassword = null;
                    ViewBag.intOrganisationId = null;
                    ViewBag.intUserRoleId = null;
                    ViewBag.intStatus = null;

                    return View();
                }             
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //TempData.Keep(); Commented due to Null ACTION issue
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

        [HttpPost]
        [Route("UpdateSelectedUsers")]
        public IActionResult UpdateSelectedUsers(Users clsUsers)
        {
            AppDataConnectivity clsAppDataConnectivity = new AppDataConnectivity();
            Boolean IsUserUpdated = false;
            String message = string.Empty;
            try
            {
                clsUsers.dteCreateDate = DateTime.Now;
                clsUsers.intUsersId = (int)TempData["UserID"];
                IsUserUpdated = clsAppDataConnectivity.UpdateUser(clsUsers);
                if (IsUserUpdated)
                {
                    message = "OK";
                }
                else
                {
                    message = "ERROR";
                }

                return Json(new { message = message });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
        }
    }
}
