using MedicalClinicHandler.Handlers;

namespace MedicalClinic.Models.Medic.Specializations
{
    public class SpecializationModelBuilder
    {
        private readonly ISpecializationHadler _specializationHadler;

        public SpecializationModelBuilder(ISpecializationHadler specializationHadler)
        {
            _specializationHadler = specializationHadler;
        }

        public bool AddNewSpecializationToUser(int userId, int specId)
        {
            return _specializationHadler.AddNewSpecializationToUser(userId, specId);
        }
    }
}