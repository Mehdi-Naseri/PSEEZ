using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Pseez.DomainClasses.Models.Sts.Staff;

namespace Pseez.DomainClasses.Models.Sts.Basic
{
    [Table("Person", Schema = "Basic")]
    public class Person
    {
        [Key]
        public long Id { get; set; }

        public string Name { get; set; }
        public string Family { get; set; }
        public string FatherName { get; set; }
        public string BirthDate { get; set; }
        public long? City_Id { get; set; }
        public string IdNumber { get; set; }
        public string NationalCode { get; set; }
        public long Gender_Id { get; set; }
        public byte[] TimeStamp { get; set; }
        public string Mobile { get; set; }

        [ForeignKey("City_Id")]
        public virtual City City { get; set; }

        [ForeignKey("Gender_Id")]
        public virtual Gender Gender { get; set; }

        [ForeignKey("Id")]
        public virtual Employee Employee { get; set; }
    }
}