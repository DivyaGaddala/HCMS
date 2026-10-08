using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PRJ2.API.DTO;
using PRJ2.API.Models;
using PRJ2.API.Repositories;

namespace PRJ2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository repository;
        private readonly IMapper mapper;

        public DepartmentController(IDepartmentRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var dept = await repository.GetAllAsync();
            var depdto = mapper.Map<List<DepartmentDTO>>(dept);
            return Ok(depdto);
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var dept = await repository.GetByIdAsync(id);
            if (dept == null)
            {
                return NotFound();
            }
            var deptdto = mapper.Map<DepartmentDTO>(dept);
            return Ok(deptdto);
        }

        [HttpPost]
        public async Task<IActionResult>CreateAsync(AddDepartmentRequestDTO departmentdto)
        {
            var deptdomain = mapper.Map<Department>(departmentdto);
            var dept = await repository.CreateAsync(deptdomain);
            var deptdto = mapper.Map<AddDepartmentRequestDTO>(dept);
            return Ok(deptdto);

        }

        [HttpPut("{id:Guid}")]
        public async Task<IActionResult>UpdateAsync(Guid id,UpdateDepartmentRequestDTO departmentdto)
        {
            var existingdep = await repository.GetByIdAsync(id);
            if(existingdep == null)
            {
                return NotFound();

            }
            var dept = mapper.Map<Department>(departmentdto);
            dept.DepartmentId=existingdep.DepartmentId;
            var department = await repository.UpdateAsync(dept);
            var deptdto = mapper.Map<Department>(department);
            return Ok(deptdto);

        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult>DeleteAsync(Guid id)
        {
            var dept = await repository.DeleteAsync(id);
            if(dept == null)
            {
                return NotFound();
            }
            var department = mapper.Map<DepartmentDTO>(dept);
            return Ok(department);
                
                
        }

    }
}
