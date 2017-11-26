using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Dothan.Library;
using LandWin.Properties;

namespace LandWin
{
    public partial class DonateSummaryFrm : Form
    {
        private DonateBook _book;
        private decimal total=0;

        public DonateBook Book
        {
            get { return _book; }
        }

        public DonateSummaryFrm(DonateBook book)
        {
            InitializeComponent();
            _book = book;
            this.donateBookBindingSource.DataSource = _book;

            if (_book.Amount != _book.Checks)
            {
                this.tb_cashsummary.Enabled = true;
            }
            this.checksTextBox.Enabled = false;
        }
        private void txtInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {

                e.Handled = true;
                SendKeys.Send("{TAB}");

            }
        }
        private decimal CalAmount()
        {
            decimal amount = 0;
            amount += (decimal)this.hundredNumericUpDown.Value * 100;
            amount += ((decimal)this.fiftyNumericUpDown.Value * 50);
            amount += ((decimal)this.twentyNumericUpDown.Value * 20);
            amount += ((decimal)this.tenNumericUpDown.Value * 10);
            amount += ((decimal)this.fiveNumericUpDown.Value * 5);
            amount += ((decimal)this.oneNumericUpDown.Value * 1);
            amount += Convert.ToDecimal(this.coinsTextBox.Text);
            return amount;

        }
        private void tb_ok_Click(object sender, EventArgs e)
        {

            StringBuilder str = new StringBuilder();
            total = Convert.ToDecimal(this.checksTextBox.Text);
            total += (decimal)this.hundredNumericUpDown.Value * 100;
            total += ((decimal)this.fiftyNumericUpDown.Value * 50);
            total += ((decimal)this.twentyNumericUpDown.Value * 20);
            total += ((decimal)this.tenNumericUpDown.Value * 10);
            total += ((decimal)this.fiveNumericUpDown.Value * 5);
            total += ((decimal)this.oneNumericUpDown.Value * 1);
            total += Convert.ToDecimal(this.coinsTextBox.Text);



            if (_book.Amount.Equals(total))
            {
                if (this.tb_cash.Checked)
                    str.Append("Cash Only(X)  ");
                else
                    str.Append("Cash Only( )  ");
                if (this.tb_check.Checked)
                    str.Append("Check Only(X)  ");
                else
                    str.Append("Check Only( )  ");

                if (this.tb_mix.Checked)
                    str.Append("Mix Only(X)  ");
                else
                    str.Append("Mix Only( ) ,");

                _book.Detail = str.ToString();

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {

                MessageBox.Show(Resources.DonateAmountError);
            }
        }

        private void tb_cancel_Click(object sender, EventArgs e)
        {
            this.Close();

        }
        private void Amount_ValueChanged(object sender, EventArgs e)
        {
            this.tb_amount.Text = CalAmount().ToString();
        }
    }
}
