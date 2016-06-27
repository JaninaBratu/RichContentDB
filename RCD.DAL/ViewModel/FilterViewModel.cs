using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCD.DAL.ViewModel
{
    public class FilterViewModel
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTill { get; set; }

        public FilterViewModel(string text, string type, DateTime dateStart, DateTime dateEnd)
        {
            Name = text;
            Type = type;
            DateFrom = dateStart;
            DateTill = dateEnd;
        }
    }
}
