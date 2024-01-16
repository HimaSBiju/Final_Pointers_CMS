using Pointers_CMS.Models;

namespace Pointers_CMS.Repository.A_Repository
{
    public interface ILoginRepository
    {
        LoginUsers validateUser(string un, string pwd);

    }
}
