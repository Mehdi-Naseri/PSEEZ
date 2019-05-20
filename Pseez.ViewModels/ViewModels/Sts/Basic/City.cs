using System.ComponentModel.DataAnnotations;

namespace Pseez.ViewModels.ViewModels.Sts.Basic
{
    public class CityViewModel
    {
        [Key]
        public long Id { get; set; }

        public string Code { get; set; }
        public string Name { get; set; }
        public long Province_Id { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
    }
}