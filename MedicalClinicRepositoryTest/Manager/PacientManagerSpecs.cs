using System;
using MedicalClinicRepository.Entities;
using MedicalClinicRepository.Managers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MedicalClinicRepositoryTest.Manager
{
    public class PacientManagerSpecs
    {
        [TestClass]
        public class WhenAddingNewPacient
        {
            private readonly PacientManager _pacientManager = new PacientManager();
            private readonly Pacient _pacient;

            public WhenAddingNewPacient()
            {
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
                    tx.Commit();
                }
            }

            [TestMethod]
            public void ThenIsSavedInDatatabase()
            {
                Assert.IsTrue(_pacient.Id > 0);
            }

            [TestCleanup]
            public void Cleanup()
            {
                using (var tx = _pacientManager.Session.BeginTransaction())
                {
                    _pacientManager.Delete(_pacient);
                    tx.Commit();
                }
            }
        }

        [TestClass]
        public class WhenGettingAPacient
        {
            private readonly PacientManager _pacientManager = new PacientManager();
            private Pacient _pacient;

            public WhenGettingAPacient()
            {
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
                    tx.Commit();
                }
                _pacient = _pacientManager.GetById(_pacient.Id);
            }

            [TestMethod]
            public void ThenPacientIsLoaded()
            {
                Assert.IsTrue(_pacient.Id > 0);
            }

            [TestCleanup]
            public void Cleanup()
            {
                using (var tx = _pacientManager.Session.BeginTransaction())
                {
                    _pacientManager.Delete(_pacient);
                    tx.Commit();
                }
            }
        }
    }
}