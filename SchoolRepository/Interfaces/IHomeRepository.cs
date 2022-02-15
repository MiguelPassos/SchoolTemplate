using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SchoolRepository.Interfaces
{
    public interface IHomeRepository
    {
        DataTable GetRandomEmployeesProfiles();
    }
}
