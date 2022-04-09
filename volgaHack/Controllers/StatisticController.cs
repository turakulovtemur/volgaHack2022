using BLL.Models;
using BLL.Services;
using DAL;
using DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using volgaHack.ViewModels;
using volgaHack.ViewModels.Chart;

namespace volgaHack.Controllers
{
    public class StatisticController : Controller
    {
        private IStatisticService _statisticService;
        private readonly UserManager<User> _userManager;
        private readonly IAppService _appService;

        public StatisticController(IStatisticService statisticService, UserManager<User> userManager, IAppService appService)
        {
            _statisticService = statisticService;
            _userManager = userManager;
            _appService = appService;
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

        [HttpGet()]
        public IActionResult Graphics([FromRoute] int? id)
        {
            if (id is null)
            {
                return Ok(new GraphicsDataResult
                {
                    AppId = id.Value
                });
            }

            var data = _statisticService.EventCount(new QueryStatisticModel { ApplicationId = id.Value });

            return View(new GraphicsDataResult
            {
                AppId = id.Value
            });
        }

        [HttpGet("data/{appId?}")]
        public IActionResult GetData([FromQuery] int? appId)
        {
            if(appId is null)
            {
                return Ok(new GraphicsDataResult
                {
                    AppId = appId.Value
                }); 
            }

            var app = _appService.GetApplicationById(appId.Value);
            var data = _statisticService.EventCount(new QueryStatisticModel { ApplicationId = appId.Value });
            var random = new Random();
           
            var chartData = data.EventDataCount.Select(x =>
            {
                var red = random.Next(0, 255);
                var green = random.Next(0, 255);
                var blue = random.Next(0, 255);

                return new ChartDataViewModel
                {
                    Data = x.Value,
                    Label = x.Key,
                    Color = $"rgba({red}, {green}, {blue}, 0.2)",
                    BorderColor = $"rgba({red}, {green}, {blue})"
                };
            }).ToList();

            return Ok(new GraphicsDataResult
            {
                ChartData = chartData,
                AppName = app.Name,
                AppId = appId.Value
            }); ;
        }
    }
}
