using AutoMapper;
using CreaFormDemo.DtoModel;
using CreaFormDemo.Entitys.Users;
using CreaFormDemo.Services.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreaFormDemo.Controllers
{

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public class AdminController : ControllerBase
    {
        private readonly IAdminRepository repo;
        private readonly IMapper mapper;

        public AdminController(IAdminRepository repo ,IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }
        /// <summary>
        /// Admin kan hämta alla rådgivare som är finns
        /// </summary>
        /// <returns>List av Rådgivare </returns>
        [Authorize(Roles ="Admin")]
        [HttpGet]
        [ProducesResponseType(200,Type =typeof(List<AdvisorDto>))]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> GetAllAdvisors()
        {
            try
            {
                var advisors = await repo.GetAllAdvisors();
                if (advisors.Count()==0) return NotFound("Det finns inga rådgivare! ");
                var advisorDto = new List<AdvisorDto>();
                foreach (var advisor in advisors)
                {
                    advisorDto.Add(mapper.Map<AdvisorDto>(advisor));

                }
                return Ok(advisorDto);

            } 
            catch (Exception)
            {

               return StatusCode(500);
            }
        }
        /// <summary>
        /// Avbryt ett Rådgivare konto
        /// </summary>
        /// <param name="advisorid">Rådgivare ID</param>
        /// <returns>Rådgivaren som har tagits bort(hans/hennes Konto) </returns>
        [Authorize(Roles = "Admin")]
        [HttpDelete("{advisorid:int}")]
        [ProducesResponseType(204,Type =typeof(AdvisorDto))]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<AdvisorDto>> CancelAdvisorAccount(int advisorid)
        {
            try
            {
                var result = await repo.CancelAdvisorAccount(advisorid);
                if (result == null) return BadRequest("Något hände vid radering");
                var deletedadvisor = new AdvisorDto();
                deletedadvisor= mapper.Map<AdvisorDto>(result);
                return deletedadvisor;
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }
        /// <summary>
        /// Admin kan söka efter en Rådgivare via namn
        /// </summary>
        /// <param name="Name">Rådgivaren namn</param>
        /// <returns></returns>
        [Authorize(Roles ="Admin")]
        [HttpGet("{name}AdvisorByName")]
        [ProducesResponseType(200,Type =typeof(AdvisorDto))]
        [ProducesDefaultResponseType]
        public async Task<ActionResult>GetAdvisorByname(string Name)
        {
            try
            {
                if (string.IsNullOrEmpty(Name)) return BadRequest();
                var advisors = await repo.GetAdvisorByName(Name);
                if (advisors.Count()==0) return BadRequest($"Det finns inte Klienter som matchar den här namnet!{Name}");
                var advisorsDto = new List<AdvisorDto>();
                foreach (var advisor in advisors)
                {
                    advisorsDto.Add(mapper.Map<AdvisorDto>(advisor));
                }
                return Ok(advisorsDto);
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }

    }
}
