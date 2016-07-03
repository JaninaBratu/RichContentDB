using RCD.BL.Services;
using RCD.Form;
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
    public partial class UserProfileForm : Form
    {
        //public static string userid="user";
        protected string Username = "";
        protected string Password = "";

        public UserProfileForm()
        {
            InitializeComponent();
        }

        public UserProfileForm(string username, string password)
        {
            Username = username;
            Password = password;
            InitializeComponent();
            InitializeUserProfileForm();
        }

        private void InitializeUserProfileForm()
        {
            nameLabel.Text = "Username";
            textBox1.Text = Username;
            passwordLabel.Text = "Password";
            textBox2.Text = Password;

            Image image = Image.FromFile("E:\\images\\edit_profile.png");
            pictureBoxEdit.Image = image;
            pictureBoxEdit.Height = image.Height;
            pictureBoxEdit.Width = image.Width;
        }


        //not fully implemented
        private void saveProfileButton_Click(object sender, EventArgs e)
        {
            bool success = UserService.EditUser(Username, Password);
            if (success)
            {
                MessageBox.Show("The user's profile has been succesfully updated");
            }
        }

        private void backEditButton_Click(object sender, EventArgs e)
        {
            Hide();
            FilesForm filesForm = new FilesForm(Username, Password);
            filesForm.Show();
        }
    }
}
