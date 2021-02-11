using AutoMapper;
using CreaFormDemo.DtoModel;
using CreaFormDemo.DtoModel.UserDtoModel;
using CreaFormDemo.Entitys.Users;
using CreaFormDemo.Repository;
using CreaFormDemo.Services;
using CreaFormDemo.ViewModel;
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
        private readonly IAuthRepository repo;
        private readonly IMapper mapper;


        public AccountsController(IMapper mapper, IAuthRepository repo)
        {

            this.mapper = mapper;
            this.repo = repo;
        }


        /// <summary>
        /// Skapa ett nytt användare med Klients roll
        /// </summary>
        /// <param name="model">UserRegisterDto From body</param>
        /// <returns> Användare med Klients role</returns>
        [Authorize(Roles = "Advisor")]
        [HttpPost("CreateClient")]
        [ProducesResponseType(201, Type = typeof(CreatedUserDto))]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> CreateNewClient( [FromBody] UserLogInDto model)
        {
            try
            {
                var user = await repo.GetUserByID(User.FindFirstValue(ClaimTypes.Name));// Hämtar user id som är inloggad
                if (!user.ProfileConfirmation) return Unauthorized();// Kontrollera om den här user har kompletterat sitt profil eller inte för att undvika null referens eller status kod 500.


                if (await repo.UserExists(model.UserName.ToLower())) return BadRequest("Användarnamnet är redan registrerat");
                var createduser = await repo.Rigester(user.ID, model.UserName.ToLower(), model.Password, "Client");
                if (createduser == null)
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
        
        /// <returns>Användare med rådgivares role</returns>
        [Authorize(Roles = "Admin")]
        [HttpPost("CreateAdvisor")]

        [ProducesResponseType(201, Type = typeof(CreatedUserDto))]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> CreateNewAdvisor( [FromBody] UserLogInDto model)
        {
            try
            {
                string userid= User.FindFirstValue(ClaimTypes.Name); //Hämtar user id som är inloggad

                if (await repo.UserExists(model.UserName.ToLower())) return BadRequest("Användarnamnet är redan registrerat");
                var user = await repo.Rigester(userid, model.UserName.ToLower(), model.Password, "Advisor");
                if (user == null)
                { return BadRequest("Ett fel uppstod när Rådgivaren registreras"); }

                return StatusCode(201, model);
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
        [HttpPost("Login")]
        //[Route("api/Accounts/Login")]
        [ProducesResponseType(200, Type = typeof(UserDto))]
        [ProducesDefaultResponseType]

        public async Task<ActionResult> LoginUser([FromBody] UserLogInDto model)
        {
            try
            {

                var user = await repo.Login(model.UserName.ToLower(), model.Password);
                if (user == null)
                    return BadRequest(new { message = "Användarnamn eller lösenord är felaktigt" });
                if (user.IsBlocked == true) return Unauthorized(new { message = "Din konto har avbrutit !" });
                var userdto = mapper.Map<UserDto>(user);
                return Ok(userdto);

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        /// <summary>
        /// User kan byta Lösenordet
        /// </summary>
        /// <param name="model">ChangePassword model</param>
        /// <returns> Login action</returns>
        [Authorize]
        [HttpPost("ChangePassword")]
        [ProducesResponseType(204)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> ChangePassword(ChangePassword model)
        {
            try
            {
                
                var currentuser = await repo.GetUserByID(User.FindFirstValue(ClaimTypes.Name));
              
                if (currentuser == null) return BadRequest();
                var result = await repo.ChangePassword(currentuser, model.CurrentPassword, model.NewPassword);
                if (!result) return BadRequest();
                return Ok("Lösenordet har ändrats framgångsrikt");
               
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }



    }
}
