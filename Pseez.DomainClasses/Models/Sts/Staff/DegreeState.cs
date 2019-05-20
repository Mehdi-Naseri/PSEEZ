using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pseez.DomainClasses.Models.Sts.Staff
{
    [Table("DegreeState", Schema = "Staff")]
    public class DegreeState
    {
        //public DegreeState()
        //{
        //    this.EmployeeAcademicalResumes = new HashSet<EmployeeAcademicalResume>();
        //}
        [Key]
        public long Id { get; set; }

        public string Title { get; set; }

        [Timestamp]
        public byte[] TimeStamp { get; set; }

        public string Describer { get; set; }

        public virtual ICollection<EmployeeAcademicalResume> EmployeeAcademicalResumes { get; set; }
    }
}