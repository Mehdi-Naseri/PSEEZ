using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

//using Pseez.DomainClasses.Models.Identity;

namespace Pseez.DomainClasses.Models.PseezEnt.Common
{
    [Table("UserContactList", Schema = "Common.Contact")]
    public class UserContactList
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Index("IX_UserAndContactList", 1, IsUnique = true)]
        [MaxLength(60)]
        public string UserId { get; set; }

        [Required]
        [Index("IX_UserAndContactList", 2, IsUnique = true)]
        public int ContactListId { get; set; }

        [Timestamp]
        public byte[] TimeStamp { get; set; }

        public virtual ContactList ContactList { get; set; }
        //public virtual ApplicationUser ApplicationUser { get; set; }
        //[ForeignKey("UserID")]
    }
}