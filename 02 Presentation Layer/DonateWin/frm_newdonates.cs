using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Dothan.Library;
using Dothan.Library.bizDonate;
using DonateWin.Properties;
using System.Collections;
using System.IO;
using System.Data.SqlClient;
using System.Threading;
using System.Configuration;
using System.Net.Sockets;
using DevExpress.XtraGrid.Menu;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Utils.Menu;


namespace DonateWin
{
    public partial class frm_newdonates : WinPart
    {
        private string _fileLog = string.Empty;
        private DonateBook _books = null;
        private DonateMemberInfo _member = null;
        private string _filename = string.Empty;
      

        public frm_newdonates()
        {

            InitializeComponent();
            txtMemberId.Leave += new EventHandler(txtMemberID_Leave);
            txtName.Leave += new EventHandler(txtName_Leave);
          

 
            BindingLookUpData();

            SetPage(false);
            SetListViewColumn();
             CheckUnSavedFile();
        }

  
        /// <summary>
        /// Check unsaved donate log
        /// </summary>
        private void CheckUnSavedFile()
        {
            string[] fileEntries = Util.GetUnSavedFile();
            if (fileEntries.Length != 0)
            {
                DialogResult dlg = MessageBox.Show(Resources.UnsavedFile, "Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dlg == DialogResult.Yes)
                {
                    btnNew2.Enabled = false;
                    OpenFileListForm();

                }
            }
        }

        private void OpenFileListForm()
        {
            frmFileList frm = new frmFileList();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                ToLoadUnSavedBook(frm.SelectedFile);
            }
        }
        private void BindingLookUpData()
        {
            try
            {
                this.donateTypeListBindingSource.DataSource = DonateTypeList.GetList(0);
                this.moneyTypesBindingSource.DataSource = MoneyTypes.GetList(false);
                this.ddlLanguage.SelectedIndex = 0;
                this.ddlMoneyType.EditValue = 0;
            }
            catch (Dothan.DataPortalException ex)
            {
                if (ex.BusinessException is SqlException)
                {
                    Util.ErrorLogging(Resources.SqlError, ex.BusinessException.ToString(), "Error");
                }
                else
                {
                    Util.ErrorLogging("An unexpected error occured. Please Contact a administrator", ex.BusinessException.ToString(), "Error");
                }
            }
            catch (Exception ex)
            {
                Util.ErrorLogging("An unexpected error occured. Please Contact a administrator", ex.ToString(), "Error");
            }
         }
        private void SetPage(bool enable)
        {

            this.lcgBookHeader.Enabled = enable;
            this.btnAddMember.Enabled = enable;
          
            this.lcgDonateInput.Enabled = enable;
            this.dataGridView1.Enabled = enable;
            
        }

        #region WinPart Code

        protected internal override object GetIdValue()
        {
            return Resources.NewDonate.ToString();
        }

        #endregion

        #region  Evnet Handling

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
    

            InsertDonate(_member, amount, (int)ddlMoneyType.EditValue , txtMemo.Text);
        }

     

