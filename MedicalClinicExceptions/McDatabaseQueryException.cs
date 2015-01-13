namespace MedicalClinicExceptions
{
    public class McDatabaseQueryException : McDatabaseBaseException
    {
        public McDatabaseQueryException()
        {
            ExceptionType = ExceptionType.MinorError;
            CustomMessage =
                "Este o eroare la executarea interogarii catre baza de date. Navigati inapoi si incercati din nou.";
        }
    }
}