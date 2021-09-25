using System;
using System.Windows.Forms;

namespace PrintContract1
{
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();
        }
        private void Splash_Load(object sender, EventArgs e)
        {
            this.Opacity = 1;
            for (int i = 0; i < 100; i++)
            {
                this.Opacity -= 0.01;
                Application.DoEvents();
                System.Threading.Thread.Sleep(15);
            }
            frmLogin frmlogin = new frmLogin();
            frmlogin.Show();
            this.Hide();
        }
    }
}
