﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductMate.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AddProductController : Controller
    {
        [Route("AddProduct")]
        public IActionResult AddProduct()
        {
            return View();
        }
    }
}
