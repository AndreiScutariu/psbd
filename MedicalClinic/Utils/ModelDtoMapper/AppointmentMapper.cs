using AutoMapper;
using MedicalClinic.Models.Medic.Appointment;
using MedicalClinicHandler.Dto;

namespace MedicalClinic.Utils.ModelDtoMapper
{
    public static class AppointmentMapper
    {
        static AppointmentMapper()
        {
            InitMapper.InitUserMapper();
        }

        public static AppointmentDto GetDto(AppointmentModel appointment)
        {
            if (appointment == null)
                return null;

            var appointmentDto = Mapper.Map<AppointmentModel, AppointmentDto>(appointment);
            appointmentDto.PatientDto = new PatientDto { Id = appointment.PatientId };
            appointmentDto.UserDto = new UserDto { Id = appointment.UserId };
            return appointmentDto;
        }

        public static AppointmentModel GetModel(AppointmentDto appointmentDto)
        {
            if (appointmentDto == null)
                return null;

            var appointment = Mapper.Map<AppointmentDto, AppointmentModel>(appointmentDto);
            appointment.UserModel = UserMapper.GetModel(appointmentDto.UserDto);
            appointment.PatientModel = PatientMapper.GetModel(appointmentDto.PatientDto);
            return appointment;
        }
    }
}