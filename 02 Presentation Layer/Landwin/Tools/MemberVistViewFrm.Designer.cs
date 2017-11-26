namespace LandWin
{
    partial class MemberVistViewFrm
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
            this.memberVisitListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tb_addnew = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tb_detail = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tb_close = new System.Windows.Forms.ToolStripButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVisitType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVisitDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPastor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colContents = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.memberVisitListBindingSource)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // memberVisitListBindingSource
            // 
            this.memberVisitListBindingSource.DataSource = typeof(Dothan.Library.MemberVisitList);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Id";
            this.dataGridViewTextBoxColumn1.HeaderText = "Id";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 50;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn2.HeaderText = "Name";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "VisitType";
            this.dataGridViewTextBoxColumn3.HeaderText = "VisitType";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "VisitDate";
            this.dataGridViewTextBoxColumn4.HeaderText = "VisitDate";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Contents";
            this.dataGridViewTextBoxColumn5.HeaderText = "Contents";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Pastor";
            this.dataGridViewTextBoxColumn6.HeaderText = "Pastor";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tb_addnew,
            this.toolStripSeparator1,
            this.tb_detail,
            this.toolStripSeparator2,
            this.tb_close});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(869, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tb_addnew
            // 
            this.tb_addnew.Image = global::LandWin.Properties.Resources.BindingNavigatorAddNewItem;
            this.tb_addnew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tb_addnew.Name = "tb_addnew";
            this.tb_addnew.Size = new System.Drawing.Size(54, 22);
            this.tb_addnew.Text = "New ";
            this.tb_addnew.Click += new System.EventHandler(this.tb_new_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tb_detail
            // 
            this.tb_detail.Image = global::LandWin.Properties.Resources.edit_icon;
            this.tb_detail.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tb_detail.Name = "tb_detail";
            this.tb_detail.Size = new System.Drawing.Size(57, 22);
            this.tb_detail.Text = "Detail";
            this.tb_detail.Click += new System.EventHandler(this.tb_detail_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tb_close
            // 
            this.tb_close.Image = global::LandWin.Properties.Resources.close_icon;
            this.tb_close.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tb_close.Name = "tb_close";
            this.tb_close.Size = new System.Drawing.Size(56, 22);
            this.tb_close.Text = "Close";
            this.tb_close.Click += new System.EventHandler(this.tb_close_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.memberVisitListBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridControl1.Location = new System.Drawing.Point(0, 25);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(869, 351);
            this.gridControl1.TabIndex = 5;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colName,
            this.colVisitType,
            this.colVisitDate,
            this.colPastor,
            this.colContents});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsCustomization.AllowGroup = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            this.colId.OptionsColumn.AllowEdit = false;
            this.colId.OptionsColumn.AllowFocus = false;
            this.colId.OptionsColumn.ReadOnly = true;
            // 
            // colName
            // 
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.OptionsColumn.ReadOnly = true;
            this.colName.Visible = true;
            this.colName.VisibleIndex = 0;
            this.colName.Width = 94;
            // 
            // colVisitType
            // 
            this.colVisitType.Caption = "심방구분";
            this.colVisitType.FieldName = "VisitType";
            this.colVisitType.Name = "colVisitType";
            this.colVisitType.OptionsColumn.ReadOnly = true;
            this.colVisitType.Visible = true;
            this.colVisitType.VisibleIndex = 1;
            this.colVisitType.Width = 114;
            // 
            // colVisitDate
            // 
            this.colVisitDate.Caption = "심방일자";
            this.colVisitDate.FieldName = "VisitDate";
            this.colVisitDate.Name = "colVisitDate";
            this.colVisitDate.OptionsColumn.ReadOnly = true;
            this.colVisitDate.Visible = true;
            this.colVisitDate.VisibleIndex = 2;
            this.colVisitDate.Width = 101;
            // 
            // colPastor
            // 
            this.colPastor.Caption = "심방자";
            this.colPastor.FieldName = "Pastor";
            this.colPastor.Name = "colPastor";
            this.colPastor.OptionsColumn.ReadOnly = true;
            this.colPastor.Visible = true;
            this.colPastor.VisibleIndex = 3;
            this.colPastor.Width = 119;
            // 
            // colContents
            // 
            this.colContents.Caption = "심방내용";
            this.colContents.FieldName = "Contents";
            this.colContents.Name = "colContents";
            this.colContents.OptionsColumn.ReadOnly = true;
            this.colContents.Visible = true;
            this.colContents.VisibleIndex = 4;
            this.colContents.Width = 420;
            // 
            // MemberVistViewFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 376);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Name = "MemberVistViewFrm";
            this.Text = "심방 내역 리스트";
            ((System.ComponentModel.ISupportInitialize)(this.memberVisitListBindingSource)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource memberVisitListBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tb_addnew;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tb_detail;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tb_close;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colVisitType;
        private DevExpress.XtraGrid.Columns.GridColumn colVisitDate;
        private DevExpress.XtraGrid.Columns.GridColumn colPastor;
        private DevExpress.XtraGrid.Columns.GridColumn colContents;
    }
}