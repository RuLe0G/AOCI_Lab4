using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace лаб4
{
    public partial class Form1 : Form
    {

        private UCDLRAOCI myclass = new UCDLRAOCI();
        public Form1()
        {
            InitializeComponent();
        }
        //открыть картинку

        private string OpenFile()
        {
            string fileName = null;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = ("Файлы изображений | *.jpg; *.jpeg; *.jpe; *.jfif; *.png");
            var result = openFileDialog.ShowDialog(); // открытие диалога выбора файла            
            if (result == DialogResult.OK) // открытие выбранного файла
            {
                fileName = openFileDialog.FileName;
            }
            return fileName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            myclass.Source(OpenFile());
            imageBox1.Image = myclass.sourceImage;
            imageBox2.Image = myclass.sourceImage;
        }
        private void button16_Click(object sender, EventArgs e)
        {
            myclass.MainImage();
            imageBox2.Image = myclass.MainImageExp;
            myclass.ShC = 0;
            myclass.ShT = 0;
            myclass.ShR = 0;
            label1.Text = "";
            label2.Text = "";
        }
        private void button17_Click(object sender, EventArgs e)
        {

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = ("Файлы изображений | *.jpg; *.jpeg; *.jpe; *.jfif; *.png");
            var result = saveFileDialog.ShowDialog(); // открытие диалога выбора файла            
            if (result == DialogResult.OK) // открытие выбранного файла
            {
                string fileName = saveFileDialog.FileName;
                myclass.saveJpeg(fileName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            imageBox2.Image = myclass.Lab4Func(3,Convert.ToDouble(textBox1.Text.ToString()), Convert.ToDouble(textBox2.Text.ToString()));
            label1.Text = myclass.ShT.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            imageBox2.Image = myclass.Lab4Func(4, Convert.ToDouble(textBox1.Text.ToString()), Convert.ToDouble(textBox2.Text.ToString()));
            label1.Text = myclass.ShR.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            imageBox2.Image = myclass.Lab4Func(0, Convert.ToDouble(textBox1.Text.ToString()), Convert.ToDouble(textBox2.Text.ToString()));
            label1.Text = myclass.ShR.ToString();
            label2.Text = myclass.ShT.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            imageBox2.Image = myclass.Lab4FuncCircl();
            label1.Text = myclass.ShC.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            imageBox2.Image = myclass.Lab4FuncColor(Convert.ToByte(textBox6.Text.ToString()));
        }

        private void button7_Click(object sender, EventArgs e)
        {
            imageBox2.Image = myclass.CannyProcess();
        }
    }
}
