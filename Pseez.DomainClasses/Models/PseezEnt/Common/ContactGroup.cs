using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pseez.DomainClasses.Models.PseezEnt.Common
{
    [Table("ContactGroup", Schema = "Common.Contact")]
    public class ContactGroup
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "نام")]
        [Required(ErrorMessage = "نام گروه را وارد نمایید")]
        [MaxLength(30)]
        [Index("IX_NameAndContactList", 1, IsUnique = true)]
        public string Name { get; set; }

        [Display(Name = "توضیحات")]
        public string Description { get; set; }

        [Required(ErrorMessage = "کد دفترچه تلفن را وارد نمایید")]
        [Index("IX_NameAndContactList", 2, IsUnique = true)]
        public int ContactListId { get; set; }

        [Timestamp]
        public byte[] TimeStamp { get; set; }

        public virtual ContactList ContactList { get; set; }

        //public virtual Contact Contact { get; set; }
    }
}