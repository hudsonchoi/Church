using System;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Configuration;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;

namespace LandWin.Modules
{

   
    public partial class WinPart : XtraUserControl
    {
        public virtual string LayoutName { get { return null; } }
        public virtual GridView ReportView { get { return null; } }
        public virtual bool IsReadOnly { get { return false; } }

        public virtual void ImportMemberList(Dothan.Library.bizMember.MemberList info) { }
    
        public WinPart()
        {
            InitializeComponent();
          
        }

        protected internal virtual object GetIdValue()
        {
            return null;
        }

        public object[] SelectedRows()
        {
            return Shared.UtiltyDevExpress.SelectedRows(ReportView);
        }

        public string GetSelectedList()
        {

            StringBuilder str = new StringBuilder();
            for (int i = 0; i < ReportView.SelectedRowsCount; i++)
            {
                int row = (ReportView.GetSelectedRows()[i]);
                str.Append(ReportView.GetRowCellValue(row, "MemberId").ToString()).Append(",");
            }
            return str.ToString().TrimEnd(',') ;
        }

        public void ShowGroupPanel()
        {
            if (ReportView == null)
                return;

            ReportView.OptionsView.ShowGroupPanel =  true;
        }

        public void ShowFilterRow()
        {
             if (ReportView == null)
                return;

             ReportView.ClearColumnsFilter();
            ReportView.OptionsView.ShowAutoFilterRow =  true;
        }

        public void HideFilterRow()
        {
            if (ReportView == null)
                return;

            ReportView.OptionsView.ShowAutoFilterRow = false;
        }
        public void HideGroupPanel()
        {
            if (ReportView == null)
                return;

            ReportView.ClearGrouping();
            ReportView.OptionsView.ShowGroupPanel = false;
        }
        internal  void GridView_RowStyle(object sender, RowStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                GridView view = sender as GridView;

                Dothan.Core.BusinessBase item = view.GetRow(e.RowHandle) as Dothan.Core.BusinessBase;
                if (item.IsNew)
                {
                    e.HighPriority = true;
                    e.Appearance.BackColor = System.Drawing.Color.GreenYellow;

                }
            }
        }

        internal void ValidateDateTime(object sender, EventArgs e)
        {
            DevExpress.XtraBars.BarEditItem obj = (DevExpress.XtraBars.BarEditItem)sender;

            if (obj.EditValue == null) return;

            if(!Shared.Utility.ValidateDatetime(obj.EditValue.ToString()))
            {
                MessageBox.Show("Invalid Date entered");
                obj.EditValue = null;
            }
        }

        internal bool ValidationDateValue(string obj)
        {
            bool result = false;


            return result;
        }
  
