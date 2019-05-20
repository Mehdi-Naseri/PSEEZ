using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pseez.DomainClasses.Models.PseezEnt.Pmbok
{
    [Table("Log", Schema = "Pmbok.Management")]
    public class Log
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Display(Name = "Date Time")]
        [Required(ErrorMessage = "Enter Date/Time")]
        public DateTime DateTime { get; set; }

        [Display(Name = "Title")]
        [Required(ErrorMessage = "Enter title.")]
        [StringLength(500)]
        public string Title { get; set; }

        [Display(Name = "Message")]
        [Required(ErrorMessage = "Enter log message.")]
        [StringLength(500)]
        public string Message { get; set; }

        [Timestamp]
        public byte[] Timestamp { get; set; }
    }
}
