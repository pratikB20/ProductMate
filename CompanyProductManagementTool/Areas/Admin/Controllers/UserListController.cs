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
        //Dependency Injection - Data Access Layer
        private IAppDataConnectivity _IAppDataConnectivity;

        public UserListController(IAppDataConnectivity IAppDataConnectivity) 
        {
            _IAppDataConnectivity = IAppDataConnectivity;
        }

        [Route("UserList")]
        public IActionResult UserList()
        {
            List<UserListGrid> ColUserListGrid = new List<UserListGrid>();
            try
            {
                ColUserListGrid = _IAppDataConnectivity.getAllUsers();
                return View(ColUserListGrid);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
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
            bool IsDeleteCompleted = false;
            String message = string.Empty;
            try
            {
                IsDeleteCompleted = _IAppDataConnectivity.DeleteUser(intUserID);
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
