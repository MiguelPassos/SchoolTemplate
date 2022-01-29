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
using SchoolEntities;

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
            HomeViewModel homeViewModel = new HomeViewModel();
            
            homeViewModel.AcademicMembers.Add(new AcademicMemberModelView() { Name = "Danny Awesome", Function = "Manager", Description = "This is Photoshop's version  of Lorem Ipsum. Proin gravida nibh...", Picture = "images/faculty-mb1.jpg" });
            homeViewModel.AcademicMembers.Add(new AcademicMemberModelView() { Name = "Kimberly Richiez", Function = "Russian Teacher", Description = "This is Photoshop's version  of Lorem Ipsum. Proin gravida nibh...", Picture = "images/faculty-mb2.jpg" });
            homeViewModel.AcademicMembers.Add(new AcademicMemberModelView() { Name = "Dylan Taylor", Function = "English Teacher", Description = "This is Photoshop's version  of Lorem Ipsum. Proin gravida nibh...", Picture = "images/faculty-mb3.jpg" });
            homeViewModel.AcademicMembers.Add(new AcademicMemberModelView() { Name = "Simon Grishaber", Function = "Health Teacher", Description = "This is Photoshop's version  of Lorem Ipsum. Proin gravida nibh...", Picture = "images/faculty-mb4.jpg" });
            homeViewModel.AcademicMembers.Add(new AcademicMemberModelView() { Name = "Simon Grishaber", Function = "Health Teacher", Description = "This is Photoshop's version  of Lorem Ipsum. Proin gravida nibh...", Picture = "images/faculty-mb5.jpg" });
            homeViewModel.AcademicMembers.Add(new AcademicMemberModelView() { Name = "Simon Grishaber", Function = "Health Teacher", Description = "This is Photoshop's version  of Lorem Ipsum. Proin gravida nibh...", Picture = "images/faculty-mb6.jpg" });
            homeViewModel.AcademicMembers.Add(new AcademicMemberModelView() { Name = "Simon Grishaber", Function = "Health Teacher", Description = "This is Photoshop's version  of Lorem Ipsum. Proin gravida nibh...", Picture = "images/faculty-mb7.jpg" });
            homeViewModel.AcademicMembers.Add(new AcademicMemberModelView() { Name = "Simon Grishaber", Function = "Health Teacher", Description = "This is Photoshop's version  of Lorem Ipsum. Proin gravida nibh...", Picture = "images/faculty-mb8.jpg" });

            return View(homeViewModel);
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
