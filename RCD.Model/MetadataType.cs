using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCD.Model
{
    [Table("tblMetadataType")]
    public class MetadataType
    {
        [Key]
        [Column("MetadataTypeID")]
        public int MetadataTypeId { get; set; }

        [Required()]
        public string Name { get; set; }

    }
}
