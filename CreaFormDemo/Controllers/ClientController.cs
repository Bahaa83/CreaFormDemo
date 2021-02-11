using AutoMapper;
using CreaFormDemo.DtoModel.ClientDtoModel;
using CreaFormDemo.DtoModel.GeneralQuesDtoModel;
using CreaFormDemo.DtoModel.MedicineDtoModel;
using CreaFormDemo.DtoModel.SymtomDtoModel;
using CreaFormDemo.DtoModel.WellBeingDtoModel;
using CreaFormDemo.Entitys.Clientprofile;
using CreaFormDemo.Entitys.Symptoms;
using CreaFormDemo.Entitys.Users;
using CreaFormDemo.Services.IRepository;
using CreaFormDemo.ViewModel;
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
        private readonly ISymtomRepo symRepo;
        private readonly IMapper mapper;
        private readonly IAdvisorRepository advisorRepo;

        public ClientController(IClientRepository repo,ISymtomRepo SymRepo,IMapper mapper, IAdvisorRepository advisorRepo)
        {
            this.repo = repo;
            symRepo = SymRepo;
            this.mapper = mapper;
            this.advisorRepo = advisorRepo;
        }
        /// <summary>
        /// Klienten kan komplettera sin profile(Namn och kontakt uppgifter)
        /// </summary>
        /// <param name="model">CompletionClientDto model</param>
        /// <returns></returns>
        [Authorize(Roles ="Client")]
        [HttpPost("CompletionClient")]
        [ProducesResponseType(200,Type =typeof(ClientToReturnDto))]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> CompletionClient(CompletionClientDto model)
        {
            try
            {

                var user = await repo.GetUserByID(int.Parse(User.FindFirstValue(ClaimTypes.Name)));// hämtar user id som är inloggning
                if (user.ProfileConfirmation) return Unauthorized("Du har kompletterat din profile redan!");// Kontrollera om den här user har kompletterat sitt profil eller inte för att undvika null referens eller status kod 500.
                var clienttest = await repo.GetClientByUserID(user.ID);
                var advisor = await advisorRepo.GetAdvisorByUserID(int.Parse(user.UserIdThatCreatedit));
                var clientDto = mapper.Map<ClientDto>(model);
                clientDto.AdvisorID = advisor.ID ;
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
        /// <summary>
        /// Klienten kan Uppdatera sin profile(Namn och kontakt uppgifter)
        /// </summary>
        /// <param name="clientToupdate">CompletionClientDto model</param>
        /// <returns>ClientToReturnDto model</returns>
        [Authorize(Roles ="Client")]
        [HttpPut("UpdateClientProfile")]
        [ProducesResponseType(200,Type =typeof(ClientToReturnDto))]
        [ProducesDefaultResponseType]
        public async Task<ActionResult>UpdateClientProfile(CompletionClientDto clientToupdate)
        {
            try
            {
                var user = await repo.GetUserByID(int.Parse(User.FindFirstValue(ClaimTypes.Name)));// hämtar user id som är inloggning
                if (!user.ProfileConfirmation) return Unauthorized();// Kontrollera om den här user har kompletterat sitt profil eller inte för att undvika null referens eller status kod 500.
                var oldclient = await repo.GetClientByUserID(user.ID);
                if (oldclient == null) return BadRequest();
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
        /// Fyll i allmänna Klient frågor
        /// </summary>
        /// <param name="model">CreateGeneralQuesDto model</param>
        /// <returns>GeneralQuesDto model</returns>
        [Authorize(Roles ="Client")]
        [HttpPost("GeneralQuestions")]
        [ProducesResponseType(200,Type =typeof(GeneralQuesDto))]
        [ProducesDefaultResponseType]
        public async Task<ActionResult>GeneralQuestions(CreateGeneralQuesDto model)
        {
            try
            {
                var user = await repo.GetUserByID(int.Parse(User.FindFirstValue(ClaimTypes.Name)));// hämtar user id som är inloggning
                if (!user.ProfileConfirmation) return Unauthorized();// Kontrollera om den här user har kompletterat sitt profil eller inte för att undvika null referens eller status kod 500.
                var client = await repo.GetClientByUserID(user.ID);
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
        /// Klienten Kan uppdatera sin Allmänt frågor
        /// </summary>
        /// <param name="model"> CreateGeneralQuesDto MODEL</param>
        /// <returns>Allmänt som har uppdaterats</returns>
        [Authorize(Roles = "Client")]
        [HttpPut( "UpdateGeneral")]
        [ProducesResponseType(204)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateGeneralQuestions( [FromBody] CreateGeneralQuesDto model)
        {
            try
            {
                var user = await repo.GetUserByID(int.Parse(User.FindFirstValue(ClaimTypes.Name)));// hämtar user id som är inloggning
                if (!user.ProfileConfirmation) return Unauthorized();// Kontrollera om den här user har kompletterat sitt profil eller inte för att undvika null referens eller status kod 500.

                var oldGeneral = await repo.GetGeneralQuestionsbyUserid(user.ID);
                if (oldGeneral == null) return BadRequest();
                mapper.Map(model, oldGeneral);
                if (!await repo.Save()) return BadRequest("Ett fel inträffade när profilen kompletteras");
                return NoContent();
            }
            catch (Exception)
            {

                return StatusCode(500);
            }

        }
        /// <summary>
        /// Fyll i läkemedelsinformationen för klienten
        /// </summary>
        /// <param name="model">CreateMedicineDto model</param>
        /// <returns>MedicineDto Model</returns>
        [Authorize(Roles ="Client")]
        [HttpPost("{Userid}/MedicineInformation")]
        [ProducesResponseType(200,Type =typeof(MedicineDto))]
        [ProducesDefaultResponseType]
           
        public async Task<ActionResult>MedicineInformation(CreateMedicineDto model)
        {
            try
            {
                var user = await repo.GetUserByID(int.Parse(User.FindFirstValue(ClaimTypes.Name)));// hämtar user id som är inloggning
                if (!user.ProfileConfirmation) return Unauthorized();// Kontrollera om den här user har kompletterat sitt profil eller inte för att undvika null referens eller status kod 500.
                var client = await repo.GetClientByUserID(user.ID);
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
       
        /// <summary>
        /// Hämtar Symtom frågor genom OrderBy parameter för Att hämta frågorna enligt Kategori Ordningen
        /// </summary>
        /// <param name="orderby">Skickar från Client sida</param>
        /// <returns>Den returnerar symptom frågan med sin kategori </returns>
        [Authorize(Roles ="Client")]
        [HttpGet("{orderby:int}", Name ="GetSymtomQuestion")]
        [ProducesResponseType(200)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> GetSymtomQuestion(int orderby)
        {
            try
            {
                var symtomque = await repo.GetSymptomsQuesbycategory(orderby);
                if (symtomque == null) return BadRequest();
                return Ok(symtomque);
               

            }
            catch (Exception)
            {

              return   StatusCode(500);
            }
        }
        /// <summary>
        /// Hämtar svårighet value
        /// </summary>
        /// <returns>list av svårighet</returns>
        [Authorize(Roles ="Client")]
        [HttpGet("GetDifficulty")]
        [ProducesResponseType(200, Type = typeof(List<Difficulty>))]
        [ProducesDefaultResponseType]
        public async Task<ActionResult>GetDifficultyValue()
        {
            try
            {
                var difficulty = await repo.GetDifficultyValue();
                if (difficulty == null) return BadRequest();
                return Ok(difficulty);
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }
        /// <summary>
        /// Hämtar Frekvens value
        /// </summary>
        /// <returns>list av freqvens</returns>
        [Authorize(Roles = "Client")]
        [HttpGet("GetFrequency")]
        [ProducesResponseType(200,Type =typeof( List<Frequency>))]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> GetFrequencyValue()
        {
            try
            {
                var frequency = await repo.GetFrequencyValue();
                if (frequency == null) return BadRequest();
                return Ok(frequency);
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }
        /// <summary>
        /// Klienten kan fylla Välbefinnande - uppskattning 
        /// </summary>
        /// <param name="model">CreateWellBeing model</param>
        /// <returns>WellBeingToReturn model</returns>
        [Authorize(Roles ="Client")]
        [HttpPost("WellBeing")]
        [ProducesResponseType(200,Type =typeof( WellBeingToReturn))]
        [ProducesDefaultResponseType]
        public async Task<ActionResult>FillInWellBeing(CreateWellBeing model)
        {
            try
            {
                var user = await repo.GetUserByID(int.Parse(User.FindFirstValue(ClaimTypes.Name)));// hämtar user id som är inloggning
                if (!user.ProfileConfirmation) return Unauthorized();// Kontrollera om den här user har kompletterat sitt profil eller inte för att undvika null referens eller status kod 500.

                var client = await repo.GetClientByUserID(user.ID);
                if (client == null) return BadRequest();
                var wellbeing = mapper.Map<Well_being>(model);
                wellbeing.ClientID = client.ID;
                var wellbeingfromRepo = await repo.FillInWellBeing(wellbeing);
                if (wellbeingfromRepo == null) return BadRequest("Något gick fel när du fyllde i välbefinnande");
                var objekttoReturn = mapper.Map<WellBeingToReturn>(wellbeingfromRepo);
                return Ok(objekttoReturn);
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }
        /// <summary>
        /// Klienten kan Uppdatera Välbefinnande - uppskattning 
        /// </summary>
        /// <param name="model">CreateWellBeing model</param>
        /// <returns>WellBeingToReturn model</returns>
        [Authorize(Roles = "Client")]
        [HttpPut("UpdateWellBeing")]
        [ProducesResponseType(200, Type = typeof(WellBeingToReturn))]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateWellBeing( CreateWellBeing model)
        {
            try
            {
                var user = await repo.GetUserByID(int.Parse(User.FindFirstValue(ClaimTypes.Name)));// hämtar user id som är inloggning
                if (!user.ProfileConfirmation) return Unauthorized();// Kontrollera om den här user har kompletterat sitt profil eller inte för att undvika null referens eller status kod 500.

                var oldWellBeing = await repo.GetWellbeingByUserid(user.ID);
                if (oldWellBeing == null) return BadRequest();
                mapper.Map(model, oldWellBeing);
                if (!await repo.Save()) return BadRequest("Ett fel inträffade när välbefinnande Uppdateras");
                var WellBeingtoreturn = mapper.Map<WellBeingToReturn>(oldWellBeing);
                return Ok(WellBeingtoreturn);

            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }
        /// <summary>
        /// Fylla in Klienten svar i symtom tabbel
        /// </summary>
        /// <param name="symtomAnswers">List av symtom answer </param>
        /// <returns>ok</returns>
        [Authorize(Roles ="Client")]
        [HttpPost("FillInSymtom")]
        [ProducesResponseType(200)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult>FillInSymtom( List<SymtomAnswer> symtomAnswers)
        {
           
            try
            {
                var user = await repo.GetUserByID(int.Parse(User.FindFirstValue(ClaimTypes.Name)));// hämtar user id som är inloggning
                if (!user.ProfileConfirmation) return Unauthorized();// Kontrollera om den här user har kompletterat sitt profil eller inte för att undvika null referens eller status kod 500.

                var client = await repo.GetClientByUserID(user.ID);
                if (client.UserID != int.Parse(User.FindFirstValue(ClaimTypes.Name)))
                    return Unauthorized("Du är inte auktoriserad");
                var clientsymtoms = new List<ClientSymptom>();
                foreach (var symtomanswer in symtomAnswers)
                {
                    clientsymtoms.Add( mapper.Map<ClientSymptom>(symtomanswer));
                }



                foreach (var clientsymtom in clientsymtoms)
                {
                    clientsymtom.ClientID = client.ID;
                    clientsymtom.SymtomCategoryID = await symRepo.GetSymtomCategoryID(clientsymtom.SymtomText.ToLower());
                   
                }
                if (!await symRepo.AddSymtomAnswer(clientsymtoms)) return BadRequest("Något gick fel när du fyllde i Symtom");
                return Ok();

            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }
      


    }
}
