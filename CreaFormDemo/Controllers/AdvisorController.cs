using AutoMapper;
using CreaFormDemo.DtoModel;
using CreaFormDemo.DtoModel.ClientDtoModel;
using CreaFormDemo.Entitys.Symptoms;
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
       
        /// <returns>Lista av Klienter sor rådgivaren är ansvårig</returns>
        [Authorize(Roles ="Advisor")]
        [HttpGet("GetClients")]
        [ProducesResponseType(200,Type = typeof(List<ClientToReturnDto>))]
        [ProducesDefaultResponseType]
        public async Task<ActionResult>GetClients()
        {
            try
            {

                var user = await repo.GetUserByID(int.Parse(User.FindFirstValue(ClaimTypes.Name)));// Hämtar user id som är inloggad
                if (!user.ProfileConfirmation) return Unauthorized();// Kontrollera om den här user har kompletterat sitt profil eller inte för att undvika null referens eller status kod 500.
                var advisor =  await repo.GetAdvisorByUserID(user.ID);

                var  Clients = await repo.GetClients(advisor.ID);
                var ClientsToreturn = new List<ClientToReturnDto>();

                if (Clients.Count()==0) return NotFound("Det finns inga kunder som du är ansvariga för dem ! ");
                foreach (var client in Clients)
                {
                    ClientsToreturn.Add(mapper.Map<ClientToReturnDto>(client));
                }
                return Ok(ClientsToreturn);
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }
        /// <summary>
        ///  Komplettering Rådgivare profil
        /// </summary>
        /// <param name="createddvisordto">CreateAdvisorDto model</param>
        /// <returns>AdvisorDto model</returns>

        [Authorize(Roles = "Advisor")]
        [HttpPost("CompletionAdvisor")]
        [ProducesResponseType(201,Type=typeof(AdvisorDto))]
        [ProducesDefaultResponseType]
        public async Task<ActionResult>CompletionAdvisor( [FromBody]CreateAdvisorDto createddvisordto)
        {
            try
            {

                var user = await repo.GetUserByID
                    (int.Parse(User.FindFirstValue(ClaimTypes.Name)));// Hämtar user id som är inloggad

                if (user.ProfileConfirmation) return BadRequest("Du har kompletterat din profile redan!");

             
                var advisordto = mapper.Map<AdvisorDto>(createddvisordto);
                advisordto.UserID = user.ID;
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
        /// <param name="editAdvisor"> CreateAdvisorDto MODEL</param>
        /// <returns>rådgivarefilen som har uppdaterats</returns>
        [Authorize(Roles = "Advisor")]
        [HttpPut("Update")]
        [ProducesResponseType(204, Type = typeof(AdvisorDto))]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateAdvisorProfile( [FromBody] CreateAdvisorDto editAdvisor)
        {
            try
            {
                var user = await repo.GetUserByID(int.Parse(User.FindFirstValue(ClaimTypes.Name)));// Hämtar user id som är inloggad
                if (!user.ProfileConfirmation) return Unauthorized();// Kontrollera om den här user har kompletterat sitt profil eller inte för att undvika null referens eller status kod 500.

                var advisorfromRepo = await repo.GetAdvisorByUserID(user.ID);
                if (advisorfromRepo == null) return NotFound();
                mapper.Map(editAdvisor, advisorfromRepo);

                if (!await repo.Save()) return BadRequest("Ett fel inträffade när profilen Uppdateras");

                var advisordto = mapper.Map<AdvisorDto>(advisorfromRepo);
                return Ok(advisordto);
            }
            catch (Exception)
            {

                return StatusCode(500);
            }

        }
        /// <summary>
        ///Rådgivaren kan söka efter Klienten som är hans ansvar vid namn
        /// </summary>
        /// <param name="name">,String Namn</param>
        /// <returns>List av Klienter som har samma namn eller en Klient som matchar den här namnet</returns>
        [Authorize(Roles ="Advisor")]
        [HttpGet("{name}/ClientByName")]
        [ProducesResponseType(200,Type =typeof(List<ClientToReturnDto>))]
        [ProducesDefaultResponseType]
        public async Task<ActionResult>GetClientsbyName( string name)
        {
            try
            {
                var user = await repo.GetUserByID(int.Parse(User.FindFirstValue(ClaimTypes.Name)));// Hämtar user id som är inloggad
                if (!user.ProfileConfirmation) return Unauthorized();// Kontrollera om den här user har kompletterat sitt profil eller inte för att undvika null referens eller status kod 500.
                if (string.IsNullOrEmpty(name)) return BadRequest();
                var advisor = await repo.GetAdvisorByUserID(user.ID);
                var Clients = await repo.GetClientbyName( name, advisor.ID);
                if (Clients.Count()==0) return NotFound($"Det finns inte Klienter som matchar den här namnet!{ name}");
                var ClientsDto = new List<ClientToReturnDto>();
                foreach (var client in Clients)
                {
                    ClientsDto.Add(mapper.Map<ClientToReturnDto>(client));
                }
                
                return Ok(ClientsDto) ;
                



            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }
        /// <summary>
        /// En rådgivare kan titta på klientens svar på symtom
        /// </summary>
        /// <param name="clientid"> Klient ID </param>
        /// <returns>List av ClientSymtomOverview</returns>
        [Authorize(Roles = "Advisor")]
        [HttpGet("ClientSymptomsAnsewr")]
        [ProducesResponseType(200, Type = typeof(List<ClientSymptom>))]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<IEnumerable<ClientSymptom>>> GetSymtomAnsewr( int clientid)
        {
            try
            {
                var user = await repo.GetUserByID(int.Parse(User.FindFirstValue(ClaimTypes.Name)));// Hämtar user id som är inloggad
                if (!user.ProfileConfirmation) return Unauthorized();// Kontrollera om den här user har kompletterat sitt profil eller inte för att undvika null referens eller status kod 500.
                var advisor = await repo.GetAdvisorByUserID(user.ID);
                var client = await repo.GetClientByID(clientid);
                if (client.AdvisorID != advisor.ID) return Unauthorized();

                var symtomsoverview = await repo.GetClientSymtomAnsewr(clientid);
                if (symtomsoverview == null) return BadRequest();
                var symtomview = new List<ClientSymtomOverview>();
                foreach (var item in symtomsoverview)
                {
                    symtomview.Add(mapper.Map<ClientSymtomOverview>(item));
                }
                return Ok(symtomview);

            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
            /// <summary>
            /// Rådgivaren kan titta på Symptoms Screening -översikt för en klient
            /// </summary>
            /// <param name="clientid"> klient id</param>
            /// <returns>List SymtomOverview</returns>
            [Authorize(Roles = "Advisor")]
            [HttpGet("{clientid}/SymptomsOverview")]
            [ProducesResponseType(200, Type = typeof(List<SymtomOverview>))]
            [ProducesDefaultResponseType]
            public async Task<ActionResult> SymptomsOverview(int clientid)
            {
                try
                {
                    var client = await repo.GetClientByID(clientid);
                    var advisor = await repo.GetAdvisorByUserID(int.Parse(User.FindFirstValue(ClaimTypes.Name)));
                    if (client.AdvisorID != advisor.ID) return Unauthorized();
                    var symtomview = await repo.GetSymtomOverview(clientid);


                    if (symtomview == null) return BadRequest();
                    return Ok(symtomview);

                }
                catch (Exception)
                {

                    return StatusCode(500);
                }
            
        }
       





    }
}
