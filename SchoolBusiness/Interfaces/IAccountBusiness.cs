using SchoolEntities;

namespace SchoolBusiness.Interfaces
{
    public interface IAccountBusiness
    {
        Usuario GetUserData(string login, string password);

        Usuario GetUserData(string document);

        void RegisterNewUser(Usuario user, string userDoc);
    }
}
