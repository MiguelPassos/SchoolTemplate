using SchoolEntities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBusiness.Interfaces
{
    public interface IEmailBusiness
    {
        Task SendEmailAsync(MensagemEmail email);
    }
}
