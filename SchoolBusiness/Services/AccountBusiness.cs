using SchoolBusiness.Interfaces;
using SchoolEntities;
using SchoolRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolBusiness.Services
{
    public class AccountBusiness : IAccountBusiness
    {
        private readonly IAccountRepository _repository;

        public AccountBusiness(IAccountRepository accountRepository)
        {
            _repository = accountRepository;
        }

        public Usuario GetUserData(string login, string password)
        {
            try
            {
                var dataTable = _repository.GetUserData(login, password);
                Usuario usuario = null;

                if (dataTable.Rows.Count > 0)
                {
                    usuario = new Usuario()
                    {
                        IdUsuario = Convert.ToInt32(dataTable.Rows[0]["IdUsuario"]),
                        Nome = dataTable.Rows[0]["Nome"].ToString(),
                        Sobrenome = dataTable.Rows[0]["Sobrenome"].ToString(),
                        Login = dataTable.Rows[0]["Login"].ToString(),

                        NivelAcesso = new NivelAcesso()
                        {
                            IdNivel = Convert.ToInt32(dataTable.Rows[0]["IdNivel"]),
                            Sigla = dataTable.Rows[0]["Sigla"].ToString(),
                            Descricao = dataTable.Rows[0]["Descricao"].ToString()
                        }
                    };
                }

                return usuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Usuario GetUserData(string document)
        {
            try
            {
                var dataTable = _repository.GetUserData(document);
                Usuario usuario = null;

                if (dataTable.Rows.Count > 0)
                {
                    usuario = new Usuario()
                    {
                        IdUsuario = Convert.ToInt32(dataTable.Rows[0]["ID"]),
                        Nome = dataTable.Rows[0]["Nome"].ToString(),
                        Sobrenome = dataTable.Rows[0]["Sobrenome"].ToString(),
                        Login = dataTable.Rows[0]["Login"].ToString(),
                        Email = dataTable.Rows[0]["Email"].ToString(),
                        Token = dataTable.Rows[0]["Token"].ToString(),

                        NivelAcesso = new NivelAcesso()
                        {
                            IdNivel = Convert.ToInt32(dataTable.Rows[0]["IdNivel"]),
                            Sigla = dataTable.Rows[0]["Sigla"].ToString(),
                            Descricao = dataTable.Rows[0]["Descricao"].ToString()
                        }
                    };
                }

                return usuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Usuario GetUserDataByToken(string token)
        {
            try
            {
                var dataTable = _repository.GetUserDataByToken(token);
                Usuario usuario = null;

                if (dataTable.Rows.Count > 0)
                {
                    usuario = new Usuario()
                    {
                        IdUsuario = Convert.ToInt32(dataTable.Rows[0]["ID"]),
                        Nome = dataTable.Rows[0]["Nome"].ToString(),
                        Sobrenome = dataTable.Rows[0]["Sobrenome"].ToString(),
                        Login = dataTable.Rows[0]["Login"].ToString(),
                        Email = dataTable.Rows[0]["Email"].ToString(),
                        Documento = dataTable.Rows[0]["Documento"].ToString(),

                        NivelAcesso = new NivelAcesso()
                        {
                            IdNivel = Convert.ToInt32(dataTable.Rows[0]["IdNivel"]),
                            Sigla = dataTable.Rows[0]["Sigla"].ToString(),
                            Descricao = dataTable.Rows[0]["Descricao"].ToString()
                        }
                    };
                }

                return usuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Usuario GetUserDataByLogin(string login)
        {
            try
            {
                var dataTable = _repository.GetUserDataByLogin(login);
                Usuario usuario = null;

                if (dataTable.Rows.Count > 0)
                {
                    usuario = new Usuario()
                    {
                        IdUsuario = Convert.ToInt32(dataTable.Rows[0]["IdUsuario"]),
                        Nome = dataTable.Rows[0]["Nome"].ToString(),
                        Sobrenome = dataTable.Rows[0]["Sobrenome"].ToString(),
                        Login = dataTable.Rows[0]["Login"].ToString(),
                        Email = dataTable.Rows[0]["Email"].ToString(),
                        Documento = dataTable.Rows[0]["Documento"].ToString(),

                        NivelAcesso = new NivelAcesso()
                        {
                            IdNivel = Convert.ToInt32(dataTable.Rows[0]["IdNivel"]),
                            Sigla = dataTable.Rows[0]["Sigla"].ToString(),
                            Descricao = dataTable.Rows[0]["Descricao"].ToString()
                        }
                    };
                }

                return usuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateUserAccess(Usuario user)
        {
            try
            {
                _repository.UpdateUserAccess(user);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool IsUserValid(string validationKey)
        {
            try
            {
                Usuario usuario = GetUserDataByToken(validationKey);

                if (usuario != null)
                {
                    _repository.ActivateUserAccount(usuario);
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void RegisterNewUser(Usuario user, string userDoc)
        {
            try
            {
                _repository.RegisterNewUser(user, userDoc);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
