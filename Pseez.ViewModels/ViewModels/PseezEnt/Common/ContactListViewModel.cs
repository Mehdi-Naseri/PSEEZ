using System.ComponentModel.DataAnnotations;

namespace Pseez.ViewModels.ViewModels.PseezEnt.Common
{
    public class ContactListViewModel
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "نام")]
        [Required(ErrorMessage = "نام دفترچه تلفن را وارد نمایید")]
        public string Name { get; set; }

        [Display(Name = "توضیحات")]
        public string Description { get; set; }

        //به جای  UserId
        [Display(Name = "سازنده")]
        public string CreatedBy { get; set; }
    }
}