using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Dothan.Library;

namespace LandWin
{
    public partial class dlg_RptCells : Form
    {
    
        private RptCell _report;
        private RptCellMembers _member;
        public dlg_RptCells(RptCell report)
        {
            InitializeComponent();
            this.cellListBindingSource.DataSource = CellList.GetList("1");
            _report = report;
            if (_report.IsNew)
                this.tb_print.Enabled = false;
            _report.BeginEdit();
            this.rptCellBindingSource.DataSource = _report;
            if (_report.IsNew)
            {
                _member = RptCellMembers.New(_report.CellCode);
                _member.BeginEdit();
            }
            else
            {
                _member = RptCellMembers.Get(_report.Id);
                _member.BeginEdit();
            }
           
            textEdit1.Text = _member.MemberNameByRoles(1);
            textEdit2.Text = _member.MemberNameByRoles(2);
            
            this.rptCellMembersBindingSource.DataSource = _member;
        }

        private void tb_save_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.rptCellMembersBindingSource.RaiseListChangedEvents = false;
            this.rptCellBindingSource.RaiseListChangedEvents = false;
            if (_member.IsValid)
            {
                _report.Attendence = _member.CheckAttendence();
                RptCell temp = _report.Clone();
                temp.ApplyEdit();
                try
                {
                    _report = temp.Save();
                    _member.SetRegdate(_report.CellDate);
                    _member.SetReportID(_report.Id);
                    RptCellMembers temp1 = _member.Clone();
                    temp1.ApplyEdit();
                    _member = temp1.Save();
                    MessageBox.Show(LandWin.Properties.Resources.Success_Save);
                    if (!_report.IsNew)
                        this.tb_print.Enabled = true;

                }
                catch (Dothan.DataPortalException ex)
                {
                    MessageBox.Show(ex.BusinessException.ToString(),
                      "Error saving", MessageBoxButtons.OK,
                      MessageBoxIcon.Exclamation);
                }
                catch (Dothan.Validation.ValidationException ex)
                {
                    MessageBox.Show(string.Format(ex.Message.ToString(), "Member"), "Error Saving", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(),
                      "Error Saving", MessageBoxButtons.OK,
                      MessageBoxIcon.Exclamation);
                }
            }
            this.rptCellMembersBindingSource.RaiseListChangedEvents = true;
            this.rptCellBindingSource.RaiseListChangedEvents = true;
            this.Cursor = Cursors.Default;
        }

        private void tb_print_Click(object sender, EventArgs e)
        {
            if (_report.IsDirty || _member.IsDirty )
            {
                MessageBox.Show("수정사항이 업데이트 되지않았습니다. 저장하신 다음에 프린트 하시길 바랍니다.");
            }
            else
            {
                MainForm.Instance.Cursor = Cursors.WaitCursor;
                try
                {
                    ReportManager manager = new ReportManager();
                    manager.RunCellReportPrint(_report.Id.ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Error Printing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                MainForm.Instance.Cursor = Cursors.Default;
            }
        }

        private void tb_close_Click(object sender, EventArgs e)
        {
            if (_report.IsDirty || _member.IsDirty)
            {
                DialogResult result = MessageBox.Show("Do you want to close without saving data?", "Important Message", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                    this.Close();
            }
            else
            {
                this.Close();
            }
        }
        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

    

  
    }
}
