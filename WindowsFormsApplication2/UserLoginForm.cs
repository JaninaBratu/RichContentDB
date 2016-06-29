using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormWindows
{
    public partial class UserLoginForm : Form
    {
        public UserLoginForm()
        {
            InitializeComponent();
        }

        private void Register(object sender, EventArgs e)
        {
            RegistrationForm regForm = new RegistrationForm();
            Hide();
            regForm.Show();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                //with true
                // Show an admin form
            }
            else
            {
                //with false
                // show a normal user form
            }
        }
    }
}
