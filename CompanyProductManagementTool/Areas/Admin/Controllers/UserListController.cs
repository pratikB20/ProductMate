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
    public class UserListController : Controller
    {
        [Route("UserList")]
        public IActionResult UserList()
        {
            AppDataConnectivity clsAppDataConnectivity = new AppDataConnectivity();
            List<UserListGrid> ColUserListGrid = new List<UserListGrid>();
            try
            {
                ColUserListGrid = clsAppDataConnectivity.getAllUsers();
                return View(ColUserListGrid);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                clsAppDataConnectivity = null;
                ColUserListGrid = null;
            }
        }

        [HttpPut]
        [Route("UpdateUser")]
        public IActionResult UpdateUser(int intUserID)
        {
            try
            {
                TempData["UserID"] = intUserID;
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
        [Route("DeleteUser")]
        public IActionResult DeleteUser(int intUserID)
        {
            AppDataConnectivity clsAppDataConnectivity = new AppDataConnectivity();
            bool IsDeleteCompleted = false;
            String message = string.Empty;
            try
            {
                IsDeleteCompleted = clsAppDataConnectivity.DeleteUser(intUserID);
                if (IsDeleteCompleted) { message = "OK"; } else { message = "ERROR"; }
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
    }
}
