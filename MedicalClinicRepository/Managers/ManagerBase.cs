using System.Collections.Generic;
using MedicalClinicExceptions;
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
        int SaveOrUpdate(T entity);
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
            try
            {
                Session.Save(entity);
                return entity.Id;
            }
            catch
            {
                throw new McDatabaseQueryException();
            }
        }

        public virtual T Update(T entity)
        {
            try
            {
                Session.Update(entity);
                return entity;
            }
            catch
            {
                throw new McDatabaseQueryException();
            }
        }

        public virtual int SaveOrUpdate(T entity)
        {
            try
            {
                Session.SaveOrUpdate(entity);
                return entity.Id;
            }
            catch
            {
                throw new McDatabaseQueryException();
            }
        }

        public virtual T GetById(int id)
        {
            try
            {
                return Session.Get<T>(id);
            }
            catch
            {
                throw new McDatabaseQueryException();
            }
        }

        public virtual T LoadById(int id)
        {
            try
            {
                return Session.Load<T>(id);
            }
            catch
            {
                throw new McDatabaseQueryException();
            }
        }

        public virtual IList<T> GetAll()
        {
            try
            {
                return Session.CreateCriteria<T>().List<T>();
            }
            catch
            {
                throw new McDatabaseQueryException();
            }
        }

        public virtual void Delete(T entity)
        {
            try
            {
                Session.Delete(entity);
            }
            catch
            {
                throw new McDatabaseQueryException();
            }
        }
    }
}