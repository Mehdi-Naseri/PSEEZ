using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace Pseez.ViewModels.ViewModels.PseezEnt.Pmbok
{
    public class ProjectDocumentFileViewModel
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string FileName { get; set; }

        [Required]
        public byte[] File { get; set; }

        [Required]
        public DateTime UploadDateTime { get; set; }

        [Required]
        public string CreatedBy { get; set; }

        [Required]
        public string ProjectDocumentName { get; set; }

        [Required]
        public string ProjectName { get; set; }
    }
}
