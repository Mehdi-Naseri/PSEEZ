using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pseez.DomainClasses.Models.PseezEnt.Common
{
    [Table("Contact", Schema = "Common.Contact")]
    public class Contact
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "نام")]
        [Required(ErrorMessage = "نام را وارد نمایید")]
        public string Name { get; set; }

        [Display(Name = "شماره تلفن")]
        [Required]
        [MaxLength(30)]
        [Index(IsUnique = true)]
        public string Tell { get; set; }

        [Display(Name = "توضیحات")]
        public string Comment { get; set; }

        [Display(Name = "گروه")]
        public int ContactGroupId { get; set; }

        [Display(Name = "کد دفترچه تلفن")]
        [Required]
        public int ContactListId { get; set; }

        [Timestamp]
        public byte[] TimeStamp { get; set; }

        public virtual ContactList ContactList { get; set; }

        public virtual ContactGroup ContactGroup { get; set; }
    }
}