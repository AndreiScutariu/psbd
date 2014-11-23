using System;
using MedicalClinicRepository.Entities;
using MedicalClinicRepository.Managers;
using MedicalClinicRepository.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MedicalClinicRepositoryTest.Manager
{
    public class AppointmentManagerSpecs
    {
        [TestClass]
        public class WhenAddingNewAppointment
        {
            private Appointment _appointment;
            private readonly User _user;
            private readonly Pacient _pacient;
            private readonly UserRoleManager _userRoleManager = new UserRoleManager();
            private readonly UserManager _userManager = new UserManager();
            private readonly PacientManager _pacientManager = new PacientManager();
            private readonly AppointmentManager _appointmentManager = new AppointmentManager();

            public WhenAddingNewAppointment()
            {
                var administrator = _userRoleManager.GetById((int)Roles.Admin);
                _user = new User
                {
                    FirstName = "Andrei",
                    LastName = "Scutariu",
                    Email = "andrei_s4u@yahoo.com",
                    Password = "andpass",
                    UserRole = administrator
                };
                _pacient = new Pacient
                {
                    FirstName = "Andrei",
                    LastName = "Scutariu",
                    Email = "andrei_s4u@yahoo.com",
                    PhoneNumber = "0756487225",
                    PersonalId = "1234567890",
                    BirthDate = new DateTime(1992, 12, 4)
                };
                
            }

            [TestInitialize]
            public void Initialize()
            {
                using (var tx = _pacientManager.Session.BeginTransaction())
                {
                    _pacientManager.Save(_pacient);
                    _userManager.Save(_user);
                    tx.Commit();
                }

                _appointment = new Appointment
                {
                    Description = "Test Description",
                    AppointmentDate = DateTime.Now,
                    Pacient = _pacientManager.GetById(_pacient.Id),
                    User = _userManager.GetById(_user.Id)
                };

                using (var tx = _appointmentManager.Session.BeginTransaction())
                {
                    _appointmentManager.Save(_appointment);
                    tx.Commit();
                }
            }

            [TestMethod]
            public void ThenIsSavedInDatatabase()
            {
                Assert.IsTrue(_appointment.Id > 0);
            }

            [TestCleanup]
            public void Cleanup()
            {
                using (var tx = _appointmentManager.Session.BeginTransaction())
                {
                    _appointmentManager.Delete(_appointment);
                    tx.Commit();
                }

                using (var tx = _pacientManager.Session.BeginTransaction())
                {
                    _pacientManager.Delete(_pacient);
                    _userManager.Delete(_user);
                    tx.Commit();
                }
            }
        }

        [TestClass]
        public class WhenGettingAnAppointment
        {
            private Appointment _appointment;
            private readonly User _user;
            private readonly Pacient _pacient;
            private readonly UserRoleManager _userRoleManager = new UserRoleManager();
            private readonly UserManager _userManager = new UserManager();
            private readonly PacientManager _pacientManager = new PacientManager();
            private readonly AppointmentManager _appointmentManager = new AppointmentManager();

            public WhenGettingAnAppointment()
            {
                var administrator = _userRoleManager.GetById((int)Roles.Admin);
                _user = new User
                {
                    FirstName = "Andrei",
                    LastName = "Scutariu",
                    Email = "andrei_s4u@yahoo.com",
                    Password = "andpass",
                    UserRole = administrator
                };
                _pacient = new Pacient
                {
                    FirstName = "Andrei",
                    LastName = "Scutariu",
                    Email = "andrei_s4u@yahoo.com",
                    PhoneNumber = "0756487225",
                    PersonalId = "1234567890",
                    BirthDate = new DateTime(1992, 12, 4)
                };

            }

            [TestInitialize]
            public void Initialize()
            {
                using (var tx = _pacientManager.Session.BeginTransaction())
                {
                    _pacientManager.Save(_pacient);
                    _userManager.Save(_user);
                    tx.Commit();
                }

                _appointment = new Appointment
                {
                    Description = "Test Description",
                    AppointmentDate = DateTime.Now,
                    Pacient = _pacientManager.GetById(_pacient.Id),
                    User = _userManager.GetById(_user.Id)
                };

                using (var tx = _appointmentManager.Session.BeginTransaction())
                {
                    _appointmentManager.Save(_appointment);
                    tx.Commit();
                }

                //Clear the session cache objects
                _appointmentManager.Session.Clear();
                _appointmentManager.Session.Evict(_appointment);

                _appointment = _appointmentManager.GetById(_appointment.Id);
            }

            [TestMethod]
            public void ThenAppointmentIsLoader()
            {
                Assert.IsTrue(_appointment.Id > 0);
            }

            [TestMethod]
            public void ThenUserIsTheSame()
            {
                Assert.IsTrue(_user.Id == _appointment.User.Id);
            }

            [TestMethod]
            public void ThenPacientIsTheSame()
            {
                Assert.IsTrue(_pacient.Id == _appointment.Pacient.Id);
            }
            [TestCleanup]
            public void Cleanup()
            {
                using (var tx = _appointmentManager.Session.BeginTransaction())
                {
                    _appointmentManager.Delete(_appointment);
                    tx.Commit();
                }

                using (var tx = _pacientManager.Session.BeginTransaction())
                {
                    _pacientManager.Delete(_pacient);
                    _userManager.Delete(_user);
                    tx.Commit();
                }
            }
        }
    }
}