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
    [Authorize(Roles ="Admin")]
    public class LineUpController : Controller
    {
        public List<Artiest> artiesten { get; set; }

        private readonly ProjectContext _context;

        public LineUpController(ProjectContext context)
        {
            _context = context;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Line-up";
            LineUpListViewModel viewModel = new LineUpListViewModel();
            viewModel.artiesten = await _context.Artiesten.ToListAsync();
            return View(viewModel);
        }
        [Authorize(Roles ="Admin")]
        public  IActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Datum,Tijd")] LineUp lineUp)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lineUp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            CreateLineUpViewModel vm = new CreateLineUpViewModel()
            {
                Datum = lineUp.Datum,
                Tijd = lineUp.Tijd
            };
            return View(vm);  
            
        }

        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,[Bind("Datum,Tijd")]LineUp lineUp)
        {
            lineUp.LineUpID = id;
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lineUp);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LineUpExists(lineUp.LineUpID))
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
            EditLineUpViewModel vm = new EditLineUpViewModel()
            {
                Datum = lineUp.Datum,
                Tijd = lineUp.Tijd
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
            var lineUp = await _context.LineUp.FirstOrDefaultAsync(m => m.LineUpID == id);
            if (lineUp == null)
            {
                return NotFound();
            }
            DeleteLineUpViewModel vm = new DeleteLineUpViewModel()
            {
                Datum = lineUp.Datum,
                Tijd = lineUp.Tijd
            };
            return View(vm);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lineUp = await _context.LineUp.FindAsync(id);
            _context.LineUp.Remove(lineUp);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool LineUpExists(int id)
        {
            LineUp lineup = _context.LineUp.Find(id);
            if (lineup != null)
            {
                return true;
            }
            return false;
        }
    }
}
