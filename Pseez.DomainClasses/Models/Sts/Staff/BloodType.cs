using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pseez.DomainClasses.Models.Sts.Staff
{
    [Table("BloodType", Schema = "Staff")]
    public class BloodType
    {
        //public BloodType()
        //{
        //    this.Employees = new HashSet<Employee>();
        //}
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[Required]
        //public long Id { get; set; }
        public long Id { get; set; }

        public string Title { get; set; }

        [Timestamp]
        public byte[] TimeStamp { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string Describer { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}