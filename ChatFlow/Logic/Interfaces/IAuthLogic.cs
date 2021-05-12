using Microsoft.AspNetCore.Identity;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interfaces
{
    public interface IAuthLogic
    {
        Task<string> CreateUser(User user);
        
        IEnumerable<User> GetAllUser();

        Task<User> GetUser(string id);

        Task DeleteUser(string id);

        Task UpdateUser(User newUser);

        Task<TokenViewModel> LoginUser(LoginViewModel model);
    }
}
