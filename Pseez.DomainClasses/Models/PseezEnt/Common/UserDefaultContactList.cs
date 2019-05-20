using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pseez.DomainClasses.Models.PseezEnt.Common
{
    [Table("UserDefaultContactList", Schema = "Common.Contact")]
    public class UserDefaultContactList
    {
        [Key]
        public int Id { get; set; }

        public long UserId { get; set; }

        public int ContactListId { get; set; }

        [Timestamp]
        public byte[] TimeStamp { get; set; }

        public virtual ContactList ContactList { get; set; }
    }
}