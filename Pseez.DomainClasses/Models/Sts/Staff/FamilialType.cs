using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pseez.DomainClasses.Models.Sts.Staff
{
    [Table("FamilialType", Schema = "Staff")]
    public class FamilialType
    {
        //public FamilialType()
        //{
        //    this.EmployeeFamilialTypes = new HashSet<EmployeeFamilialType>();
        //}
        [Key]
        public long Id { get; set; }

        public string Title { get; set; }

        [Timestamp]
        public byte[] TimeStamp { get; set; }

        public string Describer { get; set; }

        public virtual ICollection<EmployeeFamilialType> EmployeeFamilialTypes { get; set; }
    }
}