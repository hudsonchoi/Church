using System;
using System.ComponentModel;
using System.Collections;
using System.Windows.Forms;
using Dothan.Library.bizDonate;
using System.Drawing;
using System.Data.SqlClient;
using LandWin.Properties;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using System.Text;
using System.Threading;

namespace LandWin.Modules
{
    public partial class DonateReports : WinPart
    {

        private string _fileLog = string.Empty;
        private DonateBook _books = null;
        private DonateMemberInfo _member = null;
        private string _filename = string.Empty;


        private delegate void DataLoadDelegate();

        public DonateReports()
        {

            InitializeComponent();
            txtMemberId.Leave += new EventHandler(txtMemberID_Leave);
            txtName.Leave += new EventHandler(txtName_Leave);

            LoadDefaultData();
            this.dockPanel2.Hide();
            Reset();
            SetPage(false);
             this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(CustomDrawRowIndicator);
             this.gridView2.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(CustomDrawRowIndicator);
             this.gridView2.DoubleClick += new EventHandler(GridView2_DoubleClick);
        }

      

        #region Load  & Save Data
       
        private void LoadDefaultData()
        {
            try
            {
               
                this.donateTypeListBindingSource.DataSource = DonateTypeList.GetList(0);
                this.moneyTypesBindingSource.DataSource = MoneyTypes.GetList(false);
                this.donateUsersBindingSource.DataSource = DonateUsers.GetList();
                this.txtUser.EditValue = 0;
                this.ddlLanguage.SelectedIndex = 0;
                this.ddlMoneyType.EditValue = 0;

            }
            catch (Dothan.DataPortalException ex)
            {
                if (ex.BusinessException is SqlException)
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
                Shared.Utility.ErrorLogging("Failed to Save", ex.ToString(), "Error");

            }

        }



        private void LoadDonateBook(int id)
        {
            try
            {
                _books = DonateBook.Get(id);

                this.donateBookBindingSource.DataSource = _books;

                gridView2.RefreshData();
                SetPage(true);
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
        }
        private void LoadDonateList()
        {

            try
            {
                string from = string.Empty;
                string to = string.Empty;
                int donatetype = 0;

                if (txtDonateType.EditValue != null)
                    donatetype = (int)txtDonateType.EditValue;

                if (this.txtFrom.EditValue != null)
                    from = this.txtFrom.EditValue.ToString();

                if (this.txtTo.EditValue != null)
                    to = this.txtTo.EditValue.ToString();

                this.donateBookListBindingSource.DataSource = DonateBookList.GetList(from, to, donatetype, (int)txtUser.EditValue);
                this.gridView2.RefreshData();
                this.gridView2.BestFitColumns();
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

        }



        #endregion


        #region Print Event





        private void PrintDonateBook_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
                if (this.gridView2 == null || this.gridView2.SelectedRowsCount == 0) return;
               
              
               PrintDonateSheet(Shared.UtiltyDevExpress.GetStringSelectedRow(this.gridView2,"Id"));
        }





        #endregion

        #region  Show & Hide Display
        private void SetPage(bool enable)
        {

            this.lcgBookHeader.Enabled = enable;
            this.btnAddMember.Enabled = enable;
            this.btnRemove.Enabled = enable;

            this.lcgDonateInput.Enabled = enable;

        }


        #endregion

        #region WinPart Code

        protected internal override object GetIdValue()
        {
            return Resources.NewDonate.ToString();
        }

        #endregion

        #region  Evnet Handling

        private void btnSearch_ItemClick(object sender, EventArgs e)
        {
            LoadDonateList();
        }
        private void GridView2_DoubleClick(object sender, EventArgs e)
        {

            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            GridHitInfo info = view.CalcHitInfo(pt);
            if (info.InRow || info.InRowCell)
            {
                LoadDonateBook((int)view.GetRowCellValue(info.RowHandle, "Id"));
            }
        }


        private void Reset()
        {
            txtFrom.EditValue = DateTime.Today.AddDays(-7);
            txtTo.EditValue = DateTime.Today;
            this.txtUser.EditValue = 0;
            this.txtDonateType.EditValue = 0;
        }

        private void btnDonateInput_Click(object sender, EventArgs e)
        {
            if (_books == null)
            {
                MessageBox.Show("Please Create File before inserting Donate.");
                return;
            }

            if (_member == null)
            {
                MessageBox.Show("Please Find Donate Member.");
                txtMemberId.Focus();
                return;
            }

            decimal amount = 0;
            if(!decimal.TryParse(txtAmount.Text , out amount))
            {

                    MessageBox.Show("Please Input Amount.");
                    txtAmount.Focus();
                    return;
            }
    

            InsertDonate(_member, amount, (int)ddlMoneyType.EditValue, txtMemo.Text );
        }

     

        private void txtMemberID_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMemberId.Text))
                return;

            

