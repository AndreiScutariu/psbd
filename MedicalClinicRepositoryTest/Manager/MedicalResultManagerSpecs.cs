using System;
using System.Linq;
using MedicalClinicRepository.Entities;
using MedicalClinicRepository.Managers;
using MedicalClinicRepository.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MedicalClinicRepositoryTest.Manager
{
    [TestClass]
    public class MedicalResultManagerSpecs
    {
        [TestClass]
        public class WhenAddingAnMedicalResult
        {
            private readonly Appointment _appointment;
            private readonly User _user;
            private readonly Patient _patient;
            private readonly Diagnostic _diagnostic1;
            private readonly Diagnostic _diagnostic2;
            private readonly MedicalResultDiagnostic _medicalResultDiagnostic1;
            private readonly MedicalResultDiagnostic _medicalResultDiagnostic2;
            private readonly MedicalResult _medicalResult;
            private readonly Specialization _specialization1;
            private readonly StaffSpecialization _staffSpecialization;

            private readonly MedicalResultManager _medicalResultManager = new MedicalResultManager();
            private readonly MedicalResultDiagnosticManager _medicalResultDiagnosticManager = new MedicalResultDiagnosticManager();
            private readonly DiagnosticManager _diagnosticManager = new DiagnosticManager();
            private readonly UserRoleManager _userRoleManager = new UserRoleManager();
            private readonly UserManager _userManager = new UserManager();
            private readonly PatientManager _patientManager = new PatientManager();
            private readonly AppointmentManager _appointmentManager = new AppointmentManager();
            private readonly SpecilizationManager _specilizationManager = new SpecilizationManager();
            private readonly StaffSpecializationManager _staffSpecializationManager = new StaffSpecializationManager();

            public WhenAddingAnMedicalResult()
            {
                var doctor = _userRoleManager.GetById((int)Roles.Doctor);
                _specialization1 = _specilizationManager.GetById((int)Specializations.Specializare1);

                _user = new User
                {
                    FirstName = "Andrei",
                    LastName = "Scutariu",
                    Email = "andrei_s4u@yahoo.com",
                    Password = "andpass",
                    UserRole = doctor
                };

                _patient = new Patient
                {
                    FirstName = "Andrei",
                    LastName = "Scutariu",
                    Email = "andrei_s4u@yahoo.com",
                    PhoneNumber = "0756487225",
                    PersonalId = "1234567890",
                    BirthDate = new DateTime(1992, 12, 4)
                };

                using (var tx = _patientManager.Session.BeginTransaction())
                {
                    _patientManager.Save(_patient);
                    _userManager.Save(_user);
                    tx.Commit();
                }

                _staffSpecialization = new StaffSpecialization
                {
                    CreatedDate = DateTime.Now,
                    Specialization = _specialization1,
                    User = _user
                };

                using (var tx = _staffSpecializationManager.Session.BeginTransaction())
                {
                    _staffSpecializationManager.Save(_staffSpecialization);
                    tx.Commit();
                }

                _appointment = new Appointment
                {
                    Description = "Test Description",
                    AppointmentDate = DateTime.Now,
                    Patient = _patientManager.GetById(_patient.Id),
                    User = _userManager.GetById(_user.Id)
                };

                using (var tx = _appointmentManager.Session.BeginTransaction())
                {
                    _appointmentManager.Save(_appointment);
                    tx.Commit();
                }

                _diagnostic1 = new Diagnostic
                    {
                        Description = "Description",
                        Name = "Ebola",
                        Solution = "Tratament: Impuscare in cap :)"
                    };

                _diagnostic2 = new Diagnostic
                {
                    Description = "Description",
                    Name = "Prost la cap",
                    Solution = "Tratament: Castrare :))"
                };

                using (var tx = _diagnosticManager.Session.BeginTransaction())
                {
                    _diagnosticManager.Save(_diagnostic1);
                    _diagnosticManager.Save(_diagnostic2);
                    tx.Commit();
                }

                _medicalResult = new MedicalResult
                    {
                        Appointment = _appointment,
                        CreatedDate = DateTime.Now,
                        Description = "Description"
                    };

                using (var tx = _medicalResultManager.Session.BeginTransaction())
                {
                    _medicalResultManager.Save(_medicalResult);
                    tx.Commit();
                }

                _medicalResultDiagnostic1 = new MedicalResultDiagnostic
                    {
                        CreatedDate = DateTime.Now,
                        Diagnostic = _diagnostic1,
                        MedicalResult = _medicalResult
                    };

                using (var tx = _medicalResultDiagnosticManager.Session.BeginTransaction())
                {
                    _medicalResultDiagnosticManager.Save(_medicalResultDiagnostic1);
                    tx.Commit();
                }

                _medicalResultDiagnostic2 = new MedicalResultDiagnostic
                {
                    CreatedDate = DateTime.Now,
                    Diagnostic = _diagnostic2,
                    MedicalResult = _medicalResult
                };

                using (var tx = _medicalResultDiagnosticManager.Session.BeginTransaction())
                {
                    _medicalResultDiagnosticManager.Save(_medicalResultDiagnostic2);
                    tx.Commit();
                }

                //Clear the session cache objects
                _medicalResultManager.Session.Clear();
                _medicalResultManager.Session.Evict(_medicalResult);

            }

            [TestInitialize]
            public void Initialize()
            {
                
            }

            [TestMethod]
            public void ThenMedicalResultIsSaved()
            {
                Assert.IsTrue(_medicalResult.Id > 0);
            }

            [TestCleanup]
            public void Cleanup()
            {
                using (var tx = _medicalResultDiagnosticManager.Session.BeginTransaction())
                {
                    _medicalResultDiagnosticManager.Delete(_medicalResultDiagnostic1);
                    _medicalResultDiagnosticManager.Delete(_medicalResultDiagnostic2);
                    tx.Commit();
                }

                using (var tx = _medicalResultManager.Session.BeginTransaction())
                {
                    _medicalResultManager.Delete(_medicalResult);
                    tx.Commit();
                }

                using (var tx = _appointmentManager.Session.BeginTransaction())
                {
                    _appointmentManager.Delete(_appointment);
                    tx.Commit();
                }

                using (var tx = _staffSpecializationManager.Session.BeginTransaction())
                {
                    _staffSpecializationManager.Delete(_staffSpecialization);
                    tx.Commit();
                }

                using (var tx = _patientManager.Session.BeginTransaction())
                {
                    _patientManager.Delete(_patient);
                    _userManager.Delete(_user);
                    tx.Commit();
                }

                using (var tx = _diagnosticManager.Session.BeginTransaction())
                {
                    _diagnosticManager.Delete(_diagnostic1);
                    _diagnosticManager.Delete(_diagnostic2);
                    tx.Commit();
                }
            }
        }

        [TestClass]
        public class WhenGettingAnMedicalResult
        {
            private readonly Appointment _appointment;
            private readonly User _user;
            private readonly Patient _patient;
            private readonly Diagnostic _diagnostic1;
            private readonly Diagnostic _diagnostic2;
            private readonly MedicalResultDiagnostic _medicalResultDiagnostic1;
            private readonly MedicalResultDiagnostic _medicalResultDiagnostic2;
            private readonly MedicalResult _medicalResult;

            private readonly MedicalResultManager _medicalResultManager = new MedicalResultManager();
            private readonly MedicalResultDiagnosticManager _medicalResultDiagnosticManager = new MedicalResultDiagnosticManager();
            private readonly DiagnosticManager _diagnosticManager = new DiagnosticManager();
            private readonly UserRoleManager _userRoleManager = new UserRoleManager();
            private readonly UserManager _userManager = new UserManager();
            private readonly PatientManager _patientManager = new PatientManager();
            private readonly AppointmentManager _appointmentManager = new AppointmentManager();

            private const string TestIllness = @"Prost la cap";

            public WhenGettingAnMedicalResult()
            {
                var doctor = _userRoleManager.GetById((int)Roles.Doctor);

                _user = new User
                {
                    FirstName = "Andrei",
                    LastName = "Scutariu",
                    Email = "andrei_s4u@yahoo.com",
                    Password = "andpass",
                    UserRole = doctor
                };

                _patient = new Patient
                {
                    FirstName = "Andrei",
                    LastName = "Scutariu",
                    Email = "andrei_s4u@yahoo.com",
                    PhoneNumber = "0756487225",
                    PersonalId = "1234567890",
                    BirthDate = new DateTime(1992, 12, 4)
                };

                using (var tx = _patientManager.Session.BeginTransaction())
                {
                    _patientManager.Save(_patient);
                    _userManager.Save(_user);
                    tx.Commit();
                }

                _appointment = new Appointment
                {
                    Description = "Test Description",
                    AppointmentDate = DateTime.Now,
                    Patient = _patientManager.GetById(_patient.Id),
                    User = _userManager.GetById(_user.Id)
                };

                using (var tx = _appointmentManager.Session.BeginTransaction())
                {
                    _appointmentManager.Save(_appointment);
                    tx.Commit();
                }

                _diagnostic1 = new Diagnostic
                {
                    Description = "Description",
                    Name = "Ebola",
                    Solution = "Tratament: Impuscare in cap :)"
                };

                _diagnostic2 = new Diagnostic
                {
                    Description = "Description",
                    Name = TestIllness,
                    Solution = "Tratament: Castrare :))"
                };

                using (var tx = _diagnosticManager.Session.BeginTransaction())
                {
                    _diagnosticManager.Save(_diagnostic1);
                    _diagnosticManager.Save(_diagnostic2);
                    tx.Commit();
                }

                _medicalResult = new MedicalResult
                {
                    Appointment = _appointment,
                    CreatedDate = DateTime.Now,
                    Description = "Description"
                };

                using (var tx = _medicalResultManager.Session.BeginTransaction())
                {
                    _medicalResultManager.Save(_medicalResult);
                    tx.Commit();
                }

                _medicalResultDiagnostic1 = new MedicalResultDiagnostic
                {
                    CreatedDate = DateTime.Now,
                    Diagnostic = _diagnostic1,
                    MedicalResult = _medicalResult
                };

                using (var tx = _medicalResultDiagnosticManager.Session.BeginTransaction())
                {
                    _medicalResultDiagnosticManager.Save(_medicalResultDiagnostic1);
                    tx.Commit();
                }

                _medicalResultDiagnostic2 = new MedicalResultDiagnostic
                {
                    CreatedDate = DateTime.Now,
                    Diagnostic = _diagnostic2,
                    MedicalResult = _medicalResult
                };

                using (var tx = _medicalResultDiagnosticManager.Session.BeginTransaction())
                {
                    _medicalResultDiagnosticManager.Save(_medicalResultDiagnostic2);
                    tx.Commit();
                }

                //Clear the session cache objects
                _medicalResultManager.Session.Clear();
                _medicalResultManager.Session.Evict(_medicalResult);

                _medicalResult = _medicalResultManager.GetById(_medicalResult.Id);
            }

            [TestInitialize]
            public void Initialize()
            {

            }

            [TestMethod]
            public void ThenMedicalResultIsLoaded()
            {
                Assert.IsTrue(_medicalResult.Id > 0);
            }

            [TestMethod]
            public void ThenMedicalResultHaveTwoDiagnostics()
            {
                Assert.IsTrue(_medicalResult.Diagnostics.Count == 2);
            }

            [TestMethod]
            public void ThenUserIsBolnavLaCap()
            {
                var medicalResultDiagnostic = _medicalResult.Diagnostics.SingleOrDefault(diagnostic => diagnostic.Diagnostic.Name == TestIllness);
                Assert.IsTrue(medicalResultDiagnostic != null && medicalResultDiagnostic.Id > 0);
            }

            [TestCleanup]
            public void Cleanup()
            {
                //using (var tx = _medicalResultManager.Session.BeginTransaction())
                //{
                //    _medicalResultManager.Delete(_medicalResult);
                //    tx.Commit();
                //}

                //using (var tx = _appointmentManager.Session.BeginTransaction())
                //{
                //    _appointmentManager.Delete(_appointment);
                //    tx.Commit();
                //}

                //using (var tx = _pacientManager.Session.BeginTransaction())
                //{
                //    _pacientManager.Delete(_pacient);
                //    _userManager.Delete(_user);
                //    tx.Commit();
                //}

                //_medicalResultDiagnosticManager.Session.Clear();
                //_medicalResultDiagnosticManager.Session.Evict(_medicalResultDiagnostic1);
                //_medicalResultDiagnosticManager.Session.Evict(_medicalResultDiagnostic2);

                //using (var tx = _medicalResultDiagnosticManager.Session.BeginTransaction())
                //{
                //    _medicalResultDiagnosticManager.Delete(_medicalResultDiagnostic1);
                //    _medicalResultDiagnosticManager.Delete(_medicalResultDiagnostic2);
                //    tx.Commit();
                //}

                //using (var tx = _diagnosticManager.Session.BeginTransaction())
                //{
                //    _diagnosticManager.Delete(_diagnostic1);
                //    _diagnosticManager.Delete(_diagnostic2);
                //    tx.Commit();
                //}
            }
        }
    }
}

