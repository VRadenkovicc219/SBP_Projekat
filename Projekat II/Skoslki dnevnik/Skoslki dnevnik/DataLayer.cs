

namespace Skoslki_dnevnik
{
    class DataLayer
    {
        private static ISessionFactory _factory = null;
        private static object _lockObj = new();
        public static ISession GetSession()
        {
            if (_factory is null)
            {
                lock (_lockObj)
                {
                    if (_factory is null)
                    {
                        _factory = CreateSessionFactory();
                    }
                }
            }
            return _factory.OpenSession();
        }

        private static ISessionFactory CreateSessionFactory()
        {
            try
            {

                //string constr = "Host=localhost;Port=5432;Database=Skolski_dnevnik;Username=postgres;Password=ZaPostgre;";

                //return Fluently.Configure()
                //    .Database(PostgreSQLConfiguration.Standard
                //        .ConnectionString(constr)
                //        .Driver<NHibernate.Driver.NpgsqlDriver>()      
                //        .Dialect<NHibernate.Dialect.PostgreSQLDialect>()
                //        .ShowSql())                                      
                //    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<OsobaMapiranja>()) 
                //    .BuildSessionFactory();


                var cfg = OracleManagedDataClientConfiguration.Oracle10
                        .ShowSql()
                        .ConnectionString(c =>
                         c.Is("Data Source=gislab-oracle.elfak.ni.ac.rs:1521/SBP_PDB;User Id=S19862;Password=ZaSistemeBaza"));

                return Fluently.Configure().Database(cfg).Mappings(m => m.FluentMappings
                                                                         .AddFromAssemblyOf<OsobaMapiranja>())
                                                                         .BuildSessionFactory();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return null;
            }
        }
    }
}
