namespace LandWin.Tools
{
    partial class FamilyAddFrm
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
            this.memberListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMemberId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKo_Name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSpouse = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHome = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCell = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSex = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMarried = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAge = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFamilyName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRelationShip = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRegDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSubDivision = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colActive = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnApply = new DevExpress.XtraEditors.SimpleButton();
            this.ddlRelationship = new DevExpress.XtraEditors.LookUpEdit();
            this.typeListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.ddlSubDivision = new DevExpress.XtraEditors.LookUpEdit();
            this.subdivisionListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtKoName = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memberListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ddlRelationship.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.typeListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlSubDivision.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.subdivisionListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKoName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.DataSource = this.memberListBindingSource;
            this.gridControl1.Location = new System.Drawing.Point(14, 44);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(814, 296);
            this.gridControl1.TabIndex = 27;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // memberListBindingSource
            // 
            this.memberListBindingSource.DataSource = typeof(Dothan.Library.bizMember.MemberList);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMemberId,
            this.colKo_Name,
            this.colSpouse,
            this.colEmail,
            this.colHome,
            this.colCell,
            this.colSex,
            this.colMarried,
            this.colAge,
            this.colFamilyName,
            this.colRelationShip,
            this.colRegDate,
            this.colSubDivision,
            this.colActive});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsCustomization.AllowGroup = false;
            this.gridView1.OptionsCustomization.AllowSort = false;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colMemberId
            // 
            this.colMemberId.Caption = "교인번호";
            this.colMemberId.FieldName = "MemberId";
            this.colMemberId.Name = "colMemberId";
            this.colMemberId.OptionsColumn.ReadOnly = true;
            this.colMemberId.Visible = true;
            this.colMemberId.VisibleIndex = 0;
            // 
            // colKo_Name
            // 
            this.colKo_Name.Caption = "이름";
            this.colKo_Name.FieldName = "Ko_Name";
            this.colKo_Name.Name = "colKo_Name";
            this.colKo_Name.OptionsColumn.ReadOnly = true;
            this.colKo_Name.Visible = true;
            this.colKo_Name.VisibleIndex = 1;
            // 
            // colSpouse
            // 
            this.colSpouse.Caption = "배우자";
            this.colSpouse.FieldName = "Spouse";
            this.colSpouse.Name = "colSpouse";
            this.colSpouse.Visible = true;
            this.colSpouse.VisibleIndex = 11;
            // 
            // colEmail
            // 
            this.colEmail.Caption = "이메일";
            this.colEmail.FieldName = "Email";
            this.colEmail.Name = "colEmail";
            this.colEmail.OptionsColumn.ReadOnly = true;
            this.colEmail.Visible = true;
            this.colEmail.VisibleIndex = 2;
            // 
            // colHome
            // 
            this.colHome.Caption = "집전화";
            this.colHome.FieldName = "Home";
            this.colHome.Name = "colHome";
            this.colHome.OptionsColumn.ReadOnly = true;
            // 
            // colCell
            // 
            this.colCell.Caption = "휴대전화";
            this.colCell.FieldName = "Cell";
            this.colCell.Name = "colCell";
            this.colCell.OptionsColumn.ReadOnly = true;
            // 
            // colSex
            // 
            this.colSex.Caption = "성별";
            this.colSex.FieldName = "Sex";
            this.colSex.Name = "colSex";
            this.colSex.OptionsColumn.ReadOnly = true;
            this.colSex.Visible = true;
            this.colSex.VisibleIndex = 3;
            // 
            // colMarried
            // 
            this.colMarried.Caption = "결혼";
            this.colMarried.FieldName = "Married";
            this.colMarried.Name = "colMarried";
            this.colMarried.OptionsColumn.ReadOnly = true;
            this.colMarried.Visible = true;
            this.colMarried.VisibleIndex = 4;
            // 
            // colAge
            // 
            this.colAge.Caption = "나이";
            this.colAge.FieldName = "Age";
            this.colAge.Name = "colAge";
            this.colAge.OptionsColumn.ReadOnly = true;
            this.colAge.Visible = true;
            this.colAge.VisibleIndex = 5;
            // 
            // colFamilyName
            // 
            this.colFamilyName.Caption = "세대주명";
            this.colFamilyName.FieldName = "FamilyName";
            this.colFamilyName.Name = "colFamilyName";
            this.colFamilyName.OptionsColumn.ReadOnly = true;
            this.colFamilyName.Visible = true;
            this.colFamilyName.VisibleIndex = 6;
            // 
            // colRelationShip
            // 
            this.colRelationShip.Caption = "관계";
            this.colRelationShip.FieldName = "RelationShip";
            this.colRelationShip.Name = "colRelationShip";
            this.colRelationShip.OptionsColumn.ReadOnly = true;
            this.colRelationShip.Visible = true;
            this.colRelationShip.VisibleIndex = 7;
            // 
            // colRegDate
            // 
            this.colRegDate.Caption = "등록일";
            this.colRegDate.FieldName = "RegDate";
            this.colRegDate.Name = "colRegDate";
            this.colRegDate.OptionsColumn.ReadOnly = true;
            this.colRegDate.Visible = true;
            this.colRegDate.VisibleIndex = 8;
            // 
            // colSubDivision
            // 
            this.colSubDivision.Caption = "소속";
            this.colSubDivision.FieldName = "SubDivision";
            this.colSubDivision.Name = "colSubDivision";
            this.colSubDivision.OptionsColumn.ReadOnly = true;
            this.colSubDivision.Visible = true;
            this.colSubDivision.VisibleIndex = 9;
            // 
            // colActive
            // 
            this.colActive.Caption = "교적상태";
            this.colActive.FieldName = "Active";
            this.colActive.Name = "colActive";
            this.colActive.OptionsColumn.ReadOnly = true;
            this.colActive.Visible = true;
            this.colActive.VisibleIndex = 10;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.btnCancel);
            this.layoutControl1.Controls.Add(this.btnApply);
            this.layoutControl1.Controls.Add(this.ddlRelationship);
            this.layoutControl1.Controls.Add(this.btnSearch);
            this.layoutControl1.Controls.Add(this.gridControl1);
            this.layoutControl1.Controls.Add(this.ddlSubDivision);
            this.layoutControl1.Controls.Add(this.txtKoName);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.HiddenItems.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem7});
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(842, 390);
            this.layoutControl1.TabIndex = 28;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.Location = new System.Drawing.Point(734, 351);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(91, 22);
            this.btnCancel.StyleController = this.layoutControl1;
            this.btnCancel.TabIndex = 31;
            this.btnCancel.Text = "C&ancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnApply
            // 
            this.btnApply.Appearance.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApply.Appearance.Options.UseFont = true;
            this.btnApply.Image = global::LandWin.Properties.Resources.Apply;
            this.btnApply.Location = new System.Drawing.Point(619, 351);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(101, 22);
            this.btnApply.StyleController = this.layoutControl1;
            this.btnApply.TabIndex = 30;
            this.btnApply.Text = "Apply";
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // ddlRelationship
            // 
            this.ddlRelationship.Location = new System.Drawing.Point(369, 348);
            this.ddlRelationship.Name = "ddlRelationship";
            this.ddlRelationship.Properties.Appearance.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlRelationship.Properties.Appearance.Options.UseFont = true;
            this.ddlRelationship.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ddlRelationship.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Value", "Value", 40, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.ddlRelationship.Properties.DataSource = this.typeListBindingSource;
            this.ddlRelationship.Properties.DisplayMember = "Value";
            this.ddlRelationship.Properties.ValueMember = "Key";
            this.ddlRelationship.Size = new System.Drawing.Size(239, 22);
            this.ddlRelationship.StyleController = this.layoutControl1;
            this.ddlRelationship.TabIndex = 29;
            // 
            // typeListBindingSource
            // 
            this.typeListBindingSource.DataSource = typeof(Dothan.Library.bizCommon.TypeList);
            // 
            // btnSearch
            // 
            this.btnSearch.Appearance.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Appearance.Options.UseFont = true;
            this.btnSearch.Image = global::LandWin.Properties.Resources.Find_16x16;
            this.btnSearch.Location = new System.Drawing.Point(707, 14);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(121, 22);
            this.btnSearch.StyleController = this.layoutControl1;
            this.btnSearch.TabIndex = 28;
            this.btnSearch.Text = "Search";
            // 
            // ddlSubDivision
            // 
            this.ddlSubDivision.Location = new System.Drawing.Point(414, 14);
            this.ddlSubDivision.Name = "ddlSubDivision";
            this.ddlSubDivision.Properties.Appearance.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlSubDivision.Properties.Appearance.Options.UseFont = true;
            this.ddlSubDivision.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ddlSubDivision.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Value", "Value", 40, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.ddlSubDivision.Properties.DataSource = this.subdivisionListBindingSource;
            this.ddlSubDivision.Properties.DisplayMember = "Value";
            this.ddlSubDivision.Properties.NullText = "All";
            this.ddlSubDivision.Properties.ValueMember = "Key";
            this.ddlSubDivision.Size = new System.Drawing.Size(190, 22);
            this.ddlSubDivision.StyleController = this.layoutControl1;
            this.ddlSubDivision.TabIndex = 5;
            // 
            // subdivisionListBindingSource
            // 
            this.subdivisionListBindingSource.DataSource = typeof(Dothan.Library.bizCommon.SubdivisionList);
            // 
            // txtKoName
            // 
            this.txtKoName.Location = new System.Drawing.Point(66, 14);
            this.txtKoName.Name = "txtKoName";
            this.txtKoName.Properties.Appearance.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKoName.Properties.Appearance.Options.UseFont = true;
            this.txtKoName.Size = new System.Drawing.Size(288, 22);
            this.txtKoName.StyleController = this.layoutControl1;
            this.txtKoName.TabIndex = 4;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.CustomizationFormText = "layoutControlItem7";
            this.layoutControlItem7.Location = new System.Drawing.Point(621, 30);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(201, 310);
            this.layoutControlItem7.Text = "layoutControlItem7";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(50, 20);
            this.layoutControlItem7.TextToControlDistance = 5;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.emptySpaceItem1,
            this.emptySpaceItem2,
            this.layoutControlItem1,
            this.layoutControlItem8});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(842, 390);
            this.layoutControlGroup1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Text = "layoutControlGroup1";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.AppearanceItemCaption.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem2.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem2.Control = this.ddlSubDivision;
            this.layoutControlItem2.CustomizationFormText = "교적구분";
            this.layoutControlItem2.Location = new System.Drawing.Point(348, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(250, 30);
            this.layoutControlItem2.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem2.Text = "교적구분";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(48, 15);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.AppearanceItemCaption.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem3.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem3.Control = this.gridControl1;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 30);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(822, 304);
            this.layoutControlItem3.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem3.Text = "layoutControlItem3";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextToControlDistance = 0;
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.AppearanceItemCaption.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem4.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem4.Control = this.btnSearch;
            this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
            this.layoutControlItem4.Location = new System.Drawing.Point(693, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(129, 30);
            this.layoutControlItem4.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem4.Text = "layoutControlItem4";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextToControlDistance = 0;
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.AppearanceItemCaption.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem5.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem5.Control = this.ddlRelationship;
            this.layoutControlItem5.CustomizationFormText = "세대관계";
            this.layoutControlItem5.Location = new System.Drawing.Point(303, 334);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(299, 36);
            this.layoutControlItem5.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem5.Text = "세대관계";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(48, 15);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.AppearanceItemCaption.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem6.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem6.Control = this.btnApply;
            this.layoutControlItem6.CustomizationFormText = "layoutControlItem6";
            this.layoutControlItem6.Location = new System.Drawing.Point(602, 334);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(115, 36);
            this.layoutControlItem6.Spacing = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem6.Text = "layoutControlItem6";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextToControlDistance = 0;
            this.layoutControlItem6.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 334);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(303, 36);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.CustomizationFormText = "emptySpaceItem2";
            this.emptySpaceItem2.Location = new System.Drawing.Point(598, 0);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(95, 30);
            this.emptySpaceItem2.Text = "emptySpaceItem2";
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.AppearanceItemCaption.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlItem1.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem1.Control = this.txtKoName;
            this.layoutControlItem1.CustomizationFormText = "한글이름";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(348, 30);
            this.layoutControlItem1.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem1.Text = "한글이름";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(48, 15);
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.btnCancel;
            this.layoutControlItem8.CustomizationFormText = "layoutControlItem8";
            this.layoutControlItem8.Location = new System.Drawing.Point(717, 334);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(105, 36);
            this.layoutControlItem8.Spacing = new DevExpress.XtraLayout.Utils.Padding(5, 5, 5, 5);
            this.layoutControlItem8.Text = "layoutControlItem8";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextToControlDistance = 0;
            this.layoutControlItem8.TextVisible = false;
            // 
            // FamilyAddFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(842, 390);
            this.Controls.Add(this.layoutControl1);
            this.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(593, 426);
            this.Name = "FamilyAddFrm";
            this.Text = "가족 추가";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memberListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ddlRelationship.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.typeListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlSubDivision.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.subdivisionListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKoName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colMemberId;
        private DevExpress.XtraGrid.Columns.GridColumn colKo_Name;
        private DevExpress.XtraGrid.Columns.GridColumn colEmail;
        private DevExpress.XtraGrid.Columns.GridColumn colHome;
        private DevExpress.XtraGrid.Columns.GridColumn colCell;
        private DevExpress.XtraGrid.Columns.GridColumn colSex;
        private DevExpress.XtraGrid.Columns.GridColumn colMarried;
        private DevExpress.XtraGrid.Columns.GridColumn colAge;
        private DevExpress.XtraGrid.Columns.GridColumn colFamilyName;
        private DevExpress.XtraGrid.Columns.GridColumn colRelationShip;
        private DevExpress.XtraGrid.Columns.GridColumn colRegDate;
        private DevExpress.XtraGrid.Columns.GridColumn colSubDivision;
        private DevExpress.XtraGrid.Columns.GridColumn colActive;
        private DevExpress.XtraGrid.Columns.GridColumn colSpouse;
        private System.Windows.Forms.BindingSource memberListBindingSource;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.SimpleButton btnApply;
        private DevExpress.XtraEditors.LookUpEdit ddlRelationship;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraEditors.LookUpEdit ddlSubDivision;
        private DevExpress.XtraEditors.TextEdit txtKoName;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private System.Windows.Forms.BindingSource typeListBindingSource;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private System.Windows.Forms.BindingSource subdivisionListBindingSource;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
    }
}