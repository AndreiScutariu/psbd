using System;
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
            private readonly SpecilizationManager _specilizationManager = new SpecilizationManager();
            private readonly StaffSpecializationManager _staffSpecializationManager = new StaffSpecializationManager();

            private User _user;
            private StaffSpecialization _staffSpecialization;
            private readonly UserRole _administrator;
            private readonly Specialization _specialization1;

            public WhenGettingAnUser()
            {
                _administrator = _userRoleManager.GetById((int)Roles.Admin);
                _specialization1 = _specilizationManager.GetById((int) Specializations.Specializare1);
                _user = new User
                    {
                        FirstName = "Andrei",
                        LastName = "Scutariu",
                        Email = "andrei_s4u@yahoo.com",
                        Password = "andpass",
                        UserRole = _administrator,
                    };

                _staffSpecialization = new StaffSpecialization
                    {
                        CreatedDate = DateTime.Now,
                        Specialization = _specialization1,
                        User = _user
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

                _user.StaffSpecializations.Add(_staffSpecialization);
                using (var tx = _staffSpecializationManager.Session.BeginTransaction())
                {
                    _staffSpecializationManager.Save(_staffSpecialization);
                    tx.Commit();
                }

                //Clear the session cache objects
                _userManager.Session.Clear();
                _userManager.Session.Evict(_user);
                _staffSpecializationManager.Session.Evict(_staffSpecialization);

                _staffSpecialization = _staffSpecializationManager.GetById(_staffSpecialization.Id);
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
                Assert.IsTrue(_user.UserRole.Id == _administrator.Id);
            }

            [TestMethod]
            public void ThenHisSpecializationsIsCorrectlyLoaded()
            {
                Assert.IsTrue(_user.StaffSpecializations.Count > 0);
                Assert.IsTrue(_user.StaffSpecializations[0].Id > (int)Specializations.Specializare1);
            }

            [TestCleanup]
            public void Cleanup()
            {
                using (var tx = _staffSpecializationManager.Session.BeginTransaction())
                {
                    _staffSpecializationManager.Delete(_staffSpecialization);
                    tx.Commit();
                }
                using (var tx = _userManager.Session.BeginTransaction())
                {
                    _userManager.Delete(_user);
                    tx.Commit();
                }
            }
        }
        
        [TestClass]
        public class WhenAddingAndDeletingAnUser
        {
            private readonly UserManager _userManager = new UserManager();
            private readonly UserRoleManager _userRoleManager = new UserRoleManager();
            private readonly User _user;
            private readonly UserRole _administrator;

            private int _initialCountOfUsers;
            private int _actualCountOfUsers;

            public WhenAddingAndDeletingAnUser()
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

                _initialCountOfUsers = _userManager.GetAll().Count;
                _userManager.DeleteById(_user.Id);
                _userManager.Session.Flush();
                _actualCountOfUsers = _userManager.GetAll().Count;
            }

            [TestMethod]
            public void ThenTheUserIsDeleted()
            {
                Assert.IsTrue(_initialCountOfUsers > _actualCountOfUsers);
            }
        }
    }
}