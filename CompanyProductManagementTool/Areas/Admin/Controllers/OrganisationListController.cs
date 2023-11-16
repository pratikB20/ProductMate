using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductMate.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrganisationListController : Controller
    {
        [Route("OrganisationList")]
        public IActionResult OrganisationList()
        {
            return View();
        }
    }
}
