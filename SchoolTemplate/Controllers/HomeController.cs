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
        public IActionResult Index([FromQuery]string recoveryKey)
        {
            if (!string.IsNullOrEmpty(recoveryKey))
                return PartialView("_ResetAccess", new UserViewModel());

            HomeViewModel homeViewModel = new HomeViewModel();

            homeViewModel.AcademicMembers = GetAcademicMembers();

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

        #region Métodos Auxiliares

        private List<AcademicMemberModelView> GetAcademicMembers() 
        {
            try
            {
                List<AcademicMemberModelView> listMembersModelView = new List<AcademicMemberModelView>();

                var employeesProfiles = _homeBusiness.GetRandomEmployeesProfiles();

                foreach (var item in employeesProfiles)
                {
                    AcademicMemberModelView memberModelView = new AcademicMemberModelView()
                    {
                        ID = item.IdPerfil,
                        Name = string.Concat(item.Funcionario.Nome, " ", item.Funcionario.Sobrenome),
                        Function = item.Titulo,
                        Description = item.Informacoes,
                        Picture = item.Imagem,
                    };

                    listMembersModelView.Add(memberModelView);
                }

                return listMembersModelView;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
