using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using MedicalClinicExceptions;
using MedicalClinicRepository.Entities;
using NHibernate;

namespace MedicalClinicRepository.Factory
{
    public class OracleSessionFactory
    {
        private static readonly ISessionFactory SessionFactory;
        private static ISession _session;

        private const string ConnectionString = "Data Source=localhost:1521/xe;User ID=CLINIC;Password=clinic;Unicode=True";

static OracleSessionFactory()
{
    try
    {
        SessionFactory = Fluently.Configure().
                Database(OracleClientConfiguration.Oracle10.ConnectionString(ConnectionString).DefaultSchema("CLINIC"))
            .Mappings(m => m.FluentMappings.AddFromAssemblyOf<BaseEntity>())
            .BuildSessionFactory();
    }
    catch
    {
        throw new McDatabaseConnectionException();
    }
}

public static ISession GetSession()
{
    try
    {
        return _session ?? (_session = SessionFactory.OpenSession());
    }
    catch
    {
        //LOG actual exception in file or database
        throw new McDatabaseConnectionException();
    }
}
    }
}