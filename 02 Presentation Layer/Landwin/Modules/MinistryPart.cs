using System;
using System.Windows.Forms;
using _entity = Dothan.Library;
using LandWin.Properties;
using DevExpress.XtraTreeList;
using System.Collections;
using System.Text;
using System.Linq;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Base;
using System.Threading;

namespace LandWin.Modules
{
    public partial class MinistryPart : WinPart
    {
        
        private int _selectedMinistry;
        private const string _layoutName = "MinistryGridView";
        private _entity.bizMinistry.MinistryMembers _memberlist;
        private _entity.bizMinistry.Ministrys _ministry;
        private _entity.bizMinistry.MinistryRoleList _role;
        
        public override GridView ReportView { get { return gridView1; } }
        
        public MinistryPart()
        {
            InitializeComponent();
            Shared.UtiltyDevExpress.InitGridView(this.gridView1, _layoutName);
            LoadMinistry();
            BindingMinistry();
            LoadMinistryRoles();
            BindingRoleMenu();
            gridView1.DoubleClick += new EventHandler(this.GridViewRow_DoubleClick);
            gridView1.RowStyle += new RowStyleEventHandler(GridView_RowStyle);

            gridView1.ShowGridMenu += new DevExpress.XtraGrid.Views.Grid.GridMenuEventHandler(m_ShowGridMenu);
        }
        private void treeList1_Click(object sender, EventArgs e)
        {
            TreeList tree = sender as TreeList;
            TreeListHitInfo hi = tree.CalcHitInfo(tree.PointToClient(Control.MousePosition));
            if (hi.Node != null)
            {
                this.Cursor = Cursors.WaitCursor;
                if (_selectedMinistry != (int)hi.Node.GetValue("Code"))
                {
                    _selectedMinistry = (int)hi.Node.GetValue("Code");
                    LoadMinistryMember(_selectedMinistry, false, string.Empty, string.Empty);
                }
            }

        }

   
        #region WinPart Code

        protected internal override object GetIdValue()
        {
            return Resources.Ministry_Manage;
        }

        #endregion

