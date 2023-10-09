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
        //Dependency Injection - Data Access Layer
        public IAppDataConnectivity _IAppDataConnectivity;

        public RoleListController(IAppDataConnectivity IAppDataConnectivity)
        {
            _IAppDataConnectivity = IAppDataConnectivity;
        }

        [Route("RoleList")]
        public IActionResult RoleList()
        {
            List<RoleListGrid> ColRoleListGrid = new List<RoleListGrid>();
            try
            {
                ColRoleListGrid = _IAppDataConnectivity.getAllRoles();
                return View(ColRoleListGrid);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ColRoleListGrid = null;
            }
        }

        [HttpPut]
        [Route("UpdateUserRole")]
        public ActionResult UpdateUserRole(int intUserRolesId)
        {
            try
            {
                TempData["UserRoleID"] = intUserRolesId;
                TempData["ACTION"] = "Update";
                return Json(new { message = "OK" });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                TempData.Keep();
            }
        }

        [HttpDelete]
        [Route("DeleteUserRole")]
        public ActionResult DeleteUserRole(int intUserRolesId)
        {
            bool IsDeleteCompleted = false;
            String message = string.Empty;
            try
            {
                IsDeleteCompleted = _IAppDataConnectivity.DeleteUserRole(intUserRolesId);
                if (IsDeleteCompleted) { message = "OK"; } else { message = "ERROR"; }
                return Json(new { message = message });
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
