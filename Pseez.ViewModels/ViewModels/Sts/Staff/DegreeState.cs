using System.ComponentModel.DataAnnotations;

namespace Pseez.ViewModels.ViewModels.Sts.Staff
{
    public class DegreeStateViewModel
    {
        [Key]
        public long Id { get; set; }

        public string Title { get; set; }
        public string Describer { get; set; }
    }
}