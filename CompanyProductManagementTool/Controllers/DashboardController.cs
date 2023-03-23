using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductMate.Models;

namespace CompanyProductManagementTool.Controllers
{
    public class DashboardController : Controller
    {
        public ActionResult Dashboard()
        {
            int intUserRole = 0;
            try
            {
                //This code is used to persist role even when refreshed the Dashboard page
                intUserRole = (int)TempData["UserRole"];
                TempData["UserRole"] = intUserRole;
                return View();
            }
            catch(Exception ex)
            {
                return View();
            }
            finally
            {
                TempData.Keep();
            }
        }
    }
}
