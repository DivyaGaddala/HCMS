using AutoMapper;
using PRJ2.API.DTO;
using PRJ2.API.Models;

namespace PRJ2.API.Mappings
{
    public class ApointmetMappingProfile :Profile
    {
        public ApointmetMappingProfile()
        {
            CreateMap<Appointment, AppointmentDTO>().ReverseMap();
            CreateMap<AddAppointmentRequestDTO, Appointment>().ReverseMap();
            CreateMap<UpdateAppointmentRequestDTO, Appointment>().ReverseMap();

        }
    }
}
