using System.Data.Entity;
using Identity.Models.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Pseez.DataAccessLayer.IUnitOfWork;

namespace Pseez.DataAccessLayer.DataContext
{
    public class IdentityDbContext : IdentityDbContext<ApplicationUser>, IUnitOfWorkIdentity
    {
        public IdentityDbContext()
            : base("IdentityConnection")
        {
        }

        #region IUnitOfWork Members

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //جهت ذخیره داده های فارسی در پایگاه داده اضافه شده است.
            //modelBuilder.Properties<DateTime>().Configure(c => c.HasColumnType("datetime2"));
            //جهت ذخیره جداول در شمای "پورتال" اضافه شده است.
            modelBuilder.HasDefaultSchema("Identity");
            base.OnModelCreating(modelBuilder);

            //اضافه کردن کلیدهای اصلی جهت اتصال به ساید جداول
            //    modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            //    modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            //    modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
        }
    }
}