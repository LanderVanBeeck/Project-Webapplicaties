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
    public class TicketController : Controller
    {
        public List<Ticket> tickets;

        private readonly ProjectContext _context;
        public TicketController(ProjectContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            TicketListViewModel viewModel = new TicketListViewModel();
            viewModel.Tickets = await _context.Tickets.ToListAsync();
            return View(viewModel);
        }
        public IActionResult Search(TicketListViewModel viewModel)
        {
            if (!string.IsNullOrEmpty(viewModel.TicketSearch))
            {
                viewModel.Tickets = tickets.Where(b => b.Type.Contains(viewModel.TicketSearch)).ToList();
            }
            else
            {
                viewModel.Tickets = tickets;
            }
            return View("Index", viewModel);
        }
    }
}
