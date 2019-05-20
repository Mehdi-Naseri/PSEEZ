using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Identity.Models.Models;
//جهت اتصال به Identity

namespace Pseez.DomainClasses.Models.PseezEnt.Common
{
    [Table("ContactList", Schema = "Common.Contact")]
    public class ContactList
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "نام")]
        [Required(ErrorMessage = "نام دفترچه تلفن را وارد نمایید")]
        [Index(IsUnique = true)]
        [MaxLength(30)]
        public string Name { get; set; }

        [Display(Name = "توضیحات")]
        public string Description { get; set; }

        [Display(Name = "سازنده لیست")]
        [Required]
        //سازنده لیست تلفن
        public string UserId { get; set; }

        [Timestamp]
        public byte[] TimeStamp { get; set; }

        public virtual ICollection<Contact> Contacts { get; set; }
        //public virtual ICollection<ContactGroup> ContactGroups { get; set; }

        public virtual ICollection<UserDefaultContactList> UserDefaultContactLists { get; set; }

        public virtual ICollection<UserContactList> UserContactLists { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}