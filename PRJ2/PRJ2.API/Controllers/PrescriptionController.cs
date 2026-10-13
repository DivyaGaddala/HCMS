using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PRJ2.API.DTO;
using PRJ2.API.Models;
using PRJ2.API.Repositories;

namespace PRJ2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionController : Controller
    {



        private readonly IPrescriptionRepository repository;
        private readonly IMapper mapper;

        public PrescriptionController(
            IPrescriptionRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var prescriptions = await repository.GetAllAsync();

            var result = prescriptions.Select(p => new
            {
                p.PrescriptionId,
                p.PatientId,
                p.DoctorId,
                p.PrescriptionDate,
                p.MedicineName,
                p.Dosage,
                p.Frequency,
                p.Duration,
                p.Instructions
            });

            return Ok(result);
        }


        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var prescription = await repository.GetByIdAsync(id);

            if (prescription == null)
            {
                return NotFound();
            }

            return Ok(prescription);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddPrescriptionRequestDTO addrequest)
        {


            Console.WriteLine("STEP 1: POST started");

            var prescription = mapper.Map<Prescription>(addrequest);
            Console.WriteLine("STEP 2: Mapping completed");

            var createdPrescription =
                await repository.CreateAsync(prescription);
            Console.WriteLine("STEP 3: Repository completed");

            return Ok(createdPrescription);
        }

    

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(
            Guid id, Prescription prescription)
        {
            if (id != prescription.PrescriptionId)
            {
                return BadRequest("Prescription ID mismatch.");
            }

            var updatedPrescription =
                await repository.UpdateAsync(prescription);

            if (updatedPrescription == null)
            {
                return NotFound();
            }

            return Ok(updatedPrescription);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var deletedPrescription =
                await repository.DeleteAsync(id);

            if (deletedPrescription == null)
            {
                return NotFound();
            }

            return Ok(deletedPrescription);
        }
    }
}

