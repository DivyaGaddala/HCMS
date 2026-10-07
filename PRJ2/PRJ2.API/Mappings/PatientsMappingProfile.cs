using AutoMapper;
using PRJ2.API.DTO;
using PRJ2.API.Models;

namespace PRJ2.API.Mappings
{
    public class PatientsMappingProfile :Profile
    {
        public PatientsMappingProfile()
        {
            CreateMap<Patients, PatientsDTO>();
        }
    }
}
