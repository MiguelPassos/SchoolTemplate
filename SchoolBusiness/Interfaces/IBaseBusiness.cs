using SchoolEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolBusiness.Interfaces
{
    public interface IBaseBusiness
    {
        List<MenuItem> GetUserMenu(int idUser);
    }
}
