using System.ComponentModel.DataAnnotations;

namespace Pseez.ViewModels.ViewModels.PseezEnt.Common
{
    public class UserContactListViewModel
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "نام کاربر")]
        [Required(ErrorMessage = "نام کاربر را وارد نمایید")]
        public string UserName { get; set; }

        [Display(Name = "نام دفترچه تلفن")]
        [Required(ErrorMessage = "نام دفترچه تلفن را وارد نمایید")]
        public string ContactListName { get; set; }
    }
}