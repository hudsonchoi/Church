using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using System.Configuration;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors;
using System.Windows.Forms;

namespace LandWin.Shared
{
    public class UtiltyDevExpress
    {
        public static void Calendar(object sendor)
        {
            if (typeof(TextEdit).Equals(sendor.GetType()))
            {
                TextEdit edit = (TextEdit)sendor;
                string date = edit.Text;
                Point pt1 = edit.Parent.PointToScreen(edit.Location);
                Tools.CalendarFrm dlg = new Tools.CalendarFrm(date, pt1.X, pt1.Y + edit.Height);
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    edit.Text = dlg.SelectedDate.ToString("MM/dd/yyyy");
                    edit.Focus();
                    SendKeys.Send("{TAB}");
                }
                else
                {
                    edit.Text = date;
                    edit.Focus();
                }
            }
            else if (typeof(DevExpress.XtraBars.BarEditItem).Equals(sendor.GetType()))
            {
                DevExpress.XtraBars.BarEditItem edit = (DevExpress.XtraBars.BarEditItem)sendor;
                string date = edit.EditValue.ToString();

                Tools.CalendarFrm dlg = new Tools.CalendarFrm();
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    edit.EditValue = dlg.SelectedDate.ToString("MM/dd/yyyy");
                   
                    SendKeys.Send("{TAB}");
                }
                else
                {
                    edit.EditValue = date;
                   
                }
            }
        }

        public static string GetStringSelectedRow(GridView view, string propertyname)
        {
            StringBuilder str = new StringBuilder();
            for (int i = 0; i < view.SelectedRowsCount; i++)
            {
                int row = (view.GetSelectedRows()[i]);
                str.Append(view.GetRowCellValue(row, propertyname).ToString()).Append(",");
            }
            return str.ToString();
        }

        public static object[] SelectedRows(GridView view)
        {

            object[] rows = new object[view.SelectedRowsCount];

            for (int i = 0; i < view.SelectedRowsCount; i++)

                rows[i] = view.GetRow(view.GetSelectedRows()[i]);
            return rows;
        }
        public static void InitGridView(GridView view, string viewName)
        {
            if(string.IsNullOrEmpty(viewName))
                return;

            if(view == null)
                return;

            if (File.Exists(String.Format(@"{0}\{1}.xml", ConfigurationManager.AppSettings["DirLayout"], viewName)))
                view.RestoreLayoutFromXml(String.Format(@"{0}\{1}.xml", ConfigurationManager.AppSettings["DirLayout"], viewName));

            DefaultGridView(view);

        }

        public static void ShowGroupPanel(GridView view)
        {
            view.OptionsView.ShowGroupPanel = view.OptionsView.ShowGroupPanel ? false : true;
        }

        public static void ShowAutoFilterRow(GridView view)
        {
            view.OptionsView.ShowAutoFilterRow = view.OptionsView.ShowAutoFilterRow ? false : true;
        }
        protected static void DefaultGridView(GridView view)
        {
            view.Appearance.ColumnFilterButton.BackColor = Color.Silver;
            view.Appearance.ColumnFilterButton.BackColor2 = Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            view.Appearance.ColumnFilterButton.BorderColor = Color.Silver;
            view.Appearance.ColumnFilterButton.ForeColor = Color.Gray;
            view.Appearance.ColumnFilterButton.Options.UseBackColor = true;
            view.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
            view.Appearance.ColumnFilterButton.Options.UseForeColor = true;
            view.Appearance.ColumnFilterButtonActive.BackColor = Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            view.Appearance.ColumnFilterButtonActive.BackColor2 = Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(223)))), ((int)(((byte)(223)))));
            view.Appearance.ColumnFilterButtonActive.BorderColor = Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            view.Appearance.ColumnFilterButtonActive.ForeColor = Color.Blue;
            view.Appearance.ColumnFilterButtonActive.Options.UseBackColor = true;
            view.Appearance.ColumnFilterButtonActive.Options.UseBorderColor = true;
            view.Appearance.ColumnFilterButtonActive.Options.UseForeColor = true;
            view.Appearance.Empty.BackColor = Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            view.Appearance.Empty.Options.UseBackColor = true;
            view.Appearance.EvenRow.BackColor = Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(223)))), ((int)(((byte)(223)))));
            view.Appearance.EvenRow.BackColor2 = Color.GhostWhite;
            view.Appearance.EvenRow.Font = new Font("Malgun Gothic", 9F);
            view.Appearance.EvenRow.ForeColor = Color.Black;
            view.Appearance.EvenRow.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            view.Appearance.EvenRow.Options.UseBackColor = true;
            view.Appearance.EvenRow.Options.UseFont = true;
            view.Appearance.EvenRow.Options.UseForeColor = true;
            view.Appearance.FilterCloseButton.BackColor = Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            view.Appearance.FilterCloseButton.BackColor2 = Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(170)))), ((int)(((byte)(225)))));
            view.Appearance.FilterCloseButton.BorderColor = Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            view.Appearance.FilterCloseButton.ForeColor = Color.Black;
            view.Appearance.FilterCloseButton.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            view.Appearance.FilterCloseButton.Options.UseBackColor = true;
            view.Appearance.FilterCloseButton.Options.UseBorderColor = true;
            view.Appearance.FilterCloseButton.Options.UseForeColor = true;
            view.Appearance.FilterPanel.BackColor = Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(80)))), ((int)(((byte)(135)))));
            view.Appearance.FilterPanel.BackColor2 = Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            view.Appearance.FilterPanel.ForeColor = Color.White;
            view.Appearance.FilterPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            view.Appearance.FilterPanel.Options.UseBackColor = true;
            view.Appearance.FilterPanel.Options.UseForeColor = true;
            view.Appearance.FixedLine.BackColor = Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(58)))), ((int)(((byte)(58)))));
            view.Appearance.FixedLine.Options.UseBackColor = true;
            view.Appearance.FocusedCell.BackColor = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(225)))));
            view.Appearance.FocusedCell.Font = new Font("Malgun Gothic", 9F);
            view.Appearance.FocusedCell.ForeColor = Color.Black;
            view.Appearance.FocusedCell.Options.UseBackColor = true;
            view.Appearance.FocusedCell.Options.UseFont = true;
            view.Appearance.FocusedCell.Options.UseForeColor = true;
            view.Appearance.FocusedRow.BackColor = Color.Navy;
            view.Appearance.FocusedRow.BackColor2 = Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(178)))));
            view.Appearance.FocusedRow.Font = new Font("Malgun Gothic", 9F);
            view.Appearance.FocusedRow.ForeColor = Color.White;
            view.Appearance.FocusedRow.Options.UseBackColor = true;
            view.Appearance.FocusedRow.Options.UseFont = true;
            view.Appearance.FocusedRow.Options.UseForeColor = true;
            view.Appearance.FooterPanel.BackColor = Color.Silver;
            view.Appearance.FooterPanel.BorderColor = Color.Silver;
            view.Appearance.FooterPanel.Font = new Font("Malgun Gothic", 9F);
            view.Appearance.FooterPanel.ForeColor = Color.Black;
            view.Appearance.FooterPanel.Options.UseBackColor = true;
            view.Appearance.FooterPanel.Options.UseBorderColor = true;
            view.Appearance.FooterPanel.Options.UseFont = true;
            view.Appearance.FooterPanel.Options.UseForeColor = true;
            view.Appearance.GroupButton.BackColor = Color.Silver;
            view.Appearance.GroupButton.BorderColor = Color.Silver;
            view.Appearance.GroupButton.ForeColor = Color.Black;
            view.Appearance.GroupButton.Options.UseBackColor = true;
            view.Appearance.GroupButton.Options.UseBorderColor = true;
            view.Appearance.GroupButton.Options.UseForeColor = true;
            view.Appearance.GroupFooter.BackColor = Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(202)))), ((int)(((byte)(202)))));
            view.Appearance.GroupFooter.BorderColor = Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(202)))), ((int)(((byte)(202)))));
            view.Appearance.GroupFooter.ForeColor = Color.Black;
            view.Appearance.GroupFooter.Options.UseBackColor = true;
            view.Appearance.GroupFooter.Options.UseBorderColor = true;
            view.Appearance.GroupFooter.Options.UseForeColor = true;
            view.Appearance.GroupPanel.BackColor = Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(110)))), ((int)(((byte)(165)))));
            view.Appearance.GroupPanel.BackColor2 = Color.White;
            view.Appearance.GroupPanel.Font = new Font("Malgun Gothic", 9F);
            view.Appearance.GroupPanel.ForeColor = Color.White;
            view.Appearance.GroupPanel.Options.UseBackColor = true;
            view.Appearance.GroupPanel.Options.UseFont = true;
            view.Appearance.GroupPanel.Options.UseForeColor = true;
            view.Appearance.GroupRow.BackColor = Color.Gray;
            view.Appearance.GroupRow.Font = new Font("Malgun Gothic", 9F);
            view.Appearance.GroupRow.ForeColor = Color.Silver;
            view.Appearance.GroupRow.Options.UseBackColor = true;
            view.Appearance.GroupRow.Options.UseFont = true;
            view.Appearance.GroupRow.Options.UseForeColor = true;
            view.Appearance.HeaderPanel.BackColor = Color.Silver;
            view.Appearance.HeaderPanel.BorderColor = Color.Silver;
            view.Appearance.HeaderPanel.Font = new Font("Malgun Gothic", 9F);
            view.Appearance.HeaderPanel.ForeColor = Color.Black;
            view.Appearance.HeaderPanel.Options.UseBackColor = true;
            view.Appearance.HeaderPanel.Options.UseBorderColor = true;
            view.Appearance.HeaderPanel.Options.UseFont = true;
            view.Appearance.HeaderPanel.Options.UseForeColor = true;
            view.Appearance.HideSelectionRow.BackColor = Color.Gray;
            view.Appearance.HideSelectionRow.Font = new Font("Malgun Gothic", 9F);
            view.Appearance.HideSelectionRow.ForeColor = Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            view.Appearance.HideSelectionRow.Options.UseBackColor = true;
            view.Appearance.HideSelectionRow.Options.UseFont = true;
            view.Appearance.HideSelectionRow.Options.UseForeColor = true;
            view.Appearance.HorzLine.BackColor = Color.Silver;
            view.Appearance.HorzLine.Options.UseBackColor = true;
            view.Appearance.OddRow.BackColor = Color.White;
            view.Appearance.OddRow.BackColor2 = Color.White;
            view.Appearance.OddRow.Font = new Font("Malgun Gothic", 9F);
            view.Appearance.OddRow.ForeColor = Color.Black;
            view.Appearance.OddRow.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
            view.Appearance.OddRow.Options.UseBackColor = true;
            view.Appearance.OddRow.Options.UseFont = true;
            view.Appearance.OddRow.Options.UseForeColor = true;
            view.Appearance.Preview.BackColor = Color.White;
            view.Appearance.Preview.Font = new Font("Malgun Gothic", 9F);
            view.Appearance.Preview.ForeColor = Color.Navy;
            view.Appearance.Preview.Options.UseBackColor = true;
            view.Appearance.Preview.Options.UseFont = true;
            view.Appearance.Preview.Options.UseForeColor = true;
            view.Appearance.Row.BackColor = Color.White;
            view.Appearance.Row.Font = new Font("Malgun Gothic", 9F);
            view.Appearance.Row.ForeColor = Color.Black;
            view.Appearance.Row.Options.UseBackColor = true;
            view.Appearance.Row.Options.UseFont = true;
            view.Appearance.Row.Options.UseForeColor = true;
            view.Appearance.RowSeparator.BackColor = Color.White;
            view.Appearance.RowSeparator.BackColor2 = Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            view.Appearance.RowSeparator.Options.UseBackColor = true;
            view.Appearance.SelectedRow.BackColor = Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(138)))));
            view.Appearance.SelectedRow.Font = new Font("Malgun Gothic", 9F);
            view.Appearance.SelectedRow.ForeColor = Color.White;
            view.Appearance.SelectedRow.Options.UseBackColor = true;
            view.Appearance.SelectedRow.Options.UseFont = true;
            view.Appearance.SelectedRow.Options.UseForeColor = true;
            view.Appearance.TopNewRow.Font = new Font("Malgun Gothic", 9F);
            view.Appearance.TopNewRow.Options.UseFont = true;
            view.Appearance.VertLine.BackColor = Color.Silver;
            view.Appearance.VertLine.Options.UseBackColor = true;
            view.OptionsSelection.EnableAppearanceFocusedCell = false;
            view.OptionsSelection.MultiSelect = true;
            view.OptionsView.ColumnAutoWidth = false;
            view.OptionsView.EnableAppearanceEvenRow = true;
            view.OptionsView.EnableAppearanceOddRow = true;
            view.OptionsView.ShowFooter = true;
            view.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(CustomDrawRowIndicator);
            
           
        }

        public static void CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
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
            view.IndicatorWidth = (int)stringSize.Width + 20;
        }
    }
}
