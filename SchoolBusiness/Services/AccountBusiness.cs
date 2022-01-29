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
                        IdUsuario = Convert.ToInt32(dataTable.Rows[0]["ID"]),
                        Nome = dataTable.Rows[0]["Nome"].ToString(),
                        Login = login,

                        NivelAcesso = new NivelAcesso()
                        {
                            IdNivel = Convert.ToInt32(dataTable.Rows[0]["NivelAcesso"]),
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
                        Login = dataTable.Rows[0]["Login"].ToString(),

                        NivelAcesso = new NivelAcesso()
                        {
                            IdNivel = Convert.ToInt32(dataTable.Rows[0]["NivelAcesso"]),
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
