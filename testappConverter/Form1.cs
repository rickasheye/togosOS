using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testappConverter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (fileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    label1.Text = fileDialog.FileName;
                    string filePath = "@" + fileDialog.FileName;
                    Bitmap bitmap = new Bitmap(filePath);
                    for (int i = 1; i < bitmap.Width; i++)
                    {
                        for (int y = 1; y < bitmap.Height; y++)
                        {
                            textBox1.Text += bitmap.GetPixel(i, y).R + "," + bitmap.GetPixel(i, y).G + "," + bitmap.GetPixel(i, y).B + ",";
                        }
                    }
                }
                catch (System.Exception error)
                {
                    Console.WriteLine("Exception: " + error);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = "";
                textBox2.Text = textBox2.Text.Replace(@"\", @"/");
                Bitmap bitmap = new Bitmap(textBox2.Text);
                textBox1.Text += "private Bitmap generated = new Bitmap(" + bitmap.Width + "," + bitmap.Height + "," + "new byte[] {";
                for (int i = 0; i < bitmap.Width; i++)
                {
                    for (int y = 0; y < bitmap.Height; y++)
                    {
                        textBox1.Text += bitmap.GetPixel(i, y).A + "," + bitmap.GetPixel(i, y).R + "," + bitmap.GetPixel(i, y).G + "," + bitmap.GetPixel(i, y).B + ",";
                    }
                }
                textBox1.Text += "}, ColorDepth.ColorDepth32);";
            }
            catch (Exception eventerror)
            {
                Console.WriteLine("Exception: " + eventerror);
            }
        }
    }
}
