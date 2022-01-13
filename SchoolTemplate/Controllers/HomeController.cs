using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SchoolTemplate.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using SchoolTemplate.UtilityServices;
using Microsoft.Extensions.Configuration;
using SchoolBusiness.Interfaces;
using SchoolTemplate.Helpers;
using SchoolEntities.Enumerators;

namespace SchoolTemplate.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IHomeBusiness _homeBusiness;

        public HomeController(IHomeBusiness homeBusiness, IBaseBusiness baseBusiness) : base (baseBusiness)
        {
            _homeBusiness = homeBusiness;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
