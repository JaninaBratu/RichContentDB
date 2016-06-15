using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestWindowsForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
               doSomething();
        }

        private void doSomething()
        {
            var occurences = new List<string>();
                for (int i = 1; i <= 100; i++)
                {
                    bool fizz = i % 3 == 0;
                    bool buzz = i % 5 == 0;

                    if (fizz && buzz)
                        occurences.Add(string.Format("{0} FizzBuzz", i));

                    else if (fizz)
                        occurences.Add(string.Format("{0} Fizz", i));

                    else if (buzz)
                        occurences.Add(string.Format("{0} Buzz", i));

                textBox1.ScrollBars = ScrollBars.Vertical;
                textBox1.Text = string.Join(Environment.NewLine, occurences);
            }
        }
    }
}
