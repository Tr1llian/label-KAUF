using System;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace PortugalLabelPrint
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximizeBox = false;
            SetDefaultPrinter();
        }

        private static void SetDefaultPrinter()
        {
            PrinterSettings printerSettings = new PrinterSettings();
            try
            {
                Printer = printerSettings.PrinterName;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Printer = PrinterSettings.InstalledPrinters[0];
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        static UpcLabel Label1 = new UpcLabel("hellow");

        public static string Printer { get; set; } = PrinterSettings.InstalledPrinters[0];
        public static string Article { get; set; } = " ";
        public static string Quantity { get; set; } = " ";
        public static int Size1 { get; set; } = 0;
        public static string Batch { get; set; } = "";
        public static string Position { get; set; } = "0";

        public static void Print()
        {
            Label1.Print(Printer, Article, Quantity, Size1, Batch);
        }
        public static void PrintBlank()
        {
            Label1.PrintBlank(Printer);
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            Label1.SetPos(Position);

            var Form5 = new Form5();
            Form5.ShowDialog();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Label1.SetPos(Position);
            Label1.PrintLogo(Printer);
        }

        private void Button3_Click(object sender, EventArgs e)
        {

            var Form2 = new Form2();
            Form2.ShowDialog();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            var Form3 = new Form3();
            Form3.ShowDialog();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            var Form4 = new Form4();
            Form4.ShowDialog();
        }
    }
}
