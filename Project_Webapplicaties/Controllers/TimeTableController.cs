using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_Webapplicaties.Data;
using Project_Webapplicaties.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Webapplicaties.Controllers
{
    public class TimeTableController : Controller
    {
        private readonly ProjectContext _context;

        public TimeTableController(ProjectContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Timetable";
            TimeTableListViewModel viewModel = new TimeTableListViewModel
            {
                LineUp = await _context.LineUp.ToListAsync(),
                Artiest = await _context.Artiesten.ToListAsync()
            };
            return View(viewModel);
        }
    }
            
}
