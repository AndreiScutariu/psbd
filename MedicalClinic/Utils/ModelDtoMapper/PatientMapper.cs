using AutoMapper;
using MedicalClinic.Models.Medic.Patient;
using MedicalClinicHandler.Dto;

namespace MedicalClinic.Utils.ModelDtoMapper
{
    public static class PatientMapper
    {
        static PatientMapper()
        {
            InitMapper.InitUserMapper();
        }

        public static PatientDto GetDto(PatientModel patient)
        {
            if (patient == null)
                return null;

            var patientDto = Mapper.Map<PatientModel, PatientDto>(patient);
            return patientDto;
        }

        public static PatientModel GetModel(PatientDto patientDto)
        {
            if (patientDto == null)
                return null;

            var patient = Mapper.Map<PatientDto, PatientModel>(patientDto);
            return patient;
        }
    }
}