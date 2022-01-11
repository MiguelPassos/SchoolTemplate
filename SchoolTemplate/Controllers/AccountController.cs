using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using SchoolBusiness.Interfaces;
using SchoolEntities;
using SchoolTemplate.Models;
using SchoolTemplate.UtilityServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SchoolTemplate.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IAccountBusiness _accountBusiness;

        public AccountController(IAccountBusiness accountBusiness, IBaseBusiness baseBusiness) : base(baseBusiness)
        {
            _accountBusiness = accountBusiness;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogIn(UserViewModel userViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Usuario user = _accountBusiness.GetUserData(userViewModel.UserLogin, userViewModel.Password);

                    if (user != null)
                        await RegisterLogin(new UserViewModel(user.NivelAcesso.Descricao) { ID = user.IdUsuario, UserName = user.Nome, RememberMe = Convert.ToBoolean(userViewModel.RememberMe) });
                    else
                        TempData["Message"] = ConfigAlert(Enuns.ETypeAlert.Error, "Usuário não localizado. Verifique os dados e tente novamente.");
                }
                else
                    TempData["Message"] = ConfigAlert(Enuns.ETypeAlert.Error, "Usuário e Senha devem ser informados.");
            }
            catch (Exception ex)
            {
                TempData["Message"] = ConfigAlert(Enuns.ETypeAlert.Error, $"Falha na tentativa de realizar o login: {ex.Message}");
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await RegisterLogout();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult NotifyUnAuthorizedUser()
        {
            TempData["Message"] = ConfigAlert(Enuns.ETypeAlert.Error, "Usuário sem permissão de acesso a página.");
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult NotifyUnLoggedUser()
        {
            TempData["Message"] = ConfigAlert(Enuns.ETypeAlert.Error, "Usuário não logado no sistema.");
            return RedirectToAction("Index", "Home");
        }

        #region Métodos Auxiliares

        private async Task RegisterLogin(UserViewModel user)
        {
            var claims = new List<Claim>
            {
                new Claim("ID", user.ID.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var claimsIdentity = new ClaimsIdentity(claims, "Login");
            claimsIdentity.Label = user.Role;
            ClaimsPrincipal claimPrincipal = new ClaimsPrincipal(claimsIdentity);

            var authenticationProperties = new AuthenticationProperties
            {
                AllowRefresh = true,
                ExpiresUtc = DateTime.Now.ToLocalTime().AddMinutes(30),
                IsPersistent = user.RememberMe
            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimPrincipal, authenticationProperties);
        }

        private async Task RegisterLogout()
        {
            await HttpContext.SignOutAsync();
        }

        #endregion
    }
}
