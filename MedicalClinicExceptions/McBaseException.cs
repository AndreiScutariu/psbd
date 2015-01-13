using System;

namespace MedicalClinicExceptions
{
    public abstract class McBaseException : Exception
    {
        public ExceptionType ExceptionType { get; set; }
        public string CustomMessage { get; set; }
    }
}