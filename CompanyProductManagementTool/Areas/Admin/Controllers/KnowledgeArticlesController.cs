using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductMate.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class KnowledgeArticlesController : Controller
    {
        [Route("KnowledgeArticles")]
        public IActionResult KnowledgeArticles()
        {
            return View();
        }
    }
}
