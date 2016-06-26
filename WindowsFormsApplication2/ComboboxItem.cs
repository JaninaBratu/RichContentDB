using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormWindows
{
    public class ComboboxItem
    {
        string text;
        int value;

        public string Text
        {
            get
            {
                return text;
            }
        }

        public int Value
        {
            get
            {
                return value;
            }
        }

        public ComboboxItem(string text, int value)
        {
            this.text = text;
            this.value = value;
        }
    }
}
