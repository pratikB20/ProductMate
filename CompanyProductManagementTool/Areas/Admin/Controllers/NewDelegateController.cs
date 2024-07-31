using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductMate.Models;
using ProductMate.DatabaseConnectivity;

namespace ProductMate.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class NewDelegateController : Controller
    {
        //Dependency Injection - Data Access Layer
        private IAppDataConnectivity _IAppDataConnectivity;

        public NewDelegateController(IAppDataConnectivity IAppDataConnectivity)
        {
            _IAppDataConnectivity = IAppDataConnectivity;
        }

        [Route("NewDelegate")]
        public IActionResult NewDelegate()
        {
            Delegates clsDelegates = new Delegates();
            int intDelegateId = 0;
            try
            {
                if((string)TempData["ACTION"] != null)
                {
                    TempData["ACTION"] = "Update";
                    intDelegateId = (int)TempData["DelegateId"];
                    clsDelegates = _IAppDataConnectivity.getDelegatesDetailsByDelegateId(intDelegateId);
                    TempData["DelegateId"] = intDelegateId;
                    ViewBag.strDelegateName = clsDelegates.strDelegateName;
                    ViewBag.strDelegateContact = clsDelegates.strDelegateContact;
                    ViewBag.strDelegateEmailId = clsDelegates.strDelegateEmailId;
                    ViewBag.intStatus = clsDelegates.intStatus;
                    return View();
                }
                else
                {
                    //TempData["ACTIVE"] = "Save"; //Commented due to null issue while 2nd time coming to this page due to this save action
                    ViewBag.strDelegateName = null;
                    ViewBag.strDelegateContact = null;
                    ViewBag.strDelegateEmailId = null;
                    ViewBag.intStatus = null;
                    return View();
                }             
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [Route("SaveDelegate")]
        public IActionResult SaveDelegate(Delegates clsDelegates)
        {
            Boolean IsDelegateAdded = false;
            string message = string.Empty;
            Users clsLoggedUser = new Users();
            try
            {
                //Inserting the new delegate
                clsDelegates.dteCreateDate = DateTime.Now;
                clsLoggedUser = HttpContext.Session.GetObjectFromJson<Users>("User");
                clsDelegates.intCreatedBy = clsLoggedUser.intUsersId;

                IsDelegateAdded = _IAppDataConnectivity.SaveDelegate(clsDelegates);

                message = (IsDelegateAdded) ? "OK" : "ERROR";

                return Json(new { message = message });
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut]
        [Route("UpdateSelectedDelegate")]
        public ActionResult UpdateSelectedDelegate(Delegates clsDelegates)
        {
            Boolean IsDelegateUpdated = false;
            string message = string.Empty;
            try
            {
                clsDelegates.dteCreateDate = DateTime.Now;
                clsDelegates.intDelegatesId = (int)TempData["DelegateId"];

                IsDelegateUpdated = _IAppDataConnectivity.UpdateDelegate(clsDelegates);

                message = (IsDelegateUpdated) ? "OK" : "ERROR";

                return Json(new { message = message });
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
