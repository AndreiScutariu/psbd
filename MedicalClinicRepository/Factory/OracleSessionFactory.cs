using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using MedicalClinicRepository.Entities;
using NHibernate;

namespace MedicalClinicRepository.Factory
{
    public class OracleSessionFactory
    {
        private static readonly ISessionFactory SessionFactory;
        private static ISession _session;

        //TODO put connection string in config file
        private const string ConnectionString = "Data Source=localhost:1521/xe;User ID=CLINIC;Password=clinic;Unicode=True";

        static OracleSessionFactory()
        {
            SessionFactory = Fluently.Configure().
                 Database(OracleClientConfiguration.Oracle10.ConnectionString(ConnectionString).DefaultSchema("CLINIC"))
                /*Will add the whole assembly "Entities", it says the assembly in which "BaseEntity" is in*/
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<BaseEntity>())
                .BuildSessionFactory();
        }

        public static ISession GetSession()
        {
            return _session ?? (_session = SessionFactory.OpenSession());
        }
    }
}