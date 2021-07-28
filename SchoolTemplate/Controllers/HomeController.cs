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

namespace SchoolTemplate.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            List<MenuModelView> listMenu = null;

            if (User.Identity.IsAuthenticated)
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

            var identidadeDeUsuario = new ClaimsIdentity(claims, "Login");
            ClaimsPrincipal claimPrincipal = new ClaimsPrincipal(identidadeDeUsuario);

            var propriedadesDeAutenticacao = new AuthenticationProperties
            {
                AllowRefresh = true,
                ExpiresUtc = DateTime.Now.ToLocalTime().AddMinutes(30),
                IsPersistent = user.RememberMe
            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimPrincipal, propriedadesDeAutenticacao);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index");
        }

        private List<MenuModelView> GetMenuItems()
        {
            List<MenuModelView> listMenu = new List<MenuModelView>();

            MenuModelView menuHome = new MenuModelView();
            menuHome.ID = 1;
            menuHome.Text = "Home";
            menuHome.ActionName = "Index";
            menuHome.ControllerName = "Home";

            listMenu.Add(menuHome);

            MenuModelView menuInstitucional = new MenuModelView();
            menuInstitucional.ID = 2;
            menuInstitucional.Text = "Institucional";

            MenuModelView principalOpinion = new MenuModelView();
            principalOpinion.ID = 3;
            principalOpinion.IdParent = 2;
            principalOpinion.Text = "Palavra do Diretor";
            principalOpinion.ActionName = "PrincipalOpinion";
            principalOpinion.ControllerName = "Institutional";

            MenuModelView proposal = new MenuModelView();
            proposal.ID = 4;
            proposal.IdParent = 2;
            proposal.Text = "Proposta";
            proposal.ActionName = "Proposal";
            proposal.ControllerName = "Institutional";

            menuInstitucional.SubMenus.Add(principalOpinion);
            menuInstitucional.SubMenus.Add(proposal);

            listMenu.Add(menuInstitucional);

            return listMenu;
        }
    }
}
