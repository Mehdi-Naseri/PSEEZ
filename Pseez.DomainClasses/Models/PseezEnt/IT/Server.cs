using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pseez.DomainClasses.Models.PseezEnt.IT
{
    [Table("Server", Schema = "IT.DataCenter")]
    public class Server
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "نام سرور")]
        [Required(ErrorMessage = "نام سرور را وارد نمایید")]
        [MaxLength(30)]
        [Index(IsUnique = true)]
        public string ServerName { get; set; }

        [Display(Name = "IP")]
        public string IP { get; set; }

        [Timestamp]
        public byte[] TimeStamp { get; set; }
    }
}