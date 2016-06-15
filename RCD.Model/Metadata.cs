using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCD.Model
{
    [Table("tblMetadata")]
    public class Metadata
    {
        [Key]
        [Column("MetadataID")]
        public int MetadataId { get; set; }

        [Required()]
        public string Value { get; set; }

        [ForeignKey("File")]
        [Column("FileID")]
        [Required]
        public int FileId { get; set; }

        public File File { get; set; }


        [ForeignKey("MetadataType")]
        [Column("MetadataTypeID")]
        [Required()]
        public int MetadataTypeId { get; set; }

        public MetadataType MetadataType { get; set; }

    }
}
