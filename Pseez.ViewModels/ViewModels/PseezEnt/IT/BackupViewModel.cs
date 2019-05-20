using System.ComponentModel.DataAnnotations;

namespace Pseez.ViewModels.ViewModels.PseezEnt.IT
{
    public class BackupViewModel
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "نام سامانه")]
        [Required(ErrorMessage = "نام سامانه را وارد نمایید")]
        public string SystemName { get; set; }

        [Display(Name = "IP")]
        public string IP { get; set; }

        [Display(Name = "آدرس Full Backup")]
        public string FullBackupAddress { get; set; }

        [Display(Name = "آدرس Differential Backup")]
        public string DifferentialBackupAddress { get; set; }

        [Display(Name = "آدرس Incremental Backup")]
        public string IncrementalBackupAddress { get; set; }
    }
}