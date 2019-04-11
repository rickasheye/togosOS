using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace testappConverter
{
    public partial class Form1 : Form
    {
        string filename;

        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = "";
                filename = filename.Replace(@"\", @"/");
                Bitmap bitmap = new Bitmap(filename);
                FileInfo infoFile = new FileInfo(filename);
                textBox1.Text += "private Bitmap " + infoFile.Name.Replace(infoFile.Extension, "") + " = new Bitmap(" + bitmap.Width + "," + bitmap.Height + "," + "new byte[] {";
                for (int i = 0; i < bitmap.Width; i++)
                {
                    for (int y = 0; y < bitmap.Height; y++)
                    {
                        float alpha = bitmap.GetPixel(i, y).A;
                        float R = bitmap.GetPixel(i, y).R;
                        float G = bitmap.GetPixel(i, y).G;
                        float B = bitmap.GetPixel(i, y).B;
                        textBox1.Text += Convert.ToInt32(alpha) + "," + Convert.ToInt32(R) + "," + Convert.ToInt32(G) + "," + Convert.ToInt32(B) + ",";
                    }
                }
                textBox1.Text += "}, ColorDepth.ColorDepth32);";
            }
            catch (Exception eventerror)
            {
                Console.WriteLine("Exception: " + eventerror);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Browse for the file
            OpenFileDialog dialog = new OpenFileDialog();
            if(dialog.ShowDialog() == DialogResult.OK)
            {
                //set the file name
                filename = dialog.FileName;
                label1.Text = dialog.FileName;
                FileInfo file = new FileInfo(dialog.FileName);
                label2.Text = file.Name;
                Bitmap bitmap = new Bitmap(filename);
                pictureBox1.Image = bitmap;
            }
        }
    }
}
