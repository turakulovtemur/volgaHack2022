using BLL.Models;
using BLL.Services;
using DAL;
using DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using volgaHack.ViewModels;

namespace volgaHack.Controllers
{
    public class StatisticController : Controller
    {
        private IStatisticService _statisticService;
        private readonly UserManager<User> _userManager;

        public StatisticController(IStatisticService statisticService, UserManager<User> userManager)
        {
            _statisticService = statisticService;
            _userManager = userManager;
        }
        

        [HttpGet]
        public IActionResult Index([FromRoute] int? id)
        {
            if(id is null)
            {

                ModelState.AddModelError("id", "Не изестное приложение");

                return View();
            }

            var statistics = _statisticService.Query(new QueryStatisticModel
            {
                ApplicationId = id.Value
            }).ToList();



            return View(statistics);
        }

        //[HttpPost]
        //public IActionResult StatisticQuery([FromBody] StatisticQueryRequest  model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(new StatisticQueryViewModel()
        //        {
        //        });
        //    }
        //}

    }
}
