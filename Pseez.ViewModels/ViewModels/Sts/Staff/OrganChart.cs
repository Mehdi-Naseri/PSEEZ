using System.ComponentModel.DataAnnotations;

namespace Pseez.ViewModels.ViewModels.Sts.Staff
{
    public class OrganChartViewModel
    {
        [Key]
        public long Id { get; set; }

        public long? Job_Id { get; set; }
        public long Unit_Id { get; set; }
        public long? OrganChart_Parent_Id { get; set; }
        public long PositionType_Id { get; set; }
        public string Date { get; set; }
        public bool? KeepHistory { get; set; }
        public bool Show { get; set; }
    }
}