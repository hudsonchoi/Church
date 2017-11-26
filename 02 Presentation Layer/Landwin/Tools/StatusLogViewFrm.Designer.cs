namespace LandWin.Tools
{
    partial class StatusLogViewFrm
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMemo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEventLog = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRegDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.statusLogViewBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.statusLogListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusLogViewBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusLogListBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.statusLogListBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(609, 273);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMemo,
            this.colID,
            this.colEventLog,
            this.colRegDate});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsCustomization.AllowGroup = false;
            this.gridView1.OptionsCustomization.AllowRowSizing = true;
            this.gridView1.OptionsView.RowAutoHeight = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colMemo
            // 
            this.colMemo.FieldName = "Memo";
            this.colMemo.Name = "colMemo";
            this.colMemo.OptionsColumn.ReadOnly = true;
            this.colMemo.Visible = true;
            this.colMemo.VisibleIndex = 1;
            this.colMemo.Width = 195;
            // 
            // colID
            // 
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            this.colID.OptionsColumn.ReadOnly = true;
            this.colID.Visible = true;
            this.colID.VisibleIndex = 0;
            this.colID.Width = 65;
            // 
            // colEventLog
            // 
            this.colEventLog.FieldName = "EventLog";
            this.colEventLog.Name = "colEventLog";
            this.colEventLog.OptionsColumn.ReadOnly = true;
            this.colEventLog.Visible = true;
            this.colEventLog.VisibleIndex = 2;
            this.colEventLog.Width = 234;
            // 
            // colRegDate
            // 
            this.colRegDate.FieldName = "RegDate";
            this.colRegDate.Name = "colRegDate";
            this.colRegDate.OptionsColumn.ReadOnly = true;
            this.colRegDate.Visible = true;
            this.colRegDate.VisibleIndex = 3;
            this.colRegDate.Width = 94;
            // 
            // statusLogListBindingSource
            // 
            this.statusLogListBindingSource.DataSource = typeof(Dothan.Library.bizMember.StatusLogList);
            // 
            // StatusLogViewFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 273);
            this.Controls.Add(this.gridControl1);
            this.Name = "StatusLogViewFrm";
            this.Text = "교적 상태 변경 로그";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusLogViewBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusLogListBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource statusLogViewBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colMemo;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colEventLog;
        private DevExpress.XtraGrid.Columns.GridColumn colRegDate;
        private System.Windows.Forms.BindingSource statusLogListBindingSource;
    }
}