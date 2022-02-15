using SchoolEntities;

namespace SchoolBusiness.Interfaces
{
    public interface IAccountBusiness
    {
        Usuario GetUserData(string login, string password);

        Usuario GetUserData(string document);

        Usuario GetUserDataByToken(string token);

        Usuario GetUserDataByLogin(string login);

        void UpdateUserAccess(Usuario user);

        bool IsUserValid(string validationKey);

        void RegisterNewUser(Usuario user, string userDoc);
    }
}
