using System.Collections.Generic;
using MedicalClinicRepository.Entities;
using MedicalClinicRepository.Factory;
using NHibernate;

namespace MedicalClinicRepository.Managers
{
    public class ManagerBase<T> : IManagerBase<T> where T : BaseEntity
    {
        public ISession Session 
        {
            get { return OracleSessionFactory.GetSession(); }
        }

        public virtual void Save(T entity)
        {
            Session.Save(entity);
        }

        public virtual void Update(T entity)
        {
            Session.Update(entity);
        }

        public virtual void SaveOrUpdate(T entity)
        {
            Session.SaveOrUpdate(entity);
        }

        public virtual T GetById(int id)
        {
            return Session.Get<T>(id);
        }

        public virtual T LoadById(int id)
        {
            return Session.Load<T>(id);
        }

        public virtual IList<T> GetAll()
        {
            return Session.CreateCriteria<T>().List<T>();
        }

        public virtual void Delete(T entity)
        {
            Session.Delete(entity);
        }
    }
}