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

namespace SchoolTemplate.Controllers
{
    public class HomeController : Controller
    {
        private IHomeBusiness HomeBusiness { get; }

        public HomeController(IHomeBusiness homeBusiness)
        {
            HomeBusiness = homeBusiness;
        }

        public IActionResult Index()
        {
            List<MenuModelView> listMenu = null;

            HomeBusiness.MetodoTeste();

            if (User.Identity.IsAuthenticated)
                listMenu = GetParentMenuItems();
            else
                listMenu = GetMenuItems();

            return View(listMenu);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(string username, string password, int remember)
        {
            if (username == "miguelpassos" && password == "12345")
                Login(new UserViewModel() { UserName = "Miguel Passos", RememberMe = Convert.ToBoolean(remember) });
            else
                TempData["Message"] = Common.ShowAlert(Enuns.ETypeAlert.Error, "Usuário e/ou Senha inválidos!");

            return RedirectToAction("Index");
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

        private async void Login(UserViewModel user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, "Default")
            };

            var claimsIdentity = new ClaimsIdentity(claims, "Login");
            ClaimsPrincipal claimPrincipal = new ClaimsPrincipal(claimsIdentity);

            var authenticationProperties = new AuthenticationProperties
            {
                AllowRefresh = true,
                ExpiresUtc = DateTime.Now.ToLocalTime().AddMinutes(30),
                IsPersistent = user.RememberMe
            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimPrincipal, authenticationProperties);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index");
        }

