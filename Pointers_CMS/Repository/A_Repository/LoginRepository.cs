using Pointers_CMS.Models;
using System.Linq;

namespace Pointers_CMS.Repository.A_Repository
{
    public class LoginRepository:ILoginRepository
    {
        private readonly DB_CMSContext _context;
        private string pwd;
        private object un;

        public LoginRepository(DB_CMSContext context)
        {
            _context = context;
        }
        #region find user by redential
        public LoginUsers validateUser(string un, string pwd)
        {
            if (_context != null)
            {
                LoginUsers user = _context.LoginUsers.FirstOrDefault(us => us.UserName == un && us.Password == pwd);
                if (user != null)
                {
                    return user;
                }

            }
            return null;
        }
        #endregion

    }
}
