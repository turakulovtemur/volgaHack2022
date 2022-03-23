using DAL;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using volgaHack.ViewModels;

namespace volgaHack.Controllers
{

    [Authorize]
    public class ApplicationController : Controller
    {
        ApplicationContext context;
        private readonly UserManager<User> _userManager;

        public ApplicationController(ApplicationContext db, UserManager<User> userManager)
        {
            context = db;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ApplicationViewModel model)
        {

            if (ModelState.IsValid)
            {
                var userName = Request.HttpContext.User.Identity.Name;
                var user = await _userManager.FindByEmailAsync(userName);
                Applications application = new Applications
                {
                    Id = model.Id,
                    Name = model.Name,
                    Description = model.Description,
                    DateCreatedApp = DateTime.Today,
                    UserId = user?.Id
                };

                context.Applications.Add(application);
                await context.SaveChangesAsync();

                return RedirectToActionPermanent("Index");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit([FromRoute] int? id)
        {
            Applications app = await context.Applications.FindAsync(id);

            if (id == null)
            {
                return NotFound();
            }
            if (app == null)
            {
                return NotFound();
            }

            return View(app);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(ApplicationViewModel model)
        {
            if (ModelState.IsValid)
            {
                ModelState.AddModelError("Error", "Не валидная модель");
            }


            var userName = User.Identity.Name;
            var user = await _userManager.FindByEmailAsync(userName);

            Applications app = context.Applications.Find(model.Id);

            app.Name = model.Name;
            app.Description = model.Description;
            app.DateCreatedApp = model.DateCreatedApp;
            app.UserId = user.Id;

            context.Applications.Update(app);
            await context.SaveChangesAsync();

            return RedirectToActionPermanent("Index");

        }

        [HttpGet]
        public ActionResult Delete([FromRoute] int? id)
        {
            if (id == null)
            {
                return new NotFoundResult();
            }
            var app = context.Applications.FirstOrDefault(r => r.Id == id);
            if (app == null)
            {
                return new NotFoundResult();
            }
            return View(app);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            var app = await context.Applications.FindAsync(id);
            context.Applications.Remove(app);
            await context.SaveChangesAsync();
            return RedirectToAction("Index", "Application");
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            var userName = User.Identity.Name;

            var user = await _userManager.FindByEmailAsync(userName);
            var apps = context.Applications
                .Where(x => x.UserId == user.Id)
                .Select(app => new ApplicationViewModel
                {
                    Id = app.Id,
                    Name = app.Name,
                    Description = app.Description,
                    DateCreatedApp = app.DateCreatedApp
                }).ToList();


            return View(apps);
        }
    }
}
