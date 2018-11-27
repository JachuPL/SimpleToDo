﻿using Microsoft.AspNetCore.Mvc;
using SimpleToDo.Models.View;
using System.Diagnostics;

namespace SimpleToDo.WebApp.Controllers
{
    public class HomeController : Controller
    {
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}