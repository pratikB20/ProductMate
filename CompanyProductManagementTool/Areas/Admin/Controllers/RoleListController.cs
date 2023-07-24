using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductMate.Areas.Admin.Controllers
{
    [Route("Admin")]
    public class RoleListController : Controller
    {
        [Route("RoleList")]
        public IActionResult RoleList()
        {
            return View();
        }
    }
}
