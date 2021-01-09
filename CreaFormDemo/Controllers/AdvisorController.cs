using AutoMapper;
using CreaFormDemo.DtoModel;
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
    public class AdvisorController : ControllerBase
    {
        private readonly IAdvisorRepository repo;
      
        private readonly IMapper mapper;

        public AdvisorController(IAdvisorRepository repo,  IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }
        /// <summary>
        /// Hämta alla Klienter som  rådgivaren är ansvårig
        /// </summary>
        /// <param name="userid">User ID</param>
        /// <returns>Lista av Klienter sor rådgivaren är ansvårig</returns>
        [Authorize(Roles ="Advisor")]
        [HttpGet("{userid}/GetClients")]
        [ProducesResponseType(200,Type = typeof(List<ClientDto>))]
        [ProducesDefaultResponseType]
        public async Task<ActionResult>GetClients(int userid)
        {
            try
            {
                if (userid != int.Parse(User.FindFirst(ClaimTypes.Name).Value))
                {
                    return Unauthorized();
                }
                var advisor =  await repo.GetAdvisorByUserID( userid);
               var  Clients = await repo.GetClients(advisor.ID);
                var ClientsDto = new List<ClientDto>();

                if (Clients.Count() == 0) return NotFound("Det finns inga kunder som du är ansvariga för dem ! ");
                foreach (var client in Clients)
                {
                    ClientsDto.Add(mapper.Map<ClientDto>(client));
                }
                return Ok(ClientsDto);
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }
        /// <summary>
        ///  Komplettering Rådgivare profil
        /// </summary>
        /// <param name="id"> id</param>
        /// <param name="createddvisordto">CreateAdvisorDto model</param>
        /// <returns>AdvisorDto model</returns>

        [Authorize(Roles = "Advisor")]
        [HttpPost("{id}/Completion")]
        [ProducesResponseType(201,Type=typeof(AdvisorDto))]
        [ProducesDefaultResponseType]
        public async Task<ActionResult>CompletionAdvisor(int id, [FromBody]CreateAdvisorDto createddvisordto)
        {
            try
            {
                
                if (id != int.Parse(User.FindFirst(ClaimTypes.Name).Value))
                {
                    return Unauthorized();
                }
                var advisortest = await repo.GetAdvisorByUserID(id);
                if (advisortest != null) return BadRequest("Du har kompletterat din profile redan!");

             
                var advisordto = mapper.Map<AdvisorDto>(createddvisordto);
                advisordto.UserID = id;
                var advisor = mapper.Map<Advisor>(advisordto);

                var result = await repo.CompletionAdvisorProfile(advisor);
                if (result == null)
                {
                    return BadRequest("Ett fel inträffade när profilen kompletteras");
                }
                advisordto = mapper.Map<AdvisorDto>(result);
                return StatusCode(201, advisordto);
            }
            catch (Exception)
            {

                return StatusCode(500);
            }

        }
        /// <summary>
        /// Rådgivaren Kan uppdatera sin profile
        /// </summary>
        /// <param name=" userid">User ID </param>
        /// <param name="editAdvisorDto"> editAdvisorDto MODEL</param>
        /// <returns>rådgivarefilen som har uppdaterats</returns>
        [Authorize(Roles = "Advisor")]
        [HttpPut("{userid}/Update")]
        [ProducesResponseType(204, Type = typeof(AdvisorDto))]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateAdvisorProfile(int userid , [FromBody] EditAdvisorDto editAdvisorDto)
        {
            try
            {
                if (userid != int.Parse(User.FindFirst(ClaimTypes.Name).Value))
                {
                    return Unauthorized();
                }
              
                var advisorfromRepo = await repo.GetAdvisorByUserID(userid);
                if (advisorfromRepo == null) return NotFound();
                mapper.Map(editAdvisorDto, advisorfromRepo);

                if (!await repo.Save()) return BadRequest("Ett fel inträffade när profilen kompletteras");

                var advisordto = mapper.Map<AdvisorDto>(advisorfromRepo);
                return StatusCode(204, advisordto);
            }
            catch (Exception)
            {

                return StatusCode(500);
            }

        }
        /// <summary>
        ///Rådgivaren kan söka efter Klienten som är hans ansvar vid namn
        /// </summary>
        /// <param name="userid">User ID </param>
        /// <param name="name">,String Namn</param>
        /// <returns>List av Klienter som har samma namn eller en Klient som matchar den här namnet</returns>
        [Authorize(Roles ="Advisor")]
        [HttpGet("{userid}/GetClientsName")]
        [ProducesResponseType(200,Type =typeof(List<ClientDto>))]
        [ProducesDefaultResponseType]
        public async Task<ActionResult>GetClientsbyName( string name, int userid)
        {
            try
            {
                if (userid != int.Parse(User.FindFirst(ClaimTypes.Name).Value))
                {
                    return Unauthorized();
                }
                if (string.IsNullOrEmpty(name)) return BadRequest();
                var advisor = await repo.GetAdvisorByUserID(userid);
                var Clients = await repo.GetClientbyName( name, advisor.ID);
                if (Clients.Count()==0) return NotFound("Det finns inte Klienter som matchar den här namnet!");
                var ClientsDto = new List<ClientDto>();
                foreach (var client in Clients)
                {
                    ClientsDto.Add(mapper.Map<ClientDto>(client));
                }
                
                return Ok(ClientsDto) ;
                



            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }

        


    }
}
