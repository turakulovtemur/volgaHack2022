using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using volgaHack.Models;
using volgaHack.ViewModels;

namespace volgaHack.Controllers
{
    public class EventController : Controller
    {
        ApplicationContext context;
        private readonly UserManager<User> _userManager;

        public EventController(ApplicationContext db, UserManager<User> userManager)
        {
            context = db;
            _userManager = userManager;
        }


        [HttpGet]
        public IActionResult Create([FromRoute] int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            return View(new EventViewModel
            {
                ApplicationId = id.Value
            });

        }

        [HttpPost]
        public async Task<IActionResult> Create(EventViewModel model)
        {
            if (ModelState.IsValid)
            {
  
                Events events = new Events
                {
                    Name = model.Name,
                    Description = model.Description,
                    DateCreatedEvent = model.EventDate,
                    ApplicationId = model.ApplicationId
                };

                context.Events.Add(events);
                await context.SaveChangesAsync();
                return RedirectToAction("Index","Application");
            }
            return View(model);
        }


        [HttpGet]
        public IActionResult EventList([FromRoute] int? id)
        {
            var events = context.Events
              .Where(x => x.ApplicationId == id)
              .Select(app => new EventViewModel
              {
                  Id = app.Id,
                  Name = app.Name,
                  Description = app.Description,
                  EventDate = (DateTime)(app.DateCreatedEvent)
              }).ToList();


            if (id == null)
            {
                return NotFound();
            }

            if (events == null)
            {
                return NotFound();
            }

            var viewModel = new EventListViewModel()
            {
                ApplicationId = id.Value,
                EventList = events
            };

            return View(viewModel);

        }

        [HttpPost]
        public IActionResult EventList(EventViewModel model)
        {
            if (ModelState.IsValid)
            {
                ModelState.AddModelError("Error", "Не валидная модель");
            }


            //Events app = context.Events.Find(model.Id);
            var apps = context.Events
               .Where(x => x.Id == model.Id)
               .Select(app => new EventViewModel
               {
                   Id = app.Id,
                   Name = app.Name,
                   Description = app.Description,
                   EventDate = (DateTime)(app.DateCreatedEvent)
               }).ToList();

            return View(apps);
        }


        [HttpGet]
        public IActionResult Index()
        {

            return View();
        }
    }
}
