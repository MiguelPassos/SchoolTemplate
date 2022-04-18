using SchoolBusiness.Interfaces;
using SchoolEntities;
using SchoolRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBusiness.Services
{
    public class BaseBusiness : IBaseBusiness
    {
        private readonly IBaseRepository _repository;

        private Dictionary<string, string> configurations;

        private Dictionary<string, string> Configurations 
        {
            get { return configurations; }
            set { configurations = value; }
        }

        public BaseBusiness(IBaseRepository repository)
        {
            _repository = repository;
            Configurations = GetConfigurations();
        }

        private Dictionary<string, string> GetConfigurations()
        {
            try
            {
                var dataTable = _repository.GetConfigurations();

                Dictionary<string, string> _configurations = new Dictionary<string, string>();

                foreach (DataRow dataRow in dataTable.Rows)
                {
                    _configurations.Add(dataRow["Chave"].ToString(), dataRow["Valor"].ToString());
                }

                return _configurations;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<MenuItem> GetUserMenu(int idUser)
        {
            try
            {
                var dataTable = _repository.GetUserMenu(idUser);
                List<MenuItem> userMenuItems = new List<MenuItem>();

                if (dataTable.Rows.Count > 0)
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        MenuItem menuItem = new MenuItem()
                        {
                            IdMenu = Convert.ToInt32(row["IdMenu"]),
                            IdMenuPai = Convert.ToInt32(row["IdMenuPai"]),
                            Texto = row["Texto"].ToString(),
                            Descricao = row["Descricao"].ToString(),
                            ControllerName = row["ControllerName"].ToString(),
                            ActionName = row["ActionName"].ToString(),
                            OptionalId = row["OptionalId"] == DBNull.Value ? (int?)null : Convert.ToInt32(row["OptionalId"]),
                            Icone = row["Icone"].ToString(),
                            Ordem = Convert.ToInt32(row["Ordem"])
                        };

                        userMenuItems.Add(menuItem);
                    }
                }

                return userMenuItems;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task SendEmailAsync(MensagemEmail email)
        {
            try
            {
                using (var client = new SmtpClient(Configurations.GetValueOrDefault("ServidorSMTP"), Convert.ToInt32(Configurations.GetValueOrDefault("PortaSMTP"))))
                {
                    client.Credentials = new NetworkCredential(Configurations.GetValueOrDefault("UsuarioSMTP"), Configurations.GetValueOrDefault("SenhaSMTP"));
                    client.EnableSsl = true;

                    var message = new MailMessage();
                    message.From = new MailAddress(Configurations.GetValueOrDefault("EnderecoRemetente"), Configurations.GetValueOrDefault("NomeRemetente"));
                    message.To.Add(new MailAddress(email.Endereco));
                    message.Subject = email.Assunto;
                    message.Body = email.Mensagem;
                    message.IsBodyHtml = true;
                    message.Priority = MailPriority.High;

                    await client.SendMailAsync(message);
                    client.Dispose();
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
