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
    public class DelegateListController : Controller
    {
        //Dependency Injection - Data Access Layer
        private IAppDataConnectivity _IAppDataConnectivity;

        public DelegateListController(IAppDataConnectivity IAppDataConnectivity)
        {
            _IAppDataConnectivity = IAppDataConnectivity;
        }

        [Route("DelegateList")]
        public IActionResult DelegateList()
        {
            List<DelegateListGrid> colDelegateListGrid = new List<DelegateListGrid>();
            try
            {
                colDelegateListGrid = _IAppDataConnectivity.getAllDelegates();
                return View(colDelegateListGrid);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                //Release memory here in Finally block.
            }
        }

        [HttpPut]
        [Route("UpdateDelegate")]
        public ActionResult UpdateDelegate(int intDelegateId)
        {
            try
            {
                TempData["DelegateId"] = intDelegateId;
                TempData["ACTION"] = "Update";
                return Json(new { message = "OK" });
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete]
        [Route("DeleteDelegate")]
        public ActionResult DeleteDelegate(int intDelegateId)
        {
            int intDeleteCompletionStatusCode = 0;
            String message = string.Empty;
            try
            {
                intDeleteCompletionStatusCode = _IAppDataConnectivity.DeleteDelegate(intDelegateId);
                if(intDeleteCompletionStatusCode == 1)
                {
                    message = "DELEGATE_DELETED"; //Delegate Deleted
                }
                else
                {
                    message = "DELEGATE_NOT_DELETED"; //Delegate Not Deleted
                }

                return Json(new { message = message });
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
