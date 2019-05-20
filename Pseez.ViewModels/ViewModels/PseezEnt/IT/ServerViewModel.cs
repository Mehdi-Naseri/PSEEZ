using System.ComponentModel.DataAnnotations;

namespace Pseez.ViewModels.ViewModels.PseezEnt.IT
{
    public class ServerViewModel
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "نام سرور")]
        [Required(ErrorMessage = "نام سرور را وارد نمایید")]
        public string ServerName { get; set; }

        [Display(Name = "IP")]
        public string IP { get; set; }
    }
}