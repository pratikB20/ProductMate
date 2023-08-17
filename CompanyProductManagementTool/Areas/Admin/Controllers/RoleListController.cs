using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductMate.Models;
using ProductMate.Areas.Admin.Models;
using System.Data;
using System.Data.SqlClient;
using ProductMate.DatabaseConnectivity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProductMate.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoleListController : Controller
    {
        [Route("RoleList")]
        public IActionResult RoleList()
        {
            AppDataConnectivity clsAppDataConnectivity = new AppDataConnectivity();
            List<RoleListGrid> ColRoleListGrid = new List<RoleListGrid>();
            try
            {
                ColRoleListGrid = clsAppDataConnectivity.getAllRoles();
                return View(ColRoleListGrid);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                clsAppDataConnectivity = null;
                ColRoleListGrid = null;
            }
            
        }
    }
}
