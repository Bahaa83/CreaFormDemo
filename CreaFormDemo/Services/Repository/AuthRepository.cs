using CreaFormDemo.DtoModel;
using CreaFormDemo.Entitys;
using CreaFormDemo.Entitys.Users;
using CreaFormDemo.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CreaFormDemo.Services.Repository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly CreaFormDBcontext _dB;
        private readonly UserManager<User> _userManager;
        private readonly Appsettings _appsettings;
       
        public AuthRepository(CreaFormDBcontext DB,UserManager<User> userManager,IOptions<Appsettings> appsettings)
        {
            _dB = DB;
           _userManager = userManager;
            _appsettings = appsettings.Value;
        }
        public async Task<bool> UserExists(string name)
        {
            var exist = _userManager.FindByNameAsync(name);
                if(exist!=null) return true;
                 return false;
        }

        public async Task<User> Login(string name, string password)
        {
            var user = await _userManager.FindByNameAsync(name);
            if (user == null)
            {
                return null;
            }
            //if (!verifypasswordhash(user.PasswordHash, user.PasswordSald, password))
            //    return null;
            //user.Token = GenerateJwtToken(user);
            return user;

        }

        public string GenerateJwtToken(User user)
        {
            var tokenhandler = new JwtSecurityTokenHandler();
            var Key = Encoding.ASCII.GetBytes(_appsettings.Secret);
            var TokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {

                    new Claim(ClaimTypes.Name, user.Id),
                    //new Claim(ClaimTypes.Role,user.role)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenhandler.CreateToken(TokenDescriptor);
            string Token = tokenhandler.WriteToken(token);
            return Token;
        }

        public async Task<User> Rigester(string userID,string name, string password,string role)
        {
            byte[] passwordhash, passwordsald;
            CreatePasswordHash( password, out passwordhash, out passwordsald);
            var newuser = new User()
            {
                UserName = name,
                //PasswordHash = passwordhash,
                //PasswordSald = passwordsald,
                //role = role,
                UserIdThatCreatedit = userID.ToString()
            };
            await _userManager.CreateAsync(newuser);
                //await _dB.SaveChangesAsync();
            
         
            return newuser;


        }



      private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSald)
        {
            using(var hmac= new System.Security.Cryptography.HMACSHA512())
            {
                passwordSald = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
            
        }
        private bool verifypasswordhash(byte[] passwordHash, byte[] passwordSald, string password)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSald))
            {

               var ComputeHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < ComputeHash.Length; i++)
                {
                   if( ComputeHash[i]!=passwordHash[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        public async Task<User> GetUserByID(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user != null) return user;
            return null;
        }

        public async Task<bool> ChangePassword(User user, string currentpassword, string newpassword)
        {
            //if (!verifypasswordhash(user.PasswordHash, user.PasswordSald, currentpassword)) return false;

            //byte[] newpasswordhash, newpasswordsald;
            //CreatePasswordHash(newpassword, out newpasswordhash, out newpasswordsald);
            //user.PasswordHash = newpasswordhash;
            //user.PasswordSald = newpasswordsald;
            //user.PasswordIsChanged = true;
         return   await _dB.SaveChangesAsync() >= 0 ? true : false;

        }
    }
}
