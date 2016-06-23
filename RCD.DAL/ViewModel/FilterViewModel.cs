using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCD.DAL.ViewModel
{
    public class FilterViewModel
    {
        public string searchText { get; set; }
        public DateTime dateFrom { get; set; }
        public DateTime dateTill { get; set; }

        public FilterViewModel(string text, DateTime dateStart, DateTime dateEnd)
        {
            searchText = text;
            dateFrom = dateStart;
            dateTill = dateEnd;
        }
    }
}
