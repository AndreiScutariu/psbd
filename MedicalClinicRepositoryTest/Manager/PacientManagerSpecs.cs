using System;
using MedicalClinicRepository.Entities;
using MedicalClinicRepository.Managers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MedicalClinicRepositoryTest.Manager
{
    [TestClass]
    public class PacientManagerSpecs
    {
        [TestClass]
        public class WhenAddingNewPacient
        {
            private readonly PatientManager _patientManager = new PatientManager();
            private readonly Patient _patient;

            public WhenAddingNewPacient()
            {
                _patient = new Patient
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
                using (var tx = _patientManager.Session.BeginTransaction())
                {
                    _patientManager.Save(_patient);
                    tx.Commit();
                }
            }

            [TestMethod]
            public void ThenIsSavedInDatatabase()
            {
                Assert.IsTrue(_patient.Id > 0);
            }

            [TestCleanup]
            public void Cleanup()
            {
                using (var tx = _patientManager.Session.BeginTransaction())
                {
                    _patientManager.Delete(_patient);
                    tx.Commit();
                }
            }
        }

        [TestClass]
        public class WhenGettingAPacient
        {
            private readonly PatientManager _patientManager = new PatientManager();
            private Patient _patient;

            public WhenGettingAPacient()
            {
                _patient = new Patient
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
                using (var tx = _patientManager.Session.BeginTransaction())
                {
                    _patientManager.Save(_patient);
                    tx.Commit();
                }
                _patient = _patientManager.GetById(_patient.Id);
            }

            [TestMethod]
            public void ThenPacientIsLoaded()
            {
                Assert.IsTrue(_patient.Id > 0);
            }

            [TestCleanup]
            public void Cleanup()
            {
                using (var tx = _patientManager.Session.BeginTransaction())
                {
                    _patientManager.Delete(_patient);
                    tx.Commit();
                }
            }
        }
    }
}