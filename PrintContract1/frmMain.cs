using System;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;

namespace PrintContract1
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {            
            System.Globalization.PersianCalendar p = new System.Globalization.PersianCalendar();
            lblDate.Text = p.GetYear(DateTime.Now).ToString() + "/" + p.GetMonth(DateTime.Now).ToString("0#") + "/" + p.GetDayOfMonth(DateTime.Now).ToString("0#");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.Hour.ToString("0#");
            lblTime.Text += " : ";
            lblTime.Text += DateTime.Now.Minute.ToString("0#");
            lblTime.Text += " : ";
            lblTime.Text += DateTime.Now.Second.ToString("0#");
        }

        private void خروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("آیا مایل به خروج از برنامه هستید؟", "همکار گرامی" , MessageBoxButtons.YesNo , MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void تسهیلاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmPrintTashilat().ShowDialog();
        }

        private void واریزبرداشتToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Opacity = 1;
            while (this.Opacity > 0)
            {
                this.Opacity -= 0.01;
                Thread.Sleep(5);
            }
        }

        private void حقیقیToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmAddEditCostomer().ShowDialog();
        }

        private void وامهاToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmReportVam().ShowDialog();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("www.tejaratbank.ir");
        }

        private void خدماتغیرحضوریToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://my.tejaratbank.ir/web/ns/mainpage?execution=e1s1");
        }

        private void پروفایلکارکنانToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://newprofile.tejaratbank.ir/hr/f?p=101:LOGIN_DESKTOP:16202040132863:::::");
        }

        private void پروفایلکارکنانبازنشستهToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://newprofileb.tejaratbank.ir/hr/f?p=105:LOGIN_DESKTOP:6809208844929:::::");
        }
    }
}
