using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO;

namespace PortugalLabelPrint
{
    public partial class Form5 : Form
    {
        private void CreateIfMissing(string path)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
        }

        private void RewriteTextFile(string path)
        {


            if (!File.Exists(path))
            {
                File.Create(path).Dispose();
                using (StreamWriter tw = new StreamWriter(path, false))
                {//second parameter is `Append` and false means override content            
                    tw.WriteLine(textBox4.Text.ToString());
                    tw.Close();
                }

            }

            else if (File.Exists(path))
            {
                using (StreamWriter tw = new StreamWriter(path, false))
                {//second parameter is `Append` and false means override content            
                    tw.WriteLine(textBox4.Text.ToString());
                    tw.Close();
                }
            }
        }
        private int CheckTextFile(string path)
        {
            int size = 0;

            if (!File.Exists(path))
            {
                File.Create(path).Dispose();
                using (TextWriter tw = new StreamWriter(path))
                {
                    tw.WriteLine("50");
                    tw.Close();
                }
                size=50;

            }

            else if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    size =Convert.ToInt16(sr.ReadLine());
                    sr.Close();
                }
            }
            return size;
        }

        public Form5()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximizeBox = false;
            label1.AutoSize = false;
            label1.Size = new Size(220, 38);
            label2.AutoSize = false;
            label2.Size = new Size(220, 38);
            label3.AutoSize = false;
            label3.Size = new Size(220, 38);
            label4.AutoSize = false;
            label4.Size = new Size(220, 38);
            label1.Text = "Артикул";
            label2.Text = "Кількість штук";
            label3.Text = "Кількість етикет";
            label4.Text = "Зміщення етикетки";
            string path = "C:/test/";
            CreateIfMissing(path);
            string pathfile = @"C:/test/size.txt";
            textBox4.Text= CheckTextFile(pathfile).ToString();

        }


        

        bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            int a = Convert.ToInt32(textBox3.Text.ToString());
            Form1.Article = textBox1.Text.ToString();
            Form1.Quantity = textBox2.Text.ToString();
            Form1.size =Convert.ToInt16( textBox4.Text.ToString());
            for (int i=0;i<a;i++)
            {
                Form1.Print();
            }
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            string pathfile = @"C:/test/size.txt";
            RewriteTextFile(pathfile);



        }

     

        private void Form5_Load(object sender, EventArgs e)
        {

        }

       

        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


     

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void textBox2_KeyDown_1(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void textBox3_KeyDown_1(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
