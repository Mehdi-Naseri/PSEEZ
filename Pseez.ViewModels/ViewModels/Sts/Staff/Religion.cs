using System.ComponentModel.DataAnnotations;

namespace Pseez.ViewModels.ViewModels.Sts.Staff
{
    public class ReligionViewModel
    {
        [Key]
        public long Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
    }
}