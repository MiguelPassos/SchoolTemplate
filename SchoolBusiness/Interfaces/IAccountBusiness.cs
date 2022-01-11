using SchoolEntities;

namespace SchoolBusiness.Interfaces
{
    public interface IAccountBusiness
    {
        Usuario GetUserData(string login, string password);
    }
}
