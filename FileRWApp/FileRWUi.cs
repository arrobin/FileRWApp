using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileRWApp
{
    public partial class FileRWUi : Form
    {
        string path = @"E:\.NET Web App(Batch-4)\02-05-2015\FileRWApp\info.text";
        public FileRWUi()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            
            FileStream aFileStream = new FileStream(path,FileMode.Append);
            StreamWriter aStreamWriter = new StreamWriter(aFileStream);

            aStreamWriter.Write("Name:");
            aStreamWriter.Write(firstNameTextBox.Text);
            aStreamWriter.Write(" ");
            aStreamWriter.WriteLine(lastNameTextBox.Text);

            aStreamWriter.Close();
            aFileStream.Close();
            firstNameTextBox.Clear();
            lastNameTextBox.Clear();
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            showListBox.Items.Clear();
            FileStream aFileStream = new FileStream(path, FileMode.Open);
            StreamReader aStreamReader = new StreamReader(aFileStream);

            while (!aStreamReader.EndOfStream)
            {
                string name = aStreamReader.ReadLine();
                showListBox.Items.Add(name);
            }
            aStreamReader.Close();
            aFileStream.Close();
        }
    }
}
