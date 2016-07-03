using RCD.BL.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using FormWindows;
using RCD.DAL.ViewModel;
using System.Drawing;

namespace RCD.Form
{
    public partial class FilesForm : System.Windows.Forms.Form
    {
        protected string Username = "";
        protected string Password = "";

        public FilesForm()
        {
            InitializeComponent();
            InitializeComboBox();
            LoadProfileImage();
        }

        public FilesForm(string username, string password)
        {
            Username = username;
            Password = password;

            InitializeComponent();
            InitializeComboBox();
            InitializeUserLabel();
            LoadProfileImage();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var files = FileService.GetFileDetails();
            InitializeDataGridView(files);
        }

        private void InitializeDataGridView(List<DAL.ViewModel.FileViewModel> files)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.AutoSize = true;

            dataGridView1.ColumnCount = 4;

            dataGridView1.Columns[0].Name = "FileTypes Id";
            dataGridView1.Columns[1].Name = "FileTypes Name";
            dataGridView1.Columns[2].Name = "FileTypes Type";
            dataGridView1.Columns[3].Name = "Creation Date";

            foreach (var rowArray in files)
            {
                dataGridView1.Rows.Add(new string[] { rowArray.FileId.ToString(), rowArray.Name, rowArray.FileType.ToUpper(), rowArray.CreationDate.ToString() });
            }
            dataGridView1.Refresh();

           
        }

        private static string GetCreationDateName()
        {
            string creationDate = String.Empty;

            try
            {
                creationDate = ConfigurationManager.AppSettings["creationDate"];
            }

            catch (Exception)
            {
                Console.WriteLine("creationDate is missing.");
            }

            return creationDate;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (checkBox1.Checked)
                {
                    DateTime dateFrom = dateTimePicker1.Value.Date;
                    DateTime dateTo = dateTimePicker2.Value.Date;
                    string nameSearched = text_search.Text;

                    ComboboxItem selectedType = (ComboboxItem)comboBox1.SelectedItem;
                    string selecteVal = selectedType.Text;

                    string typeSearched = selecteVal;

                    FilterViewModel filterViewM = new FilterViewModel(nameSearched, typeSearched, dateFrom, dateTo);
                    List<FileViewModel> listOfFiles = FileService.SearchByFilters(filterViewM);

                    //reset filters
                    text_search.Text = "";
                    dateTimePicker1.Value = DateTime.Now.Date;
                    dateTimePicker2.Value = DateTime.Now.Date;

                    InitializeDataGridView(listOfFiles);
                }
                else
                {
                    dateTimePicker1.Value = new DateTime();
                    dateTimePicker2.Value = new DateTime();
                    string namesearched = text_search.Text;

                    ComboboxItem selectedType = (ComboboxItem)comboBox1.SelectedItem;
                    string selecteVal = selectedType.Text;
                    string typeSearched = selecteVal;

                    FilterViewModel filterViewList = new FilterViewModel(namesearched, typeSearched, dateTimePicker1.Value, dateTimePicker2.Value);
                    List<FileViewModel> listoffiles = FileService.SearchByFilters(filterViewList);

                    //reset filters
                    text_search.Text = "";
            }

        }
            catch (Exception)
            {
                throw;
            }
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int fileId = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                if (fileId != 0)
                {
                    Model.File file = FileService.GetFile(fileId);
                    Process.Start(@Path.GetDirectoryName(file.Path.ToString()));
                }
                
            }
            catch (Exception)
            {

                MessageBox.Show("The file does not exist anymore in the destination folder");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            if(dataGridView1.SelectedRows.Count >0)
            {
                var index = dataGridView1.SelectedRows[0].Index;
                int fileId = int.Parse(dataGridView1.Rows[index].Cells[0].Value.ToString());
                MetadataForm frm = new MetadataForm(fileId);
                frm.Show();
            }
        }

        private void InitializeComboBox()
        {
            List<Model.FileType> listOfFileTypes = FileTypeService.GetFileTypes();
            List<ComboboxItem> c = new List<ComboboxItem>();
            for (int i = 0; i < listOfFileTypes.Count; i++)
            {
                
                c.Add(new ComboboxItem(listOfFileTypes[i].Name.ToString(), listOfFileTypes[i].FileTypeId));

            }
            comboBox1.DataSource = c;

            comboBox1.DisplayMember = "Text";
            comboBox1.ValueMember = "Value";

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.SelectedIndexChanged += new EventHandler(ComboBox_SelectedIndexChanged);
        }

        private void ComboBox_SelectedIndexChanged(Object sender, EventArgs e)
        {
            string selectedType = comboBox1.Text;
            if (selectedType != "")
            {
                MessageBox.Show(selectedType);
            }
        }

        private void InitializeUserLabel()
        {
            userLabel.Text = char.ToUpper(Username[0]) + Username.Substring(1);
            userLabel.Show();
        }

        private void LoadProfileImage()
        {
            Image image = Image.FromFile("E:\\images\\userProfile.png");
            pictureBox.Image = image;
            pictureBox.Height = image.Height;
            pictureBox.Width = image.Width;
        }

        private void userLabel_Click(object sender, EventArgs e)
        {
            UserProfileForm userProfileForm = new UserProfileForm(Username, Password);
            Hide();
            userProfileForm.Show();
        }

    }
}
