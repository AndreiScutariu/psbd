using System.Collections.Generic;
using MedicalClinicHandler.Handlers;

namespace MedicalClinic.Models.Medic.Specializations
{
    public static class SpecializationHelper
    {
        private static readonly ISpecializationHadler SpecializationHadler;

        static SpecializationHelper()
        {
            SpecializationHadler = new SpecializationHadler();
        }

        public static IEnumerable<object> GetAllSpecializations()
        {
            foreach (var var in SpecializationHadler.GetAllSpecialization())
            {
                yield return new { value = var.Id, text = var.Description };
            }
        }
    }
}