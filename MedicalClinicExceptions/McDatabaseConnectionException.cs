namespace MedicalClinicExceptions
{
    public class McDatabaseConnectionException : McDatabaseBaseException
    {
        public McDatabaseConnectionException()
        {
            ExceptionType = ExceptionType.CriticalError;
            CustomMessage =
                "Este o eroare la conectarea catre baza de date. Reveniti mai tarziu.";
        }
    }
}