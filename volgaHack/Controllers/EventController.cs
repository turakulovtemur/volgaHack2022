﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace volgaHack.Controllers
{
    public class EventController : Controller
    {



        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
