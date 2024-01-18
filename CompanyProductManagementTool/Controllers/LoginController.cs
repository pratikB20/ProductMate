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

                    //Record user session to track user activity details
                    string strRemarks = String.Empty;
                    
                    switch(clsUsers.intUserRoleId)
                    {
                        case 1: strRemarks = "Administrator Role Logged In"; break;
                        case 2: strRemarks = "Customer Role Logged In"; break;
                        case 3: strRemarks = "Product Role Logged In"; break;
                        case 4: strRemarks = "IT Development Role Logged In"; break;
                        case 5: strRemarks = "Sales & Marketing Role Logged In"; break;
                        case 6: strRemarks = "Accounting Role Logged In"; break;
                        case 7: strRemarks = "IT Support Role Logged In"; break;
                        case 8: strRemarks = "Human Resource (HR) Role Logged In"; break;
                        default: strRemarks = "Unidentified User Role Logged In"; break;
                    }

                    _IAppDataConnectivity.RecordUserSession(clsUsers.intUsersId, DateTime.Now, DateTime.Now, strRemarks) ;

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
