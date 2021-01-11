using CreaFormDemo.DtoModel;
using CreaFormDemo.Entitys;
using CreaFormDemo.Entitys.Users;
using CreaFormDemo.Repository;
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
        private readonly Appsettings _appsettings;
       
        public AuthRepository(CreaFormDBcontext DB,IOptions<Appsettings> appsettings)
        {
            _dB = DB;
            _appsettings = appsettings.Value;
        }
        public async Task<bool> UserExists(string name)
        {
      
            if(await _dB.Users.AnyAsync(x => x.UserName.Equals(name)))
            {
                return true;
            }
            return false;
        }

        public async Task<User> Login(string name, string password)
        {
            var user = await _dB.Users.FirstOrDefaultAsync(x => x.UserName.Equals(name));
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
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name,user.UserName)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenhandler.CreateToken(TokenDescriptor);
            string Token = tokenhandler.WriteToken(token);
            return Token;
        }

        public async Task<User> Rigester(int userID,string name, string password,string role)
        {
            byte[] passwordhash, passwordsald;
            CreatePasswordHash( password, out passwordhash, out passwordsald);
            var newuser = new User()
            {
                UserName = name,
                //PasswordHash = passwordhash,
                //PasswordSald = passwordsald,
                //role = role,
                //UserIdThatCreatedit = userID.ToString()
            };
               await _dB.Users.AddAsync(newuser);
                await _dB.SaveChangesAsync();
            
         
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

       
    }
}
