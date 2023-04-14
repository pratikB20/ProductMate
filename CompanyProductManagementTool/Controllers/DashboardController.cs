using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductMate.Models;
using ProductMate.DatabaseConnectivity;

namespace CompanyProductManagementTool.Controllers
{
    public class DashboardController : Controller
    {
        public ActionResult Dashboard()
        {
            int intUserRole = 0;
            Users clsUsers = new Users();
            DataConnectivity clsDatabaseConnectivity = new DataConnectivity();
            try
            {
                //This code is used to persist role even when refreshed the Dashboard page
                clsUsers = clsDatabaseConnectivity.AuthenticateUser((String)TempData["Username"],(String)TempData["Password"]);
                TempData["LoginUser"] = clsUsers.strFirstName + " " + clsUsers.strLastName;
                TempData["UserRole"] = clsUsers.intUserRoleId;

                return View();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                TempData.Keep();
            }
        }
    }
}
