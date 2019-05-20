using System.ComponentModel.DataAnnotations;

namespace Pseez.ViewModels.ViewModels.Sts.Basic
{
    public class GenderViewModel
    {
        [Key]
        public long Id { get; set; }

        public string Title { get; set; }
        public string Describer { get; set; }
    }
}