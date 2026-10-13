
using AutoMapper;
using PRJ2.API.Models;

namespace PRJ2.API.DTO.Mappings
{
    public class PrescriptionMappingProfile :Profile
    {
        public PrescriptionMappingProfile()
        {
            CreateMap<AddPrescriptionRequestDTO, Prescription>().ReverseMap();
            CreateMap<UpdatePrescriptionRequestDTO, Prescription>().ReverseMap();
            CreateMap<Prescription, PrescriptionDTO>().ReverseMap();
        }


    }
}
