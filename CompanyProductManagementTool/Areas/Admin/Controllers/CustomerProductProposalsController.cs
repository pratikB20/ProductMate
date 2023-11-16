using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductMate.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CustomerProductProposalsController : Controller
    {
        [Route("CustomerProductProposals")]
        public IActionResult CustomerProductProposals()
        {
            return View();
        }
    }
}
