using System.ComponentModel.DataAnnotations;

namespace Pseez.ViewModels.ViewModels.PseezEnt.Common
{
    public class ContactGroupViewModel
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "نام")]
        [Required(ErrorMessage = "نام گروه را وارد نمایید")]
        public string Name { get; set; }

        [Display(Name = "توضیحات")]
        public string Description { get; set; }

        [Display(Name = "نام دفترچه تلفن")]
        [Required]
        public string ContactListName { get; set; }
    }
}