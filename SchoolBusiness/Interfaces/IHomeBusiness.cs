using SchoolEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolBusiness.Interfaces
{
    public interface IHomeBusiness
    {
        List<PerfilFuncionario> GetRandomEmployeesProfiles();

        List<Evento> GetLatestFourEvents();
    }
}
