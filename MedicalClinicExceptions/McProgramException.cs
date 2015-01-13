namespace MedicalClinicExceptions
{
    public abstract class McProgramException : McBaseException
    {
        protected McProgramException()
        {
            CustomMessage = "A aparut o eroare.";
        }
    }
}