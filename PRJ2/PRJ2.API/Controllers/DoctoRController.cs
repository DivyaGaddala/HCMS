using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PRJ2.API.DTO;
using PRJ2.API.Models;
using PRJ2.API.Repositories;

namespace PRJ2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctoRController : Controller
    {
        private readonly IDoctoRRepository repository;
        private readonly IMapper mapper;

        public DoctoRController(IDoctoRRepository repository,IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult>GetAllAsync()
        {
            var doctor = await repository.GetAllAsync();
            var doctorDTO = mapper.Map<List<DoctorDTO>>(doctor);

            return Ok(doctorDTO);
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult>GetByIdAsync(Guid id)
        {
            var doctor = await repository.GetByIdAsync(id);

            if(doctor == null)
            {
                return NotFound();
            }

            var doctordto = mapper.Map<DoctorDTO>(doctor);
            return Ok(doctordto);
        }


        [HttpPost]
        public async Task<IActionResult> CreateAsync(AddDoctorRequestDTO addrequest)
        {
            var doctor = mapper.Map<DoctoR>(addrequest);
            var createdoctor = await repository.CreateAsync(doctor);
            var doctordto = mapper.Map<DoctorDTO>(createdoctor);
            return Ok(doctordto);
        }

        [HttpPut("{id:Guid}")]
        public async Task<IActionResult> UpdateAsync(
      Guid id,
      UpdateDoctorRequestDTO updaterequest)
        {
            // Get existing doctor
            var existingDoctor = await repository.GetByIdAsync(id);

            if (existingDoctor == null)
            {
                return NotFound();
            }

            // DTO → Domain Model
            var doctor = mapper.Map<DoctoR>(updaterequest);

            // Keep the existing ID
            doctor.Id = existingDoctor.Id;

            // Update
            var updatedDoctor = await repository.UpdateAsync(doctor);

            // Domain Model → DTO
            var doctorDTO = mapper.Map<DoctorDTO>(updatedDoctor);

            return Ok(doctorDTO);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult>DeleteAsync(Guid id)
        {
            var doctor = await repository.DeleteAsync(id);
            if(doctor == null)
            {
                return NotFound();
            }
            var deletedto = mapper.Map<DoctorDTO>(doctor);
            return Ok(deletedto);
        }




    }
}
