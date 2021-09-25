using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using JntNum2Text;
using Microsoft.Office.Interop.Word;
using System.Data.Entity;

namespace PrintContract1
{
    public partial class frmPrintTashilat : Form
    {
        public frmPrintTashilat()
        {
            InitializeComponent();
        }

        LoanEntities8 db = new LoanEntities8();

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            #region اضافه شدن به جدول وام قبل از پرینت به صورت خودکار

            try
            {
                tblVam vam = new tblVam()
                {
                    VamType = cBoxVamType.Text.ToString(),
                    MablaghVam = Convert.ToInt64(numMablagh.Value),
                    PishDaryaft = Convert.ToInt64(numPiasDaryaft.Value),
                    BaqhiMande = Convert.ToInt64(numPiasDaryaft.Value),
                    NumberContract = txtNumberConract.Text,
                    NerkhSod = Convert.ToInt16(numNerkhSod.Value),
                    Eltezam = Convert.ToInt16(numEltezam.Value),
                    TedadAghsat = Convert.ToInt16(numTedadAghsat.Value),
                    DateOfStart = DateTimeStart.GetText("yyy/mm/dd"),
                    DateOfEnd = DateTimeEnd.GetText("yyyy/mm/dd"),
                    MablaghGhest = Convert.ToInt64(numMablaghGhest.Value),
                    MablaghAsloFara = Convert.ToInt64(numAsloFara.Value)
                };
                //اختصاص آیدی شماره حساب به وام
                var resullt = db.tblHesabs.Where(i => i.HesabNumber == txtHesabM.Text).First();
                dataGridView1.DataSource = resullt;
                vam.HesabId = resullt.Id;


                db.tblVams.Add(vam);
                db.SaveChanges();
            }
            catch
            {
                
            }            
            #endregion
            #region کدهای مربوط به بخش چاپ صفحه ورد     
            var application = new Microsoft.Office.Interop.Word.Application();
            var document = new Document();
            document = application.Documents.Add(Template: @"E:\Programing\Project\PrintContract1\Word\Morabehe 1 Zamen\Morabehe.docx");
            application.Visible = true;
            foreach (Field field in document.Fields)
            {
                try
                {
                    #region بخش نوع وام و تاریخ
                    if (field.Code.Text.Contains("نوع وام"))
                    {
                        field.Select();
                        application.Selection.TypeText(cBoxVamType.Text);
                    }
                    if (field.Code.Text.Contains("تاریخ روز"))
                    {
                        field.Select();
                        application.Selection.TypeText(lblDate.Text);
                    }
                    #endregion
                    #region بخش مشخصات شعبه
                    if (field.Code.Text.Contains("نام ش"))
                    {
                        field.Select();
                        application.Selection.TypeText(txtNameBr.Text);
                    }
                    else if (field.Code.Text.Contains("کد ش"))
                    {
                        field.Select();
                        application.Selection.TypeText(txtCodeBr.Text);
                    }
                    else if (field.Code.Text.Contains("آدرس ش"))
                    {
                        field.Select();
                        application.Selection.TypeText(txtAddressBr.Text);
                    }
                    #endregion
                    #region بخش مشخصات متقاضی
                    else if (field.Code.Text.Contains("نام م"))
                    {
                        field.Select();
                        application.Selection.TypeText(txtNameM.Text);
                    }
                    else if (field.Code.Text.Contains("نام خانوادگی م"))
                    {
                        field.Select();
                        application.Selection.TypeText(txtFamilyM.Text);
                    }
                    else if (field.Code.Text.Contains("نام پدر م"))
                    {
                        field.Select();
                        application.Selection.TypeText(txtFhaterNameM.Text);
                    }
                    else if (field.Code.Text.Contains("تاریخ تولد م"))
                    {
                        field.Select();
                        application.Selection.TypeText(txtTimeBirthM.Text);
                    }
                    else if (field.Code.Text.Contains("ش ش م"))
                    {
                        field.Select();
                        application.Selection.TypeText(txtNumberShenasM.Text);
                    }
                    else if (field.Code.Text.Contains("محل صدور م"))
                    {
                        field.Select();
                        application.Selection.TypeText(txtMahaleSodourM.Text);
                    }
                    else if (field.Code.Text.Contains("س ش م"))
                    {
                        field.Select();
                        application.Selection.TypeText(txtSeryalOfShenasnameM.Text);
                    }
                    else if (field.Code.Text.Contains("کد ملی م"))
                    {
                        field.Select();
                        application.Selection.TypeText(txtCodeMeliM.Text);
                    }
                    else if (field.Code.Text.Contains("کد پستی م"))
                    {
                        field.Select();
                        application.Selection.TypeText(txtCodePostiM.Text);
                    }
                    else if (field.Code.Text.Contains("آدرس م"))
                    {
                        field.Select();
                        application.Selection.TypeText(txtAddressM.Text);
                    }
                    else if (field.Code.Text.Contains("تلفن ثابت م"))
                    {
                        field.Select();
                        application.Selection.TypeText(txtTellM.Text);
                    }
                    else if (field.Code.Text.Contains("موبایل م"))
                    {
                        field.Select();
                        application.Selection.TypeText(txtMobileM.Text);
                    }
                    else if (field.Code.Text.Contains("email M"))
                    {
                        field.Select();
                        application.Selection.TypeText(txtEmailM.Text);
                    }
                    #endregion
                    #region بخش مشخصات ضامن اول
                    else if (field.Code.Text.Contains("نام ض"))
                    {
                        field.Select();
                        application.Selection.TypeText(txtNameZ.Text);
                    }
                    else if (field.Code.Text.Contains("نام خانوادگی ض"))
                    {
                        field.Select();
                        application.Selection.TypeText(txtFamilyZ.Text);
                    }
                    else if (field.Code.Text.Contains("نام پدر ض"))
                    {
                        field.Select();
                        application.Selection.TypeText(txtFhaterNameZ.Text);
                    }
                    else if (field.Code.Text.Contains("تاریخ تولد ض"))
                    {
                        field.Select();
                        application.Selection.TypeText(txtTimeBirthZ.Text);
                    }
                    else if (field.Code.Text.Contains("ش ش ض"))
                    {
                        field.Select();
                        application.Selection.TypeText(txtNumberShenasZ.Text);
                    }
                    else if (field.Code.Text.Contains("محل صدور ض"))
                    {
                        field.Select();
                        application.Selection.TypeText(txtMahaleSodourZ.Text);
                    }
                    else if (field.Code.Text.Contains("س ش ض"))
                    {
                        field.Select();
                        application.Selection.TypeText(txtSeryalOfShenasnameZ.Text);
                    }
                    else if (field.Code.Text.Contains("کد ملی ض"))
                    {
                        field.Select();
                        application.Selection.TypeText(txtCodeMeliZ.Text);
                    }
                    else if (field.Code.Text.Contains("کد پستی ض"))
                    {
                        field.Select();
                        application.Selection.TypeText(txtCodePostiZ.Text);
                    }
                    else if (field.Code.Text.Contains("آدرس ض"))
                    {
                        field.Select();
                        application.Selection.TypeText(txtAddressZ.Text);
                    }
                    else if (field.Code.Text.Contains("تلفن ثابت ض"))
                    {
                        field.Select();
                        application.Selection.TypeText(txtTellZ.Text);
                    }
                    else if (field.Code.Text.Contains("موبایل ض"))
                    {
                        field.Select();
                        application.Selection.TypeText(txtMobileZ.Text);
                    }
                    else if (field.Code.Text.Contains("email Z"))
                    {
                        field.Select();
                        application.Selection.TypeText(txtEmailZ.Text);
                    }
                    #endregion
                    #region بخش مبلغ وام 
                    if (field.Code.Text.Contains("مبلغ وام"))
                    {
                        field.Select();
                        application.Selection.TypeText(numMablagh.Text);
                    }
                    if (field.Code.Text.Contains("مبلغ وام به حروف"))
                    {
                        field.Select();
                        application.Selection.TypeText(txtMablaghHorof.Text);
                    }
                    #endregion
                    document.SaveAs(FileName: @"E:\Programing\Project\PrintContract1\ContractSave\Morabehe\" + (txtNameM.Text + " " + txtFamilyM.Text) + ".Docx");
                }
                catch
                {

                }
            }
        }
        #endregion
        private void btnBrSearchB_Click(object sender, EventArgs e)
        {
            try
            {
                if ((txtCodeBr.Text.Trim()).Length == 0)
                {
                    MessageBox.Show("لطفا کد شعبه را وارد نمایید", "همکار گرامی");
                    txtCodeBr.Focus();
                    return;
                }
                else
                {
                    var result = db.tblBranches.Where(i => i.BrCode == txtCodeBr.Text).First();
                    txtNameBr.Text = result.BrName;
                    txtAddressBr.Text = result.BrAddress;
                }
                   
            }
            catch
            {
                MessageBox.Show("کد شعبه صحیح نمی باشد", "همکار گرامی");
                    foreach (Control c in tabPage1.Controls)
                    {
                        if (c is TextBox)
                        {
                            c.ResetText();
                            txtCodeBr.Focus();
                        }
                    }
            }

        }

