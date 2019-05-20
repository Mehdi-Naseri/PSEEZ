using System.ComponentModel.DataAnnotations;

namespace Pseez.ViewModels.ViewModels.PseezEnt.HumanResource
{
    public class FlightListViewModel
    {
        [Key]
        [Required]
        [Display(Name = "ردیف")]
        public int Id { get; set; }

        [Required(ErrorMessage = "لطفا تاریخ پرواز را وارد نمایید")]
        [Display(Name = "تاريخ")]
        public string Date { get; set; }

        [Display(Name = "ساعت")]
        public string Time { get; set; }

        [Display(Name = "مبدا")]
        public string CityFrom { get; set; }

        [Display(Name = "مقصد")]
        public string CityTo { get; set; }

        [Display(Name = "شرکت هواپیمایی")]
        public string Provider { get; set; }

        [Display(Name = "شرکت هواپیمایی")]
        public int TimeTable { get; set; }

        [Display(Name = "شماره پرواز")]
        public int FlightNumber { get; set; }
    }
}