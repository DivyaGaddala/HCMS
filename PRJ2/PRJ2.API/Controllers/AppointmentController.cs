using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using PRJ2.API.DTO;
using PRJ2.API.Models;
using PRJ2.API.Repositories;

namespace PRJ2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : Controller
    {
        private readonly IAppointmentRepository repository;
        private readonly IMapper mapper;

        public AppointmentController(IAppointmentRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var app = await repository.GetAllAsync();
            var appdto = mapper.Map<List<AppointmentDTO>>(app);
            return Ok(appdto);
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetByIdAsync(Guid id) 
            {
                var appointment = await repository.GetByIdAsync(id);
                if (appointment == null)
                {
                    return NotFound();
                }
                var apptdto = mapper.Map<AppointmentDTO>(appointment);
                return Ok(apptdto);
            }


            [HttpPost]
           public   async Task<IActionResult> CreateAsync(AddAppointmentRequestDTO request)
            {
            var appoint = mapper.Map<Appointment>(request);
            var app = await repository.CreateAsync(appoint);
            var appdto= mapper.Map<AppointmentDTO>(app);
            return Ok(appdto);
            }

        [HttpPut("{id:Guid}")]
        public async Task<IActionResult>UpdateAsync(Guid id, UpdateAppointmentRequestDTO request)
        {
            var existingid = await repository.GetByIdAsync(id);
            if(existingid == null)
            {
                return NotFound();
            }
            var domain = mapper.Map<Appointment>(request);
            domain.AppointmentId = id;
            var updateappt = await repository.UpdateAsync(domain);
            var dto = mapper.Map<AppointmentDTO>(updateappt);
            return Ok(dto);

        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult>DeleteAsync(Guid id)
        {
            var existid = await repository.GetByIdAsync(id);
            if(existid == null)
            {
                return NotFound();
            }
            var delete = await repository.DeleteAsync(id);
            var dtoapp= mapper.Map<AppointmentDTO>(delete);
            return Ok(dtoapp);
        }

        }
    }