        private List<MenuModelView> GetMenuItems()
        {
            List<MenuModelView> listMenu = new List<MenuModelView>();

            #region Home

            MenuModelView menuHome = new MenuModelView();
            menuHome.IdMenu = 1;
            menuHome.Text = "Home";
            menuHome.ActionName = "Index";
            menuHome.ControllerName = "Home";

            listMenu.Add(menuHome);

            #endregion

            #region Institucional

            MenuModelView menuInstitucional = new MenuModelView();
            menuInstitucional.IdMenu = 2;
            menuInstitucional.Text = "Institucional";

            MenuModelView principalOpinion = new MenuModelView();
            principalOpinion.IdMenu = 3;
            principalOpinion.IdParent = 2;
            principalOpinion.Text = "Palavra do Diretor";
            principalOpinion.ActionName = "PrincipalOpinion";
            principalOpinion.ControllerName = "Institutional";
            
            menuInstitucional.SubMenus.Add(principalOpinion);

            MenuModelView proposal = new MenuModelView();
            proposal.IdMenu = 4;
            proposal.IdParent = 2;
            proposal.Text = "Proposta";
            proposal.ActionName = "Proposal";
            proposal.ControllerName = "Institutional";

            menuInstitucional.SubMenus.Add(proposal);

            MenuModelView pedagogiaHumanista = new MenuModelView();
            pedagogiaHumanista.IdMenu = 5;
            pedagogiaHumanista.IdParent = 2;
            pedagogiaHumanista.Text = "Pedagogia Humanista";
            pedagogiaHumanista.ActionName = "HumanistPedagogy";
            pedagogiaHumanista.ControllerName = "Institutional";            
            
            menuInstitucional.SubMenus.Add(pedagogiaHumanista);

            MenuModelView regulamentoInterno = new MenuModelView();
            regulamentoInterno.IdMenu = 6;
            regulamentoInterno.IdParent = 2;
            regulamentoInterno.Text = "Regulamento Interno";
            regulamentoInterno.ActionName = "InternalRegulation";
            regulamentoInterno.ControllerName = "Institutional";

            menuInstitucional.SubMenus.Add(regulamentoInterno);

            MenuModelView calendario = new MenuModelView();
            calendario.IdMenu = 7;
            calendario.IdParent = 2;
            calendario.Text = "Calendário";
            calendario.ActionName = "Calendary";
            calendario.ControllerName = "Institutional";

            menuInstitucional.SubMenus.Add(calendario);

            MenuModelView matricula = new MenuModelView();
            matricula.IdMenu = 8;
            matricula.IdParent = 2;
            matricula.Text = "Matrícula";
            matricula.ActionName = "Registration";
            matricula.ControllerName = "Institutional";

            menuInstitucional.SubMenus.Add(matricula);

            MenuModelView galeria = new MenuModelView();
            galeria.IdMenu = 9;
            galeria.IdParent = 2;
            galeria.Text = "Galeria";
            galeria.ActionName = "Gallery";
            galeria.ControllerName = "Institutional";

            menuInstitucional.SubMenus.Add(galeria);

            listMenu.Add(menuInstitucional);

            #endregion

            #region Cursos

            MenuModelView menuCursos = new MenuModelView();
            menuCursos.IdMenu = 3;
            menuCursos.Text = "Cursos";

            MenuModelView infantil = new MenuModelView();
            infantil.IdMenu = 3;
            infantil.IdParent = 3;
            infantil.Text = "Infantil";
            infantil.ActionName = "Child";
            infantil.ControllerName = "Courses";

            menuCursos.SubMenus.Add(infantil);

            MenuModelView fundamental1 = new MenuModelView();
            fundamental1.IdMenu = 3;
            fundamental1.IdParent = 3;
            fundamental1.Text = "Fundamental I";
            fundamental1.ActionName = "ElementaryI";
            fundamental1.ControllerName = "Courses";

            menuCursos.SubMenus.Add(fundamental1);

            MenuModelView fundamental2 = new MenuModelView();
            fundamental2.IdMenu = 3;
            fundamental2.IdParent = 3;
            fundamental2.Text = "Fundamental II";
            fundamental2.ActionName = "ElementaryII";
            fundamental2.ControllerName = "Courses";

            menuCursos.SubMenus.Add(fundamental2);

            MenuModelView ensinoMedio = new MenuModelView();
            ensinoMedio.IdMenu = 3;
            ensinoMedio.IdParent = 3;
            ensinoMedio.Text = "Ensino Médio";
            ensinoMedio.ActionName = "HighSchool";
            ensinoMedio.ControllerName = "Courses";

            menuCursos.SubMenus.Add(ensinoMedio);

            MenuModelView integral = new MenuModelView();
            integral.IdMenu = 3;
            integral.IdParent = 3;
            integral.Text = "Integral";
            integral.ActionName = "FullTeaching";
            integral.ControllerName = "Courses";

            menuCursos.SubMenus.Add(integral);

            listMenu.Add(menuCursos);

            #endregion

            #region Lema+

            MenuModelView menuLemaPlus = new MenuModelView();
            menuLemaPlus.IdMenu = 4;
            menuLemaPlus.Text = "Lema+";

            MenuModelView karate = new MenuModelView();
            karate.IdMenu = 3;
            karate.IdParent = 4;
            karate.Text = "Karatê";
            karate.ActionName = "Karate";
            karate.ControllerName = "ExtraCourses";

            menuLemaPlus.SubMenus.Add(karate);

            MenuModelView ingles = new MenuModelView();
            ingles.IdMenu = 3;
            ingles.IdParent = 4;
            ingles.Text = "Inglês";
            ingles.ActionName = "English";
            ingles.ControllerName = "ExtraCourses";

            menuLemaPlus.SubMenus.Add(ingles);

            MenuModelView ballet = new MenuModelView();
            ballet.IdMenu = 3;
            ballet.IdParent = 4;
            ballet.Text = "Ballet";
            ballet.ActionName = "Ballet";
            ballet.ControllerName = "ExtraCourses";

            menuLemaPlus.SubMenus.Add(ballet);

            MenuModelView musica = new MenuModelView();
            musica.IdMenu = 3;
            musica.IdParent = 4;
            musica.Text = "Música";
            musica.ActionName = "Music";
            musica.ControllerName = "ExtraCourses";

            menuLemaPlus.SubMenus.Add(musica);

            listMenu.Add(menuLemaPlus);

            #endregion

            #region Instalações

            MenuModelView menuInstalacoes = new MenuModelView();
            menuInstalacoes.IdMenu = 5;
            menuInstalacoes.IdParent = 0;
            menuInstalacoes.Text = "Instalações";
            menuInstalacoes.ActionName = "Installations";
            menuInstalacoes.ControllerName = "Home";

            listMenu.Add(menuInstalacoes);

            #endregion

            #region Parceiros

            MenuModelView menuParceiros = new MenuModelView();
            menuParceiros.IdMenu = 6;
            menuParceiros.IdParent = 0;
            menuParceiros.Text = "Parceiros";
            menuParceiros.ActionName = "Partners";
            menuParceiros.ControllerName = "Home";

            listMenu.Add(menuParceiros);

            #endregion

            #region Lema Home

            MenuModelView menuLemaHome = new MenuModelView();
            menuLemaHome.IdMenu = 7;
            menuLemaHome.Text = "Lema Home";

            MenuModelView videoAula = new MenuModelView();
            videoAula.IdMenu = 3;
            videoAula.IdParent = 6;
            videoAula.Text = "Vídeo Aula";
            videoAula.ActionName = "VideoLessons";
            videoAula.ControllerName = "HomeSchool";

            menuLemaHome.SubMenus.Add(videoAula);

            MenuModelView tarefas = new MenuModelView();
            tarefas.IdMenu = 3;
            tarefas.IdParent = 6;
            tarefas.Text = "Tarefas";
            tarefas.ActionName = "Tasks";
            tarefas.ControllerName = "HomeSchool";

            menuLemaHome.SubMenus.Add(tarefas);

            listMenu.Add(menuLemaHome);

            #endregion

            #region Contato

            MenuModelView contato = new MenuModelView();
            contato.IdMenu = 8;
            contato.IdParent = 0;
            contato.Text = "Contato";
            contato.ActionName = "Contact";
            contato.ControllerName = "Home";

            listMenu.Add(contato);

            #endregion

            return listMenu;
        }

