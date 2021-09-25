using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace PrintContract1
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        LoanEntities8 db = new LoanEntities8();

        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtCodeBranch.Focus();
        }

        private void btnExitLogin_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnEnterLogin_Click(object sender, EventArgs e)
        {
            if (txtCodeBranch.Text.Length > 0 && txtPasswordBranch.Text.Length > 0)
            {
                var result = db.tblAccounts.Where(i => i.Account == txtCodeBranch.Text && i.Password == txtPasswordBranch.Text).ToList();
                if (result.Count == 1)
                {
                    frmMain frmmain = new frmMain();
                    frmmain.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("نام کاربری یا کلمه عبور صحیح نمی باشد", "همکار گرامی", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("لطفا موارد مشخص شده را وارد نمایید", "همکار گرامی", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                if (txtCodeBranch.Text.Length == 0)
                {
                    txtCodeBranch.BackColor = System.Drawing.Color.Red;
                }
                if (txtPasswordBranch.Text.Length == 0)
                {
                    txtPasswordBranch.BackColor = System.Drawing.Color.Red;
                }
            }
        }

        private void txtCodeBranch_TextChanged(object sender, EventArgs e)
        {
            txtCodeBranch.BackColor = System.Drawing.Color.White;
        }

        private void txtPasswordBranch_TextChanged(object sender, EventArgs e)
        {
            txtPasswordBranch.BackColor = System.Drawing.Color.White;
        }
    }
}
