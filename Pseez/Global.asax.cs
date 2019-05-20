using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

//جهت ارتباط با پایگاه داده
using System.Data.Entity;
using Pseez.DataLayer.DataContext;
using Pseez.DataLayer.Migrations.PseezEntMigration;
using Pseez.DomainClasses.Models.PseezEnt.Management;

//جهت فعال سازی و دسترسی به بخش اکانت
//using Microsoft.AspNet.Identity;
//using Microsoft.AspNet.Identity.EntityFramework;
//using System.Threading.Tasks;
//using Pseez.Models;

using Pseez.DataLayer.IUnitOfWork;
using StructureMap;
using StructureMap.Web;
using StructureMap.Web.Pipeline;
using Identity.ServiceLayer.Interfaces;
using Pseez.ServiceLayer.Interfaces.PseezEnt.Datacenter;
using Pseez.ServiceLayer.Interfaces.PseezEnt.Contact;
using Pseez.ServiceLayer.Interfaces.PseezEnt.PersonnelReports;
using Pseez.ServiceLayer.Interfaces.PseezEnt.Project;
using Pseez.ServiceLayer.Interfaces.Sts.Basic;
using Pseez.ServiceLayer.Interfaces.Sts.Journey;
using Pseez.ServiceLayer.Interfaces.Sts.Staff;
using Identity.ServiceLayer.EFServices;
using Pseez.ServiceLayer.EFServices.PseezEnt.Datacenter;
using Pseez.ServiceLayer.EFServices.PseezEnt.Contact;
using Pseez.ServiceLayer.EFServices.PseezEnt.PersonnelReports;
using Pseez.ServiceLayer.EFServices.PseezEnt.Project;
using Pseez.ServiceLayer.EFServices.Sts.Basic;
using Pseez.ServiceLayer.EFServices.Sts.Journey;
using Pseez.ServiceLayer.EFServices.Sts.Staff;
using System.Globalization;


