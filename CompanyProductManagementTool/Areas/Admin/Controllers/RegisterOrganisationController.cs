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
            Organisation clsOrganisation = new Organisation();
            int intOrganisationId = 0;
            try
            {
                if ((string)TempData["ACTION"] != null)
                {
                    TempData["ACTION"] = "Update";
                    intOrganisationId = (int)TempData["OrganisationId"];
                    ViewBag.ddlDelegate = (List<SelectListItem>)_IAppDataConnectivity.getDelegates();
                    clsOrganisation = _IAppDataConnectivity.GetOrganisationDetailsByOrganisationId(intOrganisationId);
                    TempData["OrganisationId"] = intOrganisationId;
                    //Set Values
                    ViewBag.strOrganisationName = clsOrganisation.strOrganisationName;
                    ViewBag.intDelegateId = clsOrganisation.intDelegateId;
                    //Take contract tenture difference by subtracting difference between the contract year.
                    int intContractTenureDiff = clsOrganisation.dteContractToDate.Year - clsOrganisation.dteContractFromDate.Year;
                    if (intContractTenureDiff == 1) { ViewBag.intContractTenure = 1; }
                    else if (intContractTenureDiff == 3) { ViewBag.intContractTenure = 2; }
                    else { ViewBag.intContractTenure = 3; }
                    
                    ViewBag.intOrganisationStatus = clsOrganisation.intOrganisationStatus;
                    ViewBag.dteContractFromDate = DateTime.Parse(clsOrganisation.dteContractFromDate.ToString()).ToString("dd/MM/yyyy"); //Getting only date, excluding Time format.

                    return View();
                }
                else
                {
                    //TempData["ACTIVE"] = "Save"; //Commented due to null issue while 2nd time coming to this page due to this save action
                    ViewBag.ddlDelegate = (List<SelectListItem>)_IAppDataConnectivity.getDelegates();
                    //Set Null Values
                    ViewBag.strOrganisationName = null;
                    ViewBag.intDelegateId = null;
                    ViewBag.intContractTenure = null;
                    ViewBag.intOrganisationStatus = null;
                    ViewBag.dteContractFromDate = null;
                    return View();
                }

                
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
               
            }
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

        [HttpPut]
        [Route("UpdateSelectedOrganisation")]
        public ActionResult UpdateSelectedOrganisation(Organisation clsOrganisation, int intContractTenure)
        {
            Boolean IsOrganisationUpdated = false;
            string message = string.Empty;
            try
            {
                clsOrganisation.dteCreateDate = DateTime.Now;
                clsOrganisation.intOranisationId = (int)TempData["OrganisationId"];
                //Contract end date set as per plan
                if (intContractTenure == 1) { clsOrganisation.dteContractToDate = clsOrganisation.dteContractFromDate.AddYears(1); }
                else if (intContractTenure == 2) { clsOrganisation.dteContractToDate = clsOrganisation.dteContractFromDate.AddYears(3); }
                else { clsOrganisation.dteContractToDate = clsOrganisation.dteContractFromDate.AddYears(5); }

                IsOrganisationUpdated = _IAppDataConnectivity.UpdateOrganisation(clsOrganisation);

                message = (IsOrganisationUpdated) ? "OK" : "ERROR";

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
