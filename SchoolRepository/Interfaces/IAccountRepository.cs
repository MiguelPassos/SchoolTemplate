using SchoolEntities;
using System.Data;

namespace SchoolRepository.Interfaces
{
    public interface IAccountRepository
    {
        DataTable GetUserData(string login, string password);

        DataTable GetUserData(string document);

        void RegisterNewUser(Usuario user, string doc);
    }
}
