using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PRJ2.API.DTO;
using PRJ2.API.Models;
using PRJ2.API.Repositories;

namespace PRJ2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientsRepository repository;
        private readonly IMapper mapper;


        public PatientsController(IPatientsRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var patients = await repository.GetAllAsync();

            return Ok(patients);

        }


        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var patient = await repository.GetByIdAsync(id);

            if (patient == null)
            {
                return NotFound();
            }

            var patientdto = mapper.Map<PatientsDTO>(patient);
            return Ok(patientdto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(PatientsDTO request)
        {
            var patient = mapper.Map<Patients>(request);

            var createpatients = await repository.CreateAsync(patient);

            var patientDto = mapper.Map<PatientsDTO>(createpatients);

            return Ok(patientDto);

        }
        [HttpPut("{id:Guid}")]

        public async Task<IActionResult> Update([FromRoute] Guid id, PatientsDTO request)
        {
            //DTO-Domain
            var patient = mapper.Map<Patients>(request);

            //calling the repository
            var existingpatient = await repository.GetByIdAsync(id);

            //checking
            if (existingpatient == null)
            {
                return NotFound();
            }
            //updating
            patient.Id = existingpatient.Id;
            var updatepatient = await repository.UpdateAsync(patient);

            //Domain-DTO
            var patientdTo = mapper.Map<PatientsDTO>(updatepatient);
            return Ok(patientdTo);

        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var patient = await repository.DeleteAsync(id);

            if (patient == null)
            {
                return NotFound();
            }

            return Ok(patient);
        }
    }
}
