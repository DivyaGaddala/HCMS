using AutoMapper;
using PRJ2.API.DTO;
using PRJ2.API.Models;

namespace PRJ2.API.Mappings
{
    public class DoctorMappingProfile :Profile
    {
        public DoctorMappingProfile()
        {
            CreateMap<DoctoR ,DoctorDTO>().ReverseMap();
            CreateMap<AddDoctorRequestDTO, DoctoR>().ReverseMap();
            CreateMap<UpdateDoctorRequestDTO , DoctoR>().ReverseMap();
        }
    }
}
