using MedicalClinicRepository.Managers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MedicalClinicRepositoryTest.Manager
{
    public class SpecializationManagerSpecs
    {
        [TestClass]
        public class WhenGetAllSpecializations
        {
            readonly SpecilizationManager _specializationManagerSpecs = new SpecilizationManager();

            [TestMethod]
            public void ListShouldNotBeEmpty()
            {
                var size = _specializationManagerSpecs.GetAll().Count;
                Assert.IsTrue(size > 0);
            }
        }
    }
}