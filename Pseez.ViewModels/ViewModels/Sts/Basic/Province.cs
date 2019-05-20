using System.ComponentModel.DataAnnotations;

namespace Pseez.ViewModels.ViewModels.Sts.Basic
{
    public class ProvinceViewModel
    {
        [Key]
        public long Id { get; set; }

        public string Code { get; set; }
        public string Name { get; set; }
        public long Country_Id { get; set; }
        public string Description { get; set; }
    }
}