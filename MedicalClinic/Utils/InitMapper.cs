using AutoMapper;
using MedicalClinic.Models.Medic;
using MedicalClinic.Models.Medic.Appointment;
using MedicalClinic.Models.Medic.Patient;
using MedicalClinicHandler.Dto;

namespace MedicalClinic.Utils
{
    public static class InitMapper
    {
        public static void InitUserMapper()
        {
            Mapper.CreateMap<UserDto, UserModel>();
            Mapper.CreateMap<UserModel, UserDto>();

            Mapper.CreateMap<UserRoleDto, UserRoleModel>();
            Mapper.CreateMap<UserRoleModel, UserRoleDto>();

            Mapper.CreateMap<PatientDto, PatientModel>();
            Mapper.CreateMap<PatientModel, PatientDto>();

            Mapper.CreateMap<AppointmentDto, AppointmentModel>();
            Mapper.CreateMap<AppointmentModel, AppointmentDto>();
        }
    }
}
