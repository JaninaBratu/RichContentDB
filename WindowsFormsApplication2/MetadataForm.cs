
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

        bool isOk = false;

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

            dataGridView1.Rows.Add(new string[] { "FileTypes Id" , file.FileId.ToString()});
            dataGridView1.Rows.Add(new string[] { "FileTypes Name", file.Name});
            dataGridView1.Rows.Add(new string[] { "FileTypes Type", file.FileType.Name});

            for (int i = 0; i < listOfMetadata.Count; i++)
            {
                dataGridView1.Rows.Add(new string[] {listOfMetadata[i].MetadataType.Name, listOfMetadata[i].Value });
            }
            dataGridView1.Refresh();

        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            //    [4:26:12 PM]
            //        Andrei Coman: trebuie sa vezi daca custom medata name mai exista in metadata types
            //[4:26:15 PM] Andrei Coman: daca nu e o bagi
            ////[4:26:49 PM] Andrei Coman: daca era deja in metadata types trebuie s-o cauti daca este la fisierul ala
            //deci verifici doar daca id - ul din metadatatype este deja folosit la fisierul asta in metadate

            Metadata newMetadata = new Metadata();
            newMetadata.Value = textBox2.Text;

            isOk = ValidationOfMetadata(textBox1.Text, int.Parse(dataGridView1.Rows[0].Cells[1].Value.ToString()));
            if (isOk)
            {
                MetadataService.SaveMetadataIntoDb(newMetadata, textBox1.Text, int.Parse(dataGridView1.Rows[0].Cells[1].Value.ToString()));
                textBox1.Text = "";
                textBox2.Text = "";
                dataGridView1.Refresh();
            }
            else {
                textBox1.Text = "";
                textBox2.Text = "";
            }
        }

        private bool ValidationOfMetadata(string metadataType, int fileId)
        {
            List<int> resultList = MetadataTypeService.GetMetadataType(metadataType, fileId);
            if (resultList.Count == 2)
            {
                if (resultList[0] >0 && resultList[1] >0)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("The metadata is already in the database. Please try again!");
                }
            }

            return false;
        }

    }
}