        internal void GridViewRow_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            GridHitInfo info = view.CalcHitInfo(pt);
            if (info.InRow || info.InRowCell)
            {
                try
                {
                    if (!view.IsGroupRow(info.RowHandle))
                    {
                        MainForm.Instance.ShowMemberInfo((int)view.GetRowCellValue(info.RowHandle, "MemberId"));
                    }
                    else
                    {
                        view.ExpandGroupRow(info.RowHandle);
                    }
                }
                catch (Dothan.DataPortalException ex)
                {
                    MessageBox.Show(ex.BusinessException.ToString(),
                      "Error Loading", MessageBoxButtons.OK,
                      MessageBoxIcon.Exclamation);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(),
                      "Error Saving", MessageBoxButtons.OK,
                      MessageBoxIcon.Exclamation);
                }
            }
        }

 



       // protected void mExportToXml(object sender, ItemClickEventArgs e)
       // {
       //     SaveXMLFile();
       // }


       // protected void SaveLayoutToXML(object sender, ItemClickEventArgs e)
       // {
       //     if (!string.IsNullOrEmpty(LayoutName))
       //     {
       //         ReportView.SaveLayoutToXml(ConfigurationManager.AppSettings["DirLayout"] + @"\" + LayoutName + ".xml");

       //     }
       // }

       // protected void RestoreLayoutFromXML(object sender, ItemClickEventArgs e)
       // {
       //     if (!string.IsNullOrEmpty(LayoutName))
       //     {
       //         try
       //         {
       //             if (File.Exists(ConfigurationManager.AppSettings["DirLayout"] + @"\" + LayoutName + ".xml"))
       //                 File.Delete(ConfigurationManager.AppSettings["DirLayout"] + @"\" + LayoutName + ".xml");

       //             InitGridView(ReportView);
       //         }
       //         catch { }
       //     }
       // }

       // protected string ShowSaveFileDialog(string title, string filter)
       // {
       //     using (SaveFileDialog saveFileDialog1 = new SaveFileDialog { Title = title, Filter = filter, FilterIndex = 2, RestoreDirectory = true })
       //     {
       //         if (saveFileDialog1.ShowDialog() == DialogResult.OK)
       //             return saveFileDialog1.FileName;
       //         else
       //             return null;
       //     }
       // }

        public override bool Equals(object obj)
        {
            if (this.DesignMode)
                return base.Equals(obj);
            else
            {
                object id = GetIdValue();
                if (this.GetType().Equals(obj.GetType()) && id != null)
                    return ((WinPart)obj).GetIdValue().Equals(id);
                else
                    return false;
            }
        }

   

        public override int GetHashCode()
        {
            object id = GetIdValue();
            if (id != null)
                return GetIdValue().GetHashCode();
            else
                return base.GetHashCode();
        }

        public override string ToString()
        {
            object id = GetIdValue();
            if (id != null)
                return id.ToString();
            else
                return base.ToString();
        }



        private void SaveXMLFile()
        {
            //if (ReportView == null) return;
            //if (ReportView.SelectedRowsCount == 0) return;
            //this.Enabled = false;
            //BackgroundWorker _worker = new BackgroundWorker();
            //_worker.WorkerReportsProgress = true;
            //_worker.DoWork += new DoWorkEventHandler(DoWork);

            //ProgressDialog.Show(ReportView.SelectedRowsCount);
            //ProgressDialog.SetTitle("Export Data Process");
            //ProgressDialog.SetMessage("Please be patient and wait...");
            //ProgressDialog.actionBaseText = "Processing :";

            //_worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bg_RunWorkerCompleted);
            //_worker.RunWorkerAsync();

        }
        private void bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
        //    ProgressDialog.Stop();
        //    this.Enabled = true;
        //    SaveFileDialog dlg = new SaveFileDialog();
        //    dlg.InitialDirectory = ConfigurationManager.AppSettings["DirXmlData"].ToString();
        //    dlg.Filter = "xml files (*.xml)|*.xml";
        //    dlg.FilterIndex = 2;
        //    dlg.RestoreDirectory = true;
        //    if (dlg.ShowDialog() == DialogResult.OK)
        //    {
        //        string filename = dlg.FileName;
        //        if (File.Exists(filename))
        //        {
        //            DialogResult result = XtraMessageBox.Show(string.Format("{0} 파일이 존재합니다. 덮어쓰시겠습니까?", filename), "Important Message", MessageBoxButtons.YesNo);
        //            if (result == DialogResult.Yes)
        //            {
        //                File.Delete(filename);
        //                oXmlDocument.Save(filename);
        //                XtraMessageBox.Show(LandWin.Properties.Resources.Success_Save, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            }
        //        }
        //        else
        //        {
        //            oXmlDocument.Save(filename);
        //            XtraMessageBox.Show(LandWin.Properties.Resources.Success_Save, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }
   
        //    }

        }
        //private void DoWork(object sender, DoWorkEventArgs e)
        //{

        
        //    oXmlDocument = new XmlDocument();
        //    XmlNode oXMLMainNode;
        //    XmlNode oXMLNode;
        //    oXmlDocument.CreateXmlDeclaration("1.0", "UTF-8", null);

        //    oXMLMainNode = oXmlDocument.CreateNode(XmlNodeType.Element, "MemberList", string.Empty);
        //    XmlAttribute oXmlAttribute = oXmlDocument.CreateAttribute("FileName");
        //    oXmlAttribute.Value = "DataList";
        //    oXMLMainNode.Attributes.Append(oXmlAttribute);
        //    oXmlDocument.AppendChild(oXMLMainNode);
        //    for (int i= 0; i < ReportView.SelectedRowsCount; i++)
        //    {
        //        ProgressDialog.SetValue(i);

        //        int row = (ReportView.GetSelectedRows()[i]);
        //        oXMLNode = oXmlDocument.CreateNode(XmlNodeType.Element, "List", string.Empty);
        //        oXMLMainNode.AppendChild(oXMLNode);
        //        Common.AddXMLAttribute(oXmlDocument, oXMLNode, "ID", ReportView.GetRowCellValue(row, "MemberId").ToString());
        //        Common.AddXMLAttribute(oXmlDocument, oXMLNode, "MemberName", ReportView.GetRowCellValue(row, "FullName").ToString());

        //    }


        //}



        #region CloseWinPart

        public event EventHandler CloseWinPart;

        protected void Close()
        {
            if (CloseWinPart != null)
                CloseWinPart(this, EventArgs.Empty);

            Dispose();

        }
        #endregion

        #region CurrentPrincipalChanged

        public event EventHandler CurrentPrincipalChanged;

        protected internal virtual void OnCurrentPrincipalChanged(
          object sender, EventArgs e)
        {
            if (CurrentPrincipalChanged != null)
                CurrentPrincipalChanged(sender, e);
        }

        #endregion

        public event EventHandler CommonAddMemberByID;
        protected internal virtual void OnCommonAddMemberByID(object sender, EventArgs e)
        {
            if (CommonAddMemberByID != null)
                CommonAddMemberByID(sender, e);
        }


        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportView.SelectAll();
        }

        protected void m_ShowGridMenu(object sender, DevExpress.XtraGrid.Views.Grid.GridMenuEventArgs e)
        {

            GridView view = sender as GridView;

            GridHitInfo hitInfo = view.CalcHitInfo(e.Point);

            if (hitInfo.InRow)
            {

                view.FocusedRowHandle = hitInfo.RowHandle;

                this.contextMenuStrip1.Show(view.GridControl, e.Point);

            }

        }

        private void unselectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ReportView.RowCount; i++)
                ReportView.UnselectRow(i);
        }

        private void reverseSelectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ReportView.RowCount; i++)
            {
                if (ReportView.IsRowSelected(i))
                    ReportView.UnselectRow(i);
                else
                    ReportView.SelectRow(i);
            }
        }
    }

}
