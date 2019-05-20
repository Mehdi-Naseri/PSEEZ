using System;
using System.ComponentModel.DataAnnotations;

namespace Pseez.ViewModels.ViewModels.PseezEnt.VisitRegistration
{
    public class RegistrationViewModel
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [MaxLength(20)]
        [Display(Name = "Title")]
        [Required(ErrorMessage = "Enter Title.")]
        public string Title { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Enter Fist Name.")]
        [MaxLength(50, ErrorMessage = "First name must be 50 characters or less")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Enter Last Name.")]
        [MaxLength(50, ErrorMessage = "Last name must be 50 characters or less")]
        public string LastName { get; set; }


        [Display(Name = "IPEC Username")]
        [Required(ErrorMessage = "Enter IPEC Username.")]
        [MaxLength(50, ErrorMessage = "IPEC Username must be 50 characters or less")]
        public string IPECUsername { get; set; }

        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Enter Email Address.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Telephone Number")]
        [Required(ErrorMessage = "Enter Telephone Number.")]
        [MaxLength(50, ErrorMessage = "Telephone number must be 50 characters or less")]
        public string TelephoneNumber { get; set; }

        [Display(Name = "Mobile")]
        [Required(ErrorMessage = "Enter Mobile Address.")]
        [MaxLength(50, ErrorMessage = "Mobile number must be 50 characters or less")]
        public string Mobile { get; set; }

        [Display(Name = "Fax Number")]
        public string FaxNumber { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "Enter Address.")]
        //[MaxLength(350, ErrorMessage = "Address must be 350 characters or less")]
        public string Address { get; set; }

        [Display(Name = "Company Name")]
        [Required(ErrorMessage = "Enter Company Name.")]
        [MaxLength(50, ErrorMessage = "Company Name must be 50 characters or less")]
        public string CompanyName { get; set; }

        [Display(Name = "Company Phone/Fax Number")]
        [Required(ErrorMessage = "Enter Company Name.")]
        [MaxLength(50, ErrorMessage = "Company Phone must be 50 characters or less")]
        public string CompanyPhone { get; set; }

        [Display(Name = "Company Address")]
        [Required]
        //[MaxLength(350,ErrorMessage = "Company Address must be 350 characters or less")]
        public string CompanyAddress { get; set; }

        [Display(Name = "Registration Date/Time")]
        public DateTime RegistrationDateTime { get; set; }
    }
}