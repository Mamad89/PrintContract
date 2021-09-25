using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrintContract1
{
    public partial class frmReportVam : Form
    {
        public frmReportVam()
        {
            InitializeComponent();
        }

        LoanEntities8 db = new LoanEntities8();

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var result = (from hes in db.tblHesabs where hes.HesabNumber == txtSearch.Text
                         join cos in db.tblCostomers on hes.CostomerId equals cos.Id
                         join vam in db.tblVams on hes.Id equals vam.HesabId
                         join pardakht in db.tblPardakhtAghsats on vam.Id equals pardakht.VamId
                          select new ReportsVam
                         {
                             HesabNumber = hes.HesabNumber,
                             VamType = vam.VamType,
                             FullName = cos.Name + " " + cos.Family,
                             TedadAghsat=vam.TedadAghsat
                         }).First();
        


            txtNameFamily.Text = result.FullName;
            txtVamType.Text = result.VamType;
        }
    }
}
