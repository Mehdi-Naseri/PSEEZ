using System.ComponentModel.DataAnnotations;

namespace Pseez.ViewModels.ViewModels.PseezEnt.Common
{
    public class ContactViewModel
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "نام")]
        [Required(ErrorMessage = "نام را وارد نمایید")]
        public string Name { get; set; }

        [Display(Name = "شماره تلفن")]
        public string Tell { get; set; }

        [Display(Name = "توضیحات")]
        public string Comment { get; set; }

        [Display(Name = "نام گروه")]
        public string ContactGroupName { get; set; }

        [Display(Name = "نام دفترچه تلفن")]
        [Required(ErrorMessage = "انتخاب نام دفترچه تلفن اجباری است")]
        public string ContactListName { get; set; }
    }
}