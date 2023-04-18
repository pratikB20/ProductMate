using Microsoft.AspNetCore.Mvc;
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
        DataConnectivity clsDatabaseConnectivity = new DataConnectivity();

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
                clsUsers = clsDatabaseConnectivity.AuthenticateUser(strUsername, strPassword);
                
                if (clsUsers != null)
                {
                    TempData["Username"] = strUsername;
                    TempData["Password"] = strPassword;

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
                TempData.Keep();
            }
        }
    }
}
