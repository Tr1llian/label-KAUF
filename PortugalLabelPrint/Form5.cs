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
        private const string V = "C:/test/";

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
            label5.Text = "Batch/партія";
            string path = V;
            CreateIfMissing(path);
            string pathfile = @"C:/test/size.txt";
            textBox4.Text= CheckTextFile(pathfile).ToString();
            textBox1.Focus();

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
            if(textBox1.Text == string.Empty || textBox2.Text == string.Empty || textBox3.Text == string.Empty)
            {
                MessageBox.Show("Заповніть усі поля!");
                textBox1.Focus();
                return;
            }
            else if(!IsDigitsOnly(textBox1.Text) || !IsDigitsOnly(textBox2.Text))
            {
                MessageBox.Show("Артикул і кількість штук, кількість етикет мають бути лише цифрами!!!", "Увага!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int a = Convert.ToInt32(textBox3.Text.ToString());
            Form1.Article = textBox1.Text.ToString();
            Form1.Quantity = textBox2.Text.ToString();
            Form1.Size1 = Convert.ToInt16( textBox4.Text.ToString());
            Form1.Batch = textBox5.Text;

            for (int i=0;i<a;i++)
            {
                Form1.Print();
            }
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox5.Text = "";
            string pathfile = @"C:/test/size.txt";
            RewriteTextFile(pathfile);



        }

     

        private void Form5_Load(object sender, EventArgs e)
        {
        }

        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        private void TextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        private void TextBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void TextBox2_KeyDown_1(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void TextBox3_KeyDown_1(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }


        private void TextBox5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

       
    }
}
