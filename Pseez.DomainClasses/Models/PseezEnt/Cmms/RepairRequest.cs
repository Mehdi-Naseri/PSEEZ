using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pseez.DomainClasses.Models.PseezEnt.Cmms
{
    [Table("Request", Schema = "Cmms")]
    public class RepairRequest
    {
        [Key]
        public int Id { get; set; }

        //درخواست دهنده
        [Display(Name = "نام درخواست دهنده")]
        [Required]
        public string RequestByName { get; set; }

        [Display(Name = "کد کاربر درخواست دهنده")]
        //[Required]
        public string RequestById { get; set; }

        [Display(Name = "تاریخ درخواست")]
        [Required]
        public DateTime RequestDate { get; set; }

        [Required]
        public string MainSite { get; set; }

        [Required]
        public string SiteSecondary { get; set; }

        [Required]
        public string RequestType { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public Boolean BuildingMaintenanceTodo { get; set; }



        //نگهداشت
        public string BuildingMaintenanceDescription { get; set; }
        public Boolean PlanningTodo { get; set; }






        //کارشناس فنی
        public string TaskType { get; set; }

        public string Supervisor { get; set; }

        public string SeniorSupervisor { get; set; }

        public string MaxDurationTime { get; set; }

        public Boolean TechnitionTodo { get; set; }


        [Timestamp]
        public byte[] TimeStamp { get; set; }

    }
}