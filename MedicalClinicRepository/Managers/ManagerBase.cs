using System.Collections.Generic;
using MedicalClinicRepository.Entities;
using MedicalClinicRepository.Factory;
using NHibernate;

namespace MedicalClinicRepository.Managers
{
    public interface IManagerBase<T>
    {
        ISession Session { get; }
        int Save(T entity);
        T Update(T entity);
        T SaveOrUpdate(T entity);
        T GetById(int id);
        T LoadById(int id);
        IList<T> GetAll();
        void Delete(T entity);
    }

    public class ManagerBase<T> : IManagerBase<T> where T : BaseEntity
    {
        public ISession Session 
        {
            get { return OracleSessionFactory.GetSession(); }
        }

        public virtual int Save(T entity)
        {
            Session.Save(entity);
            return entity.Id;
        }

        public virtual T Update(T entity)
        {
            Session.Update(entity);
            return entity;
        }

        public virtual T SaveOrUpdate(T entity)
        {
            Session.SaveOrUpdate(entity);
            return entity;
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