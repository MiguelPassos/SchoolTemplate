using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SchoolBusiness.Interfaces;
using SchoolEntities;
using SchoolTemplate.Models;
using SchoolTemplate.UtilityServices;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
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

        [HttpGet]
        [ValidateAntiForgeryToken]
        public IActionResult ValidateUser([FromQuery]string validationKey)
        {
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [ValidateAntiForgeryToken]
        public IActionResult RecoveryAccess([FromQuery]string recoveryKey)
        {
            return RedirectToAction("Index", "Home");
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(UserViewModel userViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Usuario user = _accountBusiness.GetUserData(userViewModel.Document);

                    if (user == null)
                        TempData["Message"] = ConfigAlert(Enuns.ETypeAlert.Info, "O CPF deve ser previamente cadastrado pelo administrador.");

                    else if (!string.IsNullOrEmpty(user.Login))
                        TempData["Message"] = ConfigAlert(Enuns.ETypeAlert.Info, "Usuário já registrado no sistema.");

                    else
                        await RegisterNewUser(userViewModel);
                }
                else
                    TempData["Message"] = ConfigAlert(Enuns.ETypeAlert.Error, "Todos os campos devem ser informados.");
            }
            catch (Exception ex)
            {
                TempData["Message"] = ConfigAlert(Enuns.ETypeAlert.Error, $"Falha na tentativa de realizar o registro: {ex.Message}");
            }

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

        private async Task RegisterNewUser(UserViewModel newUser) 
        {
            try
            {
                Usuario user = new Usuario()
                {
                    Login = newUser.UserLogin,
                    Senha = newUser.Password,
                    Token = GenerateUserToken(newUser),
                };

                _accountBusiness.RegisterNewUser(user, newUser.Document);
                
                if (newUser.RememberMe)
                {
                    user = _accountBusiness.GetUserData(newUser.UserLogin, newUser.Password);
                    await RegisterLogin(new UserViewModel(user.NivelAcesso.Descricao) { ID = user.IdUsuario, UserName = string.Concat(user.Nome, " ", user.Sobrenome), RememberMe = Convert.ToBoolean(newUser.RememberMe) });
                }
                else
                    TempData["Message"] = ConfigAlert(Enuns.ETypeAlert.Success, "Usuário registrado com sucesso!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
