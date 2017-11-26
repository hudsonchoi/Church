using System;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Configuration;
using System.IO;
using System.Xml;
using _entity = Dothan.Library;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraEditors;
using System.Collections;
using System.Threading;


namespace LandWin.Modules
{
    public partial class MemberListPart :WinPart
    {

        private DataTable _doclist;
        private XmlDocument _oXmlDocument;
        private _entity.bizMember.MemberList _memberlist;
        private const string layoutName = "MemberInfoGridView";
        public override bool IsReadOnly
        {
            get
            {
                return true;
            }
        }
        public override GridView ReportView
        {
            get
            {
                return gridView1;
            }
        }

        private delegate void DataLoadDelegate();
        
        protected internal override object GetIdValue()
        {
            return "MemberListPart";
        }

        #region  Document Function
        private void InitDocumentData()
        {
            _doclist = new DataTable("MemberList");
            _doclist.BeginInit();
            AddColumn(_doclist, "ID", System.Type.GetType("System.Int32"));
            AddColumn(_doclist, "MemberName", System.Type.GetType("System.String"));
            _doclist.EndInit();
            gridControl2.DataSource =_doclist;
            gridControl2.MainView.PopulateColumns();
            gridView2.BestFitColumns();
            gridView2.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(LandWin.Shared.UtiltyDevExpress.CustomDrawRowIndicator);
            DevExpress.XtraGrid.GridSummaryItem item = new DevExpress.XtraGrid.GridSummaryItem(DevExpress.Data.SummaryItemType.Count, "ID", "Cnt={0}");
           
        }

        private static void AddColumn(DataTable data, string name, System.Type type) { AddColumn(data, name, type, false); }
        private static void AddColumn(DataTable data, string name, System.Type type, bool ro)
        {
            DataColumn col = new DataColumn(name, type) { Caption = name, ReadOnly = ro };
            data.Columns.Add(col);
        }

        #endregion

        public MemberListPart()
        {
            InitializeComponent();
            Shared.UtiltyDevExpress.InitGridView(this.gridView1, layoutName);
            pan_AdvancedSearch.Hide();
            pan_Document.Hide();
            BindingLookupData();
            ResetSearch();
            InitDocumentData();
            gridView1.DoubleClick += new EventHandler(GridViewRow_DoubleClick);

            gridView1.ShowGridMenu += new DevExpress.XtraGrid.Views.Grid.GridMenuEventHandler(m_ShowGridMenu);
        }

