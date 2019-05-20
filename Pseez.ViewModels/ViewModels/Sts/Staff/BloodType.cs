using System.ComponentModel.DataAnnotations;

namespace Pseez.ViewModels.ViewModels.Sts.Staff
{
    public class BloodTypeViewModel
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[Required]
        //public long Id { get; set; }
        public long Id { get; set; }

        public string Title { get; set; }
        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string Describer { get; set; }
    }
}