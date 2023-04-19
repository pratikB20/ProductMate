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
    }
}