        public void BindingMinistry()
        {
            if (_ministry == null)
                return;

            this.ministrysBindingSource.DataSource = from item in _ministry
                                                       where item.Status != "D"
                                                       select item;
            treeList1.ExpandAll();
            treeList1.Refresh();

        }
        private void LoadMinistry()
        {
            try
            {
                _ministry = _entity.bizMinistry.Ministrys.Get();
                this.ministryListBindingSource.DataSource = _entity.bizMinistry.MinistryList.Get(false);
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

 

        private void LoadMinistryRoles()
        {
            try
            {
                _role = _entity.bizMinistry.MinistryRoleList.Get(false);
                this.ministryRoleListBindingSource.DataSource = _role;
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
        private void BindingRoleMenu()
        {
            for (int i = 0; i < _role.Count; i++)
            {
                if (_role[i].Key != 0)
                {
                    BarButtonItem BarItem = new BarButtonItem();
                    BarItem.Name = _role[i].Key.ToString();
                    BarItem.Caption = _role[i].Value;
                    BarItem.ItemClick += new ItemClickEventHandler(mRole_Click);
                    this.btnRoleList.ItemLinks.Add(BarItem);
                }
            }
        }

        protected void mRole_Click(object sender, ItemClickEventArgs e)
        {
            try
            {
                BarButtonItem item = (BarButtonItem)e.Item;
                _memberlist = _entity.bizMinistry.MinistryMembers.GetListByRoles(Convert.ToInt32(e.Item.Name));
                RefreshBinding();
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


        private void  RefreshBinding()
        {
            this.ministryMembersBindingSource.DataSource = from list in _memberlist
                                                             where list.EndDate == string.Empty
                                                             select list;

            this.gridView1.RefreshData();
            this.gridView1.BestFitColumns();
        }

        private void LoadMinistryMember(int code, bool withHistory , string fromEndDate , string toEndDate)
        {
             if (_memberlist != null && _memberlist.IsDirty)
            {
                DialogResult result = MessageBox.Show("Do you want to re-load without saving data?", "Important Message", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                    return;
            }
             try
             {
                 this.Cursor = Cursors.WaitCursor;
                 _memberlist = _entity.bizMinistry.MinistryMembers.Get(code, withHistory, fromEndDate, toEndDate);
                 _memberlist.BeginEdit();
                 RefreshBinding();
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
                 this.Cursor = Cursors.Default;
                 this.gridView1.RefreshData();
                 this.gridView1.BestFitColumns();
             }
        }
    

        private void btnMinistry_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (!_entity.bizMinistry.Ministrys.CanEditObject())
            {
                MessageBox.Show(Resources.ErrorMassage_UnAuthorized);
                return;
            }

            Tools.MinistryListFrm frm = new LandWin.Tools.MinistryListFrm();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadMinistry();
            }
        }

        public override void ImportMemberList(_entity.bizMember.MemberList list)
        {
            foreach (_entity.bizMember.MemberInfo item in list)
                AssignMember(item);



            RefreshBinding();
        }
        private void AssignMember(Dothan.Library.bizMember.MemberInfo info)
        {
            if (_memberlist.Contains(info.MemberId))
            {
                MessageBox.Show(Resources.Err_Duplicated);
                return;
            }
            _memberlist.Assign(info,_selectedMinistry, DateTime.Today.ToString(), _role[0].Key);
            RefreshBinding();
        }
        private void SaveList()
        {
            this.gridView1.PostEditor();
            this.ministryMembersBindingSource.EndEdit();
            this.ministryMembersBindingSource.RaiseListChangedEvents = false;

            this.Enabled = false;
            _entity.bizMinistry.MinistryMembers temp = _memberlist.Clone();
            temp.ApplyEdit();
            try
            {
                _memberlist = temp.Save();
                MessageBox.Show(Resources.Success_Save);
                RefreshBinding();

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
                this.Enabled = true;
                this.Cursor = Cursors.Default;
                this.ministryMembersBindingSource.RaiseListChangedEvents = true;
            }
        }

        private void Remove(object[] row)
        {
            foreach (object obj in row)
            {
                if ((obj as _entity.bizMinistry.MinistryMember).IsNew)
                {
                    _memberlist.Remove(obj as _entity.bizMinistry.MinistryMember);
                }
                else
                {
                    (obj as _entity.bizMinistry.MinistryMember).EndDate = DateTime.Today.ToString();

                }
            }
            RefreshBinding();
        }
        
        private void btnSaveList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!_entity.bizMinistry.MinistryMembers.CanEditObject())
            {
                MessageBox.Show(Resources.ErrorMassage_UnAuthorized);
                return;
            }
           
            SaveList();
        }

 
        private void btnAddMameber_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Tools.MemberSearchFrm frm = new LandWin.Tools.MemberSearchFrm(this);
            frm.ShowDialog();
            frm.Dispose();
        }

        private void btnApplyRole_ItemClick(object sender, EventArgs e)
        {
            if (this.gridView1 == null || this.gridView1.SelectedRowsCount == 0) return;

            if (this.lookUpEdit1.EditValue == null || (int)lookUpEdit1.EditValue == 0)
                return;


            object[] list = Shared.UtiltyDevExpress.SelectedRows(this.gridView1);
            foreach (object info in list)
            {
                (info as _entity.bizMinistry.MinistryMember).Role = (int)lookUpEdit1.EditValue;
            }

            this.gridView1.ClearSelection();
            RefreshBinding();

            this.popupControlContainer1.Hide();

        }
        
        
        private void btnApplyStartDate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
            if (this.gridView1 == null || this.gridView1.SelectedRowsCount == 0)
            {
                MessageBox.Show(Properties.Resources.No_SelectedRow);
                return;
            }

            Tools.CalendarFrm dlg = new Tools.CalendarFrm();
            if (dlg.ShowDialog() == DialogResult.OK)
            {

                object[] list = Shared.UtiltyDevExpress.SelectedRows(this.gridView1);
                foreach (object info in list)
                {
                    (info as _entity.bizMinistry.MinistryMember).StartDate = dlg.SelectedDate.ToString();
                }
            }

            this.gridView1.ClearSelection();
            RefreshBinding();
        }

  
        private void btnAddMember_ItemClick(object sender, ItemClickEventArgs e)
        {
            Tools.MemberSearchFrm frm = new LandWin.Tools.MemberSearchFrm(this);
            frm.ShowDialog();
            frm.Dispose();

        }

        private void btnRemoveMember_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.gridView1 == null || this.gridView1.SelectedRowsCount == 0) return;

            if (_entity.bizMinistry.MinistryMembers.CanDeleteObject())
            {
                Remove(Shared.UtiltyDevExpress.SelectedRows(this.gridView1));
                RefreshBinding();
            }
            else
            {
                MessageBox.Show(Properties.Resources.ErrorMessage_Invalid);
            }
      
        }

        private void btnImportFromExcel_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (_memberlist == null) return;

