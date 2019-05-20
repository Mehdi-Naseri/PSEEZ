using System;
using System.ComponentModel.DataAnnotations;

namespace Pseez.ViewModels.ViewModels.PseezEnt.Cmms
{
    public class RepairRequestViewModel
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "نام و نام خانوادگی")]
        [Required(ErrorMessage = "نام را وارد نمایید")]
        public string RequestByName { get; set; }

        [Display(Name = "توضیحات")]
        public string RequestById { get; set; }

        [Display(Name = "تاریخ درخواست")]
        [Required]
        public DateTime RequestDate { get; set; }

        [Display(Name = "شرح درخواست")]
        [Required]
        public DateTime Description { get; set; }
    }
}