namespace Pseez
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            Pseez.Model.MapperConfigure.AutoMapper.ConfigureMapping.Configure();

            Database.SetInitializer<StsContext>(null);
            Database.SetInitializer<IdentityContext>(null);
            Database.SetInitializer<PseezEntContext>(null);
            //ساخت پایگاه داده
            //InitializePortalDatabase();
            //موقتا غیر فعال شده است
            //CreateAdminUserAndRole();

            InitializeStructureMap();


        }
        protected void Session_Start()
        {
            //موقتا غیر فعال شده است
            //SaveVisitorsInformation();
        }
        #region Project_Initialization
        //private void InitializePortalDatabase()
        //{
        //    Database.SetInitializer(new MigrateDatabaseToLatestVersion<PseezEntContext,Configuration>());
        //    var a = new PseezEntContext();
        //    a.Database.Initialize(true);
        //}
        //private void CreateAdminUserAndRole()
        //{
        //    //Initialzie Admin user and Password
        //    IdentityDbContext IdentityDbContext1 = new IdentityDbContext();
        //    UserManager<ApplicationUser> UserManager1 = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
        //    //Create User "Admin" if it is not existed.
        //    if (UserManager1.FindByName("Admin") == null)
        //    {
        //        var user = new ApplicationUser() { UserName = "Admin" };
        //        UserManager1.Create(user, "Pass#1");
        //    }
        //    //Create Role "Admin" if it is not existed.
        //    RoleManager<IdentityRole> RoleManager1 = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
        //    if (RoleManager1.FindByName("Admin") == null)
        //    {
        //        IdentityRole IdentityRole1 = new IdentityRole("Admin");
        //        RoleManager1.Create(IdentityRole1);
        //    }
        //    //Add Admin user to Admin Role
        //    string IdentityUserId = IdentityDbContext1.Users.First(x => x.UserName == "Admin").Id;
        //    UserManager1.AddToRole(IdentityUserId, "Admin");
        //}
        private void SaveVisitorsInformation()
        {
            using (PseezEntContext db = new PseezEntContext())
            {
                WebsiteVisitor WebsiteVisitor1 = new WebsiteVisitor();
                WebsiteVisitor1.Date = DateTime.Now;
                WebsiteVisitor1.HostAddress = Request.UserHostAddress;
                WebsiteVisitor1.HostName = Request.UserHostName;
                WebsiteVisitor1.Browser = Request.Browser.Browser;
                WebsiteVisitor1.Url = Request.Url.AbsoluteUri;
                if (Request.UrlReferrer != null)
                    WebsiteVisitor1.UrlReferrer = Request.UrlReferrer.AbsoluteUri;
                else
                    WebsiteVisitor1.UrlReferrer = "";
                db.WebsiteVisitors.Add(WebsiteVisitor1);
                db.SaveChanges();
            }
        }
        #endregion


        #region StructureMap
        private static void InitializeStructureMap()
        {
            //در StructureMap v2
            //ObjectFactory.Initialize(x =>
            //{
            //    x.For<IUnitOfWork>().HttpContextScoped().Use(() => new PseezEntContext());
            //    x.ForRequestedType<IServerService>().TheDefaultIsConcreteType<EfServerService>();
            //    x.ForRequestedType<IBackupService>().TheDefaultIsConcreteType<EfBackupService>();
            //});
            //در StructureMap v3
            ObjectFactory.Initialize(x =>
            {
                x.For<IUnitOfWorkIdentity>().HybridHttpOrThreadLocalScoped().Use(() => new IdentityContext());
                x.For<IIdentityUserService>().Use<EfIdentityUserService>();
                x.For<IIdentityRoleService>().Use<EfIdentityRoleService>();
                x.For<IIdentityUserInRoleService>().Use<EfIdentityUserInRoleService>();

                x.For<IUnitOfWorkPseezEnt>().HybridHttpOrThreadLocalScoped().Use(() => new PseezEntContext());
                x.For<IServerService>().Use<EfServerService>();
                x.For<IBackupService>().Use<EfBackupService>();
                x.For<IContactService>().Use<EfContactService>();
                x.For<IContactGroupService>().Use<EfContactGroupService>();
                x.For<IContactListService>().Use<EfContactListService>();
                x.For<IContactService>().Use<EfContactService>();
                x.For<IUserContactListService>().Use<EfUserContactListService>();
                x.For<IUserDefaultContactListService>().Use<EfUserDefaultContactListService>();
                x.For<IEmployeeDetailService>().Use<EfEmployeeDetailService>();
                x.For<IFlightsService>().Use<EfFlightsService>();
                x.For<IFlightPassengersService>().Use<EfFlightPassengersService>();
                x.For<IProjectService>().Use<EfProjectService>();

                x.For<IUnitOfWorkSts>().HybridHttpOrThreadLocalScoped().Use(() => new StsContext());
                x.For<ICityService>().Use<EfCityService>();
                x.For<IGenderService>().Use<EfGenderService>();
                x.For<IPersonService>().Use<EfPersonService>();
                x.For<IProvinceService>().Use<EfProvinceService>();
                x.For<IProviderService>().Use<EfProviderService>();
                x.For<IReservationPersonListService>().Use<EfReservationPersonListService>();
                x.For<ITimeTableService>().Use<EfTimeTableService>();
                x.For<IBloodTypeService>().Use<EfBloodTypeService>();
                x.For<IDegreeStateService>().Use<EfDegreeStateService>();
                x.For<IEmployeeAcademicalResumeService>().Use<EfEmployeeAcademicalResumeService>();
                x.For<IEmployeeFamilialTypeService>().Use<EfEmployeeFamilialTypeService>();
                x.For<IEmployeeOrganChartService>().Use<EfEmployeeOrganChartService>();
                x.For<IEmployeeService>().Use<EfEmployeeService>();
                x.For<IFamilialTypeService>().Use<EfFamilialTypeService>();
                x.For<IOrganChartService>().Use<EfOrganChartService>();
                x.For<IReligionService>().Use<EfReligionService>();
                x.For<IUnitService>().Use<EfUnitService>();
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
                if (controllerType.Name == "AccountController")
                    return base.GetControllerInstance(requestContext, controllerType);
                else
                    return ObjectFactory.GetInstance(controllerType) as Controller;
            }
        }
    }
}