        private List<MenuModelView> GetAdmMenuItems()
        {
            List<MenuModelView> listMenu = new List<MenuModelView>();

            MenuModelView menuHome = new MenuModelView();
            menuHome.IdMenu = 1;
            menuHome.Text = "Home";
            menuHome.ActionName = "Index";
            menuHome.ControllerName = "Home";

            listMenu.Add(menuHome);

            MenuModelView menuInstitucional = new MenuModelView();
            menuInstitucional.IdMenu = 2;
            menuInstitucional.Text = "Institucional";

            MenuModelView principalOpinion = new MenuModelView();
            principalOpinion.IdMenu = 3;
            principalOpinion.IdParent = 2;
            principalOpinion.Text = "Palavra do Diretor";
            principalOpinion.ActionName = "PrincipalOpinion";
            principalOpinion.ControllerName = "Institutional";

            MenuModelView proposal = new MenuModelView();
            proposal.IdMenu = 4;
            proposal.IdParent = 2;
            proposal.Text = "Proposta";
            proposal.ActionName = "Proposal";
            proposal.ControllerName = "Institutional";

            menuInstitucional.SubMenus.Add(principalOpinion);
            menuInstitucional.SubMenus.Add(proposal);

            listMenu.Add(menuInstitucional);

            return listMenu;
        }

        private List<MenuModelView> GetParentMenuItems()
        {
            List<MenuModelView> listMenu = new List<MenuModelView>();
            Dictionary<int, string> listStudents = new Dictionary<int, string>();

            listStudents.Add(1, "Aluno 1");
            listStudents.Add(2, "Aluno 2");
            listStudents.Add(3, "Aluno 3");

            MenuModelView menuHome = new MenuModelView();
            menuHome.IdMenu = 1;
            menuHome.Text = "Home";
            menuHome.ActionName = "Index";
            menuHome.ControllerName = "Home";

            listMenu.Add(menuHome);

            foreach (var item in listStudents)
            {
                MenuModelView menuStudent = new MenuModelView();
                menuStudent.IdMenu = item.Key;
                menuStudent.Text = item.Value;

                MenuModelView menuBoletim = new MenuModelView();
                menuBoletim.IdMenu = 42;
                menuBoletim.IdParent = item.Key;
                menuBoletim.Text = "Boletins";
                menuBoletim.ActionName = "ReportCard";
                menuBoletim.ControllerName = "Student";
                menuBoletim.OptionalId = item.Key;

                menuStudent.SubMenus.Add(menuBoletim);

                MenuModelView menuMaterialSala = new MenuModelView();
                menuMaterialSala.IdMenu = 43;
                menuMaterialSala.IdParent = item.Key;
                menuMaterialSala.Text = "Material de Sala";
                menuMaterialSala.ActionName = "ClassMaterial";
                menuMaterialSala.ControllerName = "Student";
                menuMaterialSala.OptionalId = item.Key;

                menuStudent.SubMenus.Add(menuMaterialSala);

                MenuModelView menuAnotacoesMedicas = new MenuModelView();
                menuAnotacoesMedicas.IdMenu = 44;
                menuAnotacoesMedicas.IdParent = item.Key;
                menuAnotacoesMedicas.Text = "Anotações Médicas";
                menuAnotacoesMedicas.ActionName = "MedicalNotes";
                menuAnotacoesMedicas.ControllerName = "Student";
                menuAnotacoesMedicas.OptionalId = item.Key;

                menuStudent.SubMenus.Add(menuAnotacoesMedicas);

                MenuModelView menuRelatorioFinanceiro = new MenuModelView();
                menuRelatorioFinanceiro.IdMenu = 45;
                menuRelatorioFinanceiro.IdParent = item.Key;
                menuRelatorioFinanceiro.Text = "Relatório Financeiro";
                menuRelatorioFinanceiro.ActionName = "FinancialReport";
                menuRelatorioFinanceiro.ControllerName = "Student";
                menuRelatorioFinanceiro.OptionalId = item.Key;

                menuStudent.SubMenus.Add(menuRelatorioFinanceiro);

                MenuModelView menuRelatorioDesempenho = new MenuModelView();
                menuRelatorioDesempenho.IdMenu = 46;
                menuRelatorioDesempenho.IdParent = item.Key;
                menuRelatorioDesempenho.Text = "Desempenho";
                menuRelatorioDesempenho.ActionName = "PerformanceReport";
                menuRelatorioDesempenho.ControllerName = "Student";
                menuRelatorioDesempenho.OptionalId = item.Key;

                menuStudent.SubMenus.Add(menuRelatorioDesempenho);
                listMenu.Add(menuStudent);
            }

            return listMenu;
        }
    }
}
