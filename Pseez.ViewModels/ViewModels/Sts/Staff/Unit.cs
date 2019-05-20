using System.ComponentModel.DataAnnotations;

namespace Pseez.ViewModels.ViewModels.Sts.Staff
{
    public class UnitViewModel
    {
        [Key]
        public long Id { get; set; }

        public string Code { get; set; }
        public string Name { get; set; }
        public long? Unit_Parent_Id { get; set; }
        public bool IsManagement { get; set; }
        public bool? Show { get; set; }
    }
}