using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using _entity = Dothan.Library;
using LandWin.Properties;

namespace LandWin
{
    public partial class MemberVisitDetailFrm : Form
    {
        private _entity.bizMemberVisit.MemberVisit _member;

        public MemberVisitDetailFrm(_entity.bizMemberVisit.MemberVisit member)
        {
            InitializeComponent();
            _member = member;

            LoadData();
         
        }

        private void LoadData()
        {
            this.typeListBindingSource.DataSource = _entity.bizCommon.TypeList.Get("visit", false);
            _member.BeginEdit();
            this.memberVisitBindingSource.DataSource = _member;
        }

        private void SaveMemberVisit()
        {;
            this.memberVisitBindingSource.RaiseListChangedEvents = false;
            this.typeListBindingSource.RaiseListChangedEvents = false;
            // do the save
            _entity.bizMemberVisit.MemberVisit temp = _member.Clone();
            temp.ApplyEdit();
            try
            {
               
                _member = temp.Save();
                this.memberVisitBindingSource.ResetBindings(false);
                MessageBox.Show(LandWin.Properties.Resources.Success_Save);
                this.DialogResult = DialogResult.OK;
            }
            catch (Dothan.DataPortalException ex)
            {
                if (ex.BusinessException is System.Data.SqlClient.SqlException)
                {
                    Shared.Utility.ErrorLogging(Properties.Resources.ErrorMessage_SqlException, ex.BusinessException.ToString(), "Error");

                }
                else
                {
                    Shared.Utility.ErrorLogging(Properties.Resources.ErrorMessage_General, ex.BusinessException.ToString(), "Error");

                }
            }
            catch (Exception ex)
            {
                Shared.Utility.ErrorLogging(Properties.Resources.ErrorMessage_General, ex.ToString(), "Error");
            }
            finally
            {
                this.memberVisitBindingSource.RaiseListChangedEvents = true;
                this.typeListBindingSource.RaiseListChangedEvents = true;
            }
        }


      
        private void bt_Close_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void VisitdateTextEdit_Click(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.TextEdit edit = (DevExpress.XtraEditors.TextEdit)sender;
            Point pt1 = edit.PointToClient(this.Location);
            Tools.CalendarFrm dlg = new Tools.CalendarFrm(edit.Text, -pt1.X, -pt1.Y + edit.Height);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                 VisitdateTextEdit.Text= dlg.SelectedDate.ToString("MM/dd/yyyy");
            }
        }

        private void bt_Save_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            this.memberVisitBindingSource.EndEdit();
            if (!_member.IsValid)
            {
                MessageBox.Show("Please fill out a required field");
                return;
            }
            System.Security.Principal.IPrincipal user = Dothan.ApplicationContext.User;
            if (_member.Recorder == ((Dothan.Library.Security.PTPrincipal)Dothan.ApplicationContext.User).UserName)
            {
                SaveMemberVisit();
            }
            else
                MessageBox.Show(Properties.Resources.No_Authorized);
        }

        private void MemberIdTextEdit_Leave(object sender, EventArgs e)
        {

        }

    }
}
