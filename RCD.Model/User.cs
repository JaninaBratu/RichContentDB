using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCD.Model
{
    [Table("tblUser")]
    public class User
    {

        public User()
        {
            Files = new List<File>();
        }

        [Key]
        [Column("UserID")]
        public int UserId { get; set; }

        [Required()]
        [Index(IsUnique = true)]
        [MaxLength(20, ErrorMessage = "Username must be greater than 5 characters or less than 20"), MinLength(5)]
        public string Username { get; set; }

        [Required()]
        [Index(IsUnique = true)]
        [MaxLength(20, ErrorMessage = "Password must be greater than 5 characters or less than 20"), MinLength(5)]
        public string Password { get; set; }

        public bool IsActive { get; set; }

        public bool IsAdmin { get; set; }

        public virtual List<File> Files { get; set; }

    }
}
