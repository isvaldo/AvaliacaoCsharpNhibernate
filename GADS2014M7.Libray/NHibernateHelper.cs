using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GADS2014M7.Libray
{
    public class NHibernateHelper
    {
        public static Configuration GetConfig()
        {
            Configuration cfg = new Configuration();
            cfg.Configure();
            cfg.AddAssembly(Assembly.GetExecutingAssembly());
            return cfg;
        }

        public static void GeraSchema()
        {
            Configuration cfg = GetConfig();
            new SchemaExport(cfg).Create(true, true);
        }


    
        public static ISession OpenSession()
        {
            Configuration cfg = NHibernateHelper.GetConfig();
            ISessionFactory sessionFactory = cfg.BuildSessionFactory();
            return sessionFactory.OpenSession();
        }

    }
}
