using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RCD.Model
{
    [Table("tblFile")]
    public class File
    {

        [Key]
        [Column("FileID")]
        public int FileId { get; set; }

        [Required()]
        public string Path { get; set; }

        [Required()]
        public string Name { get; set; }

        public virtual User User { get; set; }

        public virtual FileType FileType { get; set; }

        public virtual List<Metadata> Metadata { get; set; }

    }
}
