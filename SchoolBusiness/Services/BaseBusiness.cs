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
        private const string smtp = "smtp-mail.outlook.com";

        private const string emailRemetente = "no-reply@colegiolema.com.br";

        private const int porta = 587;

        private readonly IBaseRepository _repository;

        public BaseBusiness(IBaseRepository repository) => _repository = repository;

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
                using (var client = new SmtpClient(smtp, porta))
                {
                    client.Credentials = new NetworkCredential("credencial@emailserver.com", "YourPassword");
                    client.EnableSsl = true;

                    var message = new MailMessage();
                    message.From = new MailAddress("myemail@emailserver.com", "Nome Exibição");
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
