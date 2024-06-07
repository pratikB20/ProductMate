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
    public class OrganisationListController : Controller
    {
        //Dependency Injection - Data Access Layer
        public IAppDataConnectivity _IAppDataConnectivity;

        public OrganisationListController(IAppDataConnectivity IAppDataConnectivity)
        {
            _IAppDataConnectivity = IAppDataConnectivity;
        }

        [Route("OrganisationList")]
        public IActionResult OrganisationList()
        {
            List<OrganisationListGrid> ColOrganisationListGrid = new List<OrganisationListGrid>();
            try
            {
                ColOrganisationListGrid = _IAppDataConnectivity.getAllOrganisations();
                return View(ColOrganisationListGrid);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                ColOrganisationListGrid = null;
            }
        }

        [HttpPut]
        [Route("UpdateOrganisation")]
        public ActionResult UpdateOrganisation(int intOrganisationId)
        {
            try
            {
                TempData["OrganisationId"] = intOrganisationId;
                TempData["ACTION"] = "Update";
                return Json(new { message = "OK" });
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                TempData.Keep();
            }
        }

        [HttpDelete]
        [Route("DeleteOrganisation")]
        public ActionResult DeleteOrganisation(int intOrganisationId)
        {
            bool IsDeleteCompleted = false;
            String message = string.Empty;
            try
            {
                IsDeleteCompleted = _IAppDataConnectivity.DeleteOrganisation(intOrganisationId);
                if (IsDeleteCompleted) { message = "OK"; } else { message = "ERROR"; };
                return Json(new { message = message });
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
