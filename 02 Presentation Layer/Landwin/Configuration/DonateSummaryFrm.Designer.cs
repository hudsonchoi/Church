namespace LandWin
{
    partial class DonateSummaryFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label coinsLabel;
            System.Windows.Forms.Label checksLabel;
            this.tb_ok = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_cash = new System.Windows.Forms.RadioButton();
            this.tb_check = new System.Windows.Forms.RadioButton();
            this.tb_mix = new System.Windows.Forms.RadioButton();
            this.tb_types = new System.Windows.Forms.GroupBox();
            this.tb_cashsummary = new System.Windows.Forms.GroupBox();
            this.coinsTextBox = new System.Windows.Forms.TextBox();
            this.donateBookBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.oneNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.tenNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.twentyNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.fiveNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.fiftyNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.hundredNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.tb_cancel = new System.Windows.Forms.Button();
            this.checksTextBox = new System.Windows.Forms.TextBox();
            this.tb_amount = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            coinsLabel = new System.Windows.Forms.Label();
            checksLabel = new System.Windows.Forms.Label();
            this.tb_types.SuspendLayout();
            this.tb_cashsummary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.donateBookBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.oneNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tenNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.twentyNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fiveNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fiftyNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hundredNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // coinsLabel
            // 
            coinsLabel.AutoSize = true;
            coinsLabel.Location = new System.Drawing.Point(19, 120);
            coinsLabel.Name = "coinsLabel";
            coinsLabel.Size = new System.Drawing.Size(41, 15);
            coinsLabel.TabIndex = 23;
            coinsLabel.Text = "Coins:";
            // 
            // checksLabel
            // 
            checksLabel.AutoSize = true;
            checksLabel.Location = new System.Drawing.Point(40, 276);
            checksLabel.Name = "checksLabel";
            checksLabel.Size = new System.Drawing.Size(50, 15);
            checksLabel.TabIndex = 29;
            checksLabel.Text = "Checks:";
            // 
            // tb_ok
            // 
            this.tb_ok.Location = new System.Drawing.Point(43, 303);
            this.tb_ok.Name = "tb_ok";
            this.tb_ok.Size = new System.Drawing.Size(77, 23);
            this.tb_ok.TabIndex = 1;
            this.tb_ok.Text = "Ok";
            this.tb_ok.UseVisualStyleBackColor = true;
            this.tb_ok.Click += new System.EventHandler(this.tb_ok_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(39, 86);
            this.label5.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 15);
            this.label5.TabIndex = 16;
            this.label5.Text = "$5";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(143, 59);
            this.label4.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 15);
            this.label4.TabIndex = 15;
            this.label4.Text = "$10";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 59);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 15);
            this.label3.TabIndex = 14;
            this.label3.Text = "$20";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(143, 32);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 15);
            this.label2.TabIndex = 13;
            this.label2.Text = "$50";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 15);
            this.label1.TabIndex = 12;
            this.label1.Text = "$100";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(150, 86);
            this.label6.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 15);
            this.label6.TabIndex = 17;
            this.label6.Text = "$1";
            // 
            // tb_cash
            // 
            this.tb_cash.AutoSize = true;
            this.tb_cash.Location = new System.Drawing.Point(17, 21);
            this.tb_cash.Name = "tb_cash";
            this.tb_cash.Size = new System.Drawing.Size(80, 19);
            this.tb_cash.TabIndex = 24;
            this.tb_cash.TabStop = true;
            this.tb_cash.Text = "Cash Only";
            this.tb_cash.UseVisualStyleBackColor = true;
            // 
            // tb_check
            // 
            this.tb_check.AutoSize = true;
            this.tb_check.Location = new System.Drawing.Point(103, 21);
            this.tb_check.Name = "tb_check";
            this.tb_check.Size = new System.Drawing.Size(86, 19);
            this.tb_check.TabIndex = 25;
            this.tb_check.TabStop = true;
            this.tb_check.Text = "Check Only";
            this.tb_check.UseVisualStyleBackColor = true;
            // 
            // tb_mix
            // 
            this.tb_mix.AutoSize = true;
            this.tb_mix.Location = new System.Drawing.Point(195, 21);
            this.tb_mix.Name = "tb_mix";
            this.tb_mix.Size = new System.Drawing.Size(45, 19);
            this.tb_mix.TabIndex = 26;
            this.tb_mix.TabStop = true;
            this.tb_mix.Text = "Mix";
            this.tb_mix.UseVisualStyleBackColor = true;
            // 
            // tb_types
            // 
            this.tb_types.Controls.Add(this.tb_mix);
            this.tb_types.Controls.Add(this.tb_check);
            this.tb_types.Controls.Add(this.tb_cash);
            this.tb_types.Location = new System.Drawing.Point(21, 12);
            this.tb_types.Name = "tb_types";
            this.tb_types.Size = new System.Drawing.Size(256, 55);
            this.tb_types.TabIndex = 27;
            this.tb_types.TabStop = false;
            this.tb_types.Text = "Types";
            // 
            // tb_cashsummary
            // 
            this.tb_cashsummary.Controls.Add(this.tb_amount);
            this.tb_cashsummary.Controls.Add(this.label7);
            this.tb_cashsummary.Controls.Add(coinsLabel);
            this.tb_cashsummary.Controls.Add(this.coinsTextBox);
            this.tb_cashsummary.Controls.Add(this.oneNumericUpDown);
            this.tb_cashsummary.Controls.Add(this.tenNumericUpDown);
            this.tb_cashsummary.Controls.Add(this.twentyNumericUpDown);
            this.tb_cashsummary.Controls.Add(this.fiveNumericUpDown);
            this.tb_cashsummary.Controls.Add(this.fiftyNumericUpDown);
            this.tb_cashsummary.Controls.Add(this.hundredNumericUpDown);
            this.tb_cashsummary.Controls.Add(this.label4);
            this.tb_cashsummary.Controls.Add(this.label5);
            this.tb_cashsummary.Controls.Add(this.label3);
            this.tb_cashsummary.Controls.Add(this.label2);
            this.tb_cashsummary.Controls.Add(this.label1);
            this.tb_cashsummary.Controls.Add(this.label6);
            this.tb_cashsummary.Location = new System.Drawing.Point(21, 73);
            this.tb_cashsummary.Name = "tb_cashsummary";
            this.tb_cashsummary.Size = new System.Drawing.Size(256, 183);
            this.tb_cashsummary.TabIndex = 28;
            this.tb_cashsummary.TabStop = false;
            this.tb_cashsummary.Text = "Cash Summary";
            // 
            // coinsTextBox
            // 
            this.coinsTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.donateBookBindingSource, "Coins", true));
            this.coinsTextBox.Location = new System.Drawing.Point(65, 120);
            this.coinsTextBox.Name = "coinsTextBox";
            this.coinsTextBox.Size = new System.Drawing.Size(175, 21);
            this.coinsTextBox.TabIndex = 24;
            // 
            // donateBookBindingSource
            // 
            this.donateBookBindingSource.DataSource = typeof(Dothan.Library.DonateBook);
            // 
            // oneNumericUpDown
            // 
            this.oneNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.donateBookBindingSource, "One", true));
            this.oneNumericUpDown.Location = new System.Drawing.Point(177, 84);
            this.oneNumericUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.oneNumericUpDown.Name = "oneNumericUpDown";
            this.oneNumericUpDown.Size = new System.Drawing.Size(63, 21);
            this.oneNumericUpDown.TabIndex = 23;
            this.oneNumericUpDown.ValueChanged += new System.EventHandler(this.Amount_ValueChanged);
            // 
            // tenNumericUpDown
            // 
            this.tenNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.donateBookBindingSource, "Ten", true));
            this.tenNumericUpDown.Location = new System.Drawing.Point(177, 57);
            this.tenNumericUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.tenNumericUpDown.Name = "tenNumericUpDown";
            this.tenNumericUpDown.Size = new System.Drawing.Size(63, 21);
            this.tenNumericUpDown.TabIndex = 22;
            this.tenNumericUpDown.ValueChanged += new System.EventHandler(this.Amount_ValueChanged);
            // 
            // twentyNumericUpDown
            // 
            this.twentyNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.donateBookBindingSource, "Twenty", true));
            this.twentyNumericUpDown.Location = new System.Drawing.Point(65, 57);
            this.twentyNumericUpDown.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.twentyNumericUpDown.Name = "twentyNumericUpDown";
            this.twentyNumericUpDown.Size = new System.Drawing.Size(72, 21);
            this.twentyNumericUpDown.TabIndex = 21;
            this.twentyNumericUpDown.ValueChanged += new System.EventHandler(this.Amount_ValueChanged);
            // 
            // fiveNumericUpDown
            // 
            this.fiveNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.donateBookBindingSource, "Five", true));
            this.fiveNumericUpDown.Location = new System.Drawing.Point(65, 84);
            this.fiveNumericUpDown.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.fiveNumericUpDown.Name = "fiveNumericUpDown";
            this.fiveNumericUpDown.Size = new System.Drawing.Size(72, 21);
            this.fiveNumericUpDown.TabIndex = 20;
            this.fiveNumericUpDown.ValueChanged += new System.EventHandler(this.Amount_ValueChanged);
            // 
            // fiftyNumericUpDown
            // 
            this.fiftyNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.donateBookBindingSource, "Fifty", true));
            this.fiftyNumericUpDown.Location = new System.Drawing.Point(177, 30);
            this.fiftyNumericUpDown.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.fiftyNumericUpDown.Name = "fiftyNumericUpDown";
            this.fiftyNumericUpDown.Size = new System.Drawing.Size(63, 21);
            this.fiftyNumericUpDown.TabIndex = 19;
            this.fiftyNumericUpDown.ValueChanged += new System.EventHandler(this.Amount_ValueChanged);
            // 
            // hundredNumericUpDown
            // 
            this.hundredNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.donateBookBindingSource, "Hundred", true));
            this.hundredNumericUpDown.Location = new System.Drawing.Point(66, 30);
            this.hundredNumericUpDown.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.hundredNumericUpDown.Name = "hundredNumericUpDown";
            this.hundredNumericUpDown.Size = new System.Drawing.Size(71, 21);
            this.hundredNumericUpDown.TabIndex = 18;
            this.hundredNumericUpDown.ValueChanged += new System.EventHandler(this.Amount_ValueChanged);
            // 
            // tb_cancel
            // 
            this.tb_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.tb_cancel.Location = new System.Drawing.Point(186, 303);
            this.tb_cancel.Name = "tb_cancel";
            this.tb_cancel.Size = new System.Drawing.Size(85, 23);
            this.tb_cancel.TabIndex = 29;
            this.tb_cancel.Text = "Cancel";
            this.tb_cancel.UseVisualStyleBackColor = true;
            this.tb_cancel.Click += new System.EventHandler(this.tb_cancel_Click);
            // 
            // checksTextBox
            // 
            this.checksTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.donateBookBindingSource, "Checks", true));
            this.checksTextBox.Location = new System.Drawing.Point(96, 273);
            this.checksTextBox.Name = "checksTextBox";
            this.checksTextBox.Size = new System.Drawing.Size(175, 21);
            this.checksTextBox.TabIndex = 30;
            // 
            // tb_amount
            // 
            this.tb_amount.AutoSize = true;
            this.tb_amount.Location = new System.Drawing.Point(96, 155);
            this.tb_amount.Name = "tb_amount";
            this.tb_amount.Size = new System.Drawing.Size(14, 15);
            this.tb_amount.TabIndex = 34;
            this.tb_amount.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 155);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 15);
            this.label7.TabIndex = 33;
            this.label7.Text = "Total Cash:";
            // 
            // FrmCash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 338);
            this.Controls.Add(checksLabel);
            this.Controls.Add(this.checksTextBox);
            this.Controls.Add(this.tb_cancel);
            this.Controls.Add(this.tb_cashsummary);
            this.Controls.Add(this.tb_ok);
            this.Controls.Add(this.tb_types);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FrmCash";
            this.Text = "헌금 Summary";
            this.tb_types.ResumeLayout(false);
            this.tb_types.PerformLayout();
            this.tb_cashsummary.ResumeLayout(false);
            this.tb_cashsummary.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.donateBookBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.oneNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tenNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.twentyNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fiveNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fiftyNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hundredNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        internal System.Windows.Forms.RadioButton tb_cash;
        internal System.Windows.Forms.RadioButton tb_check;
        internal System.Windows.Forms.RadioButton tb_mix;
        private System.Windows.Forms.GroupBox tb_types;
        internal System.Windows.Forms.Button tb_ok;
        internal System.Windows.Forms.GroupBox tb_cashsummary;
        private System.Windows.Forms.TextBox coinsTextBox;
        private System.Windows.Forms.BindingSource donateBookBindingSource;
        private System.Windows.Forms.NumericUpDown oneNumericUpDown;
        private System.Windows.Forms.NumericUpDown tenNumericUpDown;
        private System.Windows.Forms.NumericUpDown twentyNumericUpDown;
        private System.Windows.Forms.NumericUpDown fiveNumericUpDown;
        private System.Windows.Forms.NumericUpDown fiftyNumericUpDown;
        private System.Windows.Forms.NumericUpDown hundredNumericUpDown;
        internal System.Windows.Forms.Button tb_cancel;
        private System.Windows.Forms.TextBox checksTextBox;
        private System.Windows.Forms.Label tb_amount;
        private System.Windows.Forms.Label label7;
    }
}