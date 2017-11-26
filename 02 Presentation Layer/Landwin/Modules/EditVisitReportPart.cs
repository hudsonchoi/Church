using System.Collections;
using System;
using System.Text;
using System.Windows.Forms;
using _entity = Dothan.Library;
using LandWin.Properties;


namespace LandWin.Modules
{
    public partial class EditVisitReportPart :WinPart
    {
        private _entity.bizMemberVisit.MemberVisit _recode;
        private string _visitdate ;
        private int _visittype;
        private string _recorder ;
        private ArrayList _list = new ArrayList();
        private _entity.bizMemberVisit.VisitReportList _reportlist;
        private string _div;
        private string _pastor;

        public EditVisitReportPart()
        {
            InitializeComponent();
        }

        private void BindVisitReportList()
        {
            string str = GetList();
            _reportlist = _entity.bizMemberVisit.VisitReportList.Get(str.TrimEnd(','));
            if (_reportlist.Count > 0)
            {
              
            }
        }
        private void GetNewVisitRecorder(int id)
        {
            if (_recode != null)
            {
                _recode = null;
            }
           // _recode = MemberVisit.New(id);
       

        }
        protected internal override object GetIdValue()
        {
            return Resources.Visit_Manage;
        }

        private void txtInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {

                e.Handled = true;
                SendKeys.Send("{TAB}");

            }
        }
        private void Frm_EditVisitReport_Load(object sender, EventArgs e)
        {
           
            Dothan.Library.Security.PTIdentity user = (Dothan.Library.Security.PTIdentity)Dothan.ApplicationContext.User.Identity;
            _recorder = user.Name;
            _pastor = user.UserName;
            _visitdate = DateTime.Today.ToString("MM/dd/yyyy");
        }

        private void Tb_Clear_Click(object sender, EventArgs e)
        {
            if (_recode != null)
            {
            }
        }

        private string GetList()
        {
            StringBuilder str = new StringBuilder();
            foreach (int item in _list)
            {
                str.Append(item.ToString()).Append(",");
            }
            return str.ToString();
        }


        private void Tb_VisitReportPrint_Click(object sender, EventArgs e)
        {
       /*     MainForm.Instance.Cursor = Cursors.WaitCursor;
            StringBuilder str = new StringBuilder();
            foreach (OutlookGridRow row in this.outlookGrid1.SelectedRows)
            {

                str.Append(row.Cells["ID"].Value.ToString()).Append(",");
            }
            try
            {
                ReportManager manager = new ReportManager();
                manager.RunVisitReport(str.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error Printing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            MainForm.Instance.Cursor = Cursors.Default;*/
        }

        private void Tb_VisitRportInvPrint_Click(object sender, EventArgs e)
        {
           /* MainForm.Instance.Cursor = Cursors.WaitCursor;
            StringBuilder str = new StringBuilder();
            foreach (OutlookGridRow row in this.outlookGrid1.SelectedRows)
            {

                str.Append(row.Cells["MemberId"].Value.ToString()).Append(",");
            }
            try
            {
                ReportManager manager = new ReportManager();
                manager.ReportMemberVisit(str.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error Printing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            MainForm.Instance.Cursor = Cursors.Default;*/
        }

        private void pastorTextBox_TextChanged(object sender, EventArgs e)
        {

            if (_recode != null)
                _recode.Pastor = ((TextBox)sender).Text;
        }

        private void Frm_EditVisitReport_VisibleChanged(object sender, EventArgs e)
        {
            
        }

        private void Tb_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /*
        private void outlookGrid1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                int id = int.Parse(this.outlookGrid1.Rows[e.RowIndex].Cells["ID"].Value.ToString());
                if (_recode != null)
                    Tb_Clear_Click(null, null);
                _recode = MemberVisit.Get(id);
          

            }
        }
        */
        private void bt_Clear_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void bt_Save_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //this.visitTypeListBindingSource.RaiseListChangedEvents = false;
            //this.memberVisitBindingSource.RaiseListChangedEvents = false;
            //MemberVisit temp = _recode.Clone();
            //temp.ApplyEdit();
            //try
            //{
            //    _recode = temp.Save();
            //    _recode.BeginEdit();
            //    MessageBox.Show("Saving Sucess");
            //    if (!_list.Contains(_recode.ID))
            //        _list.Add(_recode.ID);
            //    Tb_Clear_Click(null, null);
            //    BindVisitReportList();
            //}
            //catch (Dothan.DataPortalException ex)
            //{
            //    MessageBox.Show(ex.BusinessException.ToString(), "Error loading", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString(), "Error loading", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            //}
            //finally
            //{
            //    this.visitTypeListBindingSource.RaiseListChangedEvents = true;
            //    this.memberVisitBindingSource.RaiseListChangedEvents = true;
            //}

        }

        private void MemberIdTextEdit_Leave(object sender, EventArgs e)
        {
            //string memberid = ((TextBox)sender).Text;
            //if (!string.IsNullOrEmpty(memberid))
            //{
            //    try
            //    {
            //        int id = int.Parse(memberid);
            //        string fullname = Members.GetMemberName(id);

            //        _recode = MemberVisit.New(id);
            //        _recode.BeginEdit();
            //        _recode.FullName = fullname;
            //        _recode.VisitType = _visittype;
            //        _recode.Recorder = _recorder;
            //        _recode.Pastor = _pastor;
            //        _recode.Visitdate = _visitdate;
            //        this.memberVisitBindingSource.DataSource = _recode;


            //    }
            //    catch
            //    {
            //        MessageBox.Show("교인번호가 맞지 않습니다.", "Error loading", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        ((TextBox)sender).Text = "";
            //        ((TextBox)sender).Focus();
            //  //      this.ResetTextFiled(false);
            //    }
            //}
        }
    }
}
