using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Auth
{
    internal interface IUserService
    {
        void Register(User user);
        User Login(string email, string password);
        bool CheckIfUserExists(string email);
    }
}
