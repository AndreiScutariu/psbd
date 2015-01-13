using AutoMapper;
using MedicalClinicHandler.Dto;
using MedicalClinicHandler.Utils;
using MedicalClinicRepository.Entities;

namespace MedicalClinicHandler.DtoEntityMapper
{
    public static class DiagnosticMapper
    {
        static DiagnosticMapper()
        {
            InitMapper.InitUserMapper();
        }

        public static DiagnosticDto GetDto(Diagnostic diag)
        {
            return Mapper.Map<Diagnostic, DiagnosticDto>(diag);
        }

        public static Diagnostic GetEntity(DiagnosticDto diagDto)
        {
            return Mapper.Map<DiagnosticDto, Diagnostic>(diagDto);
        }
    }
}