        private void btnSearchM_Click(object sender, EventArgs e)
        {
            try
            {
                if ((txtHesabM.Text.Trim()).Length == 0)
                {
                    MessageBox.Show("لطفا شماره حساب را وارد نمایید", "همکار گرامی");
                    txtHesabM.Focus();
                    return;
                }
                else
                {                    
                    var result = db.tblHesabs.Where(i=>i.HesabNumber==txtHesabM.Text).Join(db.tblCostomers, hes => hes.CostomerId, cost => cost.Id, (hes, cos) => new
                    {
                        Hesab = hes.HesabNumber,
                        HesabType = hes.HesabType,
                        CodeMeli = cos.CodeMeli,
                        Name = cos.Name,
                        Family = cos.Family,
                        FatherName = cos.FatherName,
                        DateOfBirth = cos.DateOfBirth,
                        NumberOfShenasname = cos.NumberOfShenasname,
                        SeryalOfShenasname = cos.SeryalOfShenasname,
                        MahalSodour = cos.MahalSodour,
                        Tell = cos.Tell,
                        Fax = cos.Fax,
                        Mobile = cos.Mobile,
                        CodePosti = cos.CodePosti,
                        Email = cos.Email,
                        Jender = cos.Jender,
                        Address = cos.Address
                    }).First();


                    txtHesabTypeM.Text = result.HesabType;
                    txtCodeMeliM.Text = result.CodeMeli;
                    txtNameM.Text = result.Name;
                    txtFamilyM.Text = result.Family;
                    txtFhaterNameM.Text = result.FatherName;
                    txtTimeBirthM.Text = result.DateOfBirth;
                    txtNumberShenasM.Text = result.NumberOfShenasname;
                    txtSeryalOfShenasnameM.Text = result.SeryalOfShenasname;
                    txtMahaleSodourM.Text = result.MahalSodour;
                    txtTellM.Text = result.Tell;
                    txtFaxM.Text = result.Fax;
                    txtMobileM.Text = result.Mobile;
                    txtCodePostiM.Text = result.CodePosti;
                    txtEmailM.Text = result.Email;
                    txtJenderM.Text = result.Jender;
                    txtAddressM.Text = result.Address;
                    txtHesabV.Text = result.Hesab;
                }

            }
            catch
            {
                MessageBox.Show("حسابی با این شماره یافت نشد");
                foreach (Control c in tabPage2.Controls)
                {
                    if (c is TextBox)
                    {
                        c.ResetText();
                        txtHesabM.Focus();
                    }
                }
            }
        }

