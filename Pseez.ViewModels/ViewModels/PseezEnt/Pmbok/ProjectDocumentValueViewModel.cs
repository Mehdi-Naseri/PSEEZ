using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace Pseez.ViewModels.ViewModels.PseezEnt.Pmbok
{
    public class ProjectDocumentValueViewModel
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Value { get; set; }

        [Required]
        public DateTime Datetime { get; set; }

        [Required]
        public string CreatedBy { get; set; }

        [Required]
        public string ProjectDocumentName { get; set; }

        [Required]
        public string ProjectName { get; set; }

        //بعدا اصلاح گردد.
        ICollection<byte[]> ProjectDocumentFiles { get; set; }
    }
}
