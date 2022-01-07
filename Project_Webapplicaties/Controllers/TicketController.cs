using Microsoft.AspNetCore.Authorization;
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
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            TicketListViewModel viewModel = new TicketListViewModel();
            viewModel.Tickets = await _context.Tickets.ToListAsync();
            return View(viewModel);
        }
        [Authorize(Roles ="Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TicketID,Type,Beschrijving,Vip,Prijs")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ticket);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            CreateTicketVIewModel vm = new CreateTicketVIewModel()
            {
                Type = ticket.Type,
                Beschrijving = ticket.Beschrijving,
                Vip = ticket.Vip,
                Prijs = ticket.Prijs
            };
            return View(vm);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Ticket ticket = await _context.Tickets.FindAsync(id);

            if (ticket == null)
            {
                return NotFound();
            }

            EditTicketViewModel vm = new EditTicketViewModel()
            {
                Type = ticket.Type,
                Beschrijving = ticket.Beschrijving,
                Vip = ticket.Vip,
                Prijs = ticket.Prijs
            };
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,[Bind("Type,Beschrijving,Vip,Prijs")]Ticket ticket)
        {
            ticket.TicketID = id;
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ticket);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TicketExists(ticket.TicketID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            EditTicketViewModel vm = new EditTicketViewModel()
            {
                Type = ticket.Type,
                Beschrijving = ticket.Beschrijving,
                Vip = ticket.Vip,
                Prijs = ticket.Prijs
            };
            return View(vm);
        }
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var ticket = await _context.Tickets.FirstOrDefaultAsync(m => m.TicketID == id);
            if (ticket == null)
            {
                return NotFound();
            }
            DeleteTicketViewModel vm = new DeleteTicketViewModel()
            {
                Type = ticket.Type,
                Beschrijving = ticket.Beschrijving,
                Vip = ticket.Vip,
                Prijs = ticket.Prijs
            };
            return View(vm);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ticket = await _context.Tickets.FindAsync(id);
            _context.Tickets.Remove(ticket);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            
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
        private bool TicketExists(int id)
        {
            Ticket ticket = _context.Tickets.Find(id);
            if (ticket != null)
            {
                return true;
            }
            return false;
        }
    }
}
