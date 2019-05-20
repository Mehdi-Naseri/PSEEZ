using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

using System.Data.Entity;

//برای StructureMap
using System.Globalization;
using StructureMap;
using StructureMap.Web;
using StructureMap.Web.Pipeline;
using Pseez.DataAccessLayer.IUnitOfWork;
using Pseez.DataAccessLayer.DataContext;

using Identity.ServiceLayer.Interfaces;
using Identity.ServiceLayer.EFServices;
using Pseez.Extentions.MapperConfigure.AutoMapper;
using Pseez.ServiceLayer.EFServices.PseezEnt.VisitRegistration;
using Pseez.ServiceLayer.Interfaces.PseezEnt.VisitRegistration;

namespace Pseez.UI.VisitRegistration
{
    public class MvcApplication : HttpApplication
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
                x.For<IRegistrationService>().Use<EfRegistrationService>();

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
            else
            {
                if (controllerType.Name == "AccountController" || controllerType.Name == "ManageController")
                    return base.GetControllerInstance(requestContext, controllerType);
                else
                    return ObjectFactory.GetInstance(controllerType) as Controller;
            }
        }
    }
}