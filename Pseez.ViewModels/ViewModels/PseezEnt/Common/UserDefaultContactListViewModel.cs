using System.ComponentModel.DataAnnotations;

namespace Pseez.ViewModels.ViewModels.PseezEnt.Common
{
    public class UserDefaultContactListViewModel
    {
        [Key]
        public int Id { get; set; }

        public long UserID { get; set; }

        public int ContactListId { get; set; }
    }
}