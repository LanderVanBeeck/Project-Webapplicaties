using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Webapplicaties.Controllers
{
    public class TimeTableController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Timetable";
            return View();
        }
    }
}
