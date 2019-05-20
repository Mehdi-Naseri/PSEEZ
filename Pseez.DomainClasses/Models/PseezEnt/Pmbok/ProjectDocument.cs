using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pseez.DomainClasses.Models.PseezEnt.Pmbok
{
    [Table("ProjectDocument", Schema = "Pmbok.ProjectDocuments")]
    public class ProjectDocument
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string DocumentName { get; set; }

        [Required]
        [MaxLength(50)]
        public string DocumentType { get; set; }

        [MaxLength(50)]
        public string ParentDocumentName { get; set; }

        [Timestamp]
        public byte[] Timestamp { get; set; }

}
}
