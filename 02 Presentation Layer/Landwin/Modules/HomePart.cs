using System;
using System.ComponentModel;
using System.Text;
using System.Net;
using System.IO;
using System.Configuration;
using System.Windows.Forms;
using _entity = Dothan.Library;
using DevExpress.XtraNavBar;
using DevExpress.XtraGrid.Views.Grid;
using System.Collections.Generic;
using DevExpress.XtraGrid.Views.Base;
using System.Threading;

namespace LandWin.Modules
{
    public partial class HomePart : WinPart 
    {
        private delegate void DataLoadDelegate();
        private const string _szName = "HomeGridview2";
        private _entity.bizMember.MemberList  _list;

        public HomePart()
        {
            InitializeComponent();
            //InitGridView(advBandedGridView1);
            advBandedGridView1.OptionsView.ShowFooter = false;
            advBandedGridView1.OptionsView.RowAutoHeight = true;
            advBandedGridView1.DoubleClick += new System.EventHandler(GridViewRow_DoubleClick);
            barEditItem1.EditValue = repositoryItemComboBox1.Items[0];
            barEditItem2.EditValue = repositoryItemComboBox2.Items[0];
            LoadData(DateTime.Today.AddDays(-14), DateTime.Today.AddDays(1));
         //   repositoryItemComboBox1.OwnerEdit.SelectedIndex = 0;
        }


        protected internal override object GetIdValue()
        {
            return "HomePage";
        }

        public override string LayoutName { get { return _szName; } }
        public override GridView ReportView { get { return advBandedGridView1; } }
        public override bool IsReadOnly
        {
            get
            {
                return true;
            }
        }

        private void LoadData(DateTime from, DateTime to)
        {
            try
            {
                _list = _entity.bizMember.MemberList.Get(from.ToString(), to.ToString());
                this.memberListBindingSource.DataSource = _list;
                this.advBandedGridView1.RefreshData();

                labelControl1.Text = string.Format(" New Members ( Reg. Date {0} To {1} ) | Total Count : {2} ", from.ToString("MM/dd/yyyy"), to.ToString("MM/dd/yyyy"), _list.Count);
            }
            catch (Dothan.DataPortalException ex)
            {
                if (ex.BusinessException is System.Data.SqlClient.SqlException)
                {
                    Shared.Utility.ErrorLogging(Properties.Resources.ErrorMessage_SqlException, ex.BusinessException.ToString(), "Error");
                    this.Close();
                }
                else
                {
                    Shared.Utility.ErrorLogging(Properties.Resources.ErrorMessage_General, ex.BusinessException.ToString(), "Error");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Shared.Utility.ErrorLogging(Properties.Resources.ErrorMessage_General, ex.ToString(), "Error");
                this.Close();

            }

        }

        private void gridView1_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
        {

            if (_list == null) return;
            if (e.Column.Name == "colPhoto" && e.IsGetData)
            {
                int id = (int)advBandedGridView1.GetRowCellValue(e.RowHandle, colID);
                e.Value = Shared.Utility.LoadImage(id);
            }
        }



       private void ShowGroupView(bool groupview)
       {
           GridView view = advBandedGridView1;
           view.BeginSort();
           view.ClearGrouping();
           if (groupview)
           {
               view.Columns["FamilyName"].GroupIndex = 0;
           }
          view.EndSort();
       }



        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MainForm.Instance.ShowMemberInfo(0);
        }

        private void repositoryItemComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.ComboBoxEdit item = (DevExpress.XtraEditors.ComboBoxEdit)sender;
            switch (item.SelectedIndex)
            {
                case 0:
                    LoadData(DateTime.Today.AddDays(-14), DateTime.Today.AddDays(1));
                    break;
                case 1:
                    LoadData(DateTime.Today.AddMonths(-1), DateTime.Today.AddDays(1));
                    break;
                case 2:
                    LoadData(DateTime.Today.AddMonths(-6), DateTime.Today.AddDays(1));
                    break;
                case 3:
                    LoadData(new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1), DateTime.Today.AddDays(1));
                    break;
                case 4:
                    LoadData(new DateTime(DateTime.Today.Year, 1, 1), DateTime.Today.AddDays(1));
                    break;
                case 5:
                    LoadData(new DateTime(DateTime.Today.Year - 1, 1, 1), new DateTime(DateTime.Today.Year - 1, 12, 31));
                    break;
            }
        }

        private void repositoryItemComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
              DevExpress.XtraEditors.ComboBoxEdit item = (DevExpress.XtraEditors.ComboBoxEdit)sender;
              switch (item.SelectedIndex)
              {
                  case 0:
                      ShowGroupView(false);
                      break;
                  case 1:
                      ShowGroupView(true);
                      break;
              }
        }
    }
}
