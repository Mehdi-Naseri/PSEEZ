using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pseez.DomainClasses.Models.Sts.Basic
{
    [Table("City", Schema = "Basic")]
    public class City
    {
        //public City()
        //{
        //    this.People = new HashSet<Person>();
        //    this.EmployeeAcademicalResumes = new HashSet<EmployeeAcademicalResume>();
        //    this.TimeTables = new HashSet<TimeTable>();
        //    this.TimeTables1 = new HashSet<TimeTable>();
        //}
        [Key]
        public long Id { get; set; }

        public string Code { get; set; }
        public string Name { get; set; }
        public long Province_Id { get; set; }
        public string Description { get; set; }

        [Timestamp]
        public byte[] TimeStamp { get; set; }

        public int Priority { get; set; }

        [ForeignKey("Province_Id")]
        public virtual Province Province { get; set; }

        //public virtual ICollection<TimeTable> TimeTables1 { get; set; }
        //public virtual ICollection<TimeTable> TimeTables { get; set; }
        //public virtual ICollection<EmployeeAcademicalResume> EmployeeAcademicalResumes { get; set; }

        //public virtual ICollection<Person> People { get; set; }
    }
}