using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Dothan.Library;


namespace LandWin.Tools
{
    public partial class NewMemberFrm : DevExpress.XtraEditors.XtraForm
    {

        private Members _member;
        private Familys _familys;
        public int ID { get { return _member.Code; } }
        public NewMemberFrm()
        {
            InitializeComponent();
            BindingLookup();
            _member = Members.New();
            _member.RegDate = DateTime.Today.ToString("MM/dd/yyyy");
            _member.Divcode = MainForm.Instance.Divcode.ToString();
            _familys = Familys.GetList(_member.Code);
            _member.BeginEdit();
            _familys.BeginEdit();
            membersBindingSource.DataSource = _member;

        }
        private void BindingLookup()
        {
            this.jobTypesListBindingSource.DataSource = JobTypesList.GetList(MainForm.Instance.Divcode.ToString(), false);
            this.sexListBindingSource.DataSource = SexList.GetList(false);
            this.marriageListBindingSource.DataSource = MarriageList.GetList(false);
            this.fellowshipsListBindingSource.DataSource = FellowshipsList.GetList(MainForm.Instance.Divcode.ToString(), false);
            this.subdivisionListBindingSource.DataSource = SubdivisionList.GetList(MainForm.Instance.Divcode.ToString(), false);
            this.statusListBindingSource.DataSource = StatusList.GetList(MainForm.Instance.Divcode.ToString(), false,1);
            this.relationshipListBindingSource.DataSource = RelationshipList.GetList();
            this.baptismListBindingSource.DataSource = BaptismList.GetList(MainForm.Instance.Divcode.ToString(), false);
            this.entryTypeListBindingSource.DataSource = EntryTypeList.GetList(MainForm.Instance.Divcode.ToString(), false);
        }
        private void bt_Close_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void bt_SaveMember_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (dxErrorProvider1.HasErrors) return;

            this.membersBindingSource.EndEdit();
            this.familysBindingSource.EndEdit();
            this.membersBindingSource.RaiseListChangedEvents = false;
            this.familysBindingSource.RaiseListChangedEvents = false;
            
            if (_familys.IsValid)
            {
                Members temp = _member.Clone();
                temp.ApplyEdit();
                try
                {
                    _member = temp.Save();
                    if (_member.Code != 0)
                    {
                        _familys.FamilycodeChange(_member.Code);
                        Familys temp1 = _familys.Clone();
                        temp1.ApplyEdit();
                        _familys = temp1.Save();
                         if (!string.IsNullOrEmpty(this.tb_ContextEdit.Text))
                         {
                             Comment commend = Comment.New(_member.Code);
                             System.Security.Principal.IPrincipal user = Dothan.ApplicationContext.User;
                             commend.Username = user.Identity.Name;
                             commend.Context = this.tb_ContextEdit.Text;
                             Comment temp2 = commend.Clone();
                             commend = temp2.Save();
                         }

                        this.DialogResult = DialogResult.OK;
                        this.Close();
                       
                    }

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
        }

  
        private void KeyPress_Enter(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

    
        private void EditDatetimeText_Leave(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.TextEdit edit = (DevExpress.XtraEditors.TextEdit)sender;
            if (Common.ValidateDatetime(edit.Text))
                SendKeys.Send("{TAB}");
            else
            {
                XtraMessageBox.Show("Invalid DataType: It is invalid. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                edit.Text = "";
            }
        }

        private void bt_AddFamily_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Family item = _familys.AddNewFamily();
            item.EntryType = _member.EntryType;
            item.Relationship = 1;
            item.Status = _member.Status;
            item.RegDate = _member.RegDate;
            item.Relationship = _familys.DefaultRelationShip();
            item.Divcode = "1";
            LandWin.Tools.NewFamilyFrm dlg = new LandWin.Tools.NewFamilyFrm(item);
            if (dlg.ShowDialog() != DialogResult.OK)
            {
                _familys.Remove(item);
            }
            this.familysBindingSource.DataSource = _familys;
            this.gridView1.RefreshData();
        }

        private void pictureEdit1_Click(object sender, EventArgs e)
        {
          Common.SelectedCalendar( RegDateTextEdit );
        }

        private void pictureEdit2_Click(object sender, EventArgs e)
        {
            Common.SelectedCalendar(BirthDayTextEdit);
        }

        private void pictureEdit3_Click(object sender, EventArgs e)
        {
            Common.SelectedCalendar(Baptism_YearTextEdit);
        }

        private void bt_RemoveFamily_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (this.gridView1.SelectedRowsCount == 0) return;

            int row = this.gridView1.GetSelectedRows()[0];

  //           _familys.Remove( (int)this.gridView1.getdatarow
          /*  foreach (OutlookGridRow row in this.outlookGrid1.SelectedRows)
            {
                _familys.Remove((int)row.Cells[0].Value);
                this.outlookGrid1.Rows.Remove(row);
            }

            */
        }
        private void GetAddressByzipCode(string str)
        {
            if (!String.IsNullOrEmpty(str))
            {

                ZipcodeListFrm dlg = new ZipcodeListFrm(str);
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    _member.City = dlg.Zipcode_Info.City;
                    _member.State = dlg.Zipcode_Info.State;
                    _member.Zipcode = str;
                }
                dlg.Dispose();
            }
            else
                MessageBox.Show(Properties.Resources.Enter_your_zipcode.ToString());
        }
        private void ZipcodeTextEdit_Leave(object sender, EventArgs e)
        {
            TextEdit edit = (TextEdit)sender;
            if (!String.IsNullOrEmpty(edit.Text) && !_member.Zipcode.Equals(edit.Text))
            {
                GetAddressByzipCode(edit.Text);
            }
        }

  


    }

}

       
       