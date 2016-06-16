
using System.Windows.Forms;
using RCD.FormWindows;
using RCD.BL.Services;
using RCD.Model;
using System.Collections.Generic;
using System.IO;

namespace FormWindows
{
    public partial class MetadataForm : Form
    {

        public MetadataForm(MainForm mainForm)
        {

        }
       
        public MetadataForm(int fileId)
        {
            InitializeComponent();
            var file = FileService.GetFileInfo(fileId);
            InitializeDataViewGrid(file[0]);
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            MainForm mainForm = new MainForm();
            mainForm.Show();
        }

        private void InitializeDataViewGrid(RCD.Model.File file)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.AutoSize = true;

            dataGridView1.ColumnCount = 2;

            List<Metadata> listOfMetadata = file.Metadata;

            dataGridView1.Rows.Add(new string[] { "File Id" , file.FileId.ToString()});
            dataGridView1.Rows.Add(new string[] { "File Name", file.Name});
            dataGridView1.Rows.Add(new string[] { "File Type", file.FileType.Name});

            for (int i = 0; i < listOfMetadata.Count; i++)
            {
                dataGridView1.Rows.Add(new string[] {listOfMetadata[i].MetadataType.Name, listOfMetadata[i].Value });
            }
            dataGridView1.Refresh();

        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            bool isOk = false;

            Metadata newMetadata = new Metadata();
            newMetadata.Value = textBox2.Text;

            isOk = ValidateMetadata(textBox1.Text, textBox2.Text);
            if (isOk)
            {
                MetadataService.SaveMetadataIntoDb(newMetadata, textBox1.Text, int.Parse(dataGridView1.Rows[0].Cells[1].Value.ToString()));
                textBox1.Text = "";
                textBox2.Text = "";
                dataGridView1.Refresh();
            }
        }

        private bool ValidateMetadata(string nameOfMetadata, string valueOfMetadtaa)
        {
            bool isOk = false;

            int idMetadataType = MetadataTypeService.GetMetadataTypeId(nameOfMetadata);
            if (idMetadataType != 0 && idMetadataType != -1)
            {
                int idMetadata = MetadataService.GetMetadataId(valueOfMetadtaa);
                if (idMetadata != 0 && idMetadata != -1)
                {
                    MessageBox.Show("The metadata is already in the database. Please another one!");
                }
                else
                {

                    isOk = true;
                }
            }
            else
            {
                isOk = true;
            }

            return isOk;
        }

    }
}
