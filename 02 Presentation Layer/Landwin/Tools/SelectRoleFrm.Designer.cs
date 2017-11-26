namespace LandWin
{
    partial class SelectRoleFrm
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.tb_Ok = new System.Windows.Forms.Button();
            this.tb_close = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(24, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(234, 21);
            this.comboBox1.TabIndex = 0;
            // 
            // tb_Ok
            // 
            this.tb_Ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.tb_Ok.Location = new System.Drawing.Point(24, 48);
            this.tb_Ok.Name = "tb_Ok";
            this.tb_Ok.Size = new System.Drawing.Size(102, 23);
            this.tb_Ok.TabIndex = 1;
            this.tb_Ok.Text = "Ok";
            this.tb_Ok.UseVisualStyleBackColor = true;
            this.tb_Ok.Click += new System.EventHandler(this.tb_Ok_Click);
            // 
            // tb_close
            // 
            this.tb_close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.tb_close.Location = new System.Drawing.Point(150, 48);
            this.tb_close.Name = "tb_close";
            this.tb_close.Size = new System.Drawing.Size(108, 23);
            this.tb_close.TabIndex = 2;
            this.tb_close.Text = "Cancel";
            this.tb_close.UseVisualStyleBackColor = true;
            // 
            // SelectRoleFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 87);
            this.Controls.Add(this.tb_close);
            this.Controls.Add(this.tb_Ok);
            this.Controls.Add(this.comboBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SelectRoleFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "직책 설정";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button tb_close;
        internal System.Windows.Forms.Button tb_Ok;
    }
}