using System.Linq;
using System.Web;
using System.Web.Mvc;
using MedicalClinic.Models.Medic;
using MedicalClinic.Models.Medic.Appointment;
using MedicalClinic.Models.Medic.Patient;
using MedicalClinic.Models.Medic.Specializations;
using MedicalClinic.Utils;

namespace MedicalClinic.Controllers
{
    [Authorize(Roles = "Medic")]
    public class UserController : BaseController
    {
        private readonly PatientAndAppointmentModelBuilder _patientAndAppointmentModelBuilder;
        private readonly SpecializationModelBuilder _specializationModelBuilder;

public UserController(UserModelBuilder userModelBuilder, PatientAndAppointmentModelBuilder patientAndAppointmentModelBuilder, SpecializationModelBuilder specializationModelBuilder)
    : base(userModelBuilder)
{
    _patientAndAppointmentModelBuilder = patientAndAppointmentModelBuilder;
    _specializationModelBuilder = specializationModelBuilder;
}

        [HttpGet]
        public ActionResult Home() // Appointments
        {
            var userId = Session[SessionKeys.UserId];
            if (userId == null)
            {
                return RedirectToAction("Login", "Home");
            }

            return View("Appointments", _patientAndAppointmentModelBuilder.GetAllAppointments((int)userId));
        }

        [HttpGet]
        public ActionResult Patients()
        {
            var userId = Session[SessionKeys.UserId];
            if (userId == null)
            {
                return RedirectToAction("Login", "Home");
            }

            return View("Patients", _patientAndAppointmentModelBuilder.GetAllPatients());
        }

        #region CrudOperations on Appointments And Patients

        [HttpGet]
        public ActionResult AddNewAppointment()
        {
            return View("AddAppointment");
        }

        [HttpPost]
        public ActionResult AddNewAppointment(AppointmentModel appointmentModel)
        {
            if (!ModelState.IsValid)
            {
                return View("AddAppointment", appointmentModel);
            }

            appointmentModel.UserId = UserId;
            _patientAndAppointmentModelBuilder.SaveAppointment(appointmentModel);
            return RedirectToAction("Home");
        }

        [HttpGet]
        public ActionResult AddPatient()
        {
            return View("AddPatient");
        }

        [HttpPost]
        public ActionResult AddPatient(PatientModel patientModel)
        {
            if (!ModelState.IsValid)
            {
                return PartialView("AddPatient", patientModel);
            }

            _patientAndAppointmentModelBuilder.SavePatient(patientModel);
            return RedirectToAction("Patients");
        }

        #endregion

        [HttpGet]
        public ActionResult Specializations()
        {
            var userId = Session[SessionKeys.UserId];
            if (userId == null)
            {
                return RedirectToAction("Login", "Home");
            }

            var specModel = new SpecializationModel { ActualSpecializations = _patientAndAppointmentModelBuilder.GetUserById(UserId).Specialization };
            return View("Specializations", specModel);
        }

        public JsonResult AddNewSpecialization(int specializationId)
        {
            if (UserModel.Specialization.Any(spec => spec.Id == specializationId))
            {
                return Json("Deja exita aceasta specializare", JsonRequestBehavior.AllowGet);
            }

            _specializationModelBuilder.AddNewSpecializationToUser(UserId, specializationId);
            return Json("S-a trimis cererea pentru o noua specializare. Asteptati confirmarea din partea administatorului.", JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult EditAppointment(int appointmentId)
        {
            var userId = Session[SessionKeys.UserId];
            if (userId == null)
            {
                return RedirectToAction("Login", "Home");
            }

            return View("Appointment", _patientAndAppointmentModelBuilder.GetAppointment(UserId, appointmentId));
        }

        public JsonResult AddNewDiagnosticToPatient(int appointmentId, int diagnosticId, string userDescription)
        {
            var appointment = _patientAndAppointmentModelBuilder.GetAppointment(UserId, appointmentId);
            if (appointment.DiagnosticDtos.Any(diag => diag.Id == diagnosticId))
            {
                return Json("Deja exista acest diagnostic.", JsonRequestBehavior.AllowGet);
            }

            _patientAndAppointmentModelBuilder.AddNewDiagnosticToAppointment(appointmentId, diagnosticId, userDescription);
            return Json("S-a adaugat diagnosticul.", JsonRequestBehavior.AllowGet);
        }

        public FileResult DownloadHelpFile()
        {
            var sDocument = Server.MapPath("/Content/medic-help.chm");
            return File(sDocument, "application/vnd.ms-htmlhelp", "MedicalClinicHelp.chm");
        }

        [HttpGet]
        public ActionResult ViewOtherAppointments()
        {
            var userId = Session[SessionKeys.UserId];
            if (userId == null)
            {
                return RedirectToAction("Login", "Home");
            }

            return View(_patientAndAppointmentModelBuilder.GetOtherAppointmentsBasedOnMySpecialization( (int)userId) );
        }

        [HttpGet]
        public ActionResult ViewAppointment(int appointmentId, int toId)
        {
            var userId = Session[SessionKeys.UserId];
            if (userId == null)
            {
                return RedirectToAction("Login", "Home");
            }

            return View("ViewAppointment", _patientAndAppointmentModelBuilder.GetAppointmentById(appointmentId));
        }
        
        public JsonResult SendMessage(int toId, string message)
        {
            _patientAndAppointmentModelBuilder.SendMessage(UserId, toId, message);
            return Json("S-a trimis mesajul.", JsonRequestBehavior.AllowGet);
        }
    }
}