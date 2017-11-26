namespace LandWin.Tools
{
    partial class NewMemberFrm
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
            this.familysBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colKo_FullName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEn_FullName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSex = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit8 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.sexListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.colEntryType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.entryTypeListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.colBirthDay = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.statusListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.colBaptism_Code = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.baptismListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.colBaptism_Year = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRegDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSub_Division_Code = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit4 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.subdivisionListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.colFellowship_Code = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit7 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.fellowshipsListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.colRelationship = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit5 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.relationshipListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.colMarried = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit6 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.marriageListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.colCell = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWork = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colJob = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.bt_SaveMember = new DevExpress.XtraBars.BarButtonItem();
            this.bt_Close = new DevExpress.XtraBars.BarButtonItem();
            this.bt_AddFamily = new DevExpress.XtraBars.BarButtonItem();
            this.bt_RemoveFamily = new DevExpress.XtraBars.BarButtonItem();
            this.bt_EditFamily = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.pictureEdit3 = new DevExpress.XtraEditors.PictureEdit();
            this.pictureEdit2 = new DevExpress.XtraEditors.PictureEdit();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.tb_ContextEdit = new DevExpress.XtraEditors.MemoEdit();
            this.Ko_FirstnameTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.membersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Ko_LastnameTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.En_FirstnameTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.En_LastnameTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.Baptism_YearTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.JobTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.EmailTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.CellTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.WorkTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.RegDateTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.StreetTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.CityTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.StateTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ZipcodeTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.BirthDayTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.HomeTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.RelationshipSpinEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.Sub_Division_CodeSpinEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.StatusSpinEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.EntryTypeSpinEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.Fellowship_CodeSpinEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.JobTypeSpinEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.jobTypesListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Baptism_CodeSpinEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.MarriedSpinEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.SexSpinEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForKo_Lastname = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForEn_Lastname = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForKo_Firstname = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForEn_Firstname = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForStreet = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForEmail = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForEntryType = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForSex = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForRelationship = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForRegDate = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForBirthDay = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForMarried = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForSub_Division_Code = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForStatus = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForBaptism_Year = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForBaptism_Code = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForJob = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForJobType = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForWork = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForZipcode = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForCity = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForState = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForHome = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForCell = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForFellowship_Code = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup4 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.dxErrorProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            this.visitTypeListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.familysBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sexListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.entryTypeListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.baptismListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.subdivisionListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fellowshipsListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.relationshipListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.marriageListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ContextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ko_FirstnameTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.membersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ko_LastnameTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.En_FirstnameTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.En_LastnameTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Baptism_YearTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.JobTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmailTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CellTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WorkTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RegDateTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StreetTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CityTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StateTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ZipcodeTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BirthDayTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HomeTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RelationshipSpinEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sub_Division_CodeSpinEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StatusSpinEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EntryTypeSpinEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Fellowship_CodeSpinEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.JobTypeSpinEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jobTypesListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Baptism_CodeSpinEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MarriedSpinEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SexSpinEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForKo_Lastname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForEn_Lastname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForKo_Firstname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForEn_Firstname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForStreet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForEntryType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForSex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForRelationship)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForRegDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForBirthDay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForMarried)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForSub_Division_Code)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForBaptism_Year)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForBaptism_Code)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForJob)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForJobType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForWork)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForZipcode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForState)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForHome)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCell)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForFellowship_Code)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.visitTypeListBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.DataSource = this.familysBindingSource;
            this.gridControl1.Location = new System.Drawing.Point(12, 332);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit1,
            this.repositoryItemLookUpEdit2,
            this.repositoryItemLookUpEdit3,
            this.repositoryItemLookUpEdit4,
            this.repositoryItemLookUpEdit5,
            this.repositoryItemLookUpEdit6,
            this.repositoryItemLookUpEdit7,
            this.repositoryItemLookUpEdit8});
            this.gridControl1.Size = new System.Drawing.Size(874, 251);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1,
            this.gridView2});
            // 
            // familysBindingSource
            // 
            this.familysBindingSource.DataSource = typeof(Dothan.Library.Familys);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colKo_FullName,
            this.colEn_FullName,
            this.colSex,
            this.colEntryType,
            this.colBirthDay,
            this.colStatus,
            this.colBaptism_Code,
            this.colBaptism_Year,
            this.colRegDate,
            this.colSub_Division_Code,
            this.colFellowship_Code,
            this.colRelationship,
            this.colMarried,
            this.colCell,
            this.colEmail,
            this.colWork,
            this.colJob});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsCustomization.AllowGroup = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colKo_FullName
            // 
            this.colKo_FullName.Caption = "이름";
            this.colKo_FullName.FieldName = "Ko_FullName";
            this.colKo_FullName.Name = "colKo_FullName";
            this.colKo_FullName.OptionsColumn.AllowEdit = false;
            this.colKo_FullName.OptionsColumn.AllowFocus = false;
            this.colKo_FullName.OptionsColumn.ReadOnly = true;
            this.colKo_FullName.Visible = true;
            this.colKo_FullName.VisibleIndex = 0;
            // 
            // colEn_FullName
            // 
            this.colEn_FullName.Caption = "영문이름";
            this.colEn_FullName.FieldName = "En_FullName";
            this.colEn_FullName.Name = "colEn_FullName";
            this.colEn_FullName.OptionsColumn.AllowEdit = false;
            this.colEn_FullName.OptionsColumn.AllowFocus = false;
            this.colEn_FullName.OptionsColumn.ReadOnly = true;
            this.colEn_FullName.Visible = true;
            this.colEn_FullName.VisibleIndex = 1;
            // 
            // colSex
            // 
            this.colSex.Caption = "성별";
            this.colSex.ColumnEdit = this.repositoryItemLookUpEdit8;
            this.colSex.FieldName = "Sex";
            this.colSex.Name = "colSex";
            this.colSex.Visible = true;
            this.colSex.VisibleIndex = 2;
            // 
            // repositoryItemLookUpEdit8
            // 
            this.repositoryItemLookUpEdit8.AutoHeight = false;
            this.repositoryItemLookUpEdit8.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit8.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Value", "Value", 36, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.repositoryItemLookUpEdit8.DataSource = this.sexListBindingSource;
            this.repositoryItemLookUpEdit8.DisplayMember = "Value";
            this.repositoryItemLookUpEdit8.Name = "repositoryItemLookUpEdit8";
            this.repositoryItemLookUpEdit8.ValueMember = "Key";
            // 
            // sexListBindingSource
            // 
            this.sexListBindingSource.DataSource = typeof(Dothan.Library.SexList);
            // 
            // colEntryType
            // 
            this.colEntryType.Caption = "원입구분";
            this.colEntryType.ColumnEdit = this.repositoryItemLookUpEdit1;
            this.colEntryType.FieldName = "EntryType";
            this.colEntryType.Name = "colEntryType";
            this.colEntryType.Visible = true;
            this.colEntryType.VisibleIndex = 4;
            // 
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.AutoHeight = false;
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit1.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Value", "Value", 36, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.repositoryItemLookUpEdit1.DataSource = this.entryTypeListBindingSource;
            this.repositoryItemLookUpEdit1.DisplayMember = "Value";
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            this.repositoryItemLookUpEdit1.ValueMember = "Key";
            // 
            // entryTypeListBindingSource
            // 
            this.entryTypeListBindingSource.DataSource = typeof(Dothan.Library.EntryTypeList);
            // 
            // colBirthDay
            // 
            this.colBirthDay.Caption = "생년월일";
            this.colBirthDay.FieldName = "BirthDay";
            this.colBirthDay.Name = "colBirthDay";
            this.colBirthDay.Visible = true;
            this.colBirthDay.VisibleIndex = 3;
            // 
            // colStatus
            // 
            this.colStatus.Caption = "교적상태";
            this.colStatus.ColumnEdit = this.repositoryItemLookUpEdit2;
            this.colStatus.FieldName = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 5;
            // 
            // repositoryItemLookUpEdit2
            // 
            this.repositoryItemLookUpEdit2.AutoHeight = false;
            this.repositoryItemLookUpEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit2.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Value", "Value", 36, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.repositoryItemLookUpEdit2.DataSource = this.statusListBindingSource;
            this.repositoryItemLookUpEdit2.DisplayMember = "Value";
            this.repositoryItemLookUpEdit2.Name = "repositoryItemLookUpEdit2";
            this.repositoryItemLookUpEdit2.ValueMember = "Key";
            // 
            // statusListBindingSource
            // 
            this.statusListBindingSource.DataSource = typeof(Dothan.Library.StatusList);
            // 
            // colBaptism_Code
            // 
            this.colBaptism_Code.Caption = "세례";
            this.colBaptism_Code.ColumnEdit = this.repositoryItemLookUpEdit3;
            this.colBaptism_Code.FieldName = "Baptism_Code";
            this.colBaptism_Code.Name = "colBaptism_Code";
            this.colBaptism_Code.Visible = true;
            this.colBaptism_Code.VisibleIndex = 6;
            // 
            // repositoryItemLookUpEdit3
            // 
            this.repositoryItemLookUpEdit3.AutoHeight = false;
            this.repositoryItemLookUpEdit3.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit3.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Value", "Value", 36, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.repositoryItemLookUpEdit3.DataSource = this.baptismListBindingSource;
            this.repositoryItemLookUpEdit3.DisplayMember = "Value";
            this.repositoryItemLookUpEdit3.Name = "repositoryItemLookUpEdit3";
            this.repositoryItemLookUpEdit3.ValueMember = "Key";
            // 
            // baptismListBindingSource
            // 
            this.baptismListBindingSource.DataSource = typeof(Dothan.Library.BaptismList);
            // 
            // colBaptism_Year
            // 
            this.colBaptism_Year.Caption = "세례년도";
            this.colBaptism_Year.FieldName = "Baptism_Year";
            this.colBaptism_Year.Name = "colBaptism_Year";
            this.colBaptism_Year.Visible = true;
            this.colBaptism_Year.VisibleIndex = 7;
            // 
            // colRegDate
            // 
            this.colRegDate.FieldName = "RegDate";
            this.colRegDate.Name = "colRegDate";
            this.colRegDate.Visible = true;
            this.colRegDate.VisibleIndex = 8;
            // 
            // colSub_Division_Code
            // 
            this.colSub_Division_Code.Caption = "교적구분";
            this.colSub_Division_Code.ColumnEdit = this.repositoryItemLookUpEdit4;
            this.colSub_Division_Code.FieldName = "Sub_Division_Code";
            this.colSub_Division_Code.Name = "colSub_Division_Code";
            this.colSub_Division_Code.Visible = true;
            this.colSub_Division_Code.VisibleIndex = 9;
            // 
            // repositoryItemLookUpEdit4
            // 
            this.repositoryItemLookUpEdit4.AutoHeight = false;
            this.repositoryItemLookUpEdit4.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit4.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Value", "Value", 36, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.repositoryItemLookUpEdit4.DataSource = this.subdivisionListBindingSource;
            this.repositoryItemLookUpEdit4.DisplayMember = "Value";
            this.repositoryItemLookUpEdit4.Name = "repositoryItemLookUpEdit4";
            this.repositoryItemLookUpEdit4.ValueMember = "Key";
            // 
            // subdivisionListBindingSource
            // 
            this.subdivisionListBindingSource.DataSource = typeof(Dothan.Library.SubdivisionList);
            // 
            // colFellowship_Code
            // 
            this.colFellowship_Code.Caption = "직분";
            this.colFellowship_Code.ColumnEdit = this.repositoryItemLookUpEdit7;
            this.colFellowship_Code.FieldName = "Fellowship_Code";
            this.colFellowship_Code.Name = "colFellowship_Code";
            this.colFellowship_Code.Visible = true;
            this.colFellowship_Code.VisibleIndex = 10;
            // 
            // repositoryItemLookUpEdit7
            // 
            this.repositoryItemLookUpEdit7.AutoHeight = false;
            this.repositoryItemLookUpEdit7.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit7.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Value", "Value", 36, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.repositoryItemLookUpEdit7.DataSource = this.fellowshipsListBindingSource;
            this.repositoryItemLookUpEdit7.DisplayMember = "Value";
            this.repositoryItemLookUpEdit7.Name = "repositoryItemLookUpEdit7";
            this.repositoryItemLookUpEdit7.ValueMember = "Key";
            // 
            // fellowshipsListBindingSource
            // 
            this.fellowshipsListBindingSource.DataSource = typeof(Dothan.Library.FellowshipsList);
            // 
            // colRelationship
            // 
            this.colRelationship.Caption = "관계";
            this.colRelationship.ColumnEdit = this.repositoryItemLookUpEdit5;
            this.colRelationship.FieldName = "Relationship";
            this.colRelationship.Name = "colRelationship";
            this.colRelationship.Visible = true;
            this.colRelationship.VisibleIndex = 11;
            // 
            // repositoryItemLookUpEdit5
            // 
            this.repositoryItemLookUpEdit5.AutoHeight = false;
            this.repositoryItemLookUpEdit5.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit5.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Value", "Value", 36, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.repositoryItemLookUpEdit5.DataSource = this.relationshipListBindingSource;
            this.repositoryItemLookUpEdit5.DisplayMember = "Value";
            this.repositoryItemLookUpEdit5.Name = "repositoryItemLookUpEdit5";
            this.repositoryItemLookUpEdit5.ValueMember = "Key";
            // 
            // relationshipListBindingSource
            // 
            this.relationshipListBindingSource.DataSource = typeof(Dothan.Library.RelationshipList);
            // 
            // colMarried
            // 
            this.colMarried.Caption = "결혼여부";
            this.colMarried.ColumnEdit = this.repositoryItemLookUpEdit6;
            this.colMarried.FieldName = "Married";
            this.colMarried.Name = "colMarried";
            this.colMarried.Visible = true;
            this.colMarried.VisibleIndex = 12;
            // 
            // repositoryItemLookUpEdit6
            // 
            this.repositoryItemLookUpEdit6.AutoHeight = false;
            this.repositoryItemLookUpEdit6.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit6.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Value", "Value", 36, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.repositoryItemLookUpEdit6.DataSource = this.marriageListBindingSource;
            this.repositoryItemLookUpEdit6.DisplayMember = "Value";
            this.repositoryItemLookUpEdit6.Name = "repositoryItemLookUpEdit6";
            this.repositoryItemLookUpEdit6.ValueMember = "Key";
            // 
            // marriageListBindingSource
            // 
            this.marriageListBindingSource.DataSource = typeof(Dothan.Library.MarriageList);
            // 
            // colCell
            // 
            this.colCell.Caption = "휴대폰";
            this.colCell.FieldName = "Cell";
            this.colCell.Name = "colCell";
            this.colCell.Visible = true;
            this.colCell.VisibleIndex = 13;
            // 
            // colEmail
            // 
            this.colEmail.Caption = "이메일";
            this.colEmail.FieldName = "Email";
            this.colEmail.Name = "colEmail";
            this.colEmail.Visible = true;
            this.colEmail.VisibleIndex = 14;
            // 
            // colWork
            // 
            this.colWork.Caption = "Work";
            this.colWork.FieldName = "Work";
            this.colWork.Name = "colWork";
            this.colWork.Visible = true;
            this.colWork.VisibleIndex = 15;
            // 
            // colJob
            // 
            this.colJob.Caption = "직업";
            this.colJob.FieldName = "Job";
            this.colJob.Name = "colJob";
            this.colJob.Visible = true;
            this.colJob.VisibleIndex = 16;
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.gridControl1;
            this.gridView2.Name = "gridView2";
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1,
            this.bar3});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.bt_SaveMember,
            this.bt_Close,
            this.bt_AddFamily,
            this.bt_RemoveFamily,
            this.bt_EditFamily});
            this.barManager1.MaxItemId = 5;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top;
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bt_SaveMember, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bt_Close, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bt_AddFamily, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bt_RemoveFamily, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bt_EditFamily, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar1.OptionsBar.AllowQuickCustomization = false;
            this.bar1.OptionsBar.DrawDragBorder = false;
            this.bar1.OptionsBar.RotateWhenVertical = false;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Tools";
            // 
            // bt_SaveMember
            // 
            this.bt_SaveMember.Caption = "Save";
            this.bt_SaveMember.Glyph = global::LandWin.Properties.Resources.msIcon3;
            this.bt_SaveMember.Id = 0;
            this.bt_SaveMember.Name = "bt_SaveMember";
            this.bt_SaveMember.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bt_SaveMember_ItemClick);
            // 
            // bt_Close
            // 
            this.bt_Close.Caption = "Close";
            this.bt_Close.Glyph = global::LandWin.Properties.Resources.close_icon;
            this.bt_Close.Id = 1;
            this.bt_Close.Name = "bt_Close";
            this.bt_Close.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bt_Close_ItemClick);
            // 
            // bt_AddFamily
            // 
            this.bt_AddFamily.Caption = "Add Family";
            this.bt_AddFamily.Glyph = global::LandWin.Properties.Resources.BindingNavigatorAddNewItem;
            this.bt_AddFamily.Id = 2;
            this.bt_AddFamily.Name = "bt_AddFamily";
            this.bt_AddFamily.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bt_AddFamily_ItemClick);
            // 
            // bt_RemoveFamily
            // 
            this.bt_RemoveFamily.Caption = "Remove Family";
            this.bt_RemoveFamily.Glyph = global::LandWin.Properties.Resources.Remove_16x16;
            this.bt_RemoveFamily.Id = 3;
            this.bt_RemoveFamily.Name = "bt_RemoveFamily";
            this.bt_RemoveFamily.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bt_RemoveFamily_ItemClick);
            // 
            // bt_EditFamily
            // 
            this.bt_EditFamily.Caption = "Edit Family";
            this.bt_EditFamily.Glyph = global::LandWin.Properties.Resources.edit_icon;
            this.bt_EditFamily.Id = 4;
            this.bt_EditFamily.Name = "bt_EditFamily";
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataLayoutControl1.Controls.Add(this.pictureEdit3);
            this.dataLayoutControl1.Controls.Add(this.pictureEdit2);
            this.dataLayoutControl1.Controls.Add(this.pictureEdit1);
            this.dataLayoutControl1.Controls.Add(this.tb_ContextEdit);
            this.dataLayoutControl1.Controls.Add(this.Ko_FirstnameTextEdit);
            this.dataLayoutControl1.Controls.Add(this.Ko_LastnameTextEdit);
            this.dataLayoutControl1.Controls.Add(this.En_FirstnameTextEdit);
            this.dataLayoutControl1.Controls.Add(this.En_LastnameTextEdit);
            this.dataLayoutControl1.Controls.Add(this.Baptism_YearTextEdit);
            this.dataLayoutControl1.Controls.Add(this.JobTextEdit);
            this.dataLayoutControl1.Controls.Add(this.EmailTextEdit);
            this.dataLayoutControl1.Controls.Add(this.CellTextEdit);
            this.dataLayoutControl1.Controls.Add(this.WorkTextEdit);
            this.dataLayoutControl1.Controls.Add(this.RegDateTextEdit);
            this.dataLayoutControl1.Controls.Add(this.StreetTextEdit);
            this.dataLayoutControl1.Controls.Add(this.CityTextEdit);
            this.dataLayoutControl1.Controls.Add(this.StateTextEdit);
            this.dataLayoutControl1.Controls.Add(this.ZipcodeTextEdit);
            this.dataLayoutControl1.Controls.Add(this.BirthDayTextEdit);
            this.dataLayoutControl1.Controls.Add(this.HomeTextEdit);
            this.dataLayoutControl1.Controls.Add(this.RelationshipSpinEdit);
            this.dataLayoutControl1.Controls.Add(this.Sub_Division_CodeSpinEdit);
            this.dataLayoutControl1.Controls.Add(this.StatusSpinEdit);
            this.dataLayoutControl1.Controls.Add(this.EntryTypeSpinEdit);
            this.dataLayoutControl1.Controls.Add(this.Fellowship_CodeSpinEdit);
            this.dataLayoutControl1.Controls.Add(this.JobTypeSpinEdit);
            this.dataLayoutControl1.Controls.Add(this.Baptism_CodeSpinEdit);
            this.dataLayoutControl1.Controls.Add(this.MarriedSpinEdit);
            this.dataLayoutControl1.Controls.Add(this.SexSpinEdit);
            this.dataLayoutControl1.DataSource = this.membersBindingSource;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 28);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.Root = this.layoutControlGroup1;
            this.dataLayoutControl1.Size = new System.Drawing.Size(898, 298);
            this.dataLayoutControl1.TabIndex = 5;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // pictureEdit3
            // 
            this.pictureEdit3.EditValue = global::LandWin.Properties.Resources.calendar;
            this.pictureEdit3.Location = new System.Drawing.Point(691, 62);
            this.pictureEdit3.MenuManager = this.barManager1;
            this.pictureEdit3.Name = "pictureEdit3";
            this.pictureEdit3.Size = new System.Drawing.Size(21, 21);
            this.pictureEdit3.StyleController = this.dataLayoutControl1;
            this.pictureEdit3.TabIndex = 29;
            this.pictureEdit3.Click += new System.EventHandler(this.pictureEdit3_Click);
            // 
            // pictureEdit2
            // 
            this.pictureEdit2.EditValue = global::LandWin.Properties.Resources.calendar;
            this.pictureEdit2.Location = new System.Drawing.Point(691, 37);
            this.pictureEdit2.MenuManager = this.barManager1;
            this.pictureEdit2.Name = "pictureEdit2";
            this.pictureEdit2.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pictureEdit2.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit2.Size = new System.Drawing.Size(21, 21);
            this.pictureEdit2.StyleController = this.dataLayoutControl1;
            this.pictureEdit2.TabIndex = 28;
            this.pictureEdit2.Click += new System.EventHandler(this.pictureEdit2_Click);
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.EditValue = global::LandWin.Properties.Resources.calendar;
            this.pictureEdit1.Location = new System.Drawing.Point(866, 12);
            this.pictureEdit1.MenuManager = this.barManager1;
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pictureEdit1.Size = new System.Drawing.Size(20, 21);
            this.pictureEdit1.StyleController = this.dataLayoutControl1;
            this.pictureEdit1.TabIndex = 27;
            this.pictureEdit1.Click += new System.EventHandler(this.pictureEdit1_Click);
            // 
            // tb_ContextEdit
            // 
            this.tb_ContextEdit.Location = new System.Drawing.Point(64, 162);
            this.tb_ContextEdit.MenuManager = this.barManager1;
            this.tb_ContextEdit.Name = "tb_ContextEdit";
            this.tb_ContextEdit.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.tb_ContextEdit.Properties.Appearance.Options.UseFont = true;
            this.tb_ContextEdit.Size = new System.Drawing.Size(822, 122);
            this.tb_ContextEdit.StyleController = this.dataLayoutControl1;
            this.tb_ContextEdit.TabIndex = 26;
            this.tb_ContextEdit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPress_Enter);
            // 
            // Ko_FirstnameTextEdit
            // 
            this.Ko_FirstnameTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.membersBindingSource, "Ko_Firstname", true));
            this.Ko_FirstnameTextEdit.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.Ko_FirstnameTextEdit.Location = new System.Drawing.Point(215, 12);
            this.Ko_FirstnameTextEdit.MenuManager = this.barManager1;
            this.Ko_FirstnameTextEdit.Name = "Ko_FirstnameTextEdit";
            this.Ko_FirstnameTextEdit.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.Ko_FirstnameTextEdit.Properties.Appearance.Options.UseFont = true;
            this.Ko_FirstnameTextEdit.Size = new System.Drawing.Size(145, 21);
            this.Ko_FirstnameTextEdit.StyleController = this.dataLayoutControl1;
            this.Ko_FirstnameTextEdit.TabIndex = 2;
            this.Ko_FirstnameTextEdit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPress_Enter);
            // 
            // membersBindingSource
            // 
            this.membersBindingSource.DataSource = typeof(Dothan.Library.Members);
            // 
            // Ko_LastnameTextEdit
            // 
            this.Ko_LastnameTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.membersBindingSource, "Ko_Lastname", true));
            this.Ko_LastnameTextEdit.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.Ko_LastnameTextEdit.Location = new System.Drawing.Point(64, 12);
            this.Ko_LastnameTextEdit.MenuManager = this.barManager1;
            this.Ko_LastnameTextEdit.Name = "Ko_LastnameTextEdit";
            this.Ko_LastnameTextEdit.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.Ko_LastnameTextEdit.Properties.Appearance.Options.UseFont = true;
            this.Ko_LastnameTextEdit.Size = new System.Drawing.Size(95, 21);
            this.Ko_LastnameTextEdit.StyleController = this.dataLayoutControl1;
            this.Ko_LastnameTextEdit.TabIndex = 1;
            this.Ko_LastnameTextEdit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPress_Enter);
            // 
            // En_FirstnameTextEdit
            // 
            this.En_FirstnameTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.membersBindingSource, "En_Firstname", true));
            this.En_FirstnameTextEdit.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.En_FirstnameTextEdit.Location = new System.Drawing.Point(215, 37);
            this.En_FirstnameTextEdit.MenuManager = this.barManager1;
            this.En_FirstnameTextEdit.Name = "En_FirstnameTextEdit";
            this.En_FirstnameTextEdit.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.En_FirstnameTextEdit.Properties.Appearance.Options.UseFont = true;
            this.En_FirstnameTextEdit.Size = new System.Drawing.Size(145, 21);
            this.En_FirstnameTextEdit.StyleController = this.dataLayoutControl1;
            this.En_FirstnameTextEdit.TabIndex = 4;
            this.En_FirstnameTextEdit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPress_Enter);
            // 
            // En_LastnameTextEdit
            // 
            this.En_LastnameTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.membersBindingSource, "En_Lastname", true));
            this.En_LastnameTextEdit.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            this.En_LastnameTextEdit.Location = new System.Drawing.Point(64, 37);
            this.En_LastnameTextEdit.MenuManager = this.barManager1;
            this.En_LastnameTextEdit.Name = "En_LastnameTextEdit";
            this.En_LastnameTextEdit.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.En_LastnameTextEdit.Properties.Appearance.Options.UseFont = true;
            this.En_LastnameTextEdit.Size = new System.Drawing.Size(95, 21);
            this.En_LastnameTextEdit.StyleController = this.dataLayoutControl1;
            this.En_LastnameTextEdit.TabIndex = 3;
            this.En_LastnameTextEdit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPress_Enter);
            // 
            // Baptism_YearTextEdit
            // 
            this.Baptism_YearTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.membersBindingSource, "Baptism_Year", true));
            this.Baptism_YearTextEdit.Location = new System.Drawing.Point(591, 62);
            this.Baptism_YearTextEdit.MenuManager = this.barManager1;
            this.Baptism_YearTextEdit.Name = "Baptism_YearTextEdit";
            this.Baptism_YearTextEdit.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.Baptism_YearTextEdit.Properties.Appearance.Options.UseFont = true;
            this.Baptism_YearTextEdit.Size = new System.Drawing.Size(96, 21);
            this.Baptism_YearTextEdit.StyleController = this.dataLayoutControl1;
            this.Baptism_YearTextEdit.TabIndex = 13;
            this.Baptism_YearTextEdit.Leave += new System.EventHandler(this.EditDatetimeText_Leave);
            this.Baptism_YearTextEdit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPress_Enter);
            // 
            // JobTextEdit
            // 
            this.JobTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.membersBindingSource, "Job", true));
            this.JobTextEdit.Location = new System.Drawing.Point(64, 87);
            this.JobTextEdit.MenuManager = this.barManager1;
            this.JobTextEdit.Name = "JobTextEdit";
            this.JobTextEdit.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.JobTextEdit.Properties.Appearance.Options.UseFont = true;
            this.JobTextEdit.Size = new System.Drawing.Size(294, 21);
            this.JobTextEdit.StyleController = this.dataLayoutControl1;
            this.JobTextEdit.TabIndex = 15;
            this.JobTextEdit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPress_Enter);
            // 
            // EmailTextEdit
            // 
            this.EmailTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.membersBindingSource, "Email", true));
            this.EmailTextEdit.Location = new System.Drawing.Point(64, 62);
            this.EmailTextEdit.MenuManager = this.barManager1;
            this.EmailTextEdit.Name = "EmailTextEdit";
            this.EmailTextEdit.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.EmailTextEdit.Properties.Appearance.Options.UseFont = true;
            this.EmailTextEdit.Size = new System.Drawing.Size(294, 21);
            this.EmailTextEdit.StyleController = this.dataLayoutControl1;
            this.EmailTextEdit.TabIndex = 5;
            this.EmailTextEdit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPress_Enter);
            // 
            // CellTextEdit
            // 
            this.CellTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.membersBindingSource, "Cell", true));
            this.CellTextEdit.Location = new System.Drawing.Point(768, 112);
            this.CellTextEdit.MenuManager = this.barManager1;
            this.CellTextEdit.Name = "CellTextEdit";
            this.CellTextEdit.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.CellTextEdit.Properties.Appearance.Options.UseFont = true;
            this.CellTextEdit.Properties.Mask.EditMask = "(\\d?\\d?\\d?)\\d\\d\\d-\\d\\d\\d\\d";
            this.CellTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Regular;
            this.CellTextEdit.Size = new System.Drawing.Size(118, 21);
            this.CellTextEdit.StyleController = this.dataLayoutControl1;
            this.CellTextEdit.TabIndex = 22;
            this.CellTextEdit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPress_Enter);
            // 
            // WorkTextEdit
            // 
            this.WorkTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.membersBindingSource, "Work", true));
            this.WorkTextEdit.Location = new System.Drawing.Point(591, 87);
            this.WorkTextEdit.MenuManager = this.barManager1;
            this.WorkTextEdit.Name = "WorkTextEdit";
            this.WorkTextEdit.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.WorkTextEdit.Properties.Appearance.Options.UseFont = true;
            this.WorkTextEdit.Properties.Mask.EditMask = "(\\d?\\d?\\d?)\\d\\d\\d-\\d\\d\\d\\d";
            this.WorkTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Regular;
            this.WorkTextEdit.Size = new System.Drawing.Size(121, 21);
            this.WorkTextEdit.StyleController = this.dataLayoutControl1;
            this.WorkTextEdit.TabIndex = 17;
            this.WorkTextEdit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPress_Enter);
            // 
            // RegDateTextEdit
            // 
            this.RegDateTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.membersBindingSource, "RegDate", true));
            this.RegDateTextEdit.EnterMoveNextControl = true;
            this.RegDateTextEdit.Location = new System.Drawing.Point(768, 12);
            this.RegDateTextEdit.MenuManager = this.barManager1;
            this.RegDateTextEdit.Name = "RegDateTextEdit";
            this.RegDateTextEdit.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.RegDateTextEdit.Properties.Appearance.Options.UseFont = true;
            this.RegDateTextEdit.Size = new System.Drawing.Size(94, 21);
            this.RegDateTextEdit.StyleController = this.dataLayoutControl1;
            this.RegDateTextEdit.TabIndex = 8;
            this.RegDateTextEdit.Leave += new System.EventHandler(this.EditDatetimeText_Leave);
            this.RegDateTextEdit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPress_Enter);
            // 
            // StreetTextEdit
            // 
            this.StreetTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.membersBindingSource, "Street", true));
            this.StreetTextEdit.Location = new System.Drawing.Point(64, 112);
            this.StreetTextEdit.MenuManager = this.barManager1;
            this.StreetTextEdit.Name = "StreetTextEdit";
            this.StreetTextEdit.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.StreetTextEdit.Properties.Appearance.Options.UseFont = true;
            this.StreetTextEdit.Size = new System.Drawing.Size(294, 21);
            this.StreetTextEdit.StyleController = this.dataLayoutControl1;
            this.StreetTextEdit.TabIndex = 19;
            this.StreetTextEdit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPress_Enter);
            // 
            // CityTextEdit
            // 
            this.CityTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.membersBindingSource, "City", true));
            this.CityTextEdit.Location = new System.Drawing.Point(64, 137);
            this.CityTextEdit.MenuManager = this.barManager1;
            this.CityTextEdit.Name = "CityTextEdit";
            this.CityTextEdit.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.CityTextEdit.Properties.Appearance.Options.UseFont = true;
            this.CityTextEdit.Size = new System.Drawing.Size(294, 21);
            this.CityTextEdit.StyleController = this.dataLayoutControl1;
            this.CityTextEdit.TabIndex = 23;
            this.CityTextEdit.TabStop = false;
            this.CityTextEdit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPress_Enter);
            // 
            // StateTextEdit
            // 
            this.StateTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.membersBindingSource, "State", true));
            this.StateTextEdit.Location = new System.Drawing.Point(414, 137);
            this.StateTextEdit.MenuManager = this.barManager1;
            this.StateTextEdit.Name = "StateTextEdit";
            this.StateTextEdit.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.StateTextEdit.Properties.Appearance.Options.UseFont = true;
            this.StateTextEdit.Size = new System.Drawing.Size(121, 21);
            this.StateTextEdit.StyleController = this.dataLayoutControl1;
            this.StateTextEdit.TabIndex = 24;
            this.StateTextEdit.TabStop = false;
            this.StateTextEdit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPress_Enter);
            // 
            // ZipcodeTextEdit
            // 
            this.ZipcodeTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.membersBindingSource, "Zipcode", true));
            this.ZipcodeTextEdit.Location = new System.Drawing.Point(414, 112);
            this.ZipcodeTextEdit.MenuManager = this.barManager1;
            this.ZipcodeTextEdit.Name = "ZipcodeTextEdit";
            this.ZipcodeTextEdit.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.ZipcodeTextEdit.Properties.Appearance.Options.UseFont = true;
            this.ZipcodeTextEdit.Properties.Mask.EditMask = "\\d\\d\\d\\d\\d";
            this.ZipcodeTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Regular;
            this.ZipcodeTextEdit.Size = new System.Drawing.Size(121, 21);
            this.ZipcodeTextEdit.StyleController = this.dataLayoutControl1;
            this.ZipcodeTextEdit.TabIndex = 20;
            this.ZipcodeTextEdit.Leave += new System.EventHandler(this.ZipcodeTextEdit_Leave);
            this.ZipcodeTextEdit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPress_Enter);
            // 
            // BirthDayTextEdit
            // 
            this.BirthDayTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.membersBindingSource, "BirthDay", true));
            this.BirthDayTextEdit.Location = new System.Drawing.Point(591, 37);
            this.BirthDayTextEdit.MenuManager = this.barManager1;
            this.BirthDayTextEdit.Name = "BirthDayTextEdit";
            this.BirthDayTextEdit.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.BirthDayTextEdit.Properties.Appearance.Options.UseFont = true;
            this.BirthDayTextEdit.Size = new System.Drawing.Size(96, 21);
            this.BirthDayTextEdit.StyleController = this.dataLayoutControl1;
            this.BirthDayTextEdit.TabIndex = 10;
            this.BirthDayTextEdit.Leave += new System.EventHandler(this.EditDatetimeText_Leave);
            this.BirthDayTextEdit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPress_Enter);
            // 
            // HomeTextEdit
            // 
            this.HomeTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.membersBindingSource, "Home", true));
            this.HomeTextEdit.Location = new System.Drawing.Point(591, 112);
            this.HomeTextEdit.MenuManager = this.barManager1;
            this.HomeTextEdit.Name = "HomeTextEdit";
            this.HomeTextEdit.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.HomeTextEdit.Properties.Appearance.Options.UseFont = true;
            this.HomeTextEdit.Properties.Mask.EditMask = "(\\d?\\d?\\d?)\\d\\d\\d-\\d\\d\\d\\d";
            this.HomeTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Regular;
            this.HomeTextEdit.Size = new System.Drawing.Size(121, 21);
            this.HomeTextEdit.StyleController = this.dataLayoutControl1;
            this.HomeTextEdit.TabIndex = 21;
            this.HomeTextEdit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPress_Enter);
            // 
            // RelationshipSpinEdit
            // 
            this.RelationshipSpinEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.membersBindingSource, "Relationship", true));
            this.RelationshipSpinEdit.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.RelationshipSpinEdit.Location = new System.Drawing.Point(591, 12);
            this.RelationshipSpinEdit.MenuManager = this.barManager1;
            this.RelationshipSpinEdit.Name = "RelationshipSpinEdit";
            this.RelationshipSpinEdit.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.RelationshipSpinEdit.Properties.Appearance.Options.UseFont = true;
            this.RelationshipSpinEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RelationshipSpinEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Value", "Value", 40, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.RelationshipSpinEdit.Properties.DataSource = this.relationshipListBindingSource;
            this.RelationshipSpinEdit.Properties.DisplayMember = "Value";
            this.RelationshipSpinEdit.Properties.NullText = "";
            this.RelationshipSpinEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.RelationshipSpinEdit.Properties.ValueMember = "Key";
            this.RelationshipSpinEdit.Size = new System.Drawing.Size(121, 21);
            this.RelationshipSpinEdit.StyleController = this.dataLayoutControl1;
            this.RelationshipSpinEdit.TabIndex = 7;
            this.RelationshipSpinEdit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPress_Enter);
            // 
            // Sub_Division_CodeSpinEdit
            // 
            this.Sub_Division_CodeSpinEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.membersBindingSource, "Sub_Division_Code", true));
            this.Sub_Division_CodeSpinEdit.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.Sub_Division_CodeSpinEdit.Location = new System.Drawing.Point(768, 37);
            this.Sub_Division_CodeSpinEdit.MenuManager = this.barManager1;
            this.Sub_Division_CodeSpinEdit.Name = "Sub_Division_CodeSpinEdit";
            this.Sub_Division_CodeSpinEdit.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.Sub_Division_CodeSpinEdit.Properties.Appearance.Options.UseFont = true;
            this.Sub_Division_CodeSpinEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.Sub_Division_CodeSpinEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Value", "Value", 40, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.Sub_Division_CodeSpinEdit.Properties.DataSource = this.subdivisionListBindingSource;
            this.Sub_Division_CodeSpinEdit.Properties.DisplayMember = "Value";
            this.Sub_Division_CodeSpinEdit.Properties.NullText = "";
            this.Sub_Division_CodeSpinEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.Sub_Division_CodeSpinEdit.Properties.ValueMember = "Key";
            this.Sub_Division_CodeSpinEdit.Size = new System.Drawing.Size(118, 21);
            this.Sub_Division_CodeSpinEdit.StyleController = this.dataLayoutControl1;
            this.Sub_Division_CodeSpinEdit.TabIndex = 11;
            this.Sub_Division_CodeSpinEdit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPress_Enter);
            // 
            // StatusSpinEdit
            // 
            this.StatusSpinEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.membersBindingSource, "Status", true));
            this.StatusSpinEdit.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.StatusSpinEdit.Location = new System.Drawing.Point(768, 62);
            this.StatusSpinEdit.MenuManager = this.barManager1;
            this.StatusSpinEdit.Name = "StatusSpinEdit";
            this.StatusSpinEdit.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.StatusSpinEdit.Properties.Appearance.Options.UseFont = true;
            this.StatusSpinEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.StatusSpinEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Value", "Value", 40, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.StatusSpinEdit.Properties.DataSource = this.statusListBindingSource;
            this.StatusSpinEdit.Properties.DisplayMember = "Value";
            this.StatusSpinEdit.Properties.NullText = "";
            this.StatusSpinEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.StatusSpinEdit.Properties.ValueMember = "Key";
            this.StatusSpinEdit.Size = new System.Drawing.Size(118, 21);
            this.StatusSpinEdit.StyleController = this.dataLayoutControl1;
            this.StatusSpinEdit.TabIndex = 14;
            this.StatusSpinEdit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPress_Enter);
            // 
            // EntryTypeSpinEdit
            // 
            this.EntryTypeSpinEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.membersBindingSource, "EntryType", true));
            this.EntryTypeSpinEdit.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.EntryTypeSpinEdit.Location = new System.Drawing.Point(768, 87);
            this.EntryTypeSpinEdit.MenuManager = this.barManager1;
            this.EntryTypeSpinEdit.Name = "EntryTypeSpinEdit";
            this.EntryTypeSpinEdit.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.EntryTypeSpinEdit.Properties.Appearance.Options.UseFont = true;
            this.EntryTypeSpinEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.EntryTypeSpinEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Value", "Value", 40, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.EntryTypeSpinEdit.Properties.DataSource = this.entryTypeListBindingSource;
            this.EntryTypeSpinEdit.Properties.DisplayMember = "Value";
            this.EntryTypeSpinEdit.Properties.NullText = "";
            this.EntryTypeSpinEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.EntryTypeSpinEdit.Properties.ValueMember = "Key";
            this.EntryTypeSpinEdit.Size = new System.Drawing.Size(118, 21);
            this.EntryTypeSpinEdit.StyleController = this.dataLayoutControl1;
            this.EntryTypeSpinEdit.TabIndex = 18;
            this.EntryTypeSpinEdit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPress_Enter);
            // 
            // Fellowship_CodeSpinEdit
            // 
            this.Fellowship_CodeSpinEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.membersBindingSource, "Fellowship_Code", true));
            this.Fellowship_CodeSpinEdit.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.Fellowship_CodeSpinEdit.Location = new System.Drawing.Point(591, 137);
            this.Fellowship_CodeSpinEdit.MenuManager = this.barManager1;
            this.Fellowship_CodeSpinEdit.Name = "Fellowship_CodeSpinEdit";
            this.Fellowship_CodeSpinEdit.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.Fellowship_CodeSpinEdit.Properties.Appearance.Options.UseFont = true;
            this.Fellowship_CodeSpinEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.Fellowship_CodeSpinEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Value", "Value", 40, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.Fellowship_CodeSpinEdit.Properties.DataSource = this.fellowshipsListBindingSource;
            this.Fellowship_CodeSpinEdit.Properties.DisplayMember = "Value";
            this.Fellowship_CodeSpinEdit.Properties.NullText = "";
            this.Fellowship_CodeSpinEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.Fellowship_CodeSpinEdit.Properties.ValueMember = "Key";
            this.Fellowship_CodeSpinEdit.Size = new System.Drawing.Size(295, 21);
            this.Fellowship_CodeSpinEdit.StyleController = this.dataLayoutControl1;
            this.Fellowship_CodeSpinEdit.TabIndex = 25;
            this.Fellowship_CodeSpinEdit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPress_Enter);
            // 
            // JobTypeSpinEdit
            // 
            this.JobTypeSpinEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.membersBindingSource, "JobType", true));
            this.JobTypeSpinEdit.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.JobTypeSpinEdit.Location = new System.Drawing.Point(414, 87);
            this.JobTypeSpinEdit.MenuManager = this.barManager1;
            this.JobTypeSpinEdit.Name = "JobTypeSpinEdit";
            this.JobTypeSpinEdit.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.JobTypeSpinEdit.Properties.Appearance.Options.UseFont = true;
            this.JobTypeSpinEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.JobTypeSpinEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Value", "Value", 40, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.JobTypeSpinEdit.Properties.DataSource = this.jobTypesListBindingSource;
            this.JobTypeSpinEdit.Properties.DisplayMember = "Value";
            this.JobTypeSpinEdit.Properties.NullText = "";
            this.JobTypeSpinEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.JobTypeSpinEdit.Properties.ValueMember = "Key";
            this.JobTypeSpinEdit.Size = new System.Drawing.Size(121, 21);
            this.JobTypeSpinEdit.StyleController = this.dataLayoutControl1;
            this.JobTypeSpinEdit.TabIndex = 16;
            this.JobTypeSpinEdit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPress_Enter);
            // 
            // jobTypesListBindingSource
            // 
            this.jobTypesListBindingSource.DataSource = typeof(Dothan.Library.JobTypesList);
            // 
            // Baptism_CodeSpinEdit
            // 
            this.Baptism_CodeSpinEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.membersBindingSource, "Baptism_Code", true));
            this.Baptism_CodeSpinEdit.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.Baptism_CodeSpinEdit.Location = new System.Drawing.Point(414, 62);
            this.Baptism_CodeSpinEdit.MenuManager = this.barManager1;
            this.Baptism_CodeSpinEdit.Name = "Baptism_CodeSpinEdit";
            this.Baptism_CodeSpinEdit.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.Baptism_CodeSpinEdit.Properties.Appearance.Options.UseFont = true;
            this.Baptism_CodeSpinEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.Baptism_CodeSpinEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Value", "Value", 40, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.Baptism_CodeSpinEdit.Properties.DataSource = this.baptismListBindingSource;
            this.Baptism_CodeSpinEdit.Properties.DisplayMember = "Value";
            this.Baptism_CodeSpinEdit.Properties.NullText = "";
            this.Baptism_CodeSpinEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.Baptism_CodeSpinEdit.Properties.ValueMember = "Key";
            this.Baptism_CodeSpinEdit.Size = new System.Drawing.Size(121, 21);
            this.Baptism_CodeSpinEdit.StyleController = this.dataLayoutControl1;
            this.Baptism_CodeSpinEdit.TabIndex = 12;
            this.Baptism_CodeSpinEdit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPress_Enter);
            // 
            // MarriedSpinEdit
            // 
            this.MarriedSpinEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.membersBindingSource, "Married", true));
            this.MarriedSpinEdit.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.MarriedSpinEdit.Location = new System.Drawing.Point(416, 37);
            this.MarriedSpinEdit.MenuManager = this.barManager1;
            this.MarriedSpinEdit.Name = "MarriedSpinEdit";
            this.MarriedSpinEdit.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.MarriedSpinEdit.Properties.Appearance.Options.UseFont = true;
            this.MarriedSpinEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.MarriedSpinEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Value", "Value", 40, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.MarriedSpinEdit.Properties.DataSource = this.marriageListBindingSource;
            this.MarriedSpinEdit.Properties.DisplayMember = "Value";
            this.MarriedSpinEdit.Properties.NullText = "";
            this.MarriedSpinEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.MarriedSpinEdit.Properties.ValueMember = "Key";
            this.MarriedSpinEdit.Size = new System.Drawing.Size(119, 21);
            this.MarriedSpinEdit.StyleController = this.dataLayoutControl1;
            this.MarriedSpinEdit.TabIndex = 9;
            this.MarriedSpinEdit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPress_Enter);
            // 
            // SexSpinEdit
            // 
            this.SexSpinEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.membersBindingSource, "Sex", true));
            this.SexSpinEdit.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.SexSpinEdit.Location = new System.Drawing.Point(416, 12);
            this.SexSpinEdit.MenuManager = this.barManager1;
            this.SexSpinEdit.Name = "SexSpinEdit";
            this.SexSpinEdit.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.SexSpinEdit.Properties.Appearance.Options.UseFont = true;
            this.SexSpinEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.SexSpinEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Value", "Value", 40, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.SexSpinEdit.Properties.DataSource = this.sexListBindingSource;
            this.SexSpinEdit.Properties.DisplayMember = "Value";
            this.SexSpinEdit.Properties.NullText = "";
            this.SexSpinEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.SexSpinEdit.Properties.ValueMember = "Key";
            this.SexSpinEdit.Size = new System.Drawing.Size(119, 21);
            this.SexSpinEdit.StyleController = this.dataLayoutControl1;
            this.SexSpinEdit.TabIndex = 6;
            this.SexSpinEdit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPress_Enter);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.AppearanceItemCaption.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlGroup1.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlGroup1.AppearanceItemCaption.Options.UseTextOptions = true;
            this.layoutControlGroup1.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2,
            this.layoutControlGroup3,
            this.layoutControlGroup4});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(898, 298);
            this.layoutControlGroup1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.AllowDrawBackground = false;
            this.layoutControlGroup2.CustomizationFormText = "autoGeneratedGroup0";
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForKo_Lastname,
            this.ItemForEn_Lastname,
            this.ItemForKo_Firstname,
            this.ItemForEn_Firstname,
            this.ItemForStreet,
            this.ItemForEmail,
            this.ItemForEntryType,
            this.ItemForSex,
            this.ItemForRelationship,
            this.ItemForRegDate,
            this.ItemForBirthDay,
            this.ItemForMarried,
            this.ItemForSub_Division_Code,
            this.ItemForStatus,
            this.ItemForBaptism_Year,
            this.ItemForBaptism_Code,
            this.ItemForJob,
            this.ItemForJobType,
            this.ItemForWork,
            this.ItemForZipcode,
            this.ItemForCity,
            this.ItemForState,
            this.ItemForHome,
            this.ItemForCell,
            this.ItemForFellowship_Code,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "autoGeneratedGroup0";
            this.layoutControlGroup2.Size = new System.Drawing.Size(878, 150);
            this.layoutControlGroup2.Text = "autoGeneratedGroup0";
            // 
            // ItemForKo_Lastname
            // 
            this.ItemForKo_Lastname.Control = this.Ko_LastnameTextEdit;
            this.ItemForKo_Lastname.CustomizationFormText = "Ko_Lastname";
            this.ItemForKo_Lastname.Location = new System.Drawing.Point(0, 0);
            this.ItemForKo_Lastname.Name = "ItemForKo_Lastname";
            this.ItemForKo_Lastname.Size = new System.Drawing.Size(151, 25);
            this.ItemForKo_Lastname.Text = "성";
            this.ItemForKo_Lastname.TextSize = new System.Drawing.Size(48, 15);
            // 
            // ItemForEn_Lastname
            // 
            this.ItemForEn_Lastname.Control = this.En_LastnameTextEdit;
            this.ItemForEn_Lastname.CustomizationFormText = "En_Lastname";
            this.ItemForEn_Lastname.Location = new System.Drawing.Point(0, 25);
            this.ItemForEn_Lastname.Name = "ItemForEn_Lastname";
            this.ItemForEn_Lastname.Size = new System.Drawing.Size(151, 25);
            this.ItemForEn_Lastname.Text = "Last";
            this.ItemForEn_Lastname.TextSize = new System.Drawing.Size(48, 15);
            // 
            // ItemForKo_Firstname
            // 
            this.ItemForKo_Firstname.Control = this.Ko_FirstnameTextEdit;
            this.ItemForKo_Firstname.CustomizationFormText = "Ko_Firstname";
            this.ItemForKo_Firstname.Location = new System.Drawing.Point(151, 0);
            this.ItemForKo_Firstname.Name = "ItemForKo_Firstname";
            this.ItemForKo_Firstname.Size = new System.Drawing.Size(201, 25);
            this.ItemForKo_Firstname.Text = "이름";
            this.ItemForKo_Firstname.TextSize = new System.Drawing.Size(48, 15);
            // 
            // ItemForEn_Firstname
            // 
            this.ItemForEn_Firstname.Control = this.En_FirstnameTextEdit;
            this.ItemForEn_Firstname.CustomizationFormText = "En_Firstname";
            this.ItemForEn_Firstname.Location = new System.Drawing.Point(151, 25);
            this.ItemForEn_Firstname.Name = "ItemForEn_Firstname";
            this.ItemForEn_Firstname.Size = new System.Drawing.Size(201, 25);
            this.ItemForEn_Firstname.Text = "First";
            this.ItemForEn_Firstname.TextSize = new System.Drawing.Size(48, 15);
            // 
            // ItemForStreet
            // 
            this.ItemForStreet.Control = this.StreetTextEdit;
            this.ItemForStreet.CustomizationFormText = "Street";
            this.ItemForStreet.Location = new System.Drawing.Point(0, 100);
            this.ItemForStreet.Name = "ItemForStreet";
            this.ItemForStreet.Size = new System.Drawing.Size(350, 25);
            this.ItemForStreet.Text = "Street";
            this.ItemForStreet.TextSize = new System.Drawing.Size(48, 15);
            // 
            // ItemForEmail
            // 
            this.ItemForEmail.Control = this.EmailTextEdit;
            this.ItemForEmail.CustomizationFormText = "Email";
            this.ItemForEmail.Location = new System.Drawing.Point(0, 50);
            this.ItemForEmail.Name = "ItemForEmail";
            this.ItemForEmail.Size = new System.Drawing.Size(350, 25);
            this.ItemForEmail.Text = "Email";
            this.ItemForEmail.TextSize = new System.Drawing.Size(48, 15);
            // 
            // ItemForEntryType
            // 
            this.ItemForEntryType.Control = this.EntryTypeSpinEdit;
            this.ItemForEntryType.CustomizationFormText = "Entry Type";
            this.ItemForEntryType.Location = new System.Drawing.Point(704, 75);
            this.ItemForEntryType.Name = "ItemForEntryType";
            this.ItemForEntryType.Size = new System.Drawing.Size(174, 25);
            this.ItemForEntryType.Text = "원입구분";
            this.ItemForEntryType.TextSize = new System.Drawing.Size(48, 15);
            // 
            // ItemForSex
            // 
            this.ItemForSex.Control = this.SexSpinEdit;
            this.ItemForSex.CustomizationFormText = "Sex";
            this.ItemForSex.Location = new System.Drawing.Point(352, 0);
            this.ItemForSex.Name = "ItemForSex";
            this.ItemForSex.Size = new System.Drawing.Size(175, 25);
            this.ItemForSex.Text = "성별";
            this.ItemForSex.TextSize = new System.Drawing.Size(48, 15);
            // 
            // ItemForRelationship
            // 
            this.ItemForRelationship.Control = this.RelationshipSpinEdit;
            this.ItemForRelationship.CustomizationFormText = "Relationship";
            this.ItemForRelationship.Location = new System.Drawing.Point(527, 0);
            this.ItemForRelationship.Name = "ItemForRelationship";
            this.ItemForRelationship.Size = new System.Drawing.Size(177, 25);
            this.ItemForRelationship.Text = "관계";
            this.ItemForRelationship.TextSize = new System.Drawing.Size(48, 15);
            // 
            // ItemForRegDate
            // 
            this.ItemForRegDate.Control = this.RegDateTextEdit;
            this.ItemForRegDate.CustomizationFormText = "Reg Date";
            this.ItemForRegDate.Location = new System.Drawing.Point(704, 0);
            this.ItemForRegDate.Name = "ItemForRegDate";
            this.ItemForRegDate.Size = new System.Drawing.Size(150, 25);
            this.ItemForRegDate.Text = "등록일";
            this.ItemForRegDate.TextSize = new System.Drawing.Size(48, 15);
            // 
            // ItemForBirthDay
            // 
            this.ItemForBirthDay.Control = this.BirthDayTextEdit;
            this.ItemForBirthDay.CustomizationFormText = "Birth Day";
            this.ItemForBirthDay.Location = new System.Drawing.Point(527, 25);
            this.ItemForBirthDay.Name = "ItemForBirthDay";
            this.ItemForBirthDay.Size = new System.Drawing.Size(152, 25);
            this.ItemForBirthDay.Text = "생년월일";
            this.ItemForBirthDay.TextSize = new System.Drawing.Size(48, 15);
            // 
            // ItemForMarried
            // 
            this.ItemForMarried.Control = this.MarriedSpinEdit;
            this.ItemForMarried.CustomizationFormText = "Married";
            this.ItemForMarried.Location = new System.Drawing.Point(352, 25);
            this.ItemForMarried.Name = "ItemForMarried";
            this.ItemForMarried.Size = new System.Drawing.Size(175, 25);
            this.ItemForMarried.Text = "기혼";
            this.ItemForMarried.TextSize = new System.Drawing.Size(48, 15);
            // 
            // ItemForSub_Division_Code
            // 
            this.ItemForSub_Division_Code.Control = this.Sub_Division_CodeSpinEdit;
            this.ItemForSub_Division_Code.CustomizationFormText = "Sub_Division_Code";
            this.ItemForSub_Division_Code.Location = new System.Drawing.Point(704, 25);
            this.ItemForSub_Division_Code.Name = "ItemForSub_Division_Code";
            this.ItemForSub_Division_Code.Size = new System.Drawing.Size(174, 25);
            this.ItemForSub_Division_Code.Text = "교적구분";
            this.ItemForSub_Division_Code.TextSize = new System.Drawing.Size(48, 15);
            // 
            // ItemForStatus
            // 
            this.ItemForStatus.Control = this.StatusSpinEdit;
            this.ItemForStatus.CustomizationFormText = "Status";
            this.ItemForStatus.Location = new System.Drawing.Point(704, 50);
            this.ItemForStatus.Name = "ItemForStatus";
            this.ItemForStatus.Size = new System.Drawing.Size(174, 25);
            this.ItemForStatus.Text = "교적상태";
            this.ItemForStatus.TextSize = new System.Drawing.Size(48, 15);
            // 
            // ItemForBaptism_Year
            // 
            this.ItemForBaptism_Year.Control = this.Baptism_YearTextEdit;
            this.ItemForBaptism_Year.CustomizationFormText = "Baptism_Year";
            this.ItemForBaptism_Year.Location = new System.Drawing.Point(527, 50);
            this.ItemForBaptism_Year.Name = "ItemForBaptism_Year";
            this.ItemForBaptism_Year.Size = new System.Drawing.Size(152, 25);
            this.ItemForBaptism_Year.Text = "신급일";
            this.ItemForBaptism_Year.TextSize = new System.Drawing.Size(48, 15);
            // 
            // ItemForBaptism_Code
            // 
            this.ItemForBaptism_Code.Control = this.Baptism_CodeSpinEdit;
            this.ItemForBaptism_Code.CustomizationFormText = "Baptism_Code";
            this.ItemForBaptism_Code.Location = new System.Drawing.Point(350, 50);
            this.ItemForBaptism_Code.Name = "ItemForBaptism_Code";
            this.ItemForBaptism_Code.Size = new System.Drawing.Size(177, 25);
            this.ItemForBaptism_Code.Text = "신급";
            this.ItemForBaptism_Code.TextSize = new System.Drawing.Size(48, 15);
            // 
            // ItemForJob
            // 
            this.ItemForJob.Control = this.JobTextEdit;
            this.ItemForJob.CustomizationFormText = "Job";
            this.ItemForJob.Location = new System.Drawing.Point(0, 75);
            this.ItemForJob.Name = "ItemForJob";
            this.ItemForJob.Size = new System.Drawing.Size(350, 25);
            this.ItemForJob.Text = "직업";
            this.ItemForJob.TextSize = new System.Drawing.Size(48, 15);
            // 
            // ItemForJobType
            // 
            this.ItemForJobType.Control = this.JobTypeSpinEdit;
            this.ItemForJobType.CustomizationFormText = "Job Type";
            this.ItemForJobType.Location = new System.Drawing.Point(350, 75);
            this.ItemForJobType.Name = "ItemForJobType";
            this.ItemForJobType.Size = new System.Drawing.Size(177, 25);
            this.ItemForJobType.Text = "직종";
            this.ItemForJobType.TextSize = new System.Drawing.Size(48, 15);
            // 
            // ItemForWork
            // 
            this.ItemForWork.Control = this.WorkTextEdit;
            this.ItemForWork.CustomizationFormText = "Work";
            this.ItemForWork.Location = new System.Drawing.Point(527, 75);
            this.ItemForWork.Name = "ItemForWork";
            this.ItemForWork.Size = new System.Drawing.Size(177, 25);
            this.ItemForWork.Text = "Work";
            this.ItemForWork.TextSize = new System.Drawing.Size(48, 15);
            // 
            // ItemForZipcode
            // 
            this.ItemForZipcode.Control = this.ZipcodeTextEdit;
            this.ItemForZipcode.CustomizationFormText = "Zipcode";
            this.ItemForZipcode.Location = new System.Drawing.Point(350, 100);
            this.ItemForZipcode.Name = "ItemForZipcode";
            this.ItemForZipcode.Size = new System.Drawing.Size(177, 25);
            this.ItemForZipcode.Text = "Zipcode";
            this.ItemForZipcode.TextSize = new System.Drawing.Size(48, 15);
            // 
            // ItemForCity
            // 
            this.ItemForCity.Control = this.CityTextEdit;
            this.ItemForCity.CustomizationFormText = "City";
            this.ItemForCity.Location = new System.Drawing.Point(0, 125);
            this.ItemForCity.Name = "ItemForCity";
            this.ItemForCity.Size = new System.Drawing.Size(350, 25);
            this.ItemForCity.Text = "City";
            this.ItemForCity.TextSize = new System.Drawing.Size(48, 15);
            // 
            // ItemForState
            // 
            this.ItemForState.Control = this.StateTextEdit;
            this.ItemForState.CustomizationFormText = "State";
            this.ItemForState.Location = new System.Drawing.Point(350, 125);
            this.ItemForState.Name = "ItemForState";
            this.ItemForState.Size = new System.Drawing.Size(177, 25);
            this.ItemForState.Text = "State";
            this.ItemForState.TextSize = new System.Drawing.Size(48, 15);
            // 
            // ItemForHome
            // 
            this.ItemForHome.Control = this.HomeTextEdit;
            this.ItemForHome.CustomizationFormText = "Home";
            this.ItemForHome.Location = new System.Drawing.Point(527, 100);
            this.ItemForHome.Name = "ItemForHome";
            this.ItemForHome.Size = new System.Drawing.Size(177, 25);
            this.ItemForHome.Text = "Home";
            this.ItemForHome.TextSize = new System.Drawing.Size(48, 15);
            // 
            // ItemForCell
            // 
            this.ItemForCell.Control = this.CellTextEdit;
            this.ItemForCell.CustomizationFormText = "Cell";
            this.ItemForCell.Location = new System.Drawing.Point(704, 100);
            this.ItemForCell.Name = "ItemForCell";
            this.ItemForCell.Size = new System.Drawing.Size(174, 25);
            this.ItemForCell.Text = "핸드폰";
            this.ItemForCell.TextSize = new System.Drawing.Size(48, 15);
            // 
            // ItemForFellowship_Code
            // 
            this.ItemForFellowship_Code.Control = this.Fellowship_CodeSpinEdit;
            this.ItemForFellowship_Code.CustomizationFormText = "Fellowship_Code";
            this.ItemForFellowship_Code.Location = new System.Drawing.Point(527, 125);
            this.ItemForFellowship_Code.Name = "ItemForFellowship_Code";
            this.ItemForFellowship_Code.Size = new System.Drawing.Size(351, 25);
            this.ItemForFellowship_Code.Text = "직분";
            this.ItemForFellowship_Code.TextSize = new System.Drawing.Size(48, 15);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.pictureEdit1;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(854, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(24, 25);
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.pictureEdit2;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(679, 25);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(25, 25);
            this.layoutControlItem3.Text = "layoutControlItem3";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextToControlDistance = 0;
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.pictureEdit3;
            this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
            this.layoutControlItem4.Location = new System.Drawing.Point(679, 50);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(25, 25);
            this.layoutControlItem4.Text = "layoutControlItem4";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextToControlDistance = 0;
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlGroup3
            // 
            this.layoutControlGroup3.AllowDrawBackground = false;
            this.layoutControlGroup3.CustomizationFormText = "autoGeneratedGroup1";
            this.layoutControlGroup3.GroupBordersVisible = false;
            this.layoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup3.Location = new System.Drawing.Point(0, 150);
            this.layoutControlGroup3.Name = "autoGeneratedGroup1";
            this.layoutControlGroup3.Size = new System.Drawing.Size(878, 126);
            this.layoutControlGroup3.Text = "autoGeneratedGroup1";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.tb_ContextEdit;
            this.layoutControlItem1.CustomizationFormText = "비고";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(878, 126);
            this.layoutControlItem1.Text = "비고";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(48, 15);
            // 
            // layoutControlGroup4
            // 
            this.layoutControlGroup4.AllowDrawBackground = false;
            this.layoutControlGroup4.CustomizationFormText = "autoGeneratedGroup2";
            this.layoutControlGroup4.GroupBordersVisible = false;
            this.layoutControlGroup4.Location = new System.Drawing.Point(0, 276);
            this.layoutControlGroup4.Name = "autoGeneratedGroup2";
            this.layoutControlGroup4.Size = new System.Drawing.Size(878, 2);
            this.layoutControlGroup4.Text = "autoGeneratedGroup2";
            // 
            // dxErrorProvider1
            // 
            this.dxErrorProvider1.ContainerControl = this;
            this.dxErrorProvider1.DataSource = this.membersBindingSource;
            // 
            // visitTypeListBindingSource
            // 
            this.visitTypeListBindingSource.DataSource = typeof(Dothan.Library.VisitTypeList);
            // 
            // NewMemberFrm
            // 
            this.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 610);
            this.Controls.Add(this.dataLayoutControl1);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "NewMemberFrm";
            this.Text = "NewMemberFrm";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.familysBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sexListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.entryTypeListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.baptismListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.subdivisionListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fellowshipsListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.relationshipListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.marriageListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_ContextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ko_FirstnameTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.membersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ko_LastnameTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.En_FirstnameTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.En_LastnameTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Baptism_YearTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.JobTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EmailTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CellTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WorkTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RegDateTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StreetTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CityTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StateTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ZipcodeTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BirthDayTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HomeTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RelationshipSpinEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sub_Division_CodeSpinEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StatusSpinEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EntryTypeSpinEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Fellowship_CodeSpinEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.JobTypeSpinEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jobTypesListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Baptism_CodeSpinEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MarriedSpinEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SexSpinEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForKo_Lastname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForEn_Lastname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForKo_Firstname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForEn_Firstname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForStreet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForEntryType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForSex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForRelationship)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForRegDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForBirthDay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForMarried)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForSub_Division_Code)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForBaptism_Year)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForBaptism_Code)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForJob)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForJobType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForWork)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForZipcode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForState)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForHome)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCell)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForFellowship_Code)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.visitTypeListBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem bt_SaveMember;
        private DevExpress.XtraBars.BarButtonItem bt_Close;
        private DevExpress.XtraBars.BarButtonItem bt_AddFamily;
        private DevExpress.XtraBars.BarButtonItem bt_RemoveFamily;
        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private System.Windows.Forms.BindingSource membersBindingSource;
        private DevExpress.XtraEditors.TextEdit Ko_FirstnameTextEdit;
        private DevExpress.XtraEditors.TextEdit Ko_LastnameTextEdit;
        private DevExpress.XtraEditors.TextEdit En_FirstnameTextEdit;
        private DevExpress.XtraEditors.TextEdit En_LastnameTextEdit;
        private DevExpress.XtraEditors.TextEdit EmailTextEdit;
        private DevExpress.XtraEditors.TextEdit Baptism_YearTextEdit;
        private DevExpress.XtraEditors.TextEdit JobTextEdit;
        private DevExpress.XtraEditors.TextEdit CellTextEdit;
        private DevExpress.XtraEditors.TextEdit WorkTextEdit;
        private DevExpress.XtraEditors.TextEdit RegDateTextEdit;
        private DevExpress.XtraEditors.TextEdit BirthDayTextEdit;
        private DevExpress.XtraEditors.TextEdit StreetTextEdit;
        private DevExpress.XtraEditors.TextEdit CityTextEdit;
        private DevExpress.XtraEditors.TextEdit StateTextEdit;
        private DevExpress.XtraEditors.TextEdit ZipcodeTextEdit;
        private DevExpress.XtraEditors.TextEdit HomeTextEdit;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem ItemForKo_Firstname;
        private DevExpress.XtraLayout.LayoutControlItem ItemForKo_Lastname;
        private DevExpress.XtraLayout.LayoutControlItem ItemForEn_Firstname;
        private DevExpress.XtraLayout.LayoutControlItem ItemForEn_Lastname;
        private DevExpress.XtraLayout.LayoutControlItem ItemForEmail;
        private DevExpress.XtraLayout.LayoutControlItem ItemForSex;
        private DevExpress.XtraLayout.LayoutControlItem ItemForBaptism_Code;
        private DevExpress.XtraLayout.LayoutControlItem ItemForBaptism_Year;
        private DevExpress.XtraLayout.LayoutControlItem ItemForJob;
        private DevExpress.XtraLayout.LayoutControlItem ItemForMarried;
        private DevExpress.XtraLayout.LayoutControlItem ItemForStatus;
        private DevExpress.XtraLayout.LayoutControlItem ItemForFellowship_Code;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private DevExpress.XtraLayout.LayoutControlItem ItemForRelationship;
        private DevExpress.XtraLayout.LayoutControlItem ItemForEntryType;
        private DevExpress.XtraLayout.LayoutControlItem ItemForJobType;
        private DevExpress.XtraLayout.LayoutControlItem ItemForSub_Division_Code;
        private DevExpress.XtraLayout.LayoutControlItem ItemForCell;
        private DevExpress.XtraLayout.LayoutControlItem ItemForWork;
        private DevExpress.XtraLayout.LayoutControlItem ItemForRegDate;
        private DevExpress.XtraLayout.LayoutControlItem ItemForBirthDay;
        private DevExpress.XtraLayout.LayoutControlItem ItemForStreet;
        private DevExpress.XtraLayout.LayoutControlItem ItemForCity;
        private DevExpress.XtraLayout.LayoutControlItem ItemForState;
        private DevExpress.XtraLayout.LayoutControlItem ItemForZipcode;
        private DevExpress.XtraLayout.LayoutControlItem ItemForHome;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup4;
        private DevExpress.XtraEditors.MemoEdit tb_ContextEdit;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.LookUpEdit RelationshipSpinEdit;
        private DevExpress.XtraEditors.LookUpEdit Sub_Division_CodeSpinEdit;
        private DevExpress.XtraEditors.LookUpEdit StatusSpinEdit;
        private DevExpress.XtraEditors.LookUpEdit EntryTypeSpinEdit;
        private DevExpress.XtraEditors.LookUpEdit Fellowship_CodeSpinEdit;
        private DevExpress.XtraEditors.LookUpEdit JobTypeSpinEdit;
        private DevExpress.XtraEditors.LookUpEdit Baptism_CodeSpinEdit;
        private DevExpress.XtraEditors.LookUpEdit MarriedSpinEdit;
        private DevExpress.XtraEditors.LookUpEdit SexSpinEdit;
        private System.Windows.Forms.BindingSource sexListBindingSource;
        private System.Windows.Forms.BindingSource relationshipListBindingSource;
        private System.Windows.Forms.BindingSource subdivisionListBindingSource;
        private System.Windows.Forms.BindingSource statusListBindingSource;
        private System.Windows.Forms.BindingSource entryTypeListBindingSource;
        private System.Windows.Forms.BindingSource fellowshipsListBindingSource;
        private System.Windows.Forms.BindingSource baptismListBindingSource;
        private System.Windows.Forms.BindingSource marriageListBindingSource;
        private System.Windows.Forms.BindingSource jobTypesListBindingSource;
        private System.Windows.Forms.BindingSource familysBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colKo_FullName;
        private DevExpress.XtraGrid.Columns.GridColumn colEn_FullName;
        private DevExpress.XtraGrid.Columns.GridColumn colSex;
        private DevExpress.XtraGrid.Columns.GridColumn colEntryType;
        private DevExpress.XtraGrid.Columns.GridColumn colBirthDay;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colBaptism_Code;
        private DevExpress.XtraGrid.Columns.GridColumn colBaptism_Year;
        private DevExpress.XtraGrid.Columns.GridColumn colRegDate;
        private DevExpress.XtraGrid.Columns.GridColumn colSub_Division_Code;
        private DevExpress.XtraGrid.Columns.GridColumn colFellowship_Code;
        private DevExpress.XtraGrid.Columns.GridColumn colRelationship;
        private DevExpress.XtraGrid.Columns.GridColumn colMarried;
        private DevExpress.XtraGrid.Columns.GridColumn colCell;
        private DevExpress.XtraGrid.Columns.GridColumn colEmail;
        private DevExpress.XtraGrid.Columns.GridColumn colWork;
        private DevExpress.XtraGrid.Columns.GridColumn colJob;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.PictureEdit pictureEdit3;
        private DevExpress.XtraEditors.PictureEdit pictureEdit2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit3;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit8;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit4;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit7;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit5;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit6;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider1;
        private DevExpress.XtraBars.BarButtonItem bt_EditFamily;
        private System.Windows.Forms.BindingSource visitTypeListBindingSource;
    }
}