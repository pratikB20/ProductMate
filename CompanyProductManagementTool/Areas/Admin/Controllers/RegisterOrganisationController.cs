//IMP Session namespace to import whenever wanted to use session variables.
using Microsoft.AspNetCore.Http;
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
    public class RegisterOrganisationController : Controller
    {
        //Dependency Injection - Data Access Layer
        private IAppDataConnectivity _IAppDataConnectivity;

        public RegisterOrganisationController(IAppDataConnectivity IAppDataConnectivity)
        {
            _IAppDataConnectivity = IAppDataConnectivity;
        }

        [Route("RegisterOrganisation")]
        public IActionResult RegisterOrganisation()
        {
            ViewBag.ddlDelegate = (List<SelectListItem>)_IAppDataConnectivity.getDelegates();
            return View();
        }

        [Route("SaveOrganisation")]
        public IActionResult SaveOrganisation(Organisation clsOrganisation, int intContractTenure)
        {
            Boolean IsOrganisationAdded = false;
            String message = string.Empty;
            Users clsLoggedInUser = new Users();
            try
            {
                //Inserting the organisation into the system
                clsOrganisation.dteCreateDate = DateTime.Now;
                clsLoggedInUser = HttpContext.Session.GetObjectFromJson<Users>("User");
                clsOrganisation.intCreatedBy = clsLoggedInUser.intUsersId;

                //Contract end date set as per plan
                if(intContractTenure == 1) { clsOrganisation.dteContractToDate = clsOrganisation.dteContractFromDate.AddYears(1); }
                else if(intContractTenure == 2) { clsOrganisation.dteContractToDate = clsOrganisation.dteContractFromDate.AddYears(3); }
                else { clsOrganisation.dteContractToDate = clsOrganisation.dteContractFromDate.AddYears(5); }

                IsOrganisationAdded = _IAppDataConnectivity.SaveOrganisation(clsOrganisation);

                message = (IsOrganisationAdded) ? "OK" : "ERROR";

                return Json(new { message = message });
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                clsLoggedInUser = null;
            }
        }
    }
}
