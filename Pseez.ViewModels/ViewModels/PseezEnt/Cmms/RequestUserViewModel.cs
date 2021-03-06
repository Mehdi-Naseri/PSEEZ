﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Pseez.ViewModels.ViewModels.PseezEnt.Cmms
{
    public class RequestUserViewModel
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "نام و نام خانوادگی")]
        [Required(ErrorMessage = "نام کاربر را وارد نمایید")]
        public string RequestByName { get; set; }

        [Display(Name = "کد کاربر")]
        public string RequestById { get; set; }

        [Display(Name = "تاریخ درخواست")]
        [Required(ErrorMessage = "تاریخ ثبت درخواست را وارد نمایید")]
        public DateTime RequestDate { get; set; }

        [Display(Name = "سایت اصلی")]
        [Required(ErrorMessage = "مشخصات سایت اصلی را وارد نمایید")]
        public string MainSite { get; set; }

        [Display(Name = "سایت فرعی")]
        [Required(ErrorMessage = "مشخصات سایت فرعی را وارد نمایید")]
        public string SiteSecondary { get; set; }

        [Display(Name = "نوع درخواست")]
        [Required(ErrorMessage = "نوع درخواست را وارد نمایید")]
        public string RequestType { get; set; }

        [Display(Name = "شرح درخواست")]
        [Required(ErrorMessage = "توضیحات درخواست را وارد نمایید")]
        public string Description { get; set; }
    }
}