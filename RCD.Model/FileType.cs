using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCD.Model
{
    [Table("tblFileType")]
    public class FileType
    {
        [Key]
        [Column("FileTypeID")]
        public int FileTypeId { get; set; }

        [Required()]
        public string Name { get; set; }

    }
}
