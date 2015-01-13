using System.Collections.Generic;
using System.Linq;
using MedicalClinicHandler.Dto;
using MedicalClinicHandler.DtoEntityMapper;
using MedicalClinicRepository.Entities;
using MedicalClinicRepository.Managers;

namespace MedicalClinicHandler.Handlers
{
    public interface IPatientHandler
    {
        PatientDto SavePatient(PatientDto patientDto);
        IEnumerable<PatientDto> GetAllPatients();
        void DeleteById(int patientId);
        PatientDto GetById(int patientId);
        PatientDto GetByPersonalId(string username);
        PatientDto GetByPhoneNumber(string username);
    }

    public class PatientHandler : IPatientHandler
    {
        private readonly IPatientManager _patientManager;

        public PatientHandler()
        {
            _patientManager = new PatientManager();
        }

        public PatientDto SavePatient(PatientDto patientDto)
        {
            using (var tx = _patientManager.Session.BeginTransaction())
            {
                var patient = _patientManager.GetById(patientDto.Id) ?? new Patient();
                PatientMapper.SetEntity(patient, patientDto);
                patientDto.Id = _patientManager.SaveOrUpdate(patient);
                tx.Commit();
            }
            return patientDto;
        }

        public IEnumerable<PatientDto> GetAllPatients()
        {
            return _patientManager.GetAll().Select(PatientMapper.GetDto);
        }

        public void DeleteById(int patientId)
        {
            throw new System.NotImplementedException();
        }

        public PatientDto GetById(int patientId)
        {
            throw new System.NotImplementedException();
        }

        public PatientDto GetByPersonalId(string username)
        {
            throw new System.NotImplementedException();
        }

        public PatientDto GetByPhoneNumber(string username)
        {
            throw new System.NotImplementedException();
        }
    }
}
