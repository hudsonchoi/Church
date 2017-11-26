namespace LandWin.Tools
{
    partial class CalendarFrm
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
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.txt_SetDateTime = new DevExpress.XtraEditors.TextEdit();
            this.bt_Ok = new DevExpress.XtraEditors.SimpleButton();
            this.bt_Cancel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txt_SetDateTime.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(18, 44);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 1;
            this.monthCalendar1.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateSelected);
            // 
            // txt_SetDateTime
            // 
            this.txt_SetDateTime.Location = new System.Drawing.Point(18, 12);
            this.txt_SetDateTime.Name = "txt_SetDateTime";
            this.txt_SetDateTime.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txt_SetDateTime.Properties.Appearance.Options.UseFont = true;
            this.txt_SetDateTime.Properties.NullText = "MM/dd/yyyy";
            this.txt_SetDateTime.Size = new System.Drawing.Size(227, 21);
            this.txt_SetDateTime.TabIndex = 0;
            this.txt_SetDateTime.TabStop = false;
            this.txt_SetDateTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_SetDateTime_KeyPress);
            // 
            // bt_Ok
            // 
            this.bt_Ok.Location = new System.Drawing.Point(18, 218);
            this.bt_Ok.Name = "bt_Ok";
            this.bt_Ok.Size = new System.Drawing.Size(75, 23);
            this.bt_Ok.TabIndex = 2;
            this.bt_Ok.Text = "OK";
            this.bt_Ok.Click += new System.EventHandler(this.bt_Ok_Click);
            // 
            // bt_Cancel
            // 
            this.bt_Cancel.Location = new System.Drawing.Point(170, 218);
            this.bt_Cancel.Name = "bt_Cancel";
            this.bt_Cancel.Size = new System.Drawing.Size(75, 23);
            this.bt_Cancel.TabIndex = 3;
            this.bt_Cancel.Text = "Cancel";
            this.bt_Cancel.Click += new System.EventHandler(this.bt_Cancel_Click);
            // 
            // CalendarFrm
            // 
            this.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(260, 249);
            this.Controls.Add(this.bt_Cancel);
            this.Controls.Add(this.bt_Ok);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.txt_SetDateTime);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CalendarFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Load += new System.EventHandler(this.CalendarFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txt_SetDateTime.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private DevExpress.XtraEditors.TextEdit txt_SetDateTime;
        private DevExpress.XtraEditors.SimpleButton bt_Ok;
        private DevExpress.XtraEditors.SimpleButton bt_Cancel;


    }
}