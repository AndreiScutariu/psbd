using System.Collections.Generic;
using MedicalClinicHandler.Handlers;
using Enumerable = System.Linq.Enumerable;

namespace MedicalClinic.Models.Medic.Appointment
{
    public static class DiagnosticHelper
    {
        private static readonly IDiagnosticHadler DiagnosticHadler;

        static DiagnosticHelper()
        {
            DiagnosticHadler = new DiagnosticHadler();
        }

        public static IEnumerable<object> GetAllDiagnosticsForSpecializations(List<int> specIds)
        {
            foreach (var var in Enumerable.Where(DiagnosticHadler.GetAllDiagnostics(), var => specIds.Contains(var.SpecializationId)))
            {
                yield return new { value = var.Id, text = string.Format("{0} - [Descriere: {1}] [Solutie: {2}]", var.Name, var.Description, var.Solution) };
            }
        }
    }
}