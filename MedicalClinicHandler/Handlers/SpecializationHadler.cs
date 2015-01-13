using System.Linq;
using MedicalClinicHandler.Dto;
using System.Collections.Generic;
using MedicalClinicHandler.DtoEntityMapper;
using MedicalClinicRepository.Managers;

namespace MedicalClinicHandler.Handlers
{
    public interface ISpecializationHadler
    {
        IEnumerable<SpecializationDto> GetAllSpecialization();
        bool AddNewSpecializationToUser(int userId, int specId);
    }

    public class SpecializationHadler : ISpecializationHadler
    {
        private readonly ISpecilizationManager _specilizationManager;

        public SpecializationHadler()
        {
            _specilizationManager = new SpecilizationManager();
        }

        public IEnumerable<SpecializationDto> GetAllSpecialization()
        {
            return _specilizationManager.GetAll().Select(SpecializationMapper.GetDto);
        }

        public bool AddNewSpecializationToUser(int userId, int specId)
        {
            return _specilizationManager.AddNewSpecializationToUser(userId, specId);
        }
    }
}