namespace LandWin
{
    partial class Frm_RoleList
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
            this.tb_rolelist = new System.Windows.Forms.CheckedListBox();
            this.tb_Ok = new System.Windows.Forms.Button();
            this.tb_cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tb_rolelist
            // 
            this.tb_rolelist.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_rolelist.FormattingEnabled = true;
            this.tb_rolelist.Location = new System.Drawing.Point(14, 14);
            this.tb_rolelist.Margin = new System.Windows.Forms.Padding(5);
            this.tb_rolelist.Name = "tb_rolelist";
            this.tb_rolelist.Size = new System.Drawing.Size(311, 260);
            this.tb_rolelist.TabIndex = 0;
            // 
            // tb_Ok
            // 
            this.tb_Ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_Ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.tb_Ok.Location = new System.Drawing.Point(132, 288);
            this.tb_Ok.Name = "tb_Ok";
            this.tb_Ok.Size = new System.Drawing.Size(87, 30);
            this.tb_Ok.TabIndex = 1;
            this.tb_Ok.Text = "&Ok";
            this.tb_Ok.UseVisualStyleBackColor = true;
            this.tb_Ok.Click += new System.EventHandler(this.tb_Ok_Click);
            // 
            // tb_cancel
            // 
            this.tb_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_cancel.Location = new System.Drawing.Point(239, 288);
            this.tb_cancel.Name = "tb_cancel";
            this.tb_cancel.Size = new System.Drawing.Size(87, 30);
            this.tb_cancel.TabIndex = 2;
            this.tb_cancel.Text = "&Cancel";
            this.tb_cancel.UseVisualStyleBackColor = true;
            this.tb_cancel.Click += new System.EventHandler(this.tb_cancel_Click);
            // 
            // FrmRoleList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 325);
            this.Controls.Add(this.tb_cancel);
            this.Controls.Add(this.tb_Ok);
            this.Controls.Add(this.tb_rolelist);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Name = "FrmRoleList";
            this.Text = "Role List";
            this.Load += new System.EventHandler(this.FrmRoleList_Load);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button tb_Ok;
        private System.Windows.Forms.Button tb_cancel;
        internal System.Windows.Forms.CheckedListBox tb_rolelist;
    }
}