using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using Skoslki_dnevnik.Entiteti;
using Skoslki_dnevnik.Mapiranja;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skoslki_dnevnik
{
    class SqlConnection
    {
        private static ISessionFactory _factory = null;
        private static object _lockObj = new();
        public static ISession GetSession() {
            if (_factory == null) {
                lock (_lockObj) {
                    if (_factory == null) {
                        _factory = CreateSessionFactory();
                    }
                }
            }
            return _factory.OpenSession();
        }

        private static ISessionFactory CreateSessionFactory() {
            try
            {
                var cfg = OracleManagedDataClientConfiguration.Oracle10
                        .ConnectionString(c =>
                         c.Is("Data Source=gislab-oracle.elfak.ni.ac.rs:1521/SBP_PDB;UserId=S19862;Password=ZaSistemeBaza"));
               
                return Fluently.Configure().Database(cfg).Mappings(m => m.FluentMappings
                                                                         .AddFromAssemblyOf<OsobaMapiranja>())
                                                                         .BuildSessionFactory();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
    }
}
