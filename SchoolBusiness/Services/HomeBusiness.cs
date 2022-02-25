using SchoolBusiness.Interfaces;
using SchoolEntities;
using SchoolEntities.Enumerators;
using SchoolRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace SchoolBusiness.Services
{
    public class HomeBusiness : IHomeBusiness
    {
        private readonly IHomeRepository _repository;

        public HomeBusiness(IHomeRepository repository) => _repository = repository;

        public List<PerfilFuncionario> GetRandomEmployeesProfiles()
        {
            try
            {
                List<PerfilFuncionario> listPerfilFuncionarios = new List<PerfilFuncionario>();

                var dataTable = _repository.GetRandomEmployeesProfiles();

                foreach (DataRow row in dataTable.Rows)
                {
                    PerfilFuncionario perfilFuncionario = new PerfilFuncionario();

                    perfilFuncionario.IdPerfil = Convert.ToInt32(row["IdPerfil"]);
                    perfilFuncionario.Titulo = row["Titulo"].ToString();
                    perfilFuncionario.Imagem = row["Imagem"].ToString();

                    perfilFuncionario.Funcionario = new Funcionario()
                    {
                        Nome = row["Nome"].ToString(),
                        Sobrenome = row["Sobrenome"].ToString()
                    };

                    listPerfilFuncionarios.Add(perfilFuncionario);
                }

                return listPerfilFuncionarios;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Evento> GetLatestFourEvents()
        {
            try
            {
                List<Evento> listEvento = new List<Evento>();

                var dataTable = _repository.GetLatestFourEvents();

                foreach (DataRow row in dataTable.Rows)
                {
                    Evento evento = new Evento();

                    evento.IdEvento = Convert.ToInt32(row["IdEvento"]);
                    evento.Titulo = row["Titulo"].ToString();
                    evento.Descricao = row["Descricao"].ToString();
                    evento.Imagem = row["UrlImagem"].ToString();
                    evento.DataInicio = Convert.ToDateTime(row["DataInicio"]);
                    evento.DataTermino = Convert.ToDateTime(row["DataTermino"]);
                    evento.DataCriacao = Convert.ToDateTime(row["DataCriacao"]);
                    evento.Autor = row["Autor"].ToString();

                    listEvento.Add(evento);
                }

                return listEvento;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}