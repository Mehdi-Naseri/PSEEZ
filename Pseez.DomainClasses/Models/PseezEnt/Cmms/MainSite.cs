using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pseez.DomainClasses.Models.PseezEnt.Cmms
{
    [Table("MainSite", Schema = "Cmms")]
    public class MainSite
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "نام سایت اصلی")]
        [Required]
        public string Name { get; set; }


        [Timestamp]
        public byte[] TimeStamp { get; set; }

    }
}