using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCD.DAL.ViewModel
{
    public class FilterViewModel
    {
        public string SearchText { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTill { get; set; }

        public FilterViewModel(string text, DateTime dateStart, DateTime dateEnd)
        {
            SearchText = text;
            DateFrom = dateStart;
            DateTill = dateEnd;
        }
    }
}
