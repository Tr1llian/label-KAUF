using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace PortugalLabelPrint
{
    public partial class Form2 : Form
    {
        int count = 0;
        Boolean check = false;

        UpcLabel Label = new UpcLabel("hellow");
        public Form2()
        {
            

            InitializeComponent();
            this.Text = "Вибір принтера";
            List<string> MyPrinter = Label.GetAllPrinterList();
            for (int i = 0; i < MyPrinter.Count(); i++)
            {
                RadioButton rdo = new RadioButton();
                rdo.Name = "RadioButton" + i;
                rdo.Text = MyPrinter[i];
                rdo.Location = new Point(0,0 + 35* i);
                System.Windows.Forms.Padding a = new Padding();
                a.Left = 30;
                a.Right = 30;
                rdo.Padding = a;
                rdo.AutoSize=false;
                rdo.Width = 305;
                rdo.Height = 30;
                rdo.Font = new Font("Arial", 12, FontStyle.Bold);
                rdo.ForeColor=Color.White;
                rdo.BackColor = Color.SaddleBrown;
                rdo.CheckedChanged += new EventHandler(this.Radio_CheckedChanged);
                panel1.Controls.Add(rdo);
                panel1.BackColor = Color.Bisque;
                count++;
            }
        }

        private void Radio_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton r = (RadioButton)sender;
            Form1.Printer = r.Text;
            check = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string message = "Ви не вибрали принтер для друку, по замовчуванню буде друк на перший принтер в списку :)";
            string caption = "Помилка - жоден принтер не вибрали";
            if (!check)
            {
                Form1.Printer = PrinterSettings.InstalledPrinters[0];
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

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
                this.Close();
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
