using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Pseez.DomainClasses.Models.Sts.Basic;

namespace Pseez.DomainClasses.Models.Sts.Staff
{
    [Table("Employee", Schema = "Staff")]
    public class Employee
    {
        //public Employee()
        //{
        //    this.EmployeeOrganCharts = new HashSet<EmployeeOrganChart>();
        //    this.EmployeeFamilialTypes = new HashSet<EmployeeFamilialType>();
        //    this.EmployeeAcademicalResumes = new HashSet<EmployeeAcademicalResume>();
        //}

        [Key, ForeignKey("Person")]
        public long Id { get; set; }

        public string Code { get; set; }
        public string CardId { get; set; }
        public string CreationFileDate { get; set; }
        public string PrimaryEmploymentDate { get; set; }
        public long? Native_Id { get; set; }
        public long? Religion_Id { get; set; }
        public string EMail { get; set; }

        [Timestamp]
        public byte[] TimeStamp { get; set; }

        public long? BloodType_Id { get; set; }
        public long CompanyType_Id { get; set; }
        public string FamilyCardId { get; set; }

        [ForeignKey("Id")]
        public virtual Person Person { get; set; }

        public virtual ICollection<EmployeeOrganChart> EmployeeOrganCharts { get; set; }

        [ForeignKey("Religion_Id")]
        public virtual Religion Religion { get; set; }

        [ForeignKey("BloodType_Id")]
        public virtual BloodType BloodType { get; set; }

        public virtual ICollection<EmployeeFamilialType> EmployeeFamilialTypes { get; set; }
        public virtual ICollection<EmployeeAcademicalResume> EmployeeAcademicalResumes { get; set; }
    }
}