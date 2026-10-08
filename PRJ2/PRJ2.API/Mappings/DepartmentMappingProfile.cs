using AutoMapper;
using PRJ2.API.DTO;
using PRJ2.API.Models;


namespace PRJ2.API.Mappings
{
    public class DepartmentMappingProfile :Profile
    {
        public DepartmentMappingProfile()
        {
            CreateMap<Department, DepartmentDTO>().ReverseMap();
            CreateMap<AddDepartmentRequestDTO, Department>().ReverseMap();
            CreateMap<UpdateDepartmentRequestDTO, Department>().ReverseMap();

        }
    }
}
