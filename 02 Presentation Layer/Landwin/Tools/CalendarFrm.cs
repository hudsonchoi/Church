using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace LandWin.Tools
{
    public partial class CalendarFrm : DevExpress.XtraEditors.XtraForm
    {

        private DateTime  _selectedDate;
        public DateTime SelectedDate { get { return _selectedDate; } }
        public CalendarFrm()
        {
            InitializeComponent();
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        }

        public CalendarFrm(string date, int X, int Y)
        {
            InitializeComponent();
            this.Location = new Point(X, Y);
            if (DateTime.TryParse(date, out _selectedDate))
            {
                monthCalendar1.SetDate(_selectedDate);
                this.txt_SetDateTime.Text = date;
            }


        }
        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            this.txt_SetDateTime.Text = e.Start.ToString("MM/dd/yyyy");
            _selectedDate = e.Start.Date;
        }

        private void txt_SetDateTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                DateTime date ;
                if (DateTime.TryParse(txt_SetDateTime.Text,out date))
                {
                    e.Handled = true;
                    _selectedDate = date;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    this.txt_SetDateTime.Text = "";
                    _selectedDate = new DateTime();
                    this.txt_SetDateTime.Focus();
                }
            }
        }

        private void bt_Ok_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_SetDateTime.Text))
            {
                  DateTime date ;
                  if (DateTime.TryParse(txt_SetDateTime.Text, out date))
                  {
                      _selectedDate = date;
                      this.DialogResult = DialogResult.OK;
                  }
         
                this.Close();
            }
        }

        private void bt_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CalendarFrm_Load(object sender, EventArgs e)
        {
            this.txt_SetDateTime.Focus();
        }
    }
}