        private void BindingLookupData()
        {
            try
            {
                this.sexListBindingSource.DataSource = _entity.bizCommon.SexList.Get(true);
                this.baptismTypeListBindingSource.DataSource = _entity.bizCommon.TypeList.Get("baptism", true);
                this.jobTypeListBindingSource.DataSource = _entity.bizCommon.TypeList.Get("job", true);
                this.stateListBindingSource.DataSource = _entity.bizCommon.StateList.Get(true);
                this.subdivisionListBindingSource.DataSource = _entity.bizCommon.SubdivisionList.Get(true);
                this.statusListBindingSource.DataSource = _entity.bizCommon.StatusList.Get();
                this.fellowshipsListBindingSource.DataSource = _entity.bizFellowship.FellowshipsList.Get(true);
                this.marriageListBindingSource.DataSource = _entity.bizCommon.MarriageList.Get(true);
                this.cellListBindingSource.DataSource = _entity.bizCell.CellList.Get(false);

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

   
        private void LoadMember()
        {
            string lastName = string.Empty;
            string fristName = string.Empty;
            string enLastName = string.Empty;
            string enFirstName = string.Empty;
            int agefrom = (int)sp_agefrom.Value;
            int ageto = (int)sp_ageto.Value;
            int sex = (int)cl_sexlist.EditValue;
            int baptism = (int)cl_baptism.EditValue;
            int married = (int)cl_marriedlist.EditValue;
            int subdiv = (int)cl_subdivisionlist.EditValue;
            int jobtype = (int)cl_joblist.EditValue;
            int status = (int)cl_statuslist.EditValue;
            int fellowship = (int)bt_Fellowship.EditValue;
            int active = (int)rActiveGroup.EditValue;
            int relationship = chk_OnlyFamily.Checked ? 1 : 0;
            string state = string.Empty;
            string city = string.Empty;
            string regFrom = string.Empty;
            string regTo = string.Empty;
            string baptismFrom = string.Empty;
            string baptismTo = string.Empty;
            string birthFrom = string.Empty;
            string birthTo = string.Empty;
            string cellphone = txtCellphone.Text;
            string home = txtHome.Text;

            if(!ck_english.Checked)
            {
                fristName = txt_firstname.Text;
                lastName = txt_lastname.Text;
            }
            else
            {
                enLastName = txt_firstname.Text;
                enLastName = txt_lastname.Text;
            }

            if (dt_baptismfrom.EditValue != null)
                baptismFrom = dt_baptismfrom.Text;
       

            if (dt_baptismto.EditValue != null)
                baptismTo = dt_baptismto.Text;
     
            
            if (dt_birthdayfrom.EditValue != null)
                birthFrom = dt_birthdayfrom.Text;
         
            
            if (dt_birthdayto.EditValue != null)
                birthTo = dt_birthdayto.Text;
        
            
            if (dt_RegFrom.EditValue != null)
                regFrom = dt_RegFrom.Text;
            

            if (dt_RegTo.EditValue != null)
                regTo = dt_RegTo.Text;
          

            if (cl_statelist.Text != "ALL")
            {
                state = cl_statelist.EditValue.ToString();
                if (cl_City.EditValue !=null && !cl_City.EditValue.Equals(0))
                    city = cl_City.EditValue.ToString();
            }

            try
            {
                _memberlist = _entity.bizMember.MemberList.Get
                    (lastName, fristName, enLastName, enFirstName, fellowship,
                         agefrom, ageto, state, city, sex, regFrom, regTo, status, baptism, baptismFrom, baptismTo, married, subdiv,
                        relationship, jobtype, birthFrom, birthTo, active, cellphone, home);
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



        private void bt_SearchAdvance_Click(object sender, EventArgs e)
        {
            SimpleButton bt = (SimpleButton)sender;
            bt.Enabled = false;
           
            this.Cursor = Cursors.WaitCursor;
            Thread t = new Thread(new ThreadStart(new DataLoadDelegate(LoadMember)));
            t.Start();
            t.Join();
            this.Cursor = Cursors.Default;
            bt.Enabled = true;
        }


        #region CityList Data Binding depended on StateCode

      
        #endregion


        private void bt_Reset_Click(object sender, EventArgs e)
        {
            ResetSearch();
        }


        private void btnAdvancedSearch_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (pan_AdvancedSearch.Visibility == DevExpress.XtraBars.Docking.DockVisibility.Visible)
                pan_AdvancedSearch.Hide();
            else
                pan_AdvancedSearch.Show();
        }

  

        private void EditDateTime_PressEnter(object sender, KeyEventArgs e)
        {
            TextEdit edit = (TextEdit)sender;
            if (e.KeyCode == Keys.Enter)
            {
                if (!Shared.Utility.ValidateDatetime(edit.Text))
                {
                    edit.EditValue = null;
                    XtraMessageBox.Show("It is invalid DataTime", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ResetSearch()
        {
            cl_joblist.EditValue = 0;
            cl_statelist.EditValue = string.Empty;
            cl_statuslist.EditValue = 0;
            cl_subdivisionlist.EditValue = 0;
            cl_sexlist.EditValue = -1;
            cl_baptism.EditValue = 0;
            ck_english.Checked = false;
            cl_marriedlist.EditValue = -1; ;
            bt_Fellowship.EditValue = 0;
            txt_firstname.Text = string.Empty;
            txt_lastname.Text = string.Empty;
            chk_OnlyFamily.Checked = false;
            cl_City.Enabled = false;
            dt_RegFrom.EditValue = null;
            dt_RegTo.EditValue = null;
            dt_baptismfrom.EditValue = null;
            dt_baptismto.EditValue = null;
            dt_birthdayfrom.EditValue = null;
            dt_birthdayto.EditValue = null;
            StatusListBinding(-1);
        }


        #region Function Documents

        private void gridView2_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            
            if (e.Column.FieldName == "ID" && e.Value != null)
            {
                GridView gv = sender as GridView;
                try
                {
                    int id;
                    if (int.TryParse(e.Value.ToString(), out id))
                    {
                        if (!CheckDuplicated(id))
                        {
                            _entity.bizMember.MemberList list = _entity.bizMember.MemberList.Get(id);


                            DataRow row = gv.GetDataRow(e.RowHandle);
                            row["MemberName"] = list[0].Ko_Name;
                        }
                        else
                            throw new InvalidCastException("It is invalid ID or duplicated ID.");
                    }
                    else
                        throw new InvalidCastException("It is invalid ID or duplicated ID.");
                }

                catch (InvalidCastException ex)
                {
                    gv.DeleteRow(e.RowHandle);
                    gv.FocusedRowHandle = 0;
                    XtraMessageBox.Show(ex.Message, "Error Loading", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
               
            }
        }
        private void bt_AddFromOtherDoc_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (_doclist == null) return;
            FileOpenAndAdd();
        }
        private void bt_OpenDocument_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (_doclist != null && _doclist.Rows.Count > 0)
            {
                DialogResult result = XtraMessageBox.Show("Would you like to delete a current list", "Important Message", MessageBoxButtons.YesNo);
                if (result == DialogResult.No) return;
            }
            InitDocumentData();
            FileOpenAndAdd();
        }

        private void FileOpenAndAdd()
        {
            using (OpenFileDialog dlg = new OpenFileDialog { InitialDirectory = ConfigurationManager.AppSettings["DirXmlData"].ToString(), Filter = "xml files (*.xml)|*.xml", FilterIndex = 2, RestoreDirectory = true })
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                    if (File.Exists(dlg.FileName))
                        LoadFromXML(dlg.FileName);
            }
        }

        private bool CheckDuplicated(int id)
        {
            bool result = false;
            foreach (DataRow row in _doclist.Rows)
            {
                if ((int)row["ID"] == id)
                {
                    result = true;
                    break;
                }

            }
            return result;

        }
        public void LoadFromXML(string filename)
        {
            XmlDocument oXmlDocument = new XmlDocument();
            oXmlDocument.Load(filename);
            XmlNode oXmlMainNode;
            if (oXmlDocument.ChildNodes.Count == 0)
                return;

            oXmlMainNode = oXmlDocument.ChildNodes[0];
            foreach (XmlNode oXmlNode in oXmlDocument.ChildNodes[0].ChildNodes)
            {
                DataRow newCustomersRow = _doclist.NewRow();
                if (!CheckDuplicated(int.Parse(oXmlNode.Attributes["ID"].Value)))
                {
                    newCustomersRow["ID"] = oXmlNode.Attributes["ID"].Value.ToString();
                    newCustomersRow["MemberName"] = oXmlNode.Attributes["MemberName"].Value.ToString();
                    _doclist.Rows.Add(newCustomersRow);
                }
            }
        }
        private void bt_SaveDocument_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (_doclist == null) return;
            if (_doclist.Rows.Count == 0) return;
            SaveXMLFile();
        }

        private void SaveXMLFile()
        {
            this.Enabled = false;
            BackgroundWorker _worker = new BackgroundWorker();
            _worker.WorkerReportsProgress = true;
            _worker.DoWork += new DoWorkEventHandler(DoWork);

            Tools.ProgressDialog.Show(_doclist.Rows.Count);
            Tools.ProgressDialog.SetTitle("Save Data Process");
            Tools.ProgressDialog.SetMessage("Please be patient and wait...");
            Tools.ProgressDialog.actionBaseText = "Processing :";

            _worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bg_RunWorkerCompleted);
            _worker.RunWorkerAsync(_doclist);
            
        }
        private void bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Tools.ProgressDialog.Stop();
            this.Enabled = true;
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.InitialDirectory = ConfigurationManager.AppSettings["DirXmlData"].ToString();
            dlg.Filter = "xml files (*.xml)|*.xml";
            dlg.FilterIndex = 2;
            dlg.RestoreDirectory = true;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string filename = dlg.FileName;
                if (File.Exists(filename))
                {
                    DialogResult result = XtraMessageBox.Show(string.Format("{0} 파일이 존재합니다. 덮어쓰시겠습니까?", filename), "Important Message", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        File.Delete(filename);
                        _oXmlDocument.Save(filename);
                        XtraMessageBox.Show(LandWin.Properties.Resources.Success_Save, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    _oXmlDocument.Save(filename);
                    XtraMessageBox.Show(LandWin.Properties.Resources.Success_Save, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                InitDocumentData();
            }

        }
        private void DoWork(object sender, DoWorkEventArgs e)
        {

            int _index = 0;
            _oXmlDocument = new XmlDocument();
            _oXmlDocument.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlAttribute oXmlAttribute = _oXmlDocument.CreateAttribute("FileName");
            XmlNode oXMLMainNode = _oXmlDocument.CreateNode(XmlNodeType.Element, "MemberList", string.Empty);
            XmlNode oXMLNode;

            oXmlAttribute.Value = "DataList";
            oXMLMainNode.Attributes.Append(oXmlAttribute);
            _oXmlDocument.AppendChild(oXMLMainNode);
            foreach (DataRow row in ((DataTable)e.Argument).Rows)
            {
                _index++;
                Tools.ProgressDialog.SetValue(_index);
                if (row[0] != null)
                {
                    oXMLNode = _oXmlDocument.CreateNode(XmlNodeType.Element, "List", string.Empty);
                    oXMLMainNode.AppendChild(oXMLNode);

                    Shared.Utility.AddXMLAttribute(_oXmlDocument, oXMLNode, "ID", row["ID"].ToString());
                    Shared.Utility.AddXMLAttribute(_oXmlDocument, oXMLNode, "MemberName", row["MemberName"].ToString());
                }
            }
           
            
        }
     
        private void FillGridWithData(string s)
        {
            if (System.IO.File.Exists(s))
            {
                DataSet ds = new DataSet();
                ds.ReadXml(s);
                gridControl2.DataSource = ds.Tables[0];
                gridControl2.MainView.PopulateColumns();
            }
            else
                XtraMessageBox.Show(String.Format("File {0} is not found", s), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        } 
        private void bt_NewDocument_ItemClick(object sender, ItemClickEventArgs e)
        {
            InitDocumentData();
        }

        private void bt_LoadList_ItemClick(object sender, ItemClickEventArgs e)
        {
            
            string str = GetListMemberid();
            if (string.IsNullOrEmpty(str)) return;

            LoadMamberListByList(str);
        }

        private string GetListMemberid()
        {
            StringBuilder str = new StringBuilder();
            if (_doclist.Rows.Count  > 0)
            {
                foreach (DataRow row in _doclist.Rows)
                {
                    if (row["ID"] != null)
                        str.Append(row["ID"].ToString()).Append(",");
                }
            }
            return str.ToString();
        }
        
        private void bt_ShowDocuments_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.pan_Document.Visibility == DevExpress.XtraBars.Docking.DockVisibility.Visible)
                this.pan_Document.Hide();
            else
                this.pan_Document.Show();
            
        }

        private void bt_AddFromSelectedRow_ItemClick(object sender, ItemClickEventArgs e)
        {
            
            if (gridView1 == null) return;
            if (gridView1.SelectedRowsCount == 0) return;

            if(_doclist == null)
                InitDocumentData();

            for (int i = 0; i < gridView1.SelectedRowsCount; i++)
            {
                int row = (gridView1.GetSelectedRows()[i]);
                DataRow newCustomersRow = _doclist.NewRow();

                newCustomersRow["ID"] = gridView1.GetRowCellValue(row, "MemberId").ToString();
                newCustomersRow["MemberName"] = gridView1.GetRowCellValue(row, "Ko_Name").ToString();

                _doclist.Rows.Add(newCustomersRow);
            }
        }
        
        private void bt_remove_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (gridView2 == null || gridView2.SelectedRowsCount == 0) return;

            DataRow[] rows = new DataRow[this.gridView2.SelectedRowsCount];
            for (int i = 0; i < this.gridView2.SelectedRowsCount; i++)
                rows[i] = this.gridView2.GetDataRow(gridView2.GetSelectedRows()[i]);

            this.gridView2.BeginSort();
            try
            {
                foreach (DataRow item in rows)
                    item.Delete();
            }
            finally
            {

                this.gridView2.EndSort();
                this.gridView2.RefreshData();

            }
        }
        
        private void bt_ImportFromExcel_ItemClick(object sender, ItemClickEventArgs e)
        {

            if (_doclist == null)
                InitDocumentData();


            using (LandWin.Tools.ImportFromExcelFrm frm = new LandWin.Tools.ImportFromExcelFrm())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    Cursor = Cursors.WaitCursor;
                    try
                    {
                        _entity.bizMember.MemberList list = _entity.bizMember.MemberList.GetListByIdList(frm.MemberList.ToString().TrimEnd(','));
                        foreach (_entity.bizMember.MemberInfo item in list)
                        {
                            DataRow newCustomersRow = _doclist.NewRow();
                            newCustomersRow["ID"] = item.MemberId.ToString();
                            newCustomersRow["MemberName"] = item.Ko_Name;
                            _doclist.Rows.Add(newCustomersRow);
                        }
                        gridView2.RefreshData();
                    }
                    catch (InvalidOperationException ex)
                    {
                        MessageBox.Show(Properties.Resources.Duplicated_assign, "Error saving", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Error saving", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    Cursor = Cursors.Default;
                    Enabled = true;
                }

            }
        }
        #endregion

        private void btnNewMember_ItemClick(object sender, ItemClickEventArgs e)
        {

            MainForm.Instance.ShowMemberInfo(0);
        }


        #region LookUp list Binding


        private void ck_english_CheckedChanged(object sender, EventArgs e)
        {
            if (ck_english.Checked)
            {
                lc_firstname.Text = "First Name";
                lc_lastname.Text = "Last Name";
            }
            else
            {
                this.lc_lastname.Text = LandWin.Properties.Resources.Last_name;
                this.lc_firstname.Text = LandWin.Properties.Resources.First_name;
            }
        }

        private void StatusGroup_EditValueChanged(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.RadioGroup obj = sender as DevExpress.XtraEditors.RadioGroup;
            StatusListBinding(Convert.ToInt32(obj.Text));
        }

        private void StatusListBinding(int active)
        {
            _entity.bizAdmin.StatusTypes list = _entity.bizAdmin.StatusTypes.Get();

            switch (active)
            {
            	case -1:
            		this.typeListBindingSource.DataSource = from status in list 
                                                            orderby status.IsActive descending
                                                            ,   status.Name ascending
                                                            select new { Key = status.ID, Value = status.IsActive == true ? "(A)" + status.Name : "(I)" + status.Name };
            		break;
                case 0: this.typeListBindingSource.DataSource = from status in list 
                                                          where status.IsActive == false
                                                          orderby status.Name ascending
                                                                select new { Key = status.ID, Value = status.IsActive == true ? "(A)" + status.Name : "(I)" + status.Name };
                    break;
                case 1:
                    this.typeListBindingSource.DataSource = from status in list 
                                                          where status.IsActive == true
                                                            orderby status.Name ascending
                                                            select new { Key = status.ID, Value = status.IsActive == true ? "(A)" + status.Name : "(I)" + status.Name };
                    break;

            }
            this.typeListBindingSource.ResetBindings(false);

        }

        private void Statelist_EditValueChanged(object sender, EventArgs e)
        {
            if (cl_statelist.EditValue == null)
                return;

            string statecode = cl_statelist.EditValue.ToString();

            if (string.IsNullOrEmpty(statecode) || statecode == "ALL")
                return;

            CityListBinding(statecode);

        }
        private void CityListBinding(string statecode)
        {
            try
            {
                if (string.IsNullOrEmpty(statecode))
                {
                    cityListBindingSource.DataSource = null;
                    cl_City.Enabled = false;
                }
                else
                {
                    cityListBindingSource.DataSource = _entity.bizCommon.CityList.Get(statecode, true);
                    cl_City.Enabled = true;
                    cl_City.EditValue = "ALL";
                }

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





        private void LoadMemberFromSelected(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (gridView1 == null) return;
            if (gridView1.SelectedRowsCount == 0) return;

            if (_doclist == null)
                InitDocumentData();

            for (int i = 0; i < gridView1.SelectedRowsCount; i++)
            {
                int row = (gridView1.GetSelectedRows()[i]);
                DataRow newCustomersRow = _doclist.NewRow();

                newCustomersRow["ID"] = gridView1.GetRowCellValue(row, "MemberId").ToString();
                newCustomersRow["MemberName"] = gridView1.GetRowCellValue(row, "Ko_Name").ToString();

                _doclist.Rows.Add(newCustomersRow);
            }
            this.Cursor = Cursors.Default;
        }



        #region Find Member by Name , ID

        /// <summary>
        /// Enter Full name 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void repositoryItemTextEdit2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                TextEdit edit = (TextEdit)sender;
                if (string.IsNullOrEmpty(edit.Text)) return;

                LoadMemberListByName(edit.Text, (int)ddlSubdivision.EditValue);
            }
        }

        private void btnFindbyName_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            string name = string.Empty;
            
            

            if( this.txtkoFullName.EditValue != null)
            {
                name = this.txtkoFullName.EditValue.ToString();
            }

            int subDivision = (int)this.ddlSubdivision.EditValue;

            
            Thread t = new Thread(() => LoadMemberListByName(name, subDivision));
            t.Start();
            t.Join();
            this.Cursor = Cursors.Default;

        }

        private void LoadMemberListByName(string fullName, int subDivision)
        {
            try
            {
                _memberlist = _entity.bizMember.MemberList.Get(fullName, subDivision);
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

        private void LoadMamberListByList(string list)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                _memberlist = _entity.bizMember.MemberList.GetListByIdList(list);
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
            }
        }

        #endregion


        public void RefreshBinding()
        {
            ThreadPool.QueueUserWorkItem(FillData);
        }

        void FillData(object state)
        {
            this.Invoke((MethodInvoker)delegate
            {
                memberListBindingSource.DataSource = _memberlist;
                this.gridView1.RefreshData();
                this.gridView1.BestFitColumns();
            });
        }
       

        #region Apply SubDvision 

       

        private void btnApplySubDivision_ItemClick(object sender, EventArgs e)
        { 
            if (gridView1.SelectedRowsCount == 0)
                return;

            if (this.txtSubDivision.EditValue == null || (int)this.txtSubDivision.EditValue == 0)
            {
                MessageBox.Show(Properties.Resources.ErrorMessage_Invalid);
                return;
            }

            string list = Shared.UtiltyDevExpress.GetStringSelectedRow(this.gridView1, "MemberId");
            try
            {
                _entity.bizMember.Member.ToUpdateSubDivision((int)this.txtSubDivision.EditValue, list);
                MessageBox.Show(Properties.Resources.Success_Save);
                LoadMamberListByList(list);
                this.popupContainerControl1.Hide();
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

        private void barShouwSubDivision_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.popupContainerControl1.Show();
            this.popupContainerControl1.BringToFront();
        }

        private void HideSubDivision_ItemClick(object sender, EventArgs e)
        {
            this.popupContainerControl1.Hide();
        }

        #endregion

   

        #region Apply Cell 

        private void ShowCellTransfer_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.gridView1.SelectedRowsCount == 0) return; 

            this.popupContainerControl2.Show();
            this.popupContainerControl2.BringToFront();
        }

        private void HideCellTransFer_ItemClick(object sender, EventArgs e)
        {
            this.popupContainerControl2.Hide();
        }


        private void ApplyCell_ItemClick(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount == 0)
                return;

            if (this.txtCell.EditValue == null || (int)this.txtCell.EditValue == 0)
            {
                MessageBox.Show(Properties.Resources.ErrorMessage_Invalid);
                return;
            }

            this.popupContainerControl2.Hide();
            string list = Shared.UtiltyDevExpress.GetStringSelectedRow(this.gridView1, "MemberId");
            try
            {
                _entity.bizMember.Member.ToTransferCell(list, DateTime.Today.ToString(), (int)this.txtCell.EditValue, Dothan.ApplicationContext.User.Identity.Name);
                MessageBox.Show(Properties.Resources.Success_Save);
                LoadMamberListByList(list);

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
            }
                        
        }


