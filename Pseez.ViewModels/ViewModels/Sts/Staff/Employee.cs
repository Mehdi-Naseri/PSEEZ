using System.ComponentModel.DataAnnotations;

namespace Pseez.ViewModels.ViewModels.Sts.Staff
{
    public class EmployeeViewModel
    {
        [Key]
        public long Id { get; set; }

        public string Code { get; set; }
        public string CardId { get; set; }
        public string CreationFileDate { get; set; }
        public string PrimaryEmploymentDate { get; set; }
        public long? Native_Id { get; set; }
        public long? Religion_Id { get; set; }
        public string EMail { get; set; }
        public long? BloodType_Id { get; set; }
        public long CompanyType_Id { get; set; }
        public string FamilyCardId { get; set; }
    }
}