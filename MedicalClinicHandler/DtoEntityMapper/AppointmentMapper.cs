using AutoMapper;
using MedicalClinicHandler.Dto;
using MedicalClinicHandler.Utils;
using MedicalClinicRepository.Entities;

namespace MedicalClinicHandler.DtoEntityMapper
{
    public static class AppointmentMapper
    {
        static AppointmentMapper()
        {
            InitMapper.InitUserMapper();
        }

        public static AppointmentDto GetDto(Appointment appointment)
        {
            if (appointment == null)
                return null;

            var appointmentDto = Mapper.Map<Appointment, AppointmentDto>(appointment);
            appointmentDto.PatientDto = PatientMapper.GetDto(appointment.Patient);
            appointmentDto.UserDto = UserMapper.GetDto(appointment.User);
            return appointmentDto;
        }

        public static Appointment SetEntity(Appointment appointment, AppointmentDto appointmentDto)
        {
            if (appointmentDto == null)
                return null;
   
            Mapper.Map(appointmentDto, appointment);
            return appointment;
        }
    }
}