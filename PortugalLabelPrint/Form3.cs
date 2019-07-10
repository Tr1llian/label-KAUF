
using System.Drawing;
using System.Windows.Forms;

namespace PortugalLabelPrint
{
    public partial class Form3 : Form
    {
        public Form3()
        {

            InitializeComponent();
            panel1.BackColor = Color.SaddleBrown;
            linkLabel1.VisitedLinkColor = Color.Yellow;
            linkLabel1.Text = "\n Petro.Monka@bader-leather.com ";
            linkLabel1.BackColor = Color.Transparent;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            label1.BackColor = Color.SaddleBrown;
            linkLabel1.Font = new Font("Arial", 12, FontStyle.Bold);
            label1.Font = new Font("Arial", 12, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location =new Point(10,10);
            linkLabel1.Location = new Point(10, 50);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(linkLabel1);
            label1.Text = " Автор програми: Монька Петро \n  \n email :";
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel1.LinkVisited = true;
            System.Diagnostics.Process.Start("mailto:Petro.Monka@bader-leather.com");
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
