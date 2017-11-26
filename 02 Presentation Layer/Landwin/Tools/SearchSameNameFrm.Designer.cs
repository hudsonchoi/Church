namespace LandWin.Tools
{
    partial class SearchSameNameFrm
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
            this.tb_importmember = new System.Windows.Forms.Button();
            this.tb_close = new System.Windows.Forms.Button();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMemberID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCellPhone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKo_name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMemo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSpouse = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colActive = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEn_name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFullAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRegdate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.donateMemberListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.donateMemberListBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tb_importmember
            // 
            this.tb_importmember.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tb_importmember.Location = new System.Drawing.Point(606, 235);
            this.tb_importmember.Name = "tb_importmember";
            this.tb_importmember.Size = new System.Drawing.Size(109, 25);
            this.tb_importmember.TabIndex = 1;
            this.tb_importmember.Text = "Import Member ";
            this.tb_importmember.UseVisualStyleBackColor = true;
            this.tb_importmember.Click += new System.EventHandler(this.tb_importmember_Click);
            // 
            // tb_close
            // 
            this.tb_close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.tb_close.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tb_close.Location = new System.Drawing.Point(725, 235);
            this.tb_close.Name = "tb_close";
            this.tb_close.Size = new System.Drawing.Size(98, 25);
            this.tb_close.TabIndex = 2;
            this.tb_close.Text = "Close";
            this.tb_close.UseVisualStyleBackColor = true;
            this.tb_close.Click += new System.EventHandler(this.tb_close_Click);
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.gridControl1);
            this.layoutControl1.Controls.Add(this.tb_importmember);
            this.layoutControl1.Controls.Add(this.tb_close);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(841, 278);
            this.layoutControl1.TabIndex = 3;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.donateMemberListBindingSource;
            this.gridControl1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.gridControl1.Location = new System.Drawing.Point(15, 15);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(811, 213);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colMemberID,
            this.colCellPhone,
            this.colKo_name,
            this.colMemo,
            this.colSpouse,
            this.colActive,
            this.colEn_name,
            this.colFullAddress,
            this.colRegdate});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsCustomization.AllowGroup = false;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colID
            // 
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            this.colID.OptionsColumn.ReadOnly = true;
            this.colID.Width = 55;
            // 
            // colMemberID
            // 
            this.colMemberID.Caption = "교번";
            this.colMemberID.FieldName = "MemberID";
            this.colMemberID.Name = "colMemberID";
            this.colMemberID.OptionsColumn.ReadOnly = true;
            this.colMemberID.Visible = true;
            this.colMemberID.VisibleIndex = 0;
            this.colMemberID.Width = 77;
            // 
            // colCellPhone
            // 
            this.colCellPhone.Caption = "핸드폰";
            this.colCellPhone.FieldName = "CellPhone";
            this.colCellPhone.Name = "colCellPhone";
            this.colCellPhone.OptionsColumn.ReadOnly = true;
            this.colCellPhone.Visible = true;
            this.colCellPhone.VisibleIndex = 5;
            this.colCellPhone.Width = 93;
            // 
            // colKo_name
            // 
            this.colKo_name.Caption = "교인명";
            this.colKo_name.FieldName = "Ko_name";
            this.colKo_name.Name = "colKo_name";
            this.colKo_name.OptionsColumn.ReadOnly = true;
            this.colKo_name.Visible = true;
            this.colKo_name.VisibleIndex = 1;
            // 
            // colMemo
            // 
            this.colMemo.Caption = "메모";
            this.colMemo.FieldName = "Memo";
            this.colMemo.Name = "colMemo";
            this.colMemo.OptionsColumn.ReadOnly = true;
            this.colMemo.Visible = true;
            this.colMemo.VisibleIndex = 6;
            this.colMemo.Width = 131;
            // 
            // colSpouse
            // 
            this.colSpouse.Caption = "배우자";
            this.colSpouse.FieldName = "Spouse";
            this.colSpouse.Name = "colSpouse";
            this.colSpouse.OptionsColumn.ReadOnly = true;
            this.colSpouse.Visible = true;
            this.colSpouse.VisibleIndex = 3;
            this.colSpouse.Width = 77;
            // 
            // colActive
            // 
            this.colActive.Caption = "교적 상태";
            this.colActive.FieldName = "Active";
            this.colActive.Name = "colActive";
            this.colActive.OptionsColumn.ReadOnly = true;
            this.colActive.Visible = true;
            this.colActive.VisibleIndex = 8;
            this.colActive.Width = 56;
            // 
            // colEn_name
            // 
            this.colEn_name.Caption = "영문 이름";
            this.colEn_name.FieldName = "En_name";
            this.colEn_name.Name = "colEn_name";
            this.colEn_name.OptionsColumn.ReadOnly = true;
            this.colEn_name.Visible = true;
            this.colEn_name.VisibleIndex = 2;
            this.colEn_name.Width = 95;
            // 
            // colFullAddress
            // 
            this.colFullAddress.Caption = "주소";
            this.colFullAddress.FieldName = "FullAddress";
            this.colFullAddress.Name = "colFullAddress";
            this.colFullAddress.OptionsColumn.ReadOnly = true;
            this.colFullAddress.Visible = true;
            this.colFullAddress.VisibleIndex = 4;
            this.colFullAddress.Width = 183;
            // 
            // colRegdate
            // 
            this.colRegdate.Caption = "등록일";
            this.colRegdate.FieldName = "Regdate";
            this.colRegdate.Name = "colRegdate";
            this.colRegdate.OptionsColumn.ReadOnly = true;
            this.colRegdate.Visible = true;
            this.colRegdate.VisibleIndex = 7;
            this.colRegdate.Width = 80;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.emptySpaceItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(841, 278);
            this.layoutControlGroup1.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.tb_importmember;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(588, 217);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(119, 35);
            this.layoutControlItem1.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.tb_close;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(707, 217);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(108, 35);
            this.layoutControlItem2.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.gridControl1;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(815, 217);
            this.layoutControlItem3.Text = "layoutControlItem3";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextToControlDistance = 0;
            this.layoutControlItem3.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 217);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(588, 35);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // donateMemberListBindingSource
            // 
            this.donateMemberListBindingSource.DataSource = typeof(Dothan.Library.bizDonate.DonateMemberList);
            // 
            // SearchSameNameFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 278);
            this.Controls.Add(this.layoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SearchSameNameFrm";
            this.Text = "동명 이인 교인 명단";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.donateMemberListBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button tb_importmember;
        private System.Windows.Forms.Button tb_close;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colMemberID;
        private DevExpress.XtraGrid.Columns.GridColumn colCellPhone;
        private DevExpress.XtraGrid.Columns.GridColumn colKo_name;
        private DevExpress.XtraGrid.Columns.GridColumn colMemo;
        private DevExpress.XtraGrid.Columns.GridColumn colSpouse;
        private DevExpress.XtraGrid.Columns.GridColumn colActive;
        private DevExpress.XtraGrid.Columns.GridColumn colEn_name;
        private DevExpress.XtraGrid.Columns.GridColumn colFullAddress;
        private DevExpress.XtraGrid.Columns.GridColumn colRegdate;
        private System.Windows.Forms.BindingSource donateMemberListBindingSource;
    }
}