using System.Collections.Generic;
using MedicalClinicHandler.Handlers;

namespace MedicalClinic.Models.Medic.Patient
{
    public static class PatientAndAppointmentHelper
    {
        private static readonly IPatientHandler PatientHandler;

        static PatientAndAppointmentHelper()
        {
            PatientHandler = new PatientHandler();
        }

        public static IEnumerable<object> GetAllPatientsSelectedList()
        {
            foreach (var var in PatientHandler.GetAllPatients())
            {
                yield return new { value = var.Id, text = string.Format("Nume: {0}[Cnp: {1}, Email: {2}, Telefon: {3}]", var.FirstName + ' ' + var.LastName, var.PersonalId, var.Email, var.PhoneNumber) };
            }
        }
    }
}