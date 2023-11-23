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

            }
        }
    }
}
