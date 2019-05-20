using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pseez.DomainClasses.Models.Sts.Staff
{
    [Table("Unit", Schema = "Staff")]
    public class Unit
    {
        //public Unit()
        //{
        //    this.Unit1 = new HashSet<Unit>();
        //}
        [Key]
        public long Id { get; set; }

        public string Code { get; set; }
        public string Name { get; set; }
        public long? Unit_Parent_Id { get; set; }

        [Timestamp]
        public byte[] TimeStamp { get; set; }

        public bool IsManagement { get; set; }
        public bool? Show { get; set; }

        public virtual ICollection<Unit> Unit1 { get; set; }

        [ForeignKey("Unit_Parent_Id")]
        public virtual Unit Unit2 { get; set; }
    }
}