            try
            {
                int memberid = int.Parse(txtMemberId.Text);
                DonateMemberList list = FindDonateMember(memberid, string.Empty, string.Empty);
                SetDonateMember(list[0]);

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
        }

        private void OpenSearchDonateMember(DonateMemberList list)
        {
            Tools.DonateMemberSearchFrm frm = new Tools.DonateMemberSearchFrm(list);
            if (frm.ShowDialog() == DialogResult.OK)
            {
              SetDonateMember(frm.SelectedMember);
            }
            else
            {
                txtMemberId.Focus();
            }
          

        }
        private void SetDonateMember(DonateMemberInfo info)
        {
            _member = info;
            txtMemberId.Text = info.MemberID.ToString();
            txtName.Text = info.Ko_name;
            txtAmount.Focus();
        }

        private void txtName_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                txtMemberId.Focus();
            }
            else
            {   
                
                if (_member != null && _member.Ko_name == txtName.Text)
                return;

                try
                {
                    DonateMemberList memberlist = null;
                    if (ddlLanguage.SelectedIndex == 0)
                    {
                        memberlist = FindDonateMember(0, txtName.Text, string.Empty);
                    }
                    else
                    {
                        memberlist = FindDonateMember(0, string.Empty, txtName.Text);
                    }

                    OpenSearchDonateMember(memberlist);
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
            }
        }


        private void BindDonateMember(DonateMemberInfo member)
        {
            txtName.Text = member.Ko_name;
            txtName.Enabled = false;
            txtMemberId.Text = member.MemberID.ToString();
            txtAmount.Focus();
            btnAddDonate.Enabled = true;

        }

        private void btnRemove_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.gridView1 == null || this.gridView1.SelectedRowsCount == 0) return;
               int  [] rows = new int[this.gridView1.SelectedRowsCount];
            for (int i = 0; i < this.gridView1.SelectedRowsCount; i++)
                rows[i] = (this.gridView1.GetRow(this.gridView1.GetSelectedRows()[i]) as Donate).ID;

            try
            {
                foreach (int row in rows)
                    Remove(row);

            }
            finally
            {
                this.donateListBindingSource.ResetBindings(true);
            }
           
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SavingDonateBook();
        }


        private void SavingDonateBook()
        {
            if (!_books.IsValid)
            {
                MessageBox.Show("Please fill out a required field");
                return;
            }
            this.gridView1.PostEditor();
            this.donateListBindingSource.EndEdit();
            this.donateListBindingSource.RaiseListChangedEvents = false;
            Tools.DonateSummaryFrm frm = new Tools.DonateSummaryFrm(_books);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                this.donateBookBindingSource.ResetBindings(true);
                SaveDonateBook();

            }
            this.donateListBindingSource.RaiseListChangedEvents = true;
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            textEdit2.Focus();//To update _books
            SavingDonateBook();
        }

        private void SelectAll()
        {
            this.gridView1.SelectAll();
        }



        private void CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            GridView view = (GridView)sender;

            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                int i = e.RowHandle + 1;
                e.Info.DisplayText = i.ToString();
                e.Info.ImageIndex = -1;

            }
            Font stringfont = e.Info.Appearance.Font;
            SizeF stringSize = new SizeF();
            stringSize = e.Graphics.MeasureString(view.RowCount.ToString(), stringfont);
            view.IndicatorWidth = (int)stringSize.Width + 10;
        }

        #endregion


        #region  Data Handling

        private void NewDonateBook()
        {
            _fileLog = string.Format("{0}-{1}.txt", (Dothan.ApplicationContext.User as Dothan.Library.Security.PTPrincipal).UserName, DateTime.Now.ToString("MMddyyyHH"));
            _books = DonateBook.New();
            _books.BeginEdit();

            BindingData();
            SetPage(true);

        }

        private void BindingData()
        {
            donateBookBindingSource.DataSource = _books;
            donateListBindingSource.DataSource = _books.DonateList;

            _books.PropertyChanged += new PropertyChangedEventHandler(DonateBook_PropertyChanged);
            _books.DonateList.ListChanged += new ListChangedEventHandler(DonateList_ListChanged);
        }

        private void InsertDonate(DonateMemberInfo info , decimal Amount , int moneytype , string memo)
        {
            try
            {
                _books.DonateList.AssignTo(info, Amount, moneytype, memo);
            }
            catch
            {
                MessageBox.Show(Resources.DonateInsertError, "Error Inserting", MessageBoxButtons.OK,
                 MessageBoxIcon.Error);
            }
            finally
            {
                ClearData();
                this.gridView1.SetFocusedRowModified();
            }

            
        }
        private void SaveDonateBook()
        {
            this.donateBookBindingSource.RaiseListChangedEvents = false;
            this.donateListBindingSource.RaiseListChangedEvents = false;
            this.donateListBindingSource.EndEdit();
            this.donateBookBindingSource.EndEdit();
            this.lcgDonateInput.Enabled = false;
            DonateBook temp = _books.Clone();
            temp.ApplyEdit();
            try
            {
                _books = temp.Save();
                LoadDonateList();
                MessageBox.Show("Successfully Saved");
                SetPage(false);
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
                this.donateBookBindingSource.RaiseListChangedEvents = true;
                this.donateListBindingSource.RaiseListChangedEvents = true;
            }
        }



        private DonateMemberList FindDonateMember(int memberid , string fullname , string enFullname)
        {
            return DonateMemberList.GetList(memberid, fullname, enFullname, string.Empty, string.Empty, string.Empty);
        }


        private void DonateList_ListChanged(object sender, ListChangedEventArgs e)
        {
            donateBookBindingSource.ResetBindings(true);
       
        }

        private void DonateBook_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(_books.IsValid)
                this.lcgDonateInput.Enabled = true;

            this.donateListBindingSource.ResetBindings(true);
            donateBookBindingSource.ResetBindings(true);
           
        }

        /// <summary>
        /// Remove Donate Details Row
        /// </summary>
        /// <param name="donateid">int</param>
        private void Remove(int donateid)
        {
            _books.DonateList.Remove(donateid);
        }



        #endregion

        #region Print 


        private void PrintDonateSheet(string list)
        {

            Shared.ReprotManager manger = new Shared.ReprotManager();
            manger.RunDonateSheet(list);
        }

        private void PrintDonateWeekly(string startdate , string enddate)
        {
            Shared.ReprotManager manager = new Shared.ReprotManager();
            manager.RunDonateWeekly(startdate, enddate);
        }

        private void PrintDonateWeeklyDetail(string startdate, string enddate)
        {
            Shared.ReprotManager manager = new LandWin.Shared.ReprotManager();
            manager.RunDonateWeeklyDetail(startdate, enddate);
        }

        #endregion
        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        private void ClearData()
        {
            _member = null;
            txtAmount.Text = "";
            txtName.Text = "";
            txtMemberId.Text = "";
            txtMemberId.Focus();
        }

        private void tb_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnDonateSheet_ItemClick(object sender, EventArgs e)
        {
            PrintDonateSheet(_books.Id.ToString());
        }

        private void btnDonateWeekly_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            PrintDonateWeekly(this.txtFrom.EditValue.ToString(), this.txtTo.EditValue.ToString());
        }
        private void btnDonateWeeklyDetail_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PrintDonateWeeklyDetail(this.txtFrom.EditValue.ToString(), this.txtTo.EditValue.ToString());
        }

      private void btnUnSelectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.gridView1.RowCount; i++)
            {
                this.gridView1.UnselectRow(i);
            }
        }

        private void btnNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_books == null)
            {
                NewDonateBook();
            }
            else
            {
                if (_books.IsNew || _books.IsDirty)
                {
                    DialogResult dialogResult = MessageBox.Show("", "Alert", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.Yes)
                    {
                        SaveDonateBook();
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        NewDonateBook();
                    }
                }
                else
                {
                    NewDonateBook();
                }
            }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            this.gridView1.SelectAll();
        }

        private void btnPrintDonateSheet_Click(object sender, EventArgs e)
        {
            PrintDonateSheet(_books.Id.ToString());
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Configuration.DonateTypeFrm frm = new Configuration.DonateTypeFrm();
            frm.ShowDialog();
            frm.Close();
            this.donateTypeListBindingSource.DataSource = DonateTypeList.GetList(0);
        }

   

    }
}
