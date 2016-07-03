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
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
            InitializeAdminForm();
        }

        public void InitializeAdminForm()
        {
            adminLabel.Text = "This page is temporary unavailable";
            adminLabel.ForeColor = System.Drawing.Color.Red;
            adminLabel.Show();
        }

        private void backButton_MouseClick(object sender, MouseEventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }
    }
}
