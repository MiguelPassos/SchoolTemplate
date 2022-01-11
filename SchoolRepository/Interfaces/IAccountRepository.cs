using System.Data;

namespace SchoolRepository.Interfaces
{
    public interface IAccountRepository
    {
        DataTable GetUserData(string login, string password);
    }
}
