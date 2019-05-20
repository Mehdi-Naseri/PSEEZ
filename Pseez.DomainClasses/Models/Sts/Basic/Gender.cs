using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pseez.DomainClasses.Models.Sts.Basic
{
    [Table("Gender", Schema = "Basic")]
    public class Gender
    {
        //public Gender()
        //{
        //    this.People = new HashSet<Person>();
        //}
        [Key]
        public long Id { get; set; }

        public string Title { get; set; }

        [Timestamp]
        public byte[] TimeStamp { get; set; }

        public string Describer { get; set; }

        public virtual ICollection<Person> People { get; set; }
    }
}