using RCD.BL.Services;
using RCD.DAL.Repositories;
using RCD.Form;
using System;
using System.Drawing;
using System.Windows.Forms;



namespace FormWindows
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            LoadImage();
        }

        private void Register(object sender, EventArgs e)
        {
            RegistrationForm regForm = new RegistrationForm();
            Hide();
            regForm.Show();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            int userId = 0;

            if (checkBox1.Checked)
            {
                //if the admin exits in the database
                //show admin page
                int adminId = RepositoryUser.CheckAdmin(usernameTextBox.Text, true);
               
                if (adminId != 0)
                {
                    AdminForm adminForm = new AdminForm();
                    adminForm.Show();
                }
                else
                {
                    loginLabel.Text = "Unrecognized admin. Please try again!";
                    loginLabel.TextAlign = ContentAlignment.MiddleCenter;
                    loginLabel.ForeColor = System.Drawing.Color.Red;
                    loginLabel.Show();
                    usernameTextBox.Text = "";
                    passwordTextBox.Text = "";
                    checkBox1.Checked = false;
                }
            }
            else
            {
                //with false
                // show a normal user form
                userId = UserService.LoginUser(usernameTextBox.Text, passwordTextBox.Text);
                if (userId != 0)
                {
                    FilesForm formFiles = new FilesForm(usernameTextBox.Text, passwordTextBox.Text);
                    Hide();
                    formFiles.Show();

                }
                else
                {
                    loginLabel.Text = "Your credentials are incorrect. Please try again";
                    loginLabel.ForeColor = System.Drawing.Color.Red;
                    usernameTextBox.Text = "";
                    passwordTextBox.Text = "";
                }
            }
        }

        private void LoadImage()
        {
            Image image = Image.FromFile("E:\\images\\login_icon.png");
            pictureBoxLogin.Image = image;
            pictureBoxLogin.Height = image.Height;
            pictureBoxLogin.Width = image.Width;
            
        }
    }
}
