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

        public HomeController(IHomeBusiness homeBusiness, IBaseBusiness baseBusiness) : base (baseBusiness) => _homeBusiness = homeBusiness;

        [HttpGet]
        public IActionResult Index()
        {
            HomeViewModel homeViewModel = new HomeViewModel();

            homeViewModel.NewsEvents = GetLatestEvents().OrderBy(x => x.EventDate).ToList();
            homeViewModel.AcademicMembers = GetAcademicMembers();

            return View(homeViewModel);
        }

        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }

        [HttpGet]
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

        private List<EventViewModel> GetLatestEvents()
        {
            List<EventViewModel> eventList = new List<EventViewModel>();

            try
            {
                var events = _homeBusiness.GetLatestFourEvents();

                foreach (var evt in events)
                {
                    EventViewModel eventViewModel = new EventViewModel()
                    {
                        ID = evt.IdEvento,
                        Description = evt.Titulo,
                        UriImage = evt.Imagem,
                        EventDate = evt.DataInicio,
                        CreationDate = evt.DataCriacao,
                        Author = evt.Autor,
                    };

                    eventList.Add(eventViewModel);
                }

                return eventList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
