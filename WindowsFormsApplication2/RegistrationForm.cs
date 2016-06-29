using RCD.BL.Services;
using RCD.BL.Utils;
using RCD.Model;
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
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void Back_Click(object sender, MouseEventArgs e)
        {
            UserLoginForm logForm = new UserLoginForm();
            Hide();
            logForm.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button_SaveUser(object sender, EventArgs e)
        {
            UserRegistrationService.RegisterUser(new User(), usernameTextBox.Text, passwordTextBox.Text, confirmPassTextBox.Text);
        }
    }
}
