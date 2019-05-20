using System.ComponentModel.DataAnnotations;

namespace Pseez.ViewModels.ViewModels.PseezEnt.HumanResource
{
    public class FlightPassengerViewModel
    {
        [Key]
        [Required]
        [Display(Name = "ردیف")]
        public int Id { get; set; }

        [Required(ErrorMessage = "لطفا نام را وارد نمایید")]
        [Display(Name = "نام")]
        public string Name { get; set; }

        [Required(ErrorMessage = "لطفا نام خانوادگی را وارد نمایید")]
        [Display(Name = "نام خانوادگی")]
        public string Family { get; set; }
    }
}