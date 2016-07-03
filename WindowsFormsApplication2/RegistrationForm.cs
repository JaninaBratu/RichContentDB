using RCD.BL.Services;
using RCD.BL.Utils;
using System;
using System.Drawing;
using System.Windows.Forms;


namespace FormWindows
{
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();
            LoadImage();
        }

        private void Back_Click(object sender, MouseEventArgs e)
        {
            LoginForm logForm = new LoginForm();
            Hide();
            logForm.Show();
        }

        private void ResetLabels()
        {
            labelErrorUsername.Text = "";
            labelErrorPassword.Text = "";
            labelErrorConfirmPass.Text = "";
        }

        private void SetUsernameLabelMessage(string message)
        {
            labelErrorUsername.Text = message;
            labelErrorUsername.ForeColor = System.Drawing.Color.Red;
            labelErrorUsername.Show();
        }

        private void SetPasswordLabelMessage(string message)
        {
            labelErrorPassword.Text = message;
            labelErrorPassword.ForeColor = System.Drawing.Color.Red;
            labelErrorPassword.Show();
        }

        private void SetConfirmPassLabelMessage(string message)
        {
            labelErrorConfirmPass.Text = message;
            labelErrorConfirmPass.ForeColor = System.Drawing.Color.Red;
            labelErrorConfirmPass.Show();
        }

        private void SetSuccesfullLabelMessage(string message)
        {
            labelMessage.Text = message;
            labelMessage.Show();
        }


        private void button_SaveUser(object sender, EventArgs e)
        {
            ResetLabels();

            bool isValid = true;

            if (String.IsNullOrEmpty(usernameTextBox.Text))
            {

                SetUsernameLabelMessage("Username is required");
                isValid = false;
            }
            else
            {
                bool isUserNameValid = RegistrationAction.CheckUsernameForRegistration(usernameTextBox.Text);
                if (isUserNameValid)
                {
                    int userId = UserService.GetUserById(usernameTextBox.Text);

                    if (userId != 0)
                    {
                        SetUsernameLabelMessage("The username exists already!");
                        isValid = false;
                    }
                }
                else
                {
                    SetUsernameLabelMessage("The username must contain between 5 and 15 characters.");
                    isValid = false;
                }
            }

            if (String.IsNullOrEmpty(passwordTextBox.Text))
            {
                SetPasswordLabelMessage("Password is required.");
                isValid = false;
            }
            else
            {
                bool isPasswordValid = RegistrationAction.CheckPasswordForRegistration(passwordTextBox.Text);
                if (!isPasswordValid)
                {
                    SetPasswordLabelMessage("The password is incorrect. Must contain at least 1 uppercase character, "
                                           + "\n"
                                           + "1 lowercase character and 1 digit "
                                           + "and have the lenght between 6 and 15");
                    isValid = false;
                }
            }

            if (String.IsNullOrEmpty(confirmPassTextBox.Text))
            {
                SetConfirmPassLabelMessage("Confirm password is required.");
                isValid = false;
            }
            else
            {
                if (passwordTextBox.Text != confirmPassTextBox.Text)
                {
                    SetConfirmPassLabelMessage("Must coincide with previous entry.");
                    isValid = false;
                }
            }

            if(isValid)
            {
                UserService.RegisterUser(usernameTextBox.Text, passwordTextBox.Text);
                SetSuccesfullLabelMessage("The user has been succesfully registered. You can now login!");
                usernameTextBox.Text = "";
                passwordTextBox.Text = "";
                confirmPassTextBox.Text = "";
            }
        }
        

        private void LoadImage()
        {
            Image image = Image.FromFile("E:\\images\\addUser.png");
            pictureBoxAddUser.Image = image;
            pictureBoxAddUser.Height = image.Height;
            pictureBoxAddUser.Width = image.Width;
        }

       
    }
}

