using AutoMapper;
using MedicalClinicHandler.Dto;
using MedicalClinicHandler.Utils;
using MedicalClinicRepository.Entities;

namespace MedicalClinicHandler.DtoEntityMapper
{
    public static class SpecializationMapper
    {
        static SpecializationMapper()
        {
            InitMapper.InitUserMapper();
        }

        public static SpecializationDto GetDto(Specialization spec)
        {
            return Mapper.Map<Specialization, SpecializationDto>(spec);
        }

        public static Specialization GetEntity(SpecializationDto specDto)
        {
            return Mapper.Map<SpecializationDto, Specialization>(specDto);
        }
    }
}
