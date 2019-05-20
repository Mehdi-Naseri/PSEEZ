using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pseez.DomainClasses.Models.Sts.Staff
{
    [Table("EmployeeOrganChart", Schema = "Staff")]
    public class EmployeeOrganChart
    {
        [Key]
        public long Id { get; set; }

        public long OrganChart_Id { get; set; }
        public long Employee_Id { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string Description { get; set; }

        [Timestamp]
        public byte[] TimeStamp { get; set; }

        [ForeignKey("Employee_Id")]
        public virtual Employee Employee { get; set; }
    }
}