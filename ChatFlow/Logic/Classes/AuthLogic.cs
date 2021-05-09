using Logic.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Classes
{
    public class AuthLogic : IAuthLogic
    {
        UserManager<User> userManager;

        public AuthLogic(UserManager<User> _userManager)
        {
            this.userManager = _userManager;
        }

        public async Task<string> CreateUser(User user)
        {
            user.Id = Guid.NewGuid().ToString();
            var result = await this.userManager.CreateAsync(user);
            if (result.Succeeded)
            {
                return "Success";
            }
            else return "Failed";
        }

        async Task DeleteUser(User user)
        {
            await this.userManager.DeleteAsync(user);
        }

        public async Task DeleteUser(string id)
        {
            var userToDelete = await this.userManager.FindByIdAsync(id);
            await this.DeleteUser(userToDelete);
        }

        public async Task<User> GetUser(string id)
        {
            return await this.userManager.FindByIdAsync(id);
        }

        public async Task UpdateUser(User newUser)
        {
            await this.userManager.UpdateAsync(newUser);
        }

        public IEnumerable<User> GetAllUser()
        {
            return this.userManager.Users;
        }

        public async Task<TokenViewModel> LoginUser(LoginViewModel model)
        {
            var user = await userManager.FindByNameAsync(model.Username);
            if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
            {


                var claims = new List<Claim>
                {
                  new Claim(JwtRegisteredClaimNames.Sub, model.Username),
                  new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                  new Claim("userId", user.Id)
                };


                var roles = await userManager.GetRolesAsync(user);

                claims.AddRange(roles.Select(role => new Claim(ClaimsIdentity.DefaultRoleClaimType, role)));


                var signinKey = new SymmetricSecurityKey(
                  Encoding.UTF8.GetBytes("#Bihari.Boldizsar#Bogdan.Roland#Buzasi.Simon#Lengyel.Tamas#Szabo.Darius"));

                var token = new JwtSecurityToken(
                  issuer: "http://www.security.org",
                  audience: "http://www.security.org",
                  claims: claims,
                  expires: DateTime.Now.AddMinutes(60),
                  signingCredentials: new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256)
                );
                return new TokenViewModel
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    Expiration = token.ValidTo
                };
            }
            throw new ArgumentException("Login failed");
        }
    }
}
