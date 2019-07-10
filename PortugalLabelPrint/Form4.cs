using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;


namespace PortugalLabelPrint
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            label1.ForeColor = Color.White;
            label1.BackColor = Color.Transparent;
            textBox1.Text = "0";
        }
      

        private string SetX()
        {
            string X_pos;
            System.IO.StreamReader file = new System.IO.StreamReader(@"configuration.txt");
            X_pos = file.ReadLine();
            Console.WriteLine(X_pos);
            file.Close();
            return X_pos;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }


        private void button1_Click(object sender, EventArgs e)
        {

            //Console.WriteLine(textBox1.Text.ToString());
            string message = "Ви не ввели на скільки змістити етикетку. По замовчуванню зміщення відбудеться на 0 пікселів";
            string caption = "Помилка - не ввели значення";
            if (string.IsNullOrEmpty(textBox1.Text.ToString()))
            {
                StreamWriter sr = new StreamWriter("configuration.txt", false);
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;
                sr.WriteLine(textBox1.Text.ToString());
                sr.Close();
                Form1.Position = "0";
                // Displays the MessageBox.
                result = MessageBox.Show(message, caption, buttons);

                if (result == System.Windows.Forms.DialogResult.Yes)
                {

                    // Closes the parent form.

                    this.Close();

                }

            }
            else
            {
                Form1.Position = textBox1.Text.ToString();
                this.Close();
            }
        }
    }
}
