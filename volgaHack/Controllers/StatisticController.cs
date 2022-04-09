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

        [HttpGet()]
        public IActionResult Graphics([FromRoute] int? id)
        {
            if (id is null)
            {
                return Ok(new GraphicsDataResult
                {
                    Data = new List<int>(),
                    AppId = id.Value
                });
            }

            var data = _statisticService.EventCount(new QueryStatisticModel { ApplicationId = id.Value });

            return View(new GraphicsDataResult
            {
                Data = data.EventDataCount.Select(x=> x.Value).ToList(),
                Labels = data.EventDataCount.Select(x=> x.Key).ToList(),
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
                    Data = new List<int>(),
                    AppId = appId.Value
                }); 
            }

            var data = _statisticService.EventCount(new QueryStatisticModel { ApplicationId = appId.Value });

            return Ok(new GraphicsDataResult
            {
                Data = data.EventDataCount.Select(x => x.Value).ToList(),
                Labels = data.EventDataCount.Select(x => x.Key).ToList(),
                AppId = appId.Value
            });
        }
    }
}
