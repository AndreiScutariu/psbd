using MedicalClinicRepository.Entities;
using System;
using System.Collections.Generic;

namespace MedicalClinicRepository.Factory
{
    public class SequencesFactory
    {
        private static readonly Dictionary<Type, string> SequenceNames;
        static SequencesFactory()
        {
            SequenceNames = new Dictionary<Type, string>
            {
                { typeof(User), "MC_ROLE_SEQ" },
                { typeof(Pacient), "PACIENT_SEQ" },
                { typeof(Appointment), "APPOINTMENT_SEQ"},
                { typeof(UserRole), "USER_ROLE_SEQ" },
                { typeof(Specialization), "SPECIALIZATION_SEQ"},
                { typeof(StaffSpecialization), "STAFF_SPECIALIZATION_SEQ"},
                { typeof(Diagnostic), "DIAGNOSTIC_SEQ"},
                { typeof(MedicalResult), "MED_RESULT_SEQ"},
                { typeof(MedicalResultDiagnostic), "MED_DIAGNOSTIC_SEQ"}
            };
        }

        public static string GetSequenceName(Type tableType)
        {
            return SequenceNames.ContainsKey(tableType) ? SequenceNames[tableType] : "DEFAULT_SEQ";
        }
    }
}