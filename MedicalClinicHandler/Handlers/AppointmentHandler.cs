using System;
using System.Collections.Generic;
using System.Linq;
using MedicalClinicHandler.Dto;
using MedicalClinicHandler.DtoEntityMapper;
using MedicalClinicRepository.Entities;
using MedicalClinicRepository.Managers;

namespace MedicalClinicHandler.Handlers
{
    public interface IAppointmentHandler
    {
        AppointmentDto SaveAppointment(AppointmentDto appointmentDto);
        IEnumerable<AppointmentDto> GetAllAppointments(int userId);
        IEnumerable<AppointmentDto> GetAll();
        void DeleteById(int appointmentId);
        AppointmentDto GetById(int appointmentId);
        void AddNewDiagnosticToAppointment(int appointmentId, int diagnosticId, string userDescription);
        void SendMessage(int userId, int toId, string message);
    }

    public class AppointmentHandler : IAppointmentHandler
    {
        private readonly IAppointmentManager _appointmentManager;
        private readonly IPatientManager _patientManager;
        private readonly IUserManager _userManager;

        private readonly IDiagnosticManager _diagnosticManager;
        private readonly IMedicalResultManager _medicalResultManager;
        private readonly IMedicalResultDiagnosticManager _medicalResultDiagnosticManager;
        private readonly IMessagesManager _messagesManager;

        public AppointmentHandler()
        {
            _appointmentManager = new AppointmentManager();
            _patientManager = new PatientManager();
            _userManager = new UserManager();
            _diagnosticManager = new DiagnosticManager();
            _medicalResultManager = new MedicalResultManager();
            _medicalResultDiagnosticManager = new MedicalResultDiagnosticManager();
            _messagesManager = new MessagesManager();
        }

        public AppointmentDto SaveAppointment(AppointmentDto appointmentDto)
        {
            using (var tx = _appointmentManager.Session.BeginTransaction())
            {
                var appointment = _appointmentManager.GetById(appointmentDto.Id) ?? new Appointment();
                AppointmentMapper.SetEntity(appointment, appointmentDto);
                
                appointment.Patient = _patientManager.GetById(appointmentDto.PatientDto.Id);
                appointment.User = _userManager.GetById(appointmentDto.UserDto.Id);
                appointmentDto.Id = _appointmentManager.SaveOrUpdate(appointment);
                
                tx.Commit();
            }
            return appointmentDto;
        }

        public IEnumerable<AppointmentDto> GetAllAppointments(int userId)
        {
            var list = _appointmentManager.GetAllAppointmentsByUserId(userId).Select(AppointmentMapper.GetDto);
            return list;
        }

        public IEnumerable<AppointmentDto> GetAll()
        {
            var list = _appointmentManager.GetAll().Select(AppointmentMapper.GetDto);
            return list;
        }

        public void DeleteById(int appointmentId)
        {
            throw new NotImplementedException();
        }

        public AppointmentDto GetById(int appointmentId)
        {
            var appointment = _appointmentManager.GetById(appointmentId);
            return AppointmentMapper.GetDto(appointment);
        }

        private MedicalResult GetMedicalResultForAppointment(int appointmentId)
        {
            return _medicalResultManager.GetByAppointmentId(appointmentId);
        }

        public void AddNewDiagnosticToAppointment(int appointmentId, int diagnosticId, string userDescription)
        {
            var appointment = _appointmentManager.GetById(appointmentId);

            var medicalResult = GetMedicalResultForAppointment(appointmentId) ??
                                new MedicalResult {Description = userDescription, Appointment = appointment, CreatedDate = DateTime.Now};
            medicalResult.Description = userDescription;
            medicalResult.CreatedDate = DateTime.Now;

            using (var tx = _medicalResultManager.Session.BeginTransaction())
            {
                _medicalResultManager.Save(medicalResult);
                tx.Commit();
            }

            var medicalResultDiagnostic = new MedicalResultDiagnostic
            {
                Diagnostic = _diagnosticManager.GetById(diagnosticId),
                MedicalResult = medicalResult
            };

            using (var tx = _medicalResultDiagnosticManager.Session.BeginTransaction())
            {
                _medicalResultDiagnosticManager.Save(medicalResultDiagnostic);
                tx.Commit();
            }
        }

        public void SendMessage(int userId, int toId, string message)
        {
            _messagesManager.SaveMessage(userId, toId, message);
        }
    }
}