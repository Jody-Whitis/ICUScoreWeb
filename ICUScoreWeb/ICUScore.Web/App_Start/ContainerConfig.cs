using Autofac;
using Autofac.Integration.Mvc;
using ICUScore.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace ICUScore.Web.App_Start
{
    public class ContainerConfig
    {
        internal static void RegisterContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<InMemoryPlayerTable>().SingleInstance();
            builder.RegisterType<InMemoryHighscoreTable>().SingleInstance();
            builder.RegisterType<InMemoryPvPTable>().SingleInstance();
            builder.RegisterType<InMemoryGamesTable>().SingleInstance();
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

    }
}