using System;
using System.Data.Entity;
using Identity.Models.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Pseez.DataAccessLayer.IUnitOfWork;
using Pseez.DomainClasses.Models.PseezEnt.Cmms;
using Pseez.DomainClasses.Models.PseezEnt.Common;
using Pseez.DomainClasses.Models.PseezEnt.IT;
using Pseez.DomainClasses.Models.PseezEnt.Pmbok;
using Pseez.DomainClasses.Models.PseezEnt.VisitRegistration;

//using Pseez.DomainClasses.Common;
//using System.Threading;
//جهت دسترسی به کاربران اضافه شده است
//using Microsoft.AspNet.Identity.EntityFramework;


namespace Pseez.DataAccessLayer.DataContext
{
    //public class PseezEntContext : DbContext, IUnitOfWorkPseezEnt
    public class PseezEntDbContext : IdentityDbContext<ApplicationUser>, IUnitOfWorkPseezEnt
    {
        public PseezEntDbContext()
            : base("name=PseezEntConnection")
        {
        }

        //Common
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<ContactGroup> ContactGroups { get; set; }
        public virtual DbSet<ContactList> ContactLists { get; set; }
        public virtual DbSet<UserContactList> UserContactLists { get; set; }
        public virtual DbSet<UserDefaultContactList> UserDefaultContactLists { get; set; }


        //IT
        public virtual DbSet<Server> Servers { get; set; }
        public virtual DbSet<Backup> Backups { get; set; }
        public virtual DbSet<Log> Logs { get; set; }
        public virtual DbSet<WebsiteVisitor> WebsiteVisitors { get; set; }


        //VisitRegistration
        public virtual DbSet<Registration> Registrations { get; set; }


        //Pmbok
        public System.Data.Entity.DbSet<Project> Projects { get; set; }
        public System.Data.Entity.DbSet<ProjectDocument> ProjectDocuments { get; set; }
        public System.Data.Entity.DbSet<ProjectDocumentValue> ProjectDocumentValues { get; set; }
        public System.Data.Entity.DbSet<ProjectDocumentFile> ProjectDocumentFiles { get; set; }
        public System.Data.Entity.DbSet<ProjectDocumentFileDeleted> ProjectDocumentFilesDeleted { get; set; }


        //CMMS
        public virtual DbSet<RepairRequest> RepairRequests { get; set; }







        #region IUnitOfWork Members



        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //جهت ذخیره داده های فارسی در پایگاه داده اضافه شده است.
            modelBuilder.Properties<DateTime>().Configure(c => c.HasColumnType("datetime2"));
            //جهت ذخیره جداول در شمای "برنامه" اضافه شده است.
            //modelBuilder.HasDefaultSchema("PseezEnt");

            //جهت ذخیره جداول ایدنتیتی در شمای "آیدنتیتی" اضافه شده است.
            modelBuilder.HasDefaultSchema("Identity");

            //.WithRequired().WillCascadeOnDelete(false);

            modelBuilder.Entity<Contact>()
                .HasRequired(t => t.ContactList)
                .WithMany(t => t.Contacts)
                .HasForeignKey(d => d.ContactListId)
                .WillCascadeOnDelete(false);

            //            modelBuilder.Entity<Contact>()
            //.HasRequired(t => t.ContactGroup)
            //.With(t => t.Contact)
            //.HasForeignKey(d => d.ContactListId)
            //.WillCascadeOnDelete(false);

            //modelBuilder.Conventions.Remove<many>();
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<ContactGroup>().HasRequired(r => r.ContactList).WithMany().HasForeignKey(r => r.ContactListId).WillCascadeOnDelete(false);
            //    modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            //    modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            //    modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
            ////
        }

        //جهت استفاده در آیدنتیتی اضافه شده است
        public static PseezEntDbContext Create()
        {
            return new PseezEntDbContext();
        }
    }
}