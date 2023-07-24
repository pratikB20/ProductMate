using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductMate.Areas.Admin.Controllers
{
    [Route("Admin")]
    public class NewRoleController : Controller
    {
        [Route("NewRole")]
        public IActionResult NewRole()
        {
            return View();
        }
    }
}
