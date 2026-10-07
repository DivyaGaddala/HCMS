using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PRJ2.API.Models;
using PRJ2.API.Repositories;

namespace PRJ2.API.Controllers
{
    public class PatientsController : ControllerBase
    {
        private readonly IPatientsRepository repository;
        private readonly IMapper mapper;

        public PatientsController(IPatientsRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        [Route("api/[controller]")]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var patients = await repository.GetAllAsync();

            return Ok(patients);
        
    }

    }

    }

