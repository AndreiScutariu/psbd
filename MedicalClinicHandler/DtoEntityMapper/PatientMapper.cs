using AutoMapper;
using MedicalClinicHandler.Dto;
using MedicalClinicHandler.Utils;
using MedicalClinicRepository.Entities;
using MedicalClinicRepository.Factory;

namespace MedicalClinicHandler.DtoEntityMapper
{
    public static class PatientMapper
    {
        static PatientMapper()
        {
            InitMapper.InitUserMapper();
        }

        public static PatientDto GetDto(Patient patient)
        {
            if (patient == null)
                return null;

            var patientDto = Mapper.Map<Patient, PatientDto>(patient);
            return patientDto;
        }

        public static Patient SetEntity(Patient patient, PatientDto patientDto)
        {
            if (patientDto == null)
                return null;
   
            Mapper.Map(patientDto, patient);
            return patient;
        }
    }
}