            using (LandWin.Tools.ImportFromExcelFrm frm = new LandWin.Tools.ImportFromExcelFrm())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {

                    this.Enabled = false;
                    this.Cursor = Cursors.WaitCursor;
                    try
                    {

                        Dothan.Library.bizMember.MemberList list = Dothan.Library.bizMember.MemberList.GetListByIdList(frm.MemberList.ToString().TrimEnd(','));


                        foreach (Dothan.Library.bizMember.MemberInfo item in list)
                            AssignMember(item);


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
                        RefreshBinding();
                        this.Cursor = Cursors.Default;
                        this.Enabled = true;
                    }
                }
            }
        }

        private void repositoryItemTextEdit1_KeyDown(object sender, KeyEventArgs e)
        {

            if (!_entity.bizMinistry.MinistryMembers.CanEditObject())
            {
                MessageBox.Show(Resources.ErrorMassage_UnAuthorized);
                return;
            }

            if (_memberlist == null) return;

            DevExpress.XtraEditors.TextEdit item = (DevExpress.XtraEditors.TextEdit)sender;
            if (e.KeyCode == Keys.Enter)
            {
                int id = 0;
                if (int.TryParse(item.Text, out id))
                {
                    Dothan.Library.bizMember.MemberList list = Dothan.Library.bizMember.MemberList.Get(id);

                    foreach (Dothan.Library.bizMember.MemberInfo info in list)
                        AssignMember(info);

                }
                else
                    MessageBox.Show("Invalid MemberID", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                item.Text = null;
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.popupControlContainer1.Hide();
        }

        private void btnShowRole_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.popupControlContainer1.Show();
            this.popupControlContainer1.BringToFront();
        }

     

     

 
      
       
        /*
        


   

       

    



        private void SetRoles_Click(object sender, EventArgs e)
        {
            SelectRoleFrm dlg = new SelectRoleFrm("ministry");
            if (dlg.ShowDialog() == DialogResult.OK)
            {
               
                foreach (OutlookGridRow row in this.outlookGrid1.SelectedRows)
                {

                    _memberlist.SetRole(int.Parse(row.Cells["MemberId"].Value.ToString()), int.Parse(dlg.SelectKey.ToString()));
                    DataBindMemberlist();
                }
            }
          
        }

        private void bt_removemember_Click(object sender, EventArgs e)
        {
            foreach (OutlookGridRow row in this.outlookGrid1.SelectedRows)
            {
                _memberlist.Remove(int.Parse(row.Cells["MemberId"].Value.ToString()), this.dateTimePicker2.Value);
                this.outlookGrid1.Rows.Remove(row);
            }
        }

  
     

        }
    

        private void Tb_importfilelist_Click(object sender, EventArgs e)
        {
            
                Frm_MemberListFiles dlg = new Frm_MemberListFiles();
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(Application.StartupPath + @"\850_" + dlg.FileName + ".xml"))
                    {
                        this.Enabled = false;
                        this.Cursor = Cursors.WaitCursor;
                        XmlDocument oXmlDocument = new XmlDocument();
                        oXmlDocument.Load(Application.StartupPath + @"\850_" + dlg.FileName + ".xml");
                        XmlNode oXmlMainNode;

                        if (oXmlDocument.ChildNodes.Count == 0)
                            return;

                        oXmlMainNode = oXmlDocument.ChildNodes[0];

                        foreach (XmlNode oXmlNode in oXmlDocument.ChildNodes[0].ChildNodes)
                        {
                            try
                            {
                                _memberlist.Assign(int.Parse(oXmlNode.Attributes["ID"].Value.ToString()), this.dateTimePicker2.Value.ToString(), MinistryRoleList.DefaultRole(MainForm.Instance.Divcode.ToString()), MainForm.Instance.Divcode.ToString());

                            }
                            catch (InvalidOperationException ex)
                            {
                                MessageBox.Show(ex.ToString(),
                                  "Data Import Error", MessageBoxButtons.OK,
                                  MessageBoxIcon.Exclamation);
                            }

                        }
                        this.Cursor = Cursors.Default;
                        this.Enabled = true;
                    }
                    DataBindMemberlist();
                }
            
        }

        private void Tb_ExportExcel_Click(object sender, EventArgs e)
        {
            this.splitContainer1.Enabled = false;


            backgroundWorker1.RunWorkerAsync();
        }

        private void tb_exportListfile_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
           
            OpenListFrm dlg = new OpenListFrm();
            if (!string.IsNullOrEmpty(_listname))
            {
                dlg.Tb_filename.Text = _listname;

            }
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                _listname = dlg.Tb_filename.Text;
                XmlDocument oXmlDocument = WriteToXML();
                oXmlDocument.Save(Application.StartupPath + @"\850_" + dlg.Tb_filename.Text + ".xml");
                MessageBox.Show(string.Format("Successfully exported '{0}'.", _listname));
            }
            this.Enabled = true;

        }

        public XmlDocument WriteToXML()
        {
            XmlDocument oXmlDocument = new XmlDocument();
            XmlNode oXMLMainNode;
            XmlNode oXMLNode;
            oXmlDocument.CreateXmlDeclaration("1.0", "UTF-8", null);

            oXMLMainNode = oXmlDocument.CreateNode(XmlNodeType.Element, "MemberList", string.Empty);
            oXmlDocument.AppendChild(oXMLMainNode);
            Common.AddXMLAttribute(oXmlDocument, oXMLMainNode, "FileName", _listname);


            foreach (MinistryMember row in _memberlist)
            {
                if (row.MemberId != 0)
                {
                    oXMLNode = oXmlDocument.CreateNode(XmlNodeType.Element, "List", string.Empty);
                    oXMLMainNode.AppendChild(oXMLNode);

                    Common.AddXMLAttribute(oXmlDocument, oXMLNode, "ID", row.MemberId.ToString());
                    Common.AddXMLAttribute(oXmlDocument, oXMLNode, "MemberName", row.FullName.ToString());
                }
            }


            return oXmlDocument;
        }

        private void rPrint_FamilyList_Click(object sender, EventArgs e)
        {
            try
            {
                ReportManager manager = new ReportManager();
                manager.ReportFamilyList(GetSelectedList());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error Printing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        */
       
      

      

    }
}
