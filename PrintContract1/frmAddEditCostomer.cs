using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Globalization;
using System.Text;

namespace PrintContract1
{
    public partial class frmAddEditCostomer : Form
    {
        public frmAddEditCostomer()
        {
            InitializeComponent();
        }
        LoanEntities8 db = new LoanEntities8();

        private string GetShamsi(DateTime date)
        {
            PersianCalendar pc = new PersianCalendar();
            StringBuilder sb = new StringBuilder();
            sb.Append(pc.GetYear(date).ToString("0000"));
            sb.Append("/");
            sb.Append(pc.GetMonth(date).ToString("00"));
            sb.Append("/");
            sb.Append(pc.GetDayOfMonth(date).ToString("00"));
            return sb.ToString();
        }


        private void btnNew_Click(object sender, EventArgs e)
        {
            #region SetErrorProvider
            
            if (txtCodeMeliNewC.Text == "")
            {
                errorProvider1.SetError(txtCodeMeliNewC, "لطفا این بخش را کامل فرمایید");
                txtCodeMeliNewC.Focus();
                return;

            }
            if (txtNameNewC.Text == "")
            {
                errorProvider1.SetError(txtNameNewC, "لطفا این بخش را کامل فرمایید");
                txtNameNewC.Focus();
                return;
            }
            if (txtFamilyNewC.Text == "")
            {
                errorProvider1.SetError(txtFamilyNewC, "لطفا این بخش را کامل فرمایید");
                txtFamilyNewC.Focus();
                return;

            }
            if (txtFhaterNameNewC.Text == "")
            {
                errorProvider1.SetError(txtFhaterNameNewC, "لطفا این بخش را کامل فرمایید");
                txtFhaterNameNewC.Focus();
                return;

            }           
            if (txtNumberShenasNewC.Text == "")
            {
                errorProvider1.SetError(txtNumberShenasNewC, "لطفا این بخش را کامل فرمایید");
                txtNumberShenasNewC.Focus();
                return;
            }
            if (txtSeryalOfShenasname.Text == "")
            {
                errorProvider1.SetError(txtSeryalOfShenasname, "لطفا این بخش را کامل فرمایید");
                txtSeryalOfShenasname.Focus();
                return;
            }
            if (txtMahalSodor.Text == "")
            {
                errorProvider1.SetError(txtMahalSodor, "لطفا این بخش را کامل فرمایید");
                txtMahalSodor.Focus();
                return;
            }
            if (txtTellNewC.Text == "")
            {
                errorProvider1.SetError(txtTellNewC, "لطفا این بخش را کامل فرمایید");
                txtTellNewC.Focus();
                return;
            }
            if (txtFaxNewC.Text == "")
            {
                errorProvider1.SetError(txtFaxNewC, "لطفا این بخش را کامل فرمایید");
                txtFaxNewC.Focus();
                return;

            }
            if (txtMobileNewC.Text == "")
            {
                errorProvider1.SetError(txtMobileNewC, "لطفا این بخش را کامل فرمایید");
                txtMobileNewC.Focus();
                return;
            }
            if (txtCodePostiNewC.Text == "")
            {
                errorProvider1.SetError(txtCodePostiNewC, "لطفا این بخش را کامل فرمایید");
                txtCodePostiNewC.Focus();
                return;

            }
            if (txtEmailNewC.Text == "")
            {
                errorProvider1.SetError(txtEmailNewC, "لطفا این بخش را کامل فرمایید");
                txtEmailNewC.Focus();
                return;

            }
            if (radioButtonMan.Checked == false && radioButtonWoman.Checked == false)
            {
                errorProvider1.SetError(groupPanel4, "لطفا جنسیت را تعیین فرمایید");
                radioButtonMan.Focus();
                return;

            }
            if (txtAddressNewC.Text == "")
            {
                errorProvider1.SetError(lblAddress, "لطفا این بخش را کامل فرمایید");
                txtAddressNewC.Focus();
                return;
            }
            #endregion
            else
            {
                #region SetProperties

                if (db.tblCostomers.Where(i => i.CodeMeli == txtCodeMeliNewC.Text).Any()) 
                {
                    MessageBox.Show("این مشتری قبلا ثبت گردیده است");
                    return;
                }
                tblCostomer co = new tblCostomer()
                {
                    Name = txtNameNewC.Text,
                    Family = txtFamilyNewC.Text,
                    FatherName = txtFhaterNameNewC.Text,
                    CodeMeli = txtCodeMeliNewC.Text,
                    NumberOfShenasname = txtNumberShenasNewC.Text,
                    MahalSodour = txtMahalSodor.Text,
                    Address = txtAddressNewC.Text,
                    Tell = txtTellNewC.Text,
                    Fax = txtFaxNewC.Text,
                    Mobile = txtMobileNewC.Text,
                    CodePosti = txtCodePostiNewC.Text,
                    Email = txtEmailNewC.Text,
                    DateOfBirth=dateTimeBirth.GetText("yyy/MM/dd"),
                    SeryalOfShenasname=txtSeryalOfShenasname.Text,
                    
                };
                if (radioButtonMan.Checked == true)
                {
                    co.Jender = "مرد";
                }
                else
                {
                    co.Jender = "زن";
                }
                db.tblCostomers.Add(co);
                db.SaveChanges();
                this.Close();
                #endregion
                
            }
        }
        #region SetCleanErrorProvider
        private void txtCodeMeliNewC_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtCodeMeliNewC, string.Empty);
        }

        private void txtNameNewC_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtNameNewC, string.Empty);
        }

        private void txtFamilyNewC_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtFamilyNewC, string.Empty);
        }

        private void txtFhaterNameNewC_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtFhaterNameNewC, string.Empty);
        }

        private void txtNumberShenasNewC_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtNumberShenasNewC, string.Empty);
        }
        private void txtTellNewC_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtTellNewC, string.Empty);
        }

        private void txtFaxNewC_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtFaxNewC, string.Empty);
        }

        private void txtMobileNewC_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtMobileNewC, string.Empty);
        }

        private void txtCodePostiNewC_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtCodePostiNewC, string.Empty);
        }

        private void txtEmailNewC_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtEmailNewC, string.Empty);
        }
        
        private void txtAddressNewC_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(txtAddressNewC, string.Empty);
        }
        private void radioButtonMan_CheckedChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(groupPanel4, string.Empty);
        }

        private void radioButtonWoman_CheckedChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(groupPanel4, string.Empty);
        }
        #endregion
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
