using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pseez.DomainClasses.Models.PseezEnt.Cmms
{
    [Table("SiteSecondary", Schema = "Cmms")]
    public class SiteSecondary
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "نام سایت فرعی")]
        [Required]
        public string Name { get; set; }


        [Timestamp]
        public byte[] TimeStamp { get; set; }

    }
}