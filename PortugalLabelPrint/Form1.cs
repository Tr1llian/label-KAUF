using System;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace PortugalLabelPrint
{
    public partial class Form1 : Form
    {
        public static string Position = "0";

        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximizeBox = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        static UpcLabel Label1 = new UpcLabel("hellow");
        public static string Printer= PrinterSettings.InstalledPrinters[0];
        static public string Article = " ";
        static public string Quantity = " ";
        static public int size = 0;

        public static void Print()
        {
            Label1.Print(Printer, Article, Quantity,size);
        }
        public static void PrintBlank()
        {
            Label1.PrintBlank(Printer);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Label1.SetPos(Position);
            
            var Form5 = new Form5();
            Form5.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Label1.SetPos(Position);
            Label1.PrintLogo(Printer);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            var Form2 = new Form2();
            Form2.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var Form3 = new Form3();
            Form3.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var Form4 = new Form4();
            Form4.ShowDialog();
        }
    }
}
