using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project_Webapplicaties.Areas.Identity.Data;
using Project_Webapplicaties.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Webapplicaties.Controllers
{
    public class GebruikerController : Controller
    {
        private UserManager<CustomUser> _userManager;

        public GebruikerController(UserManager<CustomUser> userManager)
        {
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            GebruikerListViewModel viewModel = new GebruikerListViewModel()
            {
                Gebruikers = _userManager.Users.ToList()
            };
            return View(viewModel);
        }

        public IActionResult Details(string id)
        {
            CustomUser gebruiker = _userManager.Users.Where(k => k.Id == id).FirstOrDefault();
            if (gebruiker != null)
            {
                GebruikerDetailsViewModel viewModel = new GebruikerDetailsViewModel()
                {
                    Id = gebruiker.Id,
                    Naam = gebruiker.Naam,
                    UserName = gebruiker.UserName,
                    GeboorteDatum = gebruiker.GeboorteDatum
                };
                return View(viewModel);
            }
            else
            {
                GebruikerListViewModel viewModel = new GebruikerListViewModel()
                {
                    Gebruikers = _userManager.Users.ToList()
                };
                return View("Index", viewModel);
            }
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateGebruikerViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                CustomUser gebruiker = new CustomUser()
                {
                    Naam = viewModel.Naam,
                    GeboorteDatum = viewModel.GeboorteDatum,
                    UserName = viewModel.Email,
                    Email = viewModel.Email
                };

                IdentityResult result = await _userManager.CreateAsync(gebruiker, viewModel.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            CustomUser user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", "User Not Found");
                    }
                }
            }
            return View("Index", _userManager.Users.ToList());
        }
    }
}