        private void btnSearchZ_Click(object sender, EventArgs e)
        {
            try
            {
                if ((txtHesabZ.Text.Trim()).Length == 0)
                {
                    MessageBox.Show("لطفا شماره حساب را وارد نمایید", "همکار گرامی");
                    txtHesabZ.Focus();
                    return;
                }
                else
                {
                    var result = db.tblHesabs.Where(i => i.HesabNumber == txtHesabZ.Text).Join(db.tblCostomers, hes => hes.CostomerId, cost => cost.Id, (hes, cos) => new
                    {
                        HesabType = hes.HesabType,
                        CodeMeli = cos.CodeMeli,
                        Name = cos.Name,
                        Family = cos.Family,
                        FatherName = cos.FatherName,
                        DateOfBirth = cos.DateOfBirth,
                        NumberOfShenasname = cos.NumberOfShenasname,
                        SeryalOfShenasname = cos.SeryalOfShenasname,
                        MahalSodour = cos.MahalSodour,
                        Tell = cos.Tell,
                        Fax = cos.Fax,
                        Mobile = cos.Mobile,
                        CodePosti = cos.CodePosti,
                        Email = cos.Email,
                        Jender = cos.Jender,
                        Address = cos.Address
                    }).First();


                    txtHesabTypeZ.Text = result.HesabType;
                    txtCodeMeliZ.Text = result.CodeMeli;
                    txtNameZ.Text = result.Name;
                    txtFamilyZ.Text = result.Family;
                    txtFhaterNameZ.Text = result.FatherName;
                    txtTimeBirthZ.Text = result.DateOfBirth;
                    txtNumberShenasZ.Text = result.NumberOfShenasname;
                    txtSeryalOfShenasnameZ.Text = result.SeryalOfShenasname;
                    txtMahaleSodourZ.Text = result.MahalSodour;
                    txtTellZ.Text = result.Tell;
                    txtFaxZ.Text = result.Fax;
                    txtMobileZ.Text = result.Mobile;
                    txtCodePostiZ.Text = result.CodePosti;
                    txtEmailZ.Text = result.Email;
                    txtJenderZ.Text = result.Jender;
                    txtAddressZ.Text = result.Address;

                }

            }
            catch
            {
                MessageBox.Show("حسابی با این شماره یافت نشد");
                foreach (Control c in tabPage3.Controls)
                {
                    if (c is TextBox)
                    {
                        c.ResetText();
                        txtHesabZ.Focus();
                    }
                }
            }
        }

