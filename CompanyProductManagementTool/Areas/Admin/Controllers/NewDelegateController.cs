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
            return View();
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
    }
}
