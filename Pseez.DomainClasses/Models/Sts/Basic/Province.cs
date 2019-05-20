using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pseez.DomainClasses.Models.Sts.Basic
{
    [Table("Province", Schema = "Basic")]
    public class Province
    {
        //public Province()
        //{
        //    this.Cities = new HashSet<City>();
        //}
        [Key]
        public long Id { get; set; }

        public string Code { get; set; }
        public string Name { get; set; }
        public long Country_Id { get; set; }
        public string Description { get; set; }

        [Timestamp]
        public byte[] TimeStamp { get; set; }

        public virtual ICollection<City> Cities { get; set; }
    }
}