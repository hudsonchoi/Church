namespace LandWin
{
    partial class MemberVisitDetailFrm
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
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.MemberIdTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.memberVisitBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.VisitTypeLookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.typeListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.VisitdateTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.PastorTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.AttendentTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.SongTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.FullNameTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.BibleTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ContentTextEdit = new DevExpress.XtraEditors.MemoEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForContent = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForPastor = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForVisitdate = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForBible = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForSong = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForAttendent = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForVisitType = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForMemberId = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForFullName = new DevExpress.XtraLayout.LayoutControlItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.bt_Save = new DevExpress.XtraBars.BarButtonItem();
            this.bt_Close = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.btnSearchMember = new DevExpress.XtraBars.BarButtonItem();
            this.dxErrorProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MemberIdTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memberVisitBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VisitTypeLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.typeListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VisitdateTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PastorTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AttendentTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SongTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FullNameTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BibleTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ContentTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForContent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForPastor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForVisitdate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForBible)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForSong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForAttendent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForVisitType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForMemberId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForFullName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.MemberIdTextEdit);
            this.dataLayoutControl1.Controls.Add(this.VisitTypeLookUpEdit);
            this.dataLayoutControl1.Controls.Add(this.VisitdateTextEdit);
            this.dataLayoutControl1.Controls.Add(this.PastorTextEdit);
            this.dataLayoutControl1.Controls.Add(this.AttendentTextEdit);
            this.dataLayoutControl1.Controls.Add(this.SongTextEdit);
            this.dataLayoutControl1.Controls.Add(this.FullNameTextEdit);
            this.dataLayoutControl1.Controls.Add(this.BibleTextEdit);
            this.dataLayoutControl1.Controls.Add(this.ContentTextEdit);
            this.dataLayoutControl1.DataSource = this.memberVisitBindingSource;
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 26);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.Root = this.layoutControlGroup1;
            this.dataLayoutControl1.Size = new System.Drawing.Size(596, 379);
            this.dataLayoutControl1.TabIndex = 27;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // MemberIdTextEdit
            // 
            this.MemberIdTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.memberVisitBindingSource, "MemberId", true));
            this.MemberIdTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.memberVisitBindingSource, "MemberId", true));
            this.MemberIdTextEdit.EnterMoveNextControl = true;
            this.MemberIdTextEdit.Location = new System.Drawing.Point(70, 44);
            this.MemberIdTextEdit.Name = "MemberIdTextEdit";
            this.MemberIdTextEdit.Properties.Appearance.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MemberIdTextEdit.Properties.Appearance.Options.UseFont = true;
            this.MemberIdTextEdit.Size = new System.Drawing.Size(224, 22);
            this.MemberIdTextEdit.StyleController = this.dataLayoutControl1;
            this.MemberIdTextEdit.TabIndex = 5;
            this.MemberIdTextEdit.Leave += new System.EventHandler(this.MemberIdTextEdit_Leave);
            // 
            // memberVisitBindingSource
            // 
            this.memberVisitBindingSource.DataSource = typeof(Dothan.Library.bizMemberVisit.MemberVisit);
            // 
            // VisitTypeLookUpEdit
            // 
            this.VisitTypeLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.memberVisitBindingSource, "VisitType", true));
            this.VisitTypeLookUpEdit.EnterMoveNextControl = true;
            this.VisitTypeLookUpEdit.Location = new System.Drawing.Point(358, 14);
            this.VisitTypeLookUpEdit.Name = "VisitTypeLookUpEdit";
            this.VisitTypeLookUpEdit.Properties.Appearance.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VisitTypeLookUpEdit.Properties.Appearance.Options.UseFont = true;
            this.VisitTypeLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.VisitTypeLookUpEdit.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Value", "Value", 36, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.VisitTypeLookUpEdit.Properties.DataSource = this.typeListBindingSource;
            this.VisitTypeLookUpEdit.Properties.DisplayMember = "Value";
            this.VisitTypeLookUpEdit.Properties.ValueMember = "Key";
            this.VisitTypeLookUpEdit.Size = new System.Drawing.Size(224, 22);
            this.VisitTypeLookUpEdit.StyleController = this.dataLayoutControl1;
            this.VisitTypeLookUpEdit.TabIndex = 6;
            // 
            // typeListBindingSource
            // 
            this.typeListBindingSource.DataSource = typeof(Dothan.Library.bizCommon.TypeList);
            // 
            // VisitdateTextEdit
            // 
            this.VisitdateTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.memberVisitBindingSource, "Visitdate", true));
            this.VisitdateTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.memberVisitBindingSource, "Visitdate", true));
            this.VisitdateTextEdit.EnterMoveNextControl = true;
            this.VisitdateTextEdit.Location = new System.Drawing.Point(70, 14);
            this.VisitdateTextEdit.Name = "VisitdateTextEdit";
            this.VisitdateTextEdit.Properties.Appearance.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VisitdateTextEdit.Properties.Appearance.Options.UseFont = true;
            this.VisitdateTextEdit.Size = new System.Drawing.Size(224, 22);
            this.VisitdateTextEdit.StyleController = this.dataLayoutControl1;
            this.VisitdateTextEdit.TabIndex = 7;
            this.VisitdateTextEdit.Click += new System.EventHandler(this.VisitdateTextEdit_Click);
            // 
            // PastorTextEdit
            // 
            this.PastorTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.memberVisitBindingSource, "Pastor", true));
            this.PastorTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.memberVisitBindingSource, "Pastor", true));
            this.PastorTextEdit.EnterMoveNextControl = true;
            this.PastorTextEdit.Location = new System.Drawing.Point(70, 74);
            this.PastorTextEdit.Name = "PastorTextEdit";
            this.PastorTextEdit.Properties.Appearance.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PastorTextEdit.Properties.Appearance.Options.UseFont = true;
            this.PastorTextEdit.Size = new System.Drawing.Size(224, 22);
            this.PastorTextEdit.StyleController = this.dataLayoutControl1;
            this.PastorTextEdit.TabIndex = 8;
            // 
            // AttendentTextEdit
            // 
            this.AttendentTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.memberVisitBindingSource, "Attendent", true));
            this.AttendentTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.memberVisitBindingSource, "Attendent", true));
            this.AttendentTextEdit.EnterMoveNextControl = true;
            this.AttendentTextEdit.Location = new System.Drawing.Point(358, 74);
            this.AttendentTextEdit.Name = "AttendentTextEdit";
            this.AttendentTextEdit.Properties.Appearance.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AttendentTextEdit.Properties.Appearance.Options.UseFont = true;
            this.AttendentTextEdit.Size = new System.Drawing.Size(224, 22);
            this.AttendentTextEdit.StyleController = this.dataLayoutControl1;
            this.AttendentTextEdit.TabIndex = 9;
            // 
            // SongTextEdit
            // 
            this.SongTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.memberVisitBindingSource, "Song", true));
            this.SongTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.memberVisitBindingSource, "Song", true));
            this.SongTextEdit.EnterMoveNextControl = true;
            this.SongTextEdit.Location = new System.Drawing.Point(358, 104);
            this.SongTextEdit.Name = "SongTextEdit";
            this.SongTextEdit.Properties.Appearance.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SongTextEdit.Properties.Appearance.Options.UseFont = true;
            this.SongTextEdit.Size = new System.Drawing.Size(224, 22);
            this.SongTextEdit.StyleController = this.dataLayoutControl1;
            this.SongTextEdit.TabIndex = 13;
            // 
            // FullNameTextEdit
            // 
            this.FullNameTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.memberVisitBindingSource, "FullName", true));
            this.FullNameTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.memberVisitBindingSource, "FullName", true));
            this.FullNameTextEdit.EnterMoveNextControl = true;
            this.FullNameTextEdit.Location = new System.Drawing.Point(358, 44);
            this.FullNameTextEdit.Name = "FullNameTextEdit";
            this.FullNameTextEdit.Properties.Appearance.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FullNameTextEdit.Properties.Appearance.Options.UseFont = true;
            this.FullNameTextEdit.Size = new System.Drawing.Size(224, 22);
            this.FullNameTextEdit.StyleController = this.dataLayoutControl1;
            this.FullNameTextEdit.TabIndex = 14;
            // 
            // BibleTextEdit
            // 
            this.BibleTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.memberVisitBindingSource, "Bible", true));
            this.BibleTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.memberVisitBindingSource, "Bible", true));
            this.BibleTextEdit.EnterMoveNextControl = true;
            this.BibleTextEdit.Location = new System.Drawing.Point(70, 104);
            this.BibleTextEdit.Name = "BibleTextEdit";
            this.BibleTextEdit.Properties.Appearance.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BibleTextEdit.Properties.Appearance.Options.UseFont = true;
            this.BibleTextEdit.Size = new System.Drawing.Size(224, 22);
            this.BibleTextEdit.StyleController = this.dataLayoutControl1;
            this.BibleTextEdit.TabIndex = 12;
            // 
            // ContentTextEdit
            // 
            this.ContentTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.memberVisitBindingSource, "Content", true));
            this.ContentTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.memberVisitBindingSource, "Content", true));
            this.ContentTextEdit.Location = new System.Drawing.Point(14, 152);
            this.ContentTextEdit.Name = "ContentTextEdit";
            this.ContentTextEdit.Properties.Appearance.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ContentTextEdit.Properties.Appearance.Options.UseFont = true;
            this.ContentTextEdit.Size = new System.Drawing.Size(568, 213);
            this.ContentTextEdit.StyleController = this.dataLayoutControl1;
            this.ContentTextEdit.TabIndex = 10;
            this.ContentTextEdit.TabStop = false;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(596, 379);
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
            this.ItemForContent,
            this.ItemForPastor,
            this.ItemForVisitdate,
            this.ItemForBible,
            this.ItemForSong,
            this.ItemForAttendent,
            this.ItemForVisitType,
            this.ItemForMemberId,
            this.ItemForFullName});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "autoGeneratedGroup0";
            this.layoutControlGroup2.Size = new System.Drawing.Size(576, 359);
            this.layoutControlGroup2.Text = "autoGeneratedGroup0";
            // 
            // ItemForContent
            // 
            this.ItemForContent.AppearanceItemCaption.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItemForContent.AppearanceItemCaption.Options.UseFont = true;
            this.ItemForContent.Control = this.ContentTextEdit;
            this.ItemForContent.CustomizationFormText = "Content";
            this.ItemForContent.Location = new System.Drawing.Point(0, 120);
            this.ItemForContent.Name = "ItemForContent";
            this.ItemForContent.Size = new System.Drawing.Size(576, 239);
            this.ItemForContent.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.ItemForContent.Text = "심방내용";
            this.ItemForContent.TextLocation = DevExpress.Utils.Locations.Top;
            this.ItemForContent.TextSize = new System.Drawing.Size(52, 15);
            // 
            // ItemForPastor
            // 
            this.ItemForPastor.AppearanceItemCaption.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItemForPastor.AppearanceItemCaption.Options.UseFont = true;
            this.ItemForPastor.Control = this.PastorTextEdit;
            this.ItemForPastor.CustomizationFormText = "Pastor";
            this.ItemForPastor.Location = new System.Drawing.Point(0, 60);
            this.ItemForPastor.Name = "ItemForPastor";
            this.ItemForPastor.Size = new System.Drawing.Size(288, 30);
            this.ItemForPastor.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.ItemForPastor.Text = "심방자";
            this.ItemForPastor.TextSize = new System.Drawing.Size(52, 15);
            // 
            // ItemForVisitdate
            // 
            this.ItemForVisitdate.AppearanceItemCaption.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItemForVisitdate.AppearanceItemCaption.Options.UseFont = true;
            this.ItemForVisitdate.Control = this.VisitdateTextEdit;
            this.ItemForVisitdate.CustomizationFormText = "Visitdate";
            this.ItemForVisitdate.Location = new System.Drawing.Point(0, 0);
            this.ItemForVisitdate.Name = "ItemForVisitdate";
            this.ItemForVisitdate.Size = new System.Drawing.Size(288, 30);
            this.ItemForVisitdate.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.ItemForVisitdate.Text = "심방일";
            this.ItemForVisitdate.TextSize = new System.Drawing.Size(52, 15);
            // 
            // ItemForBible
            // 
            this.ItemForBible.AppearanceItemCaption.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItemForBible.AppearanceItemCaption.Options.UseFont = true;
            this.ItemForBible.Control = this.BibleTextEdit;
            this.ItemForBible.CustomizationFormText = "Bible";
            this.ItemForBible.Location = new System.Drawing.Point(0, 90);
            this.ItemForBible.Name = "ItemForBible";
            this.ItemForBible.Size = new System.Drawing.Size(288, 30);
            this.ItemForBible.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.ItemForBible.Text = "성경";
            this.ItemForBible.TextSize = new System.Drawing.Size(52, 15);
            // 
            // ItemForSong
            // 
            this.ItemForSong.AppearanceItemCaption.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItemForSong.AppearanceItemCaption.Options.UseFont = true;
            this.ItemForSong.Control = this.SongTextEdit;
            this.ItemForSong.CustomizationFormText = "Song";
            this.ItemForSong.Location = new System.Drawing.Point(288, 90);
            this.ItemForSong.Name = "ItemForSong";
            this.ItemForSong.Size = new System.Drawing.Size(288, 30);
            this.ItemForSong.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.ItemForSong.Text = "찬송";
            this.ItemForSong.TextSize = new System.Drawing.Size(52, 15);
            // 
            // ItemForAttendent
            // 
            this.ItemForAttendent.AppearanceItemCaption.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItemForAttendent.AppearanceItemCaption.Options.UseFont = true;
            this.ItemForAttendent.Control = this.AttendentTextEdit;
            this.ItemForAttendent.CustomizationFormText = "Attendent";
            this.ItemForAttendent.Location = new System.Drawing.Point(288, 60);
            this.ItemForAttendent.Name = "ItemForAttendent";
            this.ItemForAttendent.Size = new System.Drawing.Size(288, 30);
            this.ItemForAttendent.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.ItemForAttendent.Text = "참석자";
            this.ItemForAttendent.TextSize = new System.Drawing.Size(52, 15);
            // 
            // ItemForVisitType
            // 
            this.ItemForVisitType.AppearanceItemCaption.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItemForVisitType.AppearanceItemCaption.Options.UseFont = true;
            this.ItemForVisitType.Control = this.VisitTypeLookUpEdit;
            this.ItemForVisitType.CustomizationFormText = "Visit Type";
            this.ItemForVisitType.Location = new System.Drawing.Point(288, 0);
            this.ItemForVisitType.Name = "ItemForVisitType";
            this.ItemForVisitType.Size = new System.Drawing.Size(288, 30);
            this.ItemForVisitType.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.ItemForVisitType.Text = "심방 구분";
            this.ItemForVisitType.TextSize = new System.Drawing.Size(52, 15);
            // 
            // ItemForMemberId
            // 
            this.ItemForMemberId.AppearanceItemCaption.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItemForMemberId.AppearanceItemCaption.Options.UseFont = true;
            this.ItemForMemberId.Control = this.MemberIdTextEdit;
            this.ItemForMemberId.CustomizationFormText = "Member Id";
            this.ItemForMemberId.Location = new System.Drawing.Point(0, 30);
            this.ItemForMemberId.Name = "ItemForMemberId";
            this.ItemForMemberId.Size = new System.Drawing.Size(288, 30);
            this.ItemForMemberId.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.ItemForMemberId.Text = "교인번호";
            this.ItemForMemberId.TextSize = new System.Drawing.Size(52, 15);
            // 
            // ItemForFullName
            // 
            this.ItemForFullName.AppearanceItemCaption.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItemForFullName.AppearanceItemCaption.Options.UseFont = true;
            this.ItemForFullName.Control = this.FullNameTextEdit;
            this.ItemForFullName.CustomizationFormText = "Full Name";
            this.ItemForFullName.Location = new System.Drawing.Point(288, 30);
            this.ItemForFullName.Name = "ItemForFullName";
            this.ItemForFullName.Size = new System.Drawing.Size(288, 30);
            this.ItemForFullName.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.ItemForFullName.Text = "교인이름";
            this.ItemForFullName.TextSize = new System.Drawing.Size(52, 15);
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
            this.bt_Save,
            this.bt_Close,
            this.btnSearchMember});
            this.barManager1.MaxItemId = 3;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bt_Save, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bt_Close, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar1.OptionsBar.AllowQuickCustomization = false;
            this.bar1.OptionsBar.DrawDragBorder = false;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Tools";
            // 
            // bt_Save
            // 
            this.bt_Save.Caption = "Save";
            this.bt_Save.Glyph = global::LandWin.Properties.Resources.Save;
            this.bt_Save.Id = 0;
            this.bt_Save.Name = "bt_Save";
            this.bt_Save.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bt_Save_ItemClick);
            // 
            // bt_Close
            // 
            this.bt_Close.Caption = "Close";
            this.bt_Close.Glyph = global::LandWin.Properties.Resources.close_icon;
            this.bt_Close.Id = 1;
            this.bt_Close.Name = "bt_Close";
            this.bt_Close.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bt_Close_ItemClick);
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
            // btnSearchMember
            // 
            this.btnSearchMember.Caption = "Search Member";
            this.btnSearchMember.Id = 2;
            this.btnSearchMember.Name = "btnSearchMember";
            // 
            // dxErrorProvider1
            // 
            this.dxErrorProvider1.ContainerControl = this;
            this.dxErrorProvider1.DataSource = this.memberVisitBindingSource;
            // 
            // MemberVisitDetailFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 429);
            this.Controls.Add(this.dataLayoutControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MemberVisitDetailFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "심방 내용";
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MemberIdTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memberVisitBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VisitTypeLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.typeListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VisitdateTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PastorTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AttendentTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SongTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FullNameTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BibleTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ContentTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForContent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForPastor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForVisitdate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForBible)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForSong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForAttendent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForVisitType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForMemberId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForFullName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraEditors.TextEdit MemberIdTextEdit;
        private DevExpress.XtraEditors.LookUpEdit VisitTypeLookUpEdit;
        private DevExpress.XtraEditors.TextEdit VisitdateTextEdit;
        private DevExpress.XtraEditors.TextEdit PastorTextEdit;
        private DevExpress.XtraEditors.TextEdit AttendentTextEdit;
        private DevExpress.XtraEditors.TextEdit BibleTextEdit;
        private DevExpress.XtraEditors.TextEdit SongTextEdit;
        private DevExpress.XtraEditors.TextEdit FullNameTextEdit;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem ItemForMemberId;
        private DevExpress.XtraLayout.LayoutControlItem ItemForVisitdate;
        private DevExpress.XtraLayout.LayoutControlItem ItemForAttendent;
        private DevExpress.XtraLayout.LayoutControlItem ItemForContent;
        private DevExpress.XtraLayout.LayoutControlItem ItemForVisitType;
        private DevExpress.XtraLayout.LayoutControlItem ItemForFullName;
        private DevExpress.XtraLayout.LayoutControlItem ItemForPastor;
        private DevExpress.XtraLayout.LayoutControlItem ItemForBible;
        private DevExpress.XtraLayout.LayoutControlItem ItemForSong;
        private DevExpress.XtraEditors.MemoEdit ContentTextEdit;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem bt_Save;
        private DevExpress.XtraBars.BarButtonItem bt_Close;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private System.Windows.Forms.BindingSource typeListBindingSource;
        private DevExpress.XtraBars.BarButtonItem btnSearchMember;
        private System.Windows.Forms.BindingSource memberVisitBindingSource;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider1;
    }
}