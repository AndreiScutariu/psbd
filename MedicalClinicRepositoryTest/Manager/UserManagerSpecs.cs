using MedicalClinicRepository.Entities;
using MedicalClinicRepository.Managers;
using MedicalClinicRepository.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MedicalClinicRepositoryTest.Manager
{
    public class UserManagerSpecs
    {
        [TestClass]
        public class WhenAddingNewUser
        {
            private readonly UserManager _userManager = new UserManager();
            private readonly UserRoleManager _userRoleManager = new UserRoleManager();
            private readonly User _user;
            private readonly UserRole _administrator;

            public WhenAddingNewUser()
            {
                _administrator = _userRoleManager.GetById((int)Roles.Admin);
                _user = new User
                    {
                        FirstName = "Andrei",
                        LastName = "Scutariu",
                        Email = "andrei_s4u@yahoo.com",
                        Password = "andpass",
                        UserRole = _administrator
                    };
            }

            [TestInitialize]
            public void Initialize()
            {
                using (var tx = _userManager.Session.BeginTransaction())
                {
                     _userManager.Save(_user);
                    tx.Commit();
                }
            }

            [TestMethod]
            public void ThenIsSavedInDatatabase()
            {
                Assert.IsTrue(_user.Id > 0);
            }

            [TestCleanup]
            public void Cleanup()
            {
                using (var tx = _userManager.Session.BeginTransaction())
                {
                    _userManager.Delete(_user);
                    tx.Commit();
                }
            }
        }
    
        [TestClass]
        public class WhenGettingAnUser
        {
            private readonly UserManager _userManager = new UserManager();
            private readonly UserRoleManager _userRoleManager = new UserRoleManager();
            private User _user;
            private readonly UserRole _administrator;

            public WhenGettingAnUser()
            {
                _administrator = _userRoleManager.GetById((int)Roles.Admin);
                _user = new User
                    {
                        FirstName = "Andrei",
                        LastName = "Scutariu",
                        Email = "andrei_s4u@yahoo.com",
                        Password = "andpass",
                        UserRole = _administrator
                    };
            }

            [TestInitialize]
            public void Initialize()
            {
                using (var tx = _userManager.Session.BeginTransaction())
                {
                     _userManager.Save(_user);
                    tx.Commit();
                }
                _user = _userManager.GetById(_user.Id);
            }

            [TestMethod]
            public void ThenUserIsLoaded()
            {
                Assert.IsTrue(_user.Id > 0);
            }

            [TestMethod]
            public void ThenHisRoleIsAdministrator()
            {
                Assert.IsTrue(_user.UserRole == _administrator);
            }

            [TestCleanup]
            public void Cleanup()
            {
                using (var tx = _userManager.Session.BeginTransaction())
                {
                    _userManager.Delete(_user);
                    tx.Commit();
                }
            }
        }
    }
}
