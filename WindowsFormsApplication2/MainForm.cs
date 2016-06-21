using RCD.BL.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using FormWindows;
using RCD.DAL.ViewModel;

namespace RCD.FormWindows
{
    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();
            
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
                dataGridView1.Rows.Add(new string[] { rowArray.FileId.ToString(), rowArray.FileName, rowArray.FileType.ToUpper(), rowArray.CreationDate.ToString() });
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
                var files =  FileService.SearchFile(text_search.Text);
                text_search.Clear();
                InitializeDataGridView(files);
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

        private void button3_Click(object sender, EventArgs e)
        {
            DateTime dateFrom = dateTimePicker1.Value.Date;
            DateTime dateTo = dateTimePicker2.Value.Date;

            List<FileViewModel> listOfFiles = FileService.SearchFileByDatePicker(dateFrom, dateTo);
            InitializeDataGridView(listOfFiles);
        }
    }
}
