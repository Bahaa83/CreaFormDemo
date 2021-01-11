using AutoMapper;
using CreaFormDemo.DtoModel;
using CreaFormDemo.DtoModel.UserDtoModel;
using CreaFormDemo.Entitys.Users;
using CreaFormDemo.Repository;
using CreaFormDemo.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CreaFormDemo.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public class AccountsController : ControllerBase
    {
        //private readonly IAuthRepository repo;
        private readonly IMapper mapper;
        private readonly Appsettings _appsettings;
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public AccountsController(IMapper mapper, UserManager<User> userManager, IOptions<Appsettings> 
            appsettings,SignInManager<User> signInManager)
        {
          
            this.mapper = mapper;
            _appsettings = appsettings.Value;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

      
        /// <summary>
        /// Skapa ett nytt användare med Klients roll
        /// </summary>
        /// <param name="id">User ID</param>
        /// <param name="model">UserRegisterDto From body</param>
        /// <returns> Användare med Klients role</returns>
        [Authorize(Roles = "Advisor")]
        [HttpPost("{id}/CreateClient")]
        [ProducesResponseType(201, Type = typeof(CreatedUserDto))]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> CreateNewKlient(int id,[FromBody] UserLogInDto model)
        {
            try
            {
                if (id != int.Parse(User.FindFirst(ClaimTypes.Name).Value))
                {
                    return Unauthorized("Du är inte auktoriserad");
                }
                if (await repo.UserExists(model.UserName.ToLower())) return BadRequest("Användarnamnet är redan registrerat");
                var user = await repo.Rigester(id,model.UserName.ToLower(), model.Password,"Client");
                if(user==null)
                { return BadRequest("Ett fel uppstod när Klienten registrerades"); }
             
                return StatusCode(201, model);

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        /// <summary>
        /// Skapa ett nytt användare konto med rådgivare roll
        /// </summary>
        /// <param name="model">UserRegisterDto From body</param>
        /// <param name="id">User ID</param>
        /// <returns>Användare med rådgivares role</returns>
        //[Authorize(Roles ="Admin")]
        [AllowAnonymous]
        [HttpPost("CreateAdvisor")]
      
        [ProducesResponseType(201,Type =typeof(CreatedUserDto))]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> CreateNewAdvisor(/*int id,*/[FromBody] UserLogInDto model)
        {
            try
            {
                //if (id != int.Parse(User.FindFirst(ClaimTypes.Name).Value))
                //{
                //    return Unauthorized();
                //}
                //if (await repo.UserExists(model.UserName.ToLower())) return BadRequest("Användarnamnet är redan registrerat");
                //var user = await repo.Rigester(id,model.UserName.ToLower(), model.Password, "Advisor");
                //if (user == null)
                //{ return BadRequest("Ett fel uppstod när Rådgivaren registreras"); }
                
                var Existuser = await userManager.FindByNameAsync(model.UserName);
                if(Existuser != null) return BadRequest("Användarnamnet är redan registrerat");
                var user = mapper.Map<User>(model);
                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return StatusCode(201, model);
                }
                else
                {
                    { return BadRequest("Ett fel uppstod när Rådgivaren registreras"); }
                }
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        /// <summary>
        /// logga in
        /// </summary>
        /// <param name="model"></param>
        /// <returns> Användaren med Token</returns>
        [AllowAnonymous]
        [HttpPost]
        [Route("Login")]
        [ProducesResponseType(200,Type =typeof(UserDto))]
        [ProducesDefaultResponseType]

        public async Task<ActionResult> Loginuser([FromBody] UserLogInDto model)
        {
            try
            {

                //var user = await repo.Login(model.UserName.ToLower(), model.Password);
                //if (user == null) return BadRequest(new { message = "Användarnamn eller lösenord är felaktigt" });
                //if (user.IsBlocked == true) return Unauthorized(new { message = "Din konto har avbrutit !" });
                //var userdto = mapper.Map<UserDto>(user);
                //return Ok(userdto);
                var user = await userManager.FindByNameAsync(model.UserName);
                if (user.IsBlocked==true) return Unauthorized(new
                { message = "Din konto har avbrutit ! " });

                if (user==null) return BadRequest(new { message = "Användarnamn eller lösenord är felaktigt" });
                var result = await signInManager.CheckPasswordSignInAsync(user, model.Password, false);
                if(result.Succeeded)
                {
                    var userToReturn= mapper.Map<UserDto>(user);
                    return Ok(new
                    {
                        userToReturn,
                        token = GenerateJwtToken(user)
                    }); 
                }
                else
                {
                    return Unauthorized();
                }

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        private string GenerateJwtToken(User user)
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




    }
}
