using NHibernate;
using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompanyDetailsNHibernate.Models
{
    public class OpenNHibernateSession
    {
        public static ISession OpenSession()
        {
            var configuration = new Configuration();
            var configurationPath = HttpContext.Current.Server.MapPath(@"~\Models\NHibernate\nhibernate.cfg.xml");
            configuration.Configure(configurationPath);
            var staffConfigurationFile = HttpContext.Current.Server.MapPath(@"~\Models\NHibernate\staffs.cfg.xml");
            configuration.AddFile(staffConfigurationFile);
            var branchConfigurationFile = HttpContext.Current.Server.MapPath(@"~\Models\NHibernate\branch.cfg.xml");
            configuration.AddFile(branchConfigurationFile);
            ISessionFactory sessionFactory = configuration.BuildSessionFactory();
            return sessionFactory.OpenSession();
        }
    }
}