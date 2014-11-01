using NHibernate;

namespace MedicalClinicRepository.Managers
{
    public interface IManagerBase<T>
    {
        ISession Session { get; }
    }
}