using System.ComponentModel.DataAnnotations;

namespace Pseez.ViewModels.ViewModels.PseezEnt.HumanResource
{
    public class EmployeesDetailViewModel
    {
        //From STS.Basic.Person
        [Key]
        [Required]
        [Display(Name = "ردیف")]
        public long Id { get; set; }

        [Required(ErrorMessage = "لطفا نام را وارد نمایید")]
        [Display(Name = "نام")]
        public string Name { get; set; }

        [Required(ErrorMessage = "لطفا نام خانوادگی را وارد نمایید")]
        [Display(Name = "نام خانوادگی")]
        public string Family { get; set; }

        [Display(Name = "نام پدر")]
        public string FatherName { get; set; }

        [Display(Name = "تاریخ تولد")]
        public string BirthDate { get; set; }

        [Display(Name = "شهر")]
        public string City { get; set; }

        [Display(Name = "استان")]
        public string Province { get; set; }

        [Display(Name = "شماره شناسنامه")]
        public string Shenasnameh { get; set; }

        [Display(Name = "شماره ملی")]
        public string NationalCode { get; set; }

        [Display(Name = "جنسیت")]
        public string Gender { get; set; }

        [Display(Name = "موبايل")]
        public string Mobile { get; set; }

        //From STS.Staff.Employee
        [Display(Name = "كد پرسنلی")]
        public string PersoneliCode { get; set; }

        [Display(Name = "تاريخ استخدام")]
        public string EmploymentDate { get; set; }

        [Display(Name = "دین")]
        public string Religion { get; set; }

        [Display(Name = "ايميل")]
        public string Email { get; set; }

        [Display(Name = "گروه خونی")]
        public string BloodType { get; set; }

        [Display(Name = "تاهل")]
        public string MartialStatus { get; set; }

        [Display(Name = "تاريخ ازدواج")]
        public string MartialDate { get; set; }

        [Display(Name = "مدرک دانشگاهی")]
        public string DegreeState { get; set; }

        [Display(Name = "واحد")]
        public string Unit { get; set; }
    }
}