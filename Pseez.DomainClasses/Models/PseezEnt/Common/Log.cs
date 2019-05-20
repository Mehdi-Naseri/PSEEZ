//using System;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

//namespace Pseez.DomainClasses.Models.PseezEnt.Common
//{
//    [Table("Log", Schema = "Common.Management")]
//    public class Log
//    {
//        [Key]
//        [Required]
//        public int Id { get; set; }

//        [Required]
//        [MaxLength(100)]
//        public string Title { get; set; }

//        [Display(Name = "تاریخ")]
//        [Required(ErrorMessage = "تاریخ را وارد نمایید")]
//        public DateTime DateTime { get; set; }

//        [Display(Name = "پیام")]
//        [Required(ErrorMessage = "پیام را وارد نمایید")]
//        [StringLength(2000)]
//        public string Message { get; set; }

//        [Timestamp]
//        public byte[] Timestamp { get; set; }
//    }
//}