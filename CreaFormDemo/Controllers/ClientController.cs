using AutoMapper;
using CreaFormDemo.DtoModel.ClientDtoModel;
using CreaFormDemo.Entitys.Users;
using CreaFormDemo.Services.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CreaFormDemo.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public class ClientController : ControllerBase
    {
        private readonly IClientRepository repo;
        private readonly IMapper mapper;
        private readonly IAdvisorRepository advisorRepo;

        public ClientController(IClientRepository repo,IMapper mapper, IAdvisorRepository advisorRepo)
        {
            this.repo = repo;
            this.mapper = mapper;
            this.advisorRepo = advisorRepo;
        }
        /// <summary>
        /// Klienten kan komplettera sin profile(Namn och kontakt uppgifter)
        /// </summary>
        /// <param name="userid">User id som gjorde inloggning</param>
        /// <param name="model">CompletionClientDto model</param>
        /// <returns></returns>
        [Authorize(Roles ="Client")]
        [HttpPost("{userid}/CompletionClient")]
        [ProducesResponseType(200,Type =typeof(ClientToReturnDto))]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> CompletionClient(int userid,CompletionClientDto model)
        {
            try
            {
                if(userid != int .Parse(User.FindFirst(ClaimTypes.Name).Value))
                {
                    return Unauthorized("Du är inte auktoriserad");
                }
                var user = await repo.GetUserByID(userid);
                if (user == null)
                {
                    return BadRequest();
                }
                int ID = int.Parse(user.UserIdThatCreatedit);
                var advisor = await advisorRepo.GetAdvisorByUserID(ID);
                var clientDto = mapper.Map<ClientDto>(model);
                clientDto.AdvisorID = advisor.ID;
                clientDto.UserID = user.ID;
                var client = mapper.Map<Client>(clientDto);
                var result = await repo.CompletionClientProfile(client);
                if (result == null)
                {
                    return BadRequest("något uppstod när komplettering profilen");
                }
                var clienttoreturn = mapper.Map<ClientToReturnDto>(result);
                return Ok(clienttoreturn);


            }
            catch (Exception)
            {

                return StatusCode(500);
            }

        }
    }
}
