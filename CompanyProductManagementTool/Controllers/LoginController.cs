using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductMate.Models;
using System.Web.Mvc.Ajax;
using ProductMate.DatabaseConnectivity;
using Microsoft.AspNetCore.Session;


namespace CompanyProductManagementTool.Controllers
{
    public class LoginController : Controller
    {
        //Dependency Injection - Data Access Layer
        private IAppDataConnectivity _IAppDataConnectivity;

        public LoginController(IAppDataConnectivity IAppDataConnectivity)
        {
            _IAppDataConnectivity = IAppDataConnectivity;
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AuthenticateUser(String strUsername, String strPassword)
        {
            Users clsUsers = new Users();
            try
            {
                clsUsers = _IAppDataConnectivity.AuthenticateUser(strUsername, strPassword);
                
                if (clsUsers != null)
                {
                    //Session is used to stored the database fetched objects to use anywhere in the request
                    //Below way is used to store simple objects such as int or string variables
                    HttpContext.Session.SetString("LoginUser", clsUsers.strFirstName + " " + clsUsers.strLastName);
                    HttpContext.Session.SetInt32("UserRole", clsUsers.intUserRoleId);
                    //Below way is used to store the large objects such as class object with data or collections
                    SessionHelper.SetObjectAsJson(HttpContext.Session, "User", clsUsers);

                    return Json(new { message = "FOUND", redirectUrl = Url.Action("Dashboard", "Dashboard") });
                }
                else
                {
                    return Json(new { message = "NOT_FOUND" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { message = ex.Message });
            }
            finally
            {
                clsUsers = null;
            }
        }
    }
}