        private void btnUnassignMember_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.ddlSubdivision.EditValue == null ) return;

            LoadUnAssignedCellMember((int)ddlSubdivision.EditValue);

        }
        private void btnShowCellTool_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.popupContainerControl2.Show();
            this.popupContainerControl2.BringToFront();
        }


        private void LoadUnAssignedCellMember(int subDivision)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                _memberlist = _entity.bizMember.MemberList.GetUnAssignedCellMember(subDivision);
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
                this.gridView1.BestFitColumns();
            }

        }


        #endregion



        private void rMemberID_KeyDown(object sender, KeyEventArgs e)
        {
            DevExpress.XtraEditors.TextEdit item = (DevExpress.XtraEditors.TextEdit)sender;
            if (e.KeyCode == Keys.Enter)
            {
                int id = 0;
                if (int.TryParse(item.Text, out id))
                {
                    _memberlist = Dothan.Library.bizMember.MemberList.Get(id);
                    RefreshBinding();

                }
                else
                    MessageBox.Show("Invalid MemberID", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                item.Text = null;
            }
        }


        private void pictureEdit1_Click(object sender, EventArgs e)
        {
            Shared.UtiltyDevExpress.Calendar(dt_RegFrom);
        }
        private void pictureEdit2_Click(object sender, EventArgs e)
        {
            Shared.UtiltyDevExpress.Calendar(dt_RegTo);
        }

       

        private void pictureEdit3_Click(object sender, EventArgs e)
        {
            Shared.UtiltyDevExpress.Calendar(dt_baptismfrom);
        }

        private void pictureEdit4_Click(object sender, EventArgs e)
        {
            Shared.UtiltyDevExpress.Calendar(dt_baptismto);
        }

        private void pictureEdit5_Click(object sender, EventArgs e)
        {
            Shared.UtiltyDevExpress.Calendar(dt_birthdayfrom);
        }

        private void pictureEdit6_Click(object sender, EventArgs e)
        {
            Shared.UtiltyDevExpress.Calendar(dt_birthdayto);
        }

        private void btnAttendanceTool_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.popupContainerControl3.Show();
            this.popupContainerControl3.BringToFront();
        }

        private void simpleButton4_Click_1(object sender, EventArgs e)
        {
            this.popupContainerControl3.Hide();
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {

            if (gridView1.SelectedRowsCount == 0)
                return;

            string list = Shared.UtiltyDevExpress.GetStringSelectedRow(this.gridView1, "MemberId");
            try
            {
                _entity.bizMember.Member.ToUpdateStatus((int)this.lookUpEdit1.EditValue, list, "Changed to " + lookUpEdit1.Text, "");
                MessageBox.Show(Properties.Resources.Success_Save);
                LoadMamberListByList(list);
                this.popupContainerControl3.Hide();
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
}