        private void txtMemberID_Leave(object sender, EventArgs e)
        {
            
            if (string.IsNullOrEmpty(txtMemberId.Text))
                return;

            this.Cursor = Cursors.WaitCursor;
            try
            {
                int memberid = int.Parse(txtMemberId.Text);
                DonateMemberList list = FindDonateMember(memberid, string.Empty, string.Empty);
                if (list.Count == 0)
                {
                    MessageBox.Show(Properties.Resources.Invalid_Memberid);
                    txtMemberId.Text = "";
                    return;
                }
                SetDonateMember(list[0]);

            }
            catch (Dothan.DataPortalException ex)
            {
                if (ex.BusinessException is SqlException)
                {
                    Util.ErrorLogging(Resources.SqlError, ex.BusinessException.ToString(), "Error");

                }
                else
                {
                    Util.ErrorLogging("An unexpected error occured. Please Contact a administrator", ex.BusinessException.ToString(), "Error");
                }
                txtMemberId.Text = "";
            }
            catch (Exception ex)
            {
                txtMemberId.Text = "";
                if (ex is InvalidOperationException)
                {

                    MessageBox.Show(Resources.Invalid_Name, "Error");
                }
                else
                {
                    Util.ErrorLogging("An unexpected error occured. Please Contact a administrator", ex.ToString(), "Error");
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
          
        }

        private void OpenSearchDonateMember(DonateMemberList list)
        {
            frmSearchMember frm = new frmSearchMember(list);
            if (frm.ShowDialog() == DialogResult.OK)
            {
              SetDonateMember(frm.SelectedMember);
            }
            else
            {
                txtName.Text = "";
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
                    txtName.Text = "";
                    if (ex.BusinessException is SqlException)
                    {
                        Util.ErrorLogging(Resources.SqlError, ex.BusinessException.ToString(), "Error");

                    }
                    else
                    {
                        Util.ErrorLogging("An unexpected error occured. Please Contact a administrator", ex.BusinessException.ToString(), "Error");
                    }
                }
                catch (Exception ex)
                {
                    txtName.Text = "";
                    if (ex is InvalidOperationException)
                    {

                        MessageBox.Show(Resources.Invalid_Name, "Error");
                        OpenSearchDonateMember(null);
                    }
                    else
                    {
                        Util.ErrorLogging(Resources.Error_Message, ex.ToString(), "Error");
                    }
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
            if (this.dataGridView1.SelectedRows.Count > 0)
            {
                int donateid = int.Parse(this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                _books.DonateList.Remove(donateid);
            }
           
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!_books.IsValid)
            {
                MessageBox.Show("Please fill out a required field");
                return;
            }
            this.donateListBindingSource.EndEdit();
            this.donateListBindingSource.RaiseListChangedEvents = false;
            FrmCash dlg = new FrmCash(_books.Clone());
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                this.donateBookBindingSource.ResetBindings(true);
                _books = dlg.Book;
                SaveDonateBook();
                btnNew2.Enabled = true;

            }
            
            this.donateListBindingSource.RaiseListChangedEvents = true;
           
        }

        private void SelectAll()
        {
            this.dataGridView1.SelectAll();
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
            dataGridView1.DataSource = this.donateListBindingSource;
            donateBookBindingSource.DataSource = _books;
            donateListBindingSource.DataSource = _books.DonateList;

            btnRemove.Enabled = _books.IsNew ;
            SetDonateEvent(_books);
        }

        private void SetDonateEvent(DonateBook book)
        {

            book.PropertyChanged += new PropertyChangedEventHandler(DonateBook_PropertyChanged);
            book.DonateList.ListChanged += new ListChangedEventHandler(DonateList_ListChanged);
        }
        private void InsertDonate(DonateMemberInfo info , decimal Amount , int moneytype, string memo )
        {
            try
            {
                _books.DonateList.AssignTo(info, Amount, moneytype ,memo);
            }
            catch
            {
                MessageBox.Show(Resources.DonateInsertError, "Error Inserting", MessageBoxButtons.OK,
                 MessageBoxIcon.Error);
            }
            finally
            {
                ClearData();
                this.dataGridView1.FirstDisplayedScrollingRowIndex = _books.DonateList.Count - 1;
            }

            
        }
        private void SaveDonateBook()
        {
            
            this.donateBookBindingSource.RaiseListChangedEvents = false;
            this.donateListBindingSource.RaiseListChangedEvents = false;
            this.donateListBindingSource.EndEdit();
            this.donateBookBindingSource.EndEdit();


            if (!_books.IsValid)
            {
                MessageBox.Show("This is not valid");
                return;
            }
            this.lcgDonateInput.Enabled = false;
            DonateBook temp = _books.Clone();
            temp.ApplyEdit();
            try
            {
                _books = temp.Save();
                MessageBox.Show("Successfully Saved");
                RemoveLog();
                InsertListview(_books);
                _books = null;
                this.dataGridView1.DataSource = null;
                this.donateListBindingSource.Clear() ;
                SetPage(false);
            }
            catch (Dothan.DataPortalException ex)
            {
                if (ex.BusinessException is SqlException)
                {
                    Util.ErrorLogging(Resources.SqlError, ex.BusinessException.ToString(), "Error");

                }
                else
                {
                    Util.ErrorLogging("An unexpected error occured. Please Contact a administrator", ex.BusinessException.ToString(), "Error");
                }
            }
            catch (Exception ex)
            {
                Util.ErrorLogging("An unexpected error occured. Please Contact a administrator", ex.ToString(), "Error");

            }
            finally
            {
                this.donateBookBindingSource.RaiseListChangedEvents = true;
                this.donateListBindingSource.RaiseListChangedEvents = true;

                if(_books != null )
                    this.lcgDonateInput.Enabled = true;
            }
        }



        private DonateMemberList FindDonateMember(int memberid , string fullname , string enFullname)
        {
            return DonateMemberList.GetList(memberid, fullname, enFullname, string.Empty, string.Empty, string.Empty);
        }


        private void DonateList_ListChanged(object sender, ListChangedEventArgs e)
        {
            donateBookBindingSource.ResetBindings(true);
            SaveLog();
        }

        private void DonateBook_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(_books.IsValid)
                this.lcgDonateInput.Enabled = true;

            this.donateListBindingSource.ResetBindings(true);
            donateBookBindingSource.ResetBindings(true);
            SaveLog();
        }

        /// <summary>
        /// Remove Donate Details Row
        /// </summary>
        /// <param name="donateid">int</param>
        private void Remove(int donateid)
        {
            _books.DonateList.Remove(donateid);
        }


        /// <summary>
        /// Logging Current Data by Searizable Object Binary
        /// </summary>
        private void SaveLog()
        {
            Util.SerializableObject<DonateBook>(_books, _fileLog.ToString());
        }
        private void RemoveLog()
        {
            Util.DeleteLog(_fileLog);
        }

        #endregion

        #region ListView Handling

        private void SetListViewColumn()
        {
            this.listView1.Columns.Add("No", 50, HorizontalAlignment.Left);
            this.listView1.Columns.Add("Donate Type", 150, HorizontalAlignment.Left);
            this.listView1.Columns.Add("Total", 50, HorizontalAlignment.Left);
            this.listView1.View = View.Details;
        }
        
        private void InsertListview(DonateBook book)
        {
            listView1.BeginUpdate();
            ListViewItem listItem = new ListViewItem(book.Id.ToString());
            if (!listView1.Items.ContainsKey(listItem.Name))
            {
                listItem.Name = book.Id.ToString();
                DonateTypeList list = this.donateTypeListBindingSource.List as DonateTypeList;
                listItem.SubItems.Add(list.Value(book.DonateType));
                listItem.SubItems.Add(book.Amount.ToString());
                listItem.SubItems.Add(book.RegDate);
                listView1.Items.Add(listItem);
            }
            listView1.EndUpdate();
        }


        private void  DonateBook_LoadClick(object sender, EventArgs e)
        {
            _books = DonateBook.Get(Convert.ToInt32(this.listView1.SelectedItems[0].SubItems[0].Text));
            Util.DeleteLog(_fileLog);
            _fileLog = string.Format("{0}-{1}.txt", (Dothan.ApplicationContext.User as Dothan.Library.Security.PTPrincipal).UserName, _books.Id);
            BindingData();
            SetPage(true);

            this.listView1.Items.Remove(this.listView1.SelectedItems[0]);
        }
        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_books.IsDirty || _books.IsNew)
            {
                MessageBox.Show("Please Save a current list before printing");
                return;
            }
            try
            {
                this.Cursor = Cursors.WaitCursor;
                FrmDonateSheetManger manager = new FrmDonateSheetManger();

                manager.RunDonateSheet(_books.Id.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error Printing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
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
            txtMemo.Text = "";
        }

        private void tb_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }



