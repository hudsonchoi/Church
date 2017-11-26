using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using System.Collections;
using Excel = Microsoft.Office.Interop.Excel;

namespace LandWin.Tools
{
    public partial class ImportFromExcelFrm : DevExpress.XtraEditors.XtraForm
    {
        private string _list = string.Empty;

        public string MemberList
        {
            get
            {
                return _list;
            }
        }
        
        public ImportFromExcelFrm()
        {
            InitializeComponent();
        }

         private Dictionary<int, string> _columnlist = new Dictionary<int, string>();

        private List<string[]> parseCSV(string path)
        {
            List<string[]> parsedData = new List<string[]>();

            using (StreamReader readFile = new StreamReader(path))
            {
                string line;
                string[] row;

                while ((line = readFile.ReadLine()) != null)
                {
                    row = line.Split(',');
                    parsedData.Add(row);
                }
            }

            return parsedData;
        }

        private void ProcessExcel(string filename)
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;

            var missing = System.Reflection.Missing.Value;

            xlApp = new Excel.ApplicationClass();
            xlWorkBook = xlApp.Workbooks.Open(filename, false, true, missing, missing, missing, true, Excel.XlPlatform.xlWindows, '\t', false, false, 0, false, true, 0);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            Excel.Range xlRange = xlWorkSheet.UsedRange;
            Array myValues = (Array)xlRange.Cells.Value2;

            int vertical = myValues.GetLength(0);
            int horizontal = myValues.GetLength(1);

            DataTable dt = new DataTable();

            // must start with index = 1 
            // get header information 
            for (int i = 1; i <= horizontal; i++)
            {
                if (myValues.GetValue(1, i) !=null)
                    dt.Columns.Add(new DataColumn(myValues.GetValue(1, i).ToString()));
                else
                    dt.Columns.Add(new DataColumn(string.Format("Blank{0}",i)));
            }

            // Get the row information 
            for (int a = 2; a <= vertical; a++)
            {
                object[] poop = new object[horizontal];
                for (int b = 1; b <= horizontal; b++)
                {
                    if (myValues.GetValue(a, b) == null)
                        poop[b - 1] = "";
                    else
                        poop[b - 1] = myValues.GetValue(a, b);
                }
                DataRow row = dt.NewRow();
                row.ItemArray = poop;
                dt.Rows.Add(row);
            }

            // assign table to default data grid view 
            this.gridControl1.DataSource = dt;

            xlWorkBook.Close(true, missing, missing);
            xlApp.Quit();

            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);
            BindingColumn();
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Unable to release the Object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }



        private void BindingColumn()
        {
            if (this.gridView1.Columns.Count == 0) return;
            
                foreach (DevExpress.XtraGrid.Columns.GridColumn colum in this.gridView1.Columns)
                {
                  
                    _columnlist.Add(colum.AbsoluteIndex, colum.Name);
                }

                try
                {
                   
                    this.rItemColumn.Properties.ValueMember = "Key";
                    this.rItemColumn.Properties.DisplayMember = "Value";
                    this.rItemColumn.Properties.DataSource = new BindingSource(_columnlist, null);
                    this.rItemColumn.EditValue = 1;


                }
                catch (Dothan.DataPortalException ex)
                {
                    MessageBox.Show(ex.BusinessException.ToString(),
                      "Error saving", MessageBoxButtons.OK,
                      MessageBoxIcon.Exclamation);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(),
                      "Error Saving", MessageBoxButtons.OK,
                      MessageBoxIcon.Exclamation);
                }
            
        }


        private bool Validation()
        {
            bool result = false;
            if ((int)this.rItemColumn.EditValue > -1)
                    result = true;
            
            return result;
        }
        private bool HasDuplicates(int[] arrayList)
        {
            List<int> vals = new List<int>();
            bool returnValue = false;
            foreach (int s in arrayList)
            {
                if (vals.Contains(s))
                {
                    returnValue = true;
                    break;
                }
                vals.Add(s);
            }

            return returnValue;
        }


        private void rLoadfile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialogCSV = new OpenFileDialog();

            openFileDialogCSV.InitialDirectory = Application.ExecutablePath.ToString();
            openFileDialogCSV.Filter = "Excel files (*.xls)|*.xlsx|All files (*.*)|*.*";
            openFileDialogCSV.FilterIndex = 1;
            openFileDialogCSV.RestoreDirectory = true;

            if (openFileDialogCSV.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    this.rFileName.Text = openFileDialogCSV.FileName.ToString();
                    ProcessExcel(openFileDialogCSV.FileName.ToString());

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

            }
        }

        private int ConvertID(string id)
        {
            int result;


            if (int.TryParse(id, out result))
                return result;
            else
                return 0;
        }
 
        private void GetSelectedMemberID()
        {
            if (this.gridView1.SelectedRowsCount == 0) return;
            ArrayList list = new ArrayList();
            StringBuilder str = new StringBuilder();
            for (int i = 0; i < gridView1.SelectedRowsCount; i++)
            {
                DataRow row = gridView1.GetDataRow(gridView1.GetSelectedRows()[i]);
                
                int id = ConvertID(row[(int)rItemColumn.EditValue].ToString());
                if (id != 0 && !list.Contains(id))
                    list.Add(id);
            }
            foreach (int item in list)
                str.Append(item.ToString()).Append(',');

            _list = str.ToString();
            
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void rCancel_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rOK_Click(object sender, EventArgs e)
        {
            if (Validation())
            {

                this.gridView1.SelectAll();
                GetSelectedMemberID();
                
            }
            else
            {
                MessageBox.Show("Please check a selected columns");
            }
        }

        private void btnSelectImport_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                GetSelectedMemberID();
            }
            else
            {
                MessageBox.Show("Please check a selected columns");
            }
        }
    }
}