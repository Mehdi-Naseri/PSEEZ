using System.ComponentModel.DataAnnotations;

namespace Pseez.ViewModels.ViewModels.Sts.Staff
{
    public class EmployeeAcademicalResumeViewModel
    {
        [Key]
        public long Id { get; set; }

        public long Employee_Id { get; set; }
        public string EntryYear { get; set; }
        public string GraduatedYear { get; set; }
        public long DegreeState_Id { get; set; }
        public long? AcademicalField_Id { get; set; }
        public long? School_Id { get; set; }
        public long? City_Id { get; set; }
        public double? Grade { get; set; }
        public long? ProofState_Id { get; set; }
        public string Description { get; set; }
    }
}