using Microsoft.AspNetCore.Mvc;
using Project_Webapplicaties.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Webapplicaties.Controllers
{
    public class LineUpController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Line-up";
            return View();
        }
    }
}
