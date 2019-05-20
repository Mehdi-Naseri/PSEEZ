using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Identity.ServiceLayer.EFServices;
using Identity.ServiceLayer.Interfaces;
using Pseez.DataAccessLayer.DataContext;
using Pseez.DataAccessLayer.IUnitOfWork;
using Pseez.Extentions.MapperConfigure.AutoMapper;
using Pseez.ServiceLayer.EFServices.PseezEnt.Cmms;
using Pseez.ServiceLayer.Interfaces.PseezEnt.Cmms;
using StructureMap;
using StructureMap.Web;
using StructureMap.Web.Pipeline;

namespace Pseez.UI.Cmms
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ConfigureMapping.Configure();

            Database.SetInitializer<PseezEntDbContext>(null);

            InitializeStructureMap();
        }

        #region StructureMap

        private static void InitializeStructureMap()
        {
            //در StructureMap v2
            //ObjectFactory.Initialize(x =>
            //{
            //    x.For<IUnitOfWork>().HttpContextScoped().Use(() => new PseezErpContext());
            //    x.ForRequestedType<IServerService>().TheDefaultIsConcreteType<EfServerService>();
            //    x.ForRequestedType<IBackupService>().TheDefaultIsConcreteType<EfBackupService>();
            //});
            //در StructureMap v3
            ObjectFactory.Initialize(x =>
            {
                x.For<IUnitOfWorkPseezEnt>().HybridHttpOrThreadLocalScoped().Use(() => new PseezEntDbContext());

                x.For<IRepairRequestService>().Use<EfRepairRequestService>();

                x.For<IIdentityRoleService>().Use<EfIdentityRoleService>();
                x.For<IIdentityUserRoleService>().Use<EfIdentityUserRoleService>();
                x.For<IIdentityUserService>().Use<EfIdentityUserService>();
            });
            //Set current Controller factory as StructureMapControllerFactory
            ControllerBuilder.Current.SetControllerFactory(new StructureMapControllerFactory());
        }


        protected void Application_EndRequest(object sender, EventArgs e)
        {
            //در StructureMap v2
            //ObjectFactory.ReleaseAndDisposeAllHttpScopedObjects();
            //در StructureMap v3
            HttpContextLifecycle.DisposeAndClearAll();
        }

        #endregion
    }

    public class StructureMapControllerFactory : DefaultControllerFactory
    {
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null && requestContext.HttpContext.Request.Url != null)
            {
                throw new InvalidOperationException(string.Format("Page not found: {0}",
                    requestContext.HttpContext.Request.Url.AbsoluteUri.ToString(CultureInfo.InvariantCulture)));
                //return null;
            }
            if (controllerType.Name == "AccountController" ||
                controllerType.Name == "ManageController")
                return base.GetControllerInstance(requestContext, controllerType);
            return ObjectFactory.GetInstance(controllerType) as Controller;
        }
    }
}
