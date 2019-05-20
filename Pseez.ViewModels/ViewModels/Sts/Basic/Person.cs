using System.ComponentModel.DataAnnotations;

namespace Pseez.ViewModels.ViewModels.Sts.Basic
{
    public class PersonViewModel
    {
        [Key]
        public long Id { get; set; }

        public string Name { get; set; }
        public string Family { get; set; }
        public string FatherName { get; set; }
        public string BirthDate { get; set; }
        public long? City_Id { get; set; }
        public string IdNumber { get; set; }
        public string NationalCode { get; set; }
        public long Gender_Id { get; set; }
        public string Mobile { get; set; }
    }
}