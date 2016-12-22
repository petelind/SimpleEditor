using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO; // в этой библиотеке классов "живет" статический класс File

namespace SimpleEditor
{
    public partial class MainForm : System.Windows.Forms.Form
    {
        private string name; // здесть будет храниться имя файла

        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            openFileDialog1.Title = "Выберите текстовый файл...";
            openFileDialog1.Filter = "Текстовые файлы | *.txt";
            openFileDialog1.FileName = "МойТекст";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                
                name = openFileDialog1.FileName;
                textBox1.Clear();
                textBox1.Text = File.ReadAllText(name);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Title = "Выберите куда сохранить...";
            saveFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            saveFileDialog1.Filter = "Текстовые файлы | *.txt";

            if (name == "")
            {
                saveFileDialog1.FileName = "МойТекст";
                saveFileDialog1.DefaultExt = "txt";
            }
            else
            {
                saveFileDialog1.FileName = name;
            }

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                name = saveFileDialog1.FileName;
                File.WriteAllText(name, textBox1.Text);
            }
        }

       
    }
}