        #region عدد به حروف کردن مبالغ
        
        private void numMablagh_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                //گرفتن اطلاعات ورودی برای مبلغ هر قسط 
                double MablaghVam = (double)numMablagh.Value;
                double NerkhSod = (double)(numNerkhSod.Value / 100);
                double TedadAghsat = (double)(numTedadAghsat.Value);
                double PishDaryaft = (double)numPiasDaryaft.Value;
                decimal MablaghGhest = 0M;
                double payment = (MablaghVam - PishDaryaft) * (Math.Pow((1 + NerkhSod / 12), TedadAghsat) * NerkhSod) / (12 * (Math.Pow((1 + NerkhSod / 12), TedadAghsat) - 1));
                MablaghGhest = (Int64)payment;
                //نمایش خروجی برای مبلغ هر قسط
                numMablaghGhest.Value = MablaghGhest;
                //گرفتن اطلاعات ورودی برای مبلغ اصل و فرع
                numAsloFara.Value = (numMablaghGhest.Value * numTedadAghsat.Value);
            }
            catch
            {

            }
            txtMablaghHorof.Text = Num2Text.ToFarsi(Convert.ToInt64(numMablagh.Value));
        }

        private void numPiasDaryaft_ValueChanged(object sender, EventArgs e)
        {
            txtPishdaryaftHorof.Text = Num2Text.ToFarsi(Convert.ToInt64(numPiasDaryaft.Value));            
        }

        private void numBaqhiMande_ValueChanged(object sender, EventArgs e)
        {            
            txtBaghiMandeHorof.Text = Num2Text.ToFarsi(Convert.ToInt64(numBaghiMande.Value));
        }
        #endregion

        #region تعیین میزان درصد وام در زمان انتخاب نوع وام
        private void cBoxVamType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cBoxVamType.Text=="مرابحه")
            {
                numNerkhSod.Value = 18;
            }
            else
            {
                numNerkhSod.Value = 4;
            }
        }
        #endregion

        #region محاسبه مبلغ اقساط
        private void numTedadAghsat_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                double MablaghVam = (double)numMablagh.Value;
                double NerkhSod = (double)(numNerkhSod.Value / 100);
                double TedadAghsat = (double)(numTedadAghsat.Value);
                double PishDaryaft = (double)numPiasDaryaft.Value;
                decimal MablaghGhest = 0M;
                double payment = (MablaghVam - PishDaryaft) * (Math.Pow((1 + NerkhSod / 12), TedadAghsat) * NerkhSod) / (12 * (Math.Pow((1 + NerkhSod / 12), TedadAghsat) - 1));
                MablaghGhest = (Int64)payment;

                numMablaghGhest.Value = MablaghGhest;
                //گرفتن اطلاعات ورودی برای مبلغ اصل و فرع
                numAsloFara.Value = (numMablaghGhest.Value * numTedadAghsat.Value);
            }
            catch 
            {

            }
            DateTime mydate = DateTime.Now.AddMonths(1).AddDays(1);
            int a = Convert.ToInt16(numTedadAghsat.Value);
            DateTimeEnd.Value = mydate.AddMonths(a);
        }
        #endregion

        private void dateTimeStart_Click(object sender, EventArgs e)
        {
            DateTime mydate = DateTime.Now.AddMonths(1).AddDays(1);
            int a = Convert.ToInt16(numTedadAghsat.Value);
            DateTimeEnd.Value = mydate.AddMonths(a);
        }

        private void frmPrintTashilat_Load(object sender, EventArgs e)
        {
            DateTime mydate = DateTime.Now.AddMonths(1);
            DateTimeStart.Value = mydate;
            System.Globalization.PersianCalendar p = new System.Globalization.PersianCalendar();
            lblDate.Text = p.GetYear(DateTime.Now).ToString() + "/" + p.GetMonth(DateTime.Now).ToString("0#") + "/" + p.GetDayOfMonth(DateTime.Now).ToString("0#");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //اتصال چهار جدول حساب ، مشتری ، وام ، پرداخت اقساط
            
            var result = from hes in db.tblHesabs.Where(hes => hes.HesabNumber == txtSearch.Text)                         
                         join cos in db.tblCostomers on hes.CostomerId equals cos.Id
                         join vam in db.tblVams on hes.Id equals vam.HesabId
                         join pardakht in db.tblPardakhtAghsats on vam.Id equals pardakht.VamId
                         select new
                         {
                             hes.HesabNumber,
                             FullName = cos.Name + " " + cos.Family,
                             vam.NumberContract,
                             pardakht.ShomareGhest,
                             pardakht.DateOfPardakht
                         };
            dataGridView1.DataSource = result.ToList();
            dataGridView1.Columns[0].HeaderText = "شماره حساب";
            dataGridView1.Columns[1].HeaderText = "نام و نام خانوادگی";
            dataGridView1.Columns[2].HeaderText = "شماره قرارداد";
            dataGridView1.Columns[3].HeaderText = "شماره قسط";
            dataGridView1.Columns[4].HeaderText = "تاریخ پرداخت";
        }
    }
}
