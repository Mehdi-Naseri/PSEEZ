using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pseez.DomainClasses.Models.PseezEnt.Pmbok
{
    [Table("ProjectDocumentFileDeleted", Schema = "Pmbok.ProjectDocuments")]
    public class ProjectDocumentFileDeleted
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
        public DateTime DeleteDateTime { get; set; }

        [Required]
        public string CreatedBy { get; set; }

        [Required]
        public int ProjectDocumentId { get; set; }

        [Required]
        public int ProjectId { get; set; }

        [Timestamp]
        public byte[] Timestamp { get; set; }

        public virtual ProjectDocument ProjectDocument { get; set; }

        public virtual Project Project { get; set; }
    }
}
