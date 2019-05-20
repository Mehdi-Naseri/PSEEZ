using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pseez.DomainClasses.Models.Sts.Staff
{
    [Table("Religion", Schema = "Staff")]
    public class Religion
    {
        //public Religion()
        //{
        //    this.Employees = new HashSet<Employee>();
        //}
        [Key]
        public long Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        [Timestamp]
        public byte[] TimeStamp { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}