using SchoolEntities;
using System.Data;

namespace SchoolRepository.Interfaces
{
    public interface IAccountRepository
    {
        DataTable GetUserData(string login, string password);

        DataTable GetUserData(string document);

        DataTable GetUserDataByToken(string token);

        DataTable GetUserDataByLogin(string login);

        void UpdateUserAccess(Usuario user);

        void ActivateUserAccount(Usuario user);

        void RegisterNewUser(Usuario user, string doc);
    }
}