      private void btnUnSelectAll_Click(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
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
                    DialogResult dialogResult = MessageBox.Show(Resources.Alert_Save, "Alert", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
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
            btnNew2.Enabled = false;
        }


        private void ToLoadUnSavedBook(string filename)
        {
            _fileLog = Path.GetFileName(filename); 
            DonateBook book = Util.DeSerializeObject<DonateBook>(filename);
            if (book.Createby != (Dothan.ApplicationContext.User as Dothan.Library.Security.PTPrincipal).UserName || Dothan.ApplicationContext.User.IsInRole("DonateAdmin"))
            {
                _books = book;
                BindingData();
                SetPage(true);
            }
            else
                MessageBox.Show("User does not authorized to load this data. Pleas Contact Administrator");

        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            this.dataGridView1.SelectAll();
        }

        private void btnLoadUnSavedFile_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CheckUnSavedFile();
        }

        private void donateListDataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            string strRowNumber = (e.RowIndex + 1).ToString();

            //prepend leading zeros to the string if necessary to improve
            //appearance. For example, if there are ten rows in the grid,
            //row seven will be numbered as "07" instead of "7". Similarly, if 
            //there are 100 rows in the grid, row seven will be numbered as "007".
            while (strRowNumber.Length < this.dataGridView1.RowCount.ToString().Length) strRowNumber = "0" + strRowNumber;

            //determine the display size of the row number string using
            //the DataGridView's current font.
            SizeF size = e.Graphics.MeasureString(strRowNumber, this.Font);

            //adjust the width of the column that contains the row header cells 
            //if necessary
            if (this.dataGridView1.RowHeadersWidth < (int)(size.Width + 20)) this.dataGridView1.RowHeadersWidth = (int)(size.Width + 20);

            //this brush will be used to draw the row number string on the
            //row header cell using the system's current ControlText color
            Brush b = SystemBrushes.ControlText;

            //draw the row number string on the current row header cell using
            //the brush defined above and the DataGridView's default font
            e.Graphics.DrawString(strRowNumber, this.Font, b, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));



        }

        private void ddlLanguage_Leave(object sender, EventArgs e)
        {
            if (ddlLanguage.SelectedText.Trim() == "")
                ddlLanguage.SelectedIndex = 0;
        }     
     
    }
}
