using System.ComponentModel.DataAnnotations;

namespace Pseez.ViewModels.ViewModels.Sts.Staff
{
    public class EmployeeOrganChartViewModel
    {
        [Key]
        public long Id { get; set; }

        public long OrganChart_Id { get; set; }
        public long Employee_Id { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string Description { get; set; }
    }
}