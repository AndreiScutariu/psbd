namespace MedicalClinicExceptions
{
    public abstract class McDatabaseBaseException : McBaseException
    {
        protected McDatabaseBaseException()
        {
            CustomMessage = "A aparut o eroare la nivelul bazei de date.";
        }
    }
}