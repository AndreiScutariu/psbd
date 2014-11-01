using MedicalClinicRepository.Managers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MedicalClinicRepositoryTest.Manager
{
    public class UserRoleManagerSpecs
    {
        [TestClass]
        public class WhenGetAllRoles
        {
            readonly UserRoleManager _userRoleManager = new UserRoleManager();

            [TestMethod]
            public void ListShouldNotBeEmpty()
            {
                var size = _userRoleManager.GetAll().Count;
                Assert.IsTrue(size > 0);
            }
        }
    }
}