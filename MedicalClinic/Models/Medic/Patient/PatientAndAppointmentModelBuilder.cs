using System.Collections.Generic;
using System.Linq;
using MedicalClinic.Models.Medic.Appointment;
using MedicalClinic.Utils.ModelDtoMapper;
using MedicalClinicHandler.Dto;
using MedicalClinicHandler.Handlers;

namespace MedicalClinic.Models.Medic.Patient
{
    public class PatientAndAppointmentModelBuilder : UserModelBuilder
    {
        private readonly IPatientHandler _patientHandler;
        private readonly IAppointmentHandler _appointmentHandler;
        private readonly IDiagnosticHadler _diagnosticHadler;
        private readonly IMedicalResultHandler _medicalResultHandler;

        public PatientAndAppointmentModelBuilder(IPatientHandler patientHandler, IAppointmentHandler appointmentHandler, IUserHandler userHandler, IRoleHandler roleHandler, IDiagnosticHadler diagnosticHadler, IMedicalResultHandler medicalResultHandler)
            : base(userHandler, roleHandler)
        {
            _patientHandler = patientHandler;
            _appointmentHandler = appointmentHandler;
            _diagnosticHadler = diagnosticHadler;
            _medicalResultHandler = medicalResultHandler;
        }

        public void SavePatient(PatientModel patientModel)
        {
            var patientDto = PatientMapper.GetDto(patientModel);
            _patientHandler.SavePatient(patientDto);
        }

        public List<PatientModel> GetAllPatients()
        {
            var modelList = new List<PatientModel>();
            var currentIdx = 0;
            foreach (var model in _patientHandler.GetAllPatients().Select(PatientMapper.GetModel))
            {
                model.CurrentIndex = ++currentIdx;
                modelList.Add(model);
            }
            return modelList;
        }

        public void SaveAppointment(AppointmentModel appointmentModel)
        {
            var appointmentDto = AppointmentMapper.GetDto(appointmentModel);
            _appointmentHandler.SaveAppointment(appointmentDto);
        }

        public List<AppointmentModel> GetAllAppointments(int userId)
        {
            var modelList = new List<AppointmentModel>();
            var currentIdx = 0;
            foreach (var model in _appointmentHandler.GetAllAppointments(userId).Select(AppointmentMapper.GetModel))
            {
                model.CurrentIndex = ++currentIdx;
                modelList.Add(model);
            }
            return modelList;
        }

        public List<AppointmentModel> GetOtherAppointmentsBasedOnMySpecialization(int userId)
        {
            var modelList = new List<AppointmentModel>();
            var mySpecs = GetSpecsIdsList(userId);
            var currentIdx = 0;
            foreach (var model in _appointmentHandler.GetAll()
                                   .Select(AppointmentMapper.GetModel)
                                   .Where(model => model.UserModel.Id != userId)
                                   .Select(model => new
                                   {
                                       model,
                                       addThisAppointment =
                                           model.UserModel.Specialization.Any(spec => mySpecs.Contains(spec.Id))
                                   })
                                   .Where(@t => @t.addThisAppointment)
                                   .Select(@t => @t.model))
            {
                model.CurrentIndex = ++currentIdx;
                if (model.Id != null)
                {
                    var firstOrDefault = _medicalResultHandler.GetDiagnosticForAppointment((int)model.Id).FirstOrDefault();
                    if (firstOrDefault != null)
                        model.Diagnostic = firstOrDefault.Name;
                }
                modelList.Add(model);
            }
            return modelList;
        }

        private List<int> GetSpecsIdsList(int userId)
        {
            var user = UserHandler.GetById(userId);
            return user.Specializations.Where(spec => spec.Confirmed == 1).Select(spec => spec.Id).ToList();
        }

        private List<MessageDto> GetMessagesForUser(int userId)
        {
            var user = UserHandler.GetById(userId);
            return user.MessageDtos;
        }

        public AppointmentDiagnosticModel GetAppointment(int userId, int appointmentId)
        {
            return new AppointmentDiagnosticModel
            {
                AppointmentModel = AppointmentMapper.GetModel(_appointmentHandler.GetById(appointmentId)),
                GetSpecIds = GetSpecsIdsList(userId),
                LastDescription = _medicalResultHandler.GetMedicalResultForAppointment(appointmentId),
                DiagnosticDtos = _medicalResultHandler.GetDiagnosticForAppointment(appointmentId).ToList(),
                CreatedDate = _medicalResultHandler.GetMedicalResultDateTimeForAppointment(appointmentId),
                MessageDtos = GetMessagesForUser(userId)
            };
        }

        public AppointmentDiagnosticModel GetAppointmentById(int appointmentId)
        {
            return new AppointmentDiagnosticModel
            {
                AppointmentModel = AppointmentMapper.GetModel(_appointmentHandler.GetById(appointmentId)),
                LastDescription = _medicalResultHandler.GetMedicalResultForAppointment(appointmentId),
                DiagnosticDtos = _medicalResultHandler.GetDiagnosticForAppointment(appointmentId).ToList(),
                CreatedDate = _medicalResultHandler.GetMedicalResultDateTimeForAppointment(appointmentId)
            };
        }

        public void AddNewDiagnosticToAppointment(int appointmentId, int diagnosticId, string userDescription)
        {
            _appointmentHandler.AddNewDiagnosticToAppointment(appointmentId, diagnosticId, userDescription);
        }

        public void SendMessage(int userId, int toId, string message)
        {
            _appointmentHandler.SendMessage(userId, toId, message);
        }
    }
}