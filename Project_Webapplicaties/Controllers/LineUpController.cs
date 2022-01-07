using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_Webapplicaties.Data;
using Project_Webapplicaties.Models;
using Project_Webapplicaties.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Webapplicaties.Controllers
{
    public class LineUpController : Controller
    {
        public List<Artiest> artiesten { get; set; }

        private readonly ProjectContext _context;

        public LineUpController(ProjectContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Line-up";
            LineUpListViewModel viewModel = new LineUpListViewModel();
            viewModel.artiesten = await _context.Artiesten.ToListAsync();
            return View(viewModel);
        }
    }
}
