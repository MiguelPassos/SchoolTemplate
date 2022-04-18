using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SchoolRepository.Interfaces
{
    public interface IBaseRepository
    {
        DataTable GetConfigurations();

        DataTable GetUserMenu(int idUser);
    }
}
