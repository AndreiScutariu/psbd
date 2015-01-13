using AutoMapper;
using MedicalClinicHandler.Dto;
using MedicalClinicRepository.Entities;

namespace MedicalClinicHandler.Utils
{
    public static class InitMapper
    {
        public static void InitUserMapper()
        {
            Mapper.CreateMap<UserDto, User>()
                  .ForMember(x => x.UserRole, opt => opt.Ignore());
            Mapper.CreateMap<User, UserDto>();

            Mapper.CreateMap<UserRoleDto, UserRole>();
            Mapper.CreateMap<UserRole, UserRoleDto>();

            Mapper.CreateMap<PatientDto, Patient>();
            Mapper.CreateMap<Patient, PatientDto>();

            Mapper.CreateMap<AppointmentDto, Appointment>();
            Mapper.CreateMap<Appointment, AppointmentDto>();

            Mapper.CreateMap<SpecializationDto, Specialization>();
            Mapper.CreateMap<Specialization, SpecializationDto>();

            Mapper.CreateMap<DiagnosticDto, Diagnostic>();
            Mapper.CreateMap<Diagnostic, DiagnosticDto>();
        }
    }
}