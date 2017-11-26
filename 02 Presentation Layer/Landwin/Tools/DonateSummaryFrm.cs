using System;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using Dothan.Library.bizDonate;
using System.Text.RegularExpressions;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;

namespace LandWin.Tools
{
    public partial class DonateSummaryFrm : Form
    {
       
        private DonateBook _book;
        private decimal total;

        public DonateBook Book
        {
            get { return _book; }
        }

        public DonateSummaryFrm(DonateBook book)
        {
            InitializeComponent();
            _book = book;
            _book.BeginEdit();
            this.donateBookBindingSource.DataSource = _book;
            _book.PropertyChanged += new PropertyChangedEventHandler(DonateBook_PropertyChanged);

            if( !_book.IsNew)
                this.rgSelectType.SelectedIndex = CheckedButton(_book.Detail);
            
            this.txtTotal.Text = CalAmount().ToString("c");
        }
     
        private decimal CalAmount()
        {
            decimal amount = 0;
            amount += (decimal)_book.Checks;
            amount += (decimal)_book.Hundred * 100;
            amount += (decimal)_book.Fifty * 50;
            amount += (decimal)_book.Twenty * 20;
            amount += (decimal)_book.Ten * 10;
            amount += (decimal)_book.Five * 5;
            amount += (decimal)_book.One * 1;
            amount += _book.Coins;
            return amount;

        }
        private void DonateBook_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            txtTotal.Text = CalAmount().ToString("c");
            
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            this.donateBookBindingSource.EndEdit();
            if (ValidateAmount())
            {
                _book.Detail = ToGetSummary();

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("It does not match a total amount");
            }
        }

        private bool ValidateAmount()
        {
            bool result = false;
            if (CalAmount() == _book.Amount)
                result = true;

            return result;
        }

        private string ToGetSummary()
        {
            StringBuilder str = new StringBuilder();

            switch (this.rgSelectType.SelectedIndex)
            {
                case 0:
                    str.Append("Cash Only(X) Check Only( ) Mix Only( )");
                    break;
                case 1:
                    str.Append("Cash Only( ) Check Only(X) Mix Only( )");
                    break;
                case 2:
                    str.Append("Cash Only( ) Check Only( ) Mix Only(X)");
                    break;

            }
            return str.ToString();
        }

        private int CheckedButton(string str)
        {
           int result = 0;
           if (str.Contains("Cash Only(X)"))
           {
               result = 0;
           }
           else if (str.Contains("Check Only(X)"))
           {
               result = 1;
           }
           else if (str.Contains("Mix Only(X)"))
           {
               result =2;
           }
           return result;
        }

        private void tb_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void mDonateBook_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            txtTotal.Text = CalAmount().ToString();
        }
    



        private void rgSelectType_SelectedIndexChanged(object sender, EventArgs e)
        {
            RadioGroup edit = sender as RadioGroup;
            switch (edit.SelectedIndex)
            {
                case 0:
                    this.cachControlGroup.Expanded = true;
                    this.checkControlGroup.Expanded = false;
                    break;
                case 1:
                    this.cachControlGroup.Expanded = false;
                    this.checkControlGroup.Expanded = true;
                    break;
                case 2:
                    this.cachControlGroup.Expanded = true;
                    this.checkControlGroup.Expanded = true;
                    break;

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }       
    }
}
