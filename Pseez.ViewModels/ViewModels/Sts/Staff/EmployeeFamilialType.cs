using System.ComponentModel.DataAnnotations;

namespace Pseez.ViewModels.ViewModels.Sts.Staff
{
    public class EmployeeFamilialTypeViewModel
    {
        [Key]
        public long Id { get; set; }

        public string Date { get; set; }
        public long Employee_Id { get; set; }
        public long FamilialType_Id { get; set; }
    }
}