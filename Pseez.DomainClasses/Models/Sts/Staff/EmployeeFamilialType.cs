using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pseez.DomainClasses.Models.Sts.Staff
{
    [Table("EmployeeFamilialType", Schema = "Staff")]
    public class EmployeeFamilialType
    {
        [Key]
        public long Id { get; set; }

        public string Date { get; set; }
        public long Employee_Id { get; set; }
        public long FamilialType_Id { get; set; }

        [Timestamp]
        public byte[] TimeStamp { get; set; }

        [ForeignKey("Employee_Id")]
        public virtual Employee Employee { get; set; }

        [ForeignKey("FamilialType_Id")]
        public virtual FamilialType FamilialType { get; set; }
    }
}