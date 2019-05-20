using System.ComponentModel.DataAnnotations;

namespace Pseez.ViewModels.ViewModels.Sts.Journey
{
    public class ProviderViewModel
    {
        [Key]
        public long Id { get; set; }

        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public string Agg { get; set; }
    }
}