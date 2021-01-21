using AutoMapper;
using CreaFormDemo.DtoModel.ClientDtoModel;
using CreaFormDemo.DtoModel.GeneralQuesDtoModel;
using CreaFormDemo.DtoModel.MedicineDtoModel;
using CreaFormDemo.Entitys.Clientprofile;
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
                var clienttest = await repo.GetClientByUserID(userid);
                if (clienttest != null) return BadRequest("Du har kompletterat din profile redan!");
                var user = await repo.GetUserByID(userid);
                if (user == null)
                {
                    return BadRequest();
                }

                var advisor = await advisorRepo.GetAdvisorByUserID(int.Parse(user.UserIdThatCreatedit));
                var clientDto = mapper.Map<ClientDto>(model);
                clientDto.AdvisorID = advisor.ID ;
                clientDto.UserID = userid;
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
        /// <summary>
        /// Klienten kan Uppdatera sin profile(Namn och kontakt uppgifter)
        /// </summary>
        /// <param name="Userid">User id som gjorde inloggning</param>
        /// <param name="clientToupdate">CompletionClientDto model</param>
        /// <returns>ClientToReturnDto model</returns>
        [Authorize(Roles ="Client")]
        [HttpPost("{Userid}/UpdateClientProfile")]
        [ProducesResponseType(200,Type =typeof(ClientToReturnDto))]
        [ProducesDefaultResponseType]
        public async Task<ActionResult>UpdateClientProfile(int Userid,CompletionClientDto clientToupdate)
        {
            try
            {
                if (Userid != int.Parse(User.FindFirst(ClaimTypes.Name).Value))
                {
                    return Unauthorized("Du är inte auktoriserad");
                }
                var oldclient = await repo.GetClientByUserID(Userid);
                if (oldclient == null) return BadRequest(" felet är har");
                mapper.Map(clientToupdate, oldclient);
                if (!await repo.Save()) return BadRequest("Ett fel inträffade när profilen kompletteras");
                var updatedclient = mapper.Map<ClientToReturnDto>(oldclient);
                return Ok(updatedclient);
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }
        /// <summary>
        /// Fyll i allmänna Klientfrågor
        /// </summary>
        /// <param name="Userid">User id som gjorde inloggning</param>
        /// <param name="model">CreateGeneralQuesDto model</param>
        /// <returns>GeneralQuesDto model</returns>
        [Authorize(Roles ="Client")]
        [HttpPost("{Userid}/GeneralQuestions")]
        [ProducesResponseType(200,Type =typeof(GeneralQuesDto))]
        [ProducesDefaultResponseType]
        public async Task<ActionResult>GeneralQuestions(int Userid,CreateGeneralQuesDto model)
        {
            try
            {
                if (Userid != int.Parse(User.FindFirst(ClaimTypes.Name).Value))
                {
                    return Unauthorized("Du är inte auktoriserad");
                }
                var client = await repo.GetClientByUserID(Userid);
                if (client == null) return BadRequest();
                var generalQuesdto = mapper.Map<GeneralQuesDto>(model);
                generalQuesdto.ClientID = client.ID;
                var generalQues = mapper.Map<GeneralQuestions>(generalQuesdto);
                var entity = await repo.FillInTheGeneralQuestions(generalQues);
                if (entity == null) return BadRequest("Något gick fel när du fyllde i allmänna frågor");
                var generalQuesToreturn = mapper.Map<GeneralQuesDto>(entity);

                return Ok(generalQuesToreturn);
             
            }
            catch (Exception)
            {

               return StatusCode(500);
            }
        }
        /// <summary>
        /// Fyll i läkemedelsinformationen för klienten
        /// </summary>
        /// <param name="Userid">User id som gjorde inloggning</param>
        /// <param name="model">CreateMedicineDto model</param>
        /// <returns>MedicineDto Model</returns>
        [Authorize(Roles ="Client")]
        [HttpPost("{Userid}/MedicineInformation")]
        [ProducesResponseType(200,Type =typeof(MedicineDto))]
        [ProducesDefaultResponseType]
           
        public async Task<ActionResult>MedicineInformation(int Userid,CreateMedicineDto model)
        {
            try
            {
                if (Userid != int.Parse(User.FindFirst(ClaimTypes.Name).Value))
                {
                    return Unauthorized("Du är inte auktoriserad");
                }
                var client = await repo.GetClientByUserID(Userid);
                 if (client == null) return BadRequest();
                var medicineDto = mapper.Map<MedicineDto>(model);
                medicineDto.clientID = client.ID;
                var medicine = mapper.Map<Medicine>(medicineDto);
                var entity = await repo.FillInTheMedicineInformations(medicine);
                if (entity == null) return BadRequest("Något gick fel när du fyllde i Läkemedelsinformation");
                var MedicineToReturn = mapper.Map<MedicineDto>(entity);
                return Ok(MedicineToReturn);
               
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }
    }
}
