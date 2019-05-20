using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pseez.DomainClasses.Models.Sts.Staff
{
    [Table("OrganChart", Schema = "Staff")]
    public class OrganChart
    {
        //public OrganChart()
        //{
        //    this.OrganChart1 = new HashSet<OrganChart>();
        //}
        [Key]
        public long Id { get; set; }

        public long? Job_Id { get; set; }
        public long Unit_Id { get; set; }
        public long? OrganChart_Parent_Id { get; set; }
        public long PositionType_Id { get; set; }

        [Timestamp]
        public byte[] TimeStamp { get; set; }

        public string Date { get; set; }
        public bool? KeepHistory { get; set; }
        public bool Show { get; set; }

        public virtual ICollection<OrganChart> OrganChart1 { get; set; }

        [ForeignKey("OrganChart_Parent_Id")]
        public virtual OrganChart OrganChart2 { get; set; }
    }
}