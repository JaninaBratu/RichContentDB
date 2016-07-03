namespace FormWindows
{
    partial class UserProfileForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.nameLabel = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.saveProfileButton = new System.Windows.Forms.Button();
            this.editLabel = new System.Windows.Forms.Label();
            this.backEditButton = new System.Windows.Forms.Button();
            this.pictureBoxEdit = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEdit)).BeginInit();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(51, 71);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(0, 13);
            this.nameLabel.TabIndex = 0;
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(51, 98);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(0, 13);
            this.passwordLabel.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(145, 71);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(172, 20);
            this.textBox1.TabIndex = 3;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(145, 110);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(172, 20);
            this.textBox2.TabIndex = 4;
            // 
            // saveProfileButton
            // 
            this.saveProfileButton.Location = new System.Drawing.Point(107, 229);
            this.saveProfileButton.Name = "saveProfileButton";
            this.saveProfileButton.Size = new System.Drawing.Size(113, 23);
            this.saveProfileButton.TabIndex = 6;
            this.saveProfileButton.Text = "Save";
            this.saveProfileButton.UseVisualStyleBackColor = true;
            this.saveProfileButton.Click += new System.EventHandler(this.saveProfileButton_Click);
            // 
            // editLabel
            // 
            this.editLabel.AutoSize = true;
            this.editLabel.Location = new System.Drawing.Point(145, 178);
            this.editLabel.Name = "editLabel";
            this.editLabel.Size = new System.Drawing.Size(0, 13);
            this.editLabel.TabIndex = 7;
            // 
            // backEditButton
            // 
            this.backEditButton.Location = new System.Drawing.Point(12, 12);
            this.backEditButton.Name = "backEditButton";
            this.backEditButton.Size = new System.Drawing.Size(75, 23);
            this.backEditButton.TabIndex = 8;
            this.backEditButton.Text = "Back";
            this.backEditButton.UseVisualStyleBackColor = true;
            this.backEditButton.Click += new System.EventHandler(this.backEditButton_Click);
            // 
            // pictureBoxEdit
            // 
            this.pictureBoxEdit.Location = new System.Drawing.Point(288, 3);
            this.pictureBoxEdit.Name = "pictureBoxEdit";
            this.pictureBoxEdit.Size = new System.Drawing.Size(100, 50);
            this.pictureBoxEdit.TabIndex = 9;
            this.pictureBoxEdit.TabStop = false;
            // 
            // UserProfileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 285);
            this.Controls.Add(this.pictureBoxEdit);
            this.Controls.Add(this.backEditButton);
            this.Controls.Add(this.editLabel);
            this.Controls.Add(this.saveProfileButton);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.nameLabel);
            this.Name = "UserProfileForm";
            this.Text = "UserProfile";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEdit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button saveProfileButton;
        private System.Windows.Forms.Label editLabel;
        private System.Windows.Forms.Button backEditButton;
        private System.Windows.Forms.PictureBox pictureBoxEdit;
    }
}