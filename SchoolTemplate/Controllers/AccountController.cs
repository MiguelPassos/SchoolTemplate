using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
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

        public AccountController(IAccountBusiness accountBusiness, IBaseBusiness baseBusiness) : base(baseBusiness) => _accountBusiness = accountBusiness;

        [HttpGet]
        [AutoValidateAntiforgeryToken]
        public IActionResult Profile(int id)
        {
            return View();
        }

        [HttpGet]
        [AutoValidateAntiforgeryToken]
        [Authorize(Roles = "Administrador")]
        public IActionResult Profiles()
        {
            return View();
        }

        [HttpGet]
        [ValidateAntiForgeryToken]
        public IActionResult ValidateUser([FromQuery] string validationKey)
        {
            try
            {
                if (_accountBusiness.IsUserValid(validationKey))
                    TempData["Message"] = ConfigMessage("Validação de E-mail", "Seu e-mail foi validado com sucesso.<br />Agora você já pode se autenticar no sistema.");
                else
                    TempData["Message"] = ConfigMessage("Validação de E-mail", "Não foi possível validar o e-mail.<br />Por favor, contate o administrador do sistema.");
            }
            catch (Exception)
            {
                TempData["Alert"] = ConfigAlert(Enuns.ETypeAlert.Error, "Ocorreu um erro durante a tentativa de efetuar a requisição. <br />Por favor, tente novamente ou contate o administrador.");
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [AutoValidateAntiforgeryToken]
        public IActionResult RecoveryAccess([FromQuery] string recoveryKey)
        {
            try
            {
                if (string.IsNullOrEmpty(recoveryKey))
                    return RedirectToAction("Index", "Home");
                else
                {
                    var user = _accountBusiness.GetUserDataByToken(recoveryKey);

                    if (user == null)
                    {
                        TempData["Alert"] = ConfigAlert(Enuns.ETypeAlert.Error, "O link de recuperação de acesso é inválido.<br />Por favor solicite um novo link ou entre em contato com o administrador.");
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        var newUser = new UserViewModel()
                        {
                            ID = user.IdUsuario,
                            Token = recoveryKey,
                        };

                        return View(newUser);
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["Alert"] = ConfigAlert(Enuns.ETypeAlert.Error, "Nós sentimos muito, mas ocorreu um erro na validação do link de redefinição de acesso.<br />Por favor solicite um novo link ou entre em contato com o administrador.");
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RecoveryAccess(UserViewModel userViewModel)
        {
            string mensagem = @"<div style=""font-family: Calibri, Helvetica, sans - serif; font - size: 12pt;"">
                                    <h1 style=""font-family: Arial, serif; text-align: center;"">Recuperação de Acesso</h1>
                                    <div style=""font-family: Arial, serif; font-size: medium; text-align: center; margin: 0px 20px;"">
                                        <p>Caro, {0}</p>
                                        <p>Você solicitou recuperar o seu acesso no sistema do Colégio Lema.<br/>
                                        Para recuperá-lo, por favor clique no link abaixo.</p>
                                            <a href=""{1}"">Recuperar meu acesso ao sistema</a>
                                    </div>
                                    <div style=""font-family: Arial, serif;font-size: medium;text-align: center;margin: 0px 20px;"">
                                        <p>Caso não tenha sido você que solicitou a recuperação de acesso, por favor desconsidere este e-mail.<br/><br/>
                                            Atenciosamente,<br/><br/>Diretoria do Colégio Lema</p>
                                    </div>
                                </div>";

            try
            {
                if (!string.IsNullOrEmpty(userViewModel.Document))
                {
                    var user = _accountBusiness.GetUserData(userViewModel.Document);

                    if (user != null)
                    {
                        mensagem = string.Format(mensagem, string.Concat(user.Nome, " ", user.Sobrenome), $"{BaseUrl}Account/RecoveryAcess?recoveryKey={user.Token}");

                        SendEmailMessage(user.Email, "Colégio Lema - Recuperação de Acesso", mensagem).Wait();
                        TempData["Message"] = ConfigMessage("Recuperar Acesso", "Foi enviado um e-mail contendo as intruções <br /> para recuperar o seu acesso. Por favor verifique.");
                    }
                }
                else
                    TempData["Alert"] = ConfigAlert(Enuns.ETypeAlert.Error, $"Para que possamos localizá-lo no sistema, é necessário informar o CPF cadastrado.");
            }
            catch (Exception ex)
            {
                TempData["Alert"] = ConfigAlert(Enuns.ETypeAlert.Error, $"Houve uma falha na tentativa de recuperar o acesso. <br />Erro: { ex.Message }");
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ResetAccess(UserViewModel userViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Usuario user = _accountBusiness.GetUserDataByToken(userViewModel.Token);
                    Usuario userTwo = _accountBusiness.GetUserDataByLogin(userViewModel.UserLogin);

                    if (user == null)
                        TempData["Alert"] = ConfigAlert(Enuns.ETypeAlert.Error, "Ocorreu uma falha na tentativa de atualizar o acesso.<br />Por favor tente novamente ou acione o administrador.");
                    else if (userViewModel.UserLogin == user.Login || 
                            (userViewModel.ID == user.IdUsuario && 
                            (userTwo == null || userViewModel.ID == userTwo.IdUsuario)))
                    {
                        user.Login = userViewModel.UserLogin;
                        user.Senha = userViewModel.Password;
                        user.Token = GenerateUserToken(user.Documento);

                        _accountBusiness.UpdateUserAccess(user);

                        TempData["Alert"] = ConfigAlert(Enuns.ETypeAlert.Success, "Seu acesso foi redefinido com sucesso.");
                    }
                    else
                        TempData["Alert"] = ConfigAlert(Enuns.ETypeAlert.Info, "Login de Usuário indisponível.<br />Por favor, informe outro e tente novamente.");
                }
            }
            catch (Exception ex)
            {
                TempData["Alert"] = ConfigAlert(Enuns.ETypeAlert.Error, "Nós sentimos muito, mas ocorreu um erro durante o processamento.<br />Por favor tente novamente ou entre em contato com o administrador.");
            }

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
                        await RegisterLogin(
                            new UserViewModel(user.NivelAcesso.Descricao)
                            {
                                ID = user.IdUsuario,
                                UserName = string.Concat(user.Nome, " ", user.Sobrenome),
                                RememberMe = Convert.ToBoolean(userViewModel.RememberMe)
                            });
                    else
                        TempData["Alert"] = ConfigAlert(Enuns.ETypeAlert.Error, "Usuário não localizado. Verifique os dados e tente novamente.");
                }
                else
                    TempData["Alert"] = ConfigAlert(Enuns.ETypeAlert.Error, "Usuário e Senha devem ser informados.");
            }
            catch (Exception ex)
            {
                TempData["Alert"] = ConfigAlert(Enuns.ETypeAlert.Error, $"Falha na tentativa de realizar o login: {ex.Message}");
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [AutoValidateAntiforgeryToken]
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
                    var user = _accountBusiness.GetUserDataByLogin(userViewModel.UserLogin);

                    if (user == null)
                    {
                        user = _accountBusiness.GetUserData(userViewModel.Document);

                        if (user == null)
                            TempData["Alert"] = ConfigAlert(Enuns.ETypeAlert.Info, "O CPF deve ser previamente cadastrado pelo administrador.");

                        else if (!string.IsNullOrEmpty(user.Login))
                            TempData["Alert"] = ConfigAlert(Enuns.ETypeAlert.Info, "Usuário já registrado no sistema.");

                        else
                            await RegisterNewUser(userViewModel);
                    }
                    else
                        TempData["Alert"] = ConfigAlert(Enuns.ETypeAlert.Info, "Login de Usuário indisponível.<br />Por favor, informe outro e tente novamente.");
                }
                else
                    TempData["Alert"] = ConfigAlert(Enuns.ETypeAlert.Error, "Todos os campos devem ser informados.");
            }
            catch (Exception ex)
            {
                TempData["Alert"] = ConfigAlert(Enuns.ETypeAlert.Error, $"Falha na tentativa de realizar o registro: {ex.Message}");
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [AutoValidateAntiforgeryToken]
        public IActionResult NotifyUnAuthorizedUser()
        {
            TempData["Alert"] = ConfigAlert(Enuns.ETypeAlert.Error, "Usuário sem permissão de acesso a página.");
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [AutoValidateAntiforgeryToken]
        public IActionResult NotifyUnLoggedUser()
        {
            TempData["Alert"] = ConfigAlert(Enuns.ETypeAlert.Error, "Usuário não logado no sistema.");
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
                    Token = GenerateUserToken(newUser.Document),
                };

                _accountBusiness.RegisterNewUser(user, newUser.Document);

                await RequestValidation(newUser.Document);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task RequestValidation(string userDocument)
        {
            string mensagem = @"<div style=""font-family: Calibri, Helvetica, sans - serif; font - size: 12pt;""><h1 style=""font-family: Arial, serif; text-align: center;"">Validação de Acesso</h1><div style=""font-family: Arial, serif; font-size: medium; text-align: center; margin: 0px 20px;""><p>Caro, {0}</p><p>Sua conta no sistema do Colégio Lema está quase pronta.<br/>Para ativá-la, por favor confirme o seu endereço de e-mail clicando no link abaixo.</p><a href=""{1}"">Validar meu e-mail e ativar meu acesso</a></div><div style=""font-family: Arial, serif;font-size: medium;text-align: center;margin: 0px 20px;""><p>Sua conta não será ativada até que seu e-mail seja confirmado.<br/>Se você não se cadastrou no nosso sistema recentemente, por favor ignore este e-mail.<br/><br/>Atenciosamente,<br/><br/>Diretoria do Colégio Lema</p></div></div>";

            try
            {
                var user = _accountBusiness.GetUserData(userDocument);

                mensagem = string.Format(mensagem, string.Concat(user.Nome, " ", user.Sobrenome), $"{BaseUrl}Account/ValidateUser?recoveryKey={user.Token}");

                await SendEmailMessage(user.Email, "Colégio Lema - Validação de E-mail", mensagem);
                TempData["Message"] = ConfigMessage("Usuário registrado com sucesso!", "Foi enviado um e-mail contendo as intruções para validar<br />seu e-mail e ativar o seu acesso. Por favor verifique.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
