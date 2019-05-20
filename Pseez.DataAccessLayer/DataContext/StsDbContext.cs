using System.Data.Entity;
using Pseez.DataAccessLayer.IUnitOfWork;
using Pseez.DomainClasses.Models.Sts.Basic;
using Pseez.DomainClasses.Models.Sts.Journey;
using Pseez.DomainClasses.Models.Sts.Staff;

namespace Pseez.DataAccessLayer.DataContext
{
    public class StsDbContext : DbContext, IUnitOfWorkSts
    {
        public StsDbContext()
            : base("name=StsConnection")
        {
        }

        public virtual DbSet<BloodType> BloodTypes { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<DegreeState> DegreeStates { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeAcademicalResume> EmployeeAcademicalResumes { get; set; }
        public virtual DbSet<EmployeeFamilialType> EmployeeFamilialTypes { get; set; }
        public virtual DbSet<EmployeeOrganChart> EmployeeOrganCharts { get; set; }
        public virtual DbSet<FamilialType> FamilialTypes { get; set; }
        public virtual DbSet<Gender> Genders { get; set; }
        public virtual DbSet<OrganChart> OrganCharts { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Province> Provinces { get; set; }
        public virtual DbSet<Religion> Religions { get; set; }
        public virtual DbSet<TimeTable> TimeTables { get; set; }
        public virtual DbSet<Unit> Units { get; set; }
        public virtual DbSet<ReservationPersonList> ReservationPersonLists { get; set; }

        #region IUnitOfWork Members

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}