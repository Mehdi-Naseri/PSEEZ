using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pseez.DomainClasses.Models.Sts.Journey
{
    [Table("Provider", Schema = "Journey")]
    public class Provider
    {
        [Key]
        public long Id { get; set; }

        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }

        [Timestamp]
        public byte[] TimeStamp { get; set; }

        public string Code { get; set; }
        public string Agg { get; set; }
    }
}