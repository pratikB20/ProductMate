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
    public class UserListController : Controller
    {
        [Route("UserList")]
        public IActionResult UserList()
        {
            AppDataConnectivity clsAppDataConnectivity = new AppDataConnectivity();
            List<Users> ColUsers = new List<Users>();
            try
            {
                ColUsers = clsAppDataConnectivity.getAllUsers();
                return View(ColUsers);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                clsAppDataConnectivity = null;
                ColUsers = null;
            }
        }
    }
}
