using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCD.Model
{
    [Table("tblSetting")]
    public class Setting
    {
        [Key]
        [Column("SettingID")]
        public int SettingId { get; set; }

        [Required()]
        public string PeriodTime { get; set; }
    }
}
