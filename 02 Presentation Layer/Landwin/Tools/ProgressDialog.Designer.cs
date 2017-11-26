namespace LandWin.Tools
{
    partial class ProgressDialog
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
            this.lblMessage = new System.Windows.Forms.Label();
            this.lblProgress = new System.Windows.Forms.Label();
            this.rProgressBar = new DevExpress.XtraEditors.ProgressBarControl();
            ((System.ComponentModel.ISupportInitialize)(this.rProgressBar.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMessage
            // 
            this.lblMessage.Font = new System.Drawing.Font("Tahoma", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblMessage.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lblMessage.Location = new System.Drawing.Point(14, 9);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(271, 25);
            this.lblMessage.TabIndex = 1;
            this.lblMessage.Tag = "";
            this.lblMessage.Text = "Doing some heavy work. Please wait...";
            // 
            // lblProgress
            // 
            this.lblProgress.Font = new System.Drawing.Font("Tahoma", 8.75F);
            this.lblProgress.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblProgress.Location = new System.Drawing.Point(12, 63);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblProgress.Size = new System.Drawing.Size(414, 14);
            this.lblProgress.TabIndex = 3;
            this.lblProgress.Text = "Process  1/300";
            // 
            // rProgressBar
            // 
            this.rProgressBar.Location = new System.Drawing.Point(12, 45);
            this.rProgressBar.Name = "rProgressBar";
            this.rProgressBar.Size = new System.Drawing.Size(414, 16);
            this.rProgressBar.TabIndex = 4;
            // 
            // ProgressDialog
            // 
            this.Appearance.Font = new System.Drawing.Font("Tahoma", 8.75F);
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 85);
            this.ControlBox = false;
            this.Controls.Add(this.rProgressBar);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.lblMessage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProgressDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Tag = "";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.rProgressBar.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Label lblProgress;
        private DevExpress.XtraEditors.ProgressBarControl rProgressBar;
    }
}