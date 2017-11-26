namespace LandWin
{
    partial class EditDonatorFrm
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
            this.donateMemberBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tb_Save = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tb_Close = new System.Windows.Forms.ToolStripButton();
            this.dataLayoutControl1 = new DevExpress.XtraDataLayout.DataLayoutControl();
            this.NameTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.IdSpinEdit = new DevExpress.XtraEditors.SpinEdit();
            this.AddressidSpinEdit = new DevExpress.XtraEditors.SpinEdit();
            this.MemberidSpinEdit = new DevExpress.XtraEditors.SpinEdit();
            this.En_FirstTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.En_LastTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.StreetTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.CityTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.StateTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ZipcodeTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.HomeTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.MemoTextEdit = new DevExpress.XtraEditors.MemoEdit();
            this.ItemForId = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForAddressid = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForMemberid = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForName = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForEn_Last = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForZipcode = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForState = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForMemo = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForStreet = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForCity = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForEn_First = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForHome = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.donateMemberBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NameTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IdSpinEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AddressidSpinEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MemberidSpinEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.En_FirstTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.En_LastTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StreetTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CityTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StateTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ZipcodeTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HomeTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MemoTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForAddressid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForMemberid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForEn_Last)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForZipcode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForState)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForMemo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForStreet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForEn_First)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForHome)).BeginInit();
            this.SuspendLayout();
            // 
            // donateMemberBindingSource
            // 
            this.donateMemberBindingSource.DataSource = typeof(Dothan.Library.DonateMember);
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            this.errorProvider1.DataSource = this.donateMemberBindingSource;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tb_Save,
            this.toolStripSeparator1,
            this.tb_Close});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(639, 25);
            this.toolStrip1.TabIndex = 18;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tb_Save
            // 
            this.tb_Save.Image = global::LandWin.Properties.Resources.msIcon3;
            this.tb_Save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tb_Save.Name = "tb_Save";
            this.tb_Save.Size = new System.Drawing.Size(51, 22);
            this.tb_Save.Text = "Save";
            this.tb_Save.Click += new System.EventHandler(this.tb_Save_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tb_Close
            // 
            this.tb_Close.Image = global::LandWin.Properties.Resources.close_icon;
            this.tb_Close.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tb_Close.Name = "tb_Close";
            this.tb_Close.Size = new System.Drawing.Size(56, 22);
            this.tb_Close.Text = "Close";
            this.tb_Close.ToolTipText = "Close";
            this.tb_Close.Click += new System.EventHandler(this.tb_Close_Click);
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.NameTextEdit);
            this.dataLayoutControl1.Controls.Add(this.IdSpinEdit);
            this.dataLayoutControl1.Controls.Add(this.AddressidSpinEdit);
            this.dataLayoutControl1.Controls.Add(this.MemberidSpinEdit);
            this.dataLayoutControl1.Controls.Add(this.En_FirstTextEdit);
            this.dataLayoutControl1.Controls.Add(this.En_LastTextEdit);
            this.dataLayoutControl1.Controls.Add(this.StreetTextEdit);
            this.dataLayoutControl1.Controls.Add(this.CityTextEdit);
            this.dataLayoutControl1.Controls.Add(this.StateTextEdit);
            this.dataLayoutControl1.Controls.Add(this.ZipcodeTextEdit);
            this.dataLayoutControl1.Controls.Add(this.HomeTextEdit);
            this.dataLayoutControl1.Controls.Add(this.MemoTextEdit);
            this.dataLayoutControl1.DataSource = this.donateMemberBindingSource;
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.HiddenItems.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForId,
            this.ItemForAddressid,
            this.ItemForMemberid});
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 25);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.Root = this.layoutControlGroup1;
            this.dataLayoutControl1.Size = new System.Drawing.Size(639, 233);
            this.dataLayoutControl1.TabIndex = 19;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // NameTextEdit
            // 
            this.NameTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.donateMemberBindingSource, "Name", true));
            this.NameTextEdit.Location = new System.Drawing.Point(72, 15);
            this.NameTextEdit.Name = "NameTextEdit";
            this.NameTextEdit.Size = new System.Drawing.Size(118, 20);
            this.NameTextEdit.StyleController = this.dataLayoutControl1;
            this.NameTextEdit.TabIndex = 7;
            // 
            // IdSpinEdit
            // 
            this.IdSpinEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.donateMemberBindingSource, "Id", true));
            this.IdSpinEdit.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.IdSpinEdit.Location = new System.Drawing.Point(0, 0);
            this.IdSpinEdit.Name = "IdSpinEdit";
            this.IdSpinEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.IdSpinEdit.Size = new System.Drawing.Size(0, 20);
            this.IdSpinEdit.StyleController = this.dataLayoutControl1;
            this.IdSpinEdit.TabIndex = 4;
            // 
            // AddressidSpinEdit
            // 
            this.AddressidSpinEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.donateMemberBindingSource, "Addressid", true));
            this.AddressidSpinEdit.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.AddressidSpinEdit.Location = new System.Drawing.Point(0, 0);
            this.AddressidSpinEdit.Name = "AddressidSpinEdit";
            this.AddressidSpinEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.AddressidSpinEdit.Size = new System.Drawing.Size(0, 20);
            this.AddressidSpinEdit.StyleController = this.dataLayoutControl1;
            this.AddressidSpinEdit.TabIndex = 5;
            // 
            // MemberidSpinEdit
            // 
            this.MemberidSpinEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.donateMemberBindingSource, "Memberid", true));
            this.MemberidSpinEdit.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.MemberidSpinEdit.Location = new System.Drawing.Point(0, 0);
            this.MemberidSpinEdit.Name = "MemberidSpinEdit";
            this.MemberidSpinEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.MemberidSpinEdit.Size = new System.Drawing.Size(0, 20);
            this.MemberidSpinEdit.StyleController = this.dataLayoutControl1;
            this.MemberidSpinEdit.TabIndex = 6;
            // 
            // En_FirstTextEdit
            // 
            this.En_FirstTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.donateMemberBindingSource, "En_First", true));
            this.En_FirstTextEdit.Location = new System.Drawing.Point(488, 15);
            this.En_FirstTextEdit.Name = "En_FirstTextEdit";
            this.En_FirstTextEdit.Size = new System.Drawing.Size(136, 20);
            this.En_FirstTextEdit.StyleController = this.dataLayoutControl1;
            this.En_FirstTextEdit.TabIndex = 8;
            // 
            // En_LastTextEdit
            // 
            this.En_LastTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.donateMemberBindingSource, "En_Last", true));
            this.En_LastTextEdit.Location = new System.Drawing.Point(257, 15);
            this.En_LastTextEdit.Name = "En_LastTextEdit";
            this.En_LastTextEdit.Size = new System.Drawing.Size(164, 20);
            this.En_LastTextEdit.StyleController = this.dataLayoutControl1;
            this.En_LastTextEdit.TabIndex = 9;
            // 
            // StreetTextEdit
            // 
            this.StreetTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.donateMemberBindingSource, "Street", true));
            this.StreetTextEdit.Location = new System.Drawing.Point(72, 45);
            this.StreetTextEdit.Name = "StreetTextEdit";
            this.StreetTextEdit.Size = new System.Drawing.Size(349, 20);
            this.StreetTextEdit.StyleController = this.dataLayoutControl1;
            this.StreetTextEdit.TabIndex = 11;
            // 
            // CityTextEdit
            // 
            this.CityTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.donateMemberBindingSource, "City", true));
            this.CityTextEdit.Location = new System.Drawing.Point(257, 75);
            this.CityTextEdit.Name = "CityTextEdit";
            this.CityTextEdit.Size = new System.Drawing.Size(164, 20);
            this.CityTextEdit.StyleController = this.dataLayoutControl1;
            this.CityTextEdit.TabIndex = 12;
            // 
            // StateTextEdit
            // 
            this.StateTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.donateMemberBindingSource, "State", true));
            this.StateTextEdit.Location = new System.Drawing.Point(488, 75);
            this.StateTextEdit.Name = "StateTextEdit";
            this.StateTextEdit.Size = new System.Drawing.Size(136, 20);
            this.StateTextEdit.StyleController = this.dataLayoutControl1;
            this.StateTextEdit.TabIndex = 13;
            // 
            // ZipcodeTextEdit
            // 
            this.ZipcodeTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.donateMemberBindingSource, "Zipcode", true));
            this.ZipcodeTextEdit.Location = new System.Drawing.Point(72, 75);
            this.ZipcodeTextEdit.Name = "ZipcodeTextEdit";
            this.ZipcodeTextEdit.Size = new System.Drawing.Size(118, 20);
            this.ZipcodeTextEdit.StyleController = this.dataLayoutControl1;
            this.ZipcodeTextEdit.TabIndex = 14;
            this.ZipcodeTextEdit.Leave += new System.EventHandler(this.zipcodeTextBox_Leave);
            // 
            // HomeTextEdit
            // 
            this.HomeTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.donateMemberBindingSource, "Home", true));
            this.HomeTextEdit.Location = new System.Drawing.Point(488, 45);
            this.HomeTextEdit.Name = "HomeTextEdit";
            this.HomeTextEdit.Size = new System.Drawing.Size(136, 20);
            this.HomeTextEdit.StyleController = this.dataLayoutControl1;
            this.HomeTextEdit.TabIndex = 15;
            // 
            // MemoTextEdit
            // 
            this.MemoTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.donateMemberBindingSource, "Memo", true));
            this.MemoTextEdit.Location = new System.Drawing.Point(72, 105);
            this.MemoTextEdit.Name = "MemoTextEdit";
            this.MemoTextEdit.Size = new System.Drawing.Size(552, 113);
            this.MemoTextEdit.StyleController = this.dataLayoutControl1;
            this.MemoTextEdit.TabIndex = 10;
            this.MemoTextEdit.TabStop = false;
            // 
            // ItemForId
            // 
            this.ItemForId.Control = this.IdSpinEdit;
            this.ItemForId.CustomizationFormText = "Id";
            this.ItemForId.Location = new System.Drawing.Point(0, 0);
            this.ItemForId.Name = "ItemForId";
            this.ItemForId.Size = new System.Drawing.Size(0, 0);
            this.ItemForId.Text = "Id";
            this.ItemForId.TextSize = new System.Drawing.Size(50, 20);
            this.ItemForId.TextToControlDistance = 5;
            // 
            // ItemForAddressid
            // 
            this.ItemForAddressid.Control = this.AddressidSpinEdit;
            this.ItemForAddressid.CustomizationFormText = "Addressid";
            this.ItemForAddressid.Location = new System.Drawing.Point(0, 0);
            this.ItemForAddressid.Name = "ItemForAddressid";
            this.ItemForAddressid.Size = new System.Drawing.Size(0, 0);
            this.ItemForAddressid.Text = "Addressid";
            this.ItemForAddressid.TextSize = new System.Drawing.Size(50, 20);
            this.ItemForAddressid.TextToControlDistance = 5;
            // 
            // ItemForMemberid
            // 
            this.ItemForMemberid.Control = this.MemberidSpinEdit;
            this.ItemForMemberid.CustomizationFormText = "Memberid";
            this.ItemForMemberid.Location = new System.Drawing.Point(0, 0);
            this.ItemForMemberid.Name = "ItemForMemberid";
            this.ItemForMemberid.Size = new System.Drawing.Size(0, 0);
            this.ItemForMemberid.Text = "Memberid";
            this.ItemForMemberid.TextSize = new System.Drawing.Size(50, 20);
            this.ItemForMemberid.TextToControlDistance = 5;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutControlGroup1.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(639, 233);
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
            this.ItemForName,
            this.ItemForEn_Last,
            this.ItemForZipcode,
            this.ItemForState,
            this.ItemForMemo,
            this.ItemForStreet,
            this.ItemForCity,
            this.ItemForEn_First,
            this.ItemForHome});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "autoGeneratedGroup0";
            this.layoutControlGroup2.Size = new System.Drawing.Size(619, 213);
            this.layoutControlGroup2.Text = "autoGeneratedGroup0";
            // 
            // ItemForName
            // 
            this.ItemForName.Control = this.NameTextEdit;
            this.ItemForName.CustomizationFormText = "교인명";
            this.ItemForName.Location = new System.Drawing.Point(0, 0);
            this.ItemForName.Name = "ItemForName";
            this.ItemForName.Size = new System.Drawing.Size(185, 30);
            this.ItemForName.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.ItemForName.Text = "교인명";
            this.ItemForName.TextSize = new System.Drawing.Size(53, 14);
            // 
            // ItemForEn_Last
            // 
            this.ItemForEn_Last.Control = this.En_LastTextEdit;
            this.ItemForEn_Last.CustomizationFormText = "LastName";
            this.ItemForEn_Last.Location = new System.Drawing.Point(185, 0);
            this.ItemForEn_Last.Name = "ItemForEn_Last";
            this.ItemForEn_Last.Size = new System.Drawing.Size(231, 30);
            this.ItemForEn_Last.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.ItemForEn_Last.Text = "LastName";
            this.ItemForEn_Last.TextSize = new System.Drawing.Size(53, 14);
            // 
            // ItemForZipcode
            // 
            this.ItemForZipcode.Control = this.ZipcodeTextEdit;
            this.ItemForZipcode.CustomizationFormText = "Zipcode";
            this.ItemForZipcode.Location = new System.Drawing.Point(0, 60);
            this.ItemForZipcode.Name = "ItemForZipcode";
            this.ItemForZipcode.Size = new System.Drawing.Size(185, 30);
            this.ItemForZipcode.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.ItemForZipcode.Text = "Zipcode";
            this.ItemForZipcode.TextSize = new System.Drawing.Size(53, 14);
            // 
            // ItemForState
            // 
            this.ItemForState.Control = this.StateTextEdit;
            this.ItemForState.CustomizationFormText = "State";
            this.ItemForState.Location = new System.Drawing.Point(416, 60);
            this.ItemForState.Name = "ItemForState";
            this.ItemForState.Size = new System.Drawing.Size(203, 30);
            this.ItemForState.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.ItemForState.Text = "State";
            this.ItemForState.TextSize = new System.Drawing.Size(53, 14);
            // 
            // ItemForMemo
            // 
            this.ItemForMemo.Control = this.MemoTextEdit;
            this.ItemForMemo.CustomizationFormText = "Memo";
            this.ItemForMemo.Location = new System.Drawing.Point(0, 90);
            this.ItemForMemo.Name = "ItemForMemo";
            this.ItemForMemo.Size = new System.Drawing.Size(619, 123);
            this.ItemForMemo.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.ItemForMemo.Text = "Memo";
            this.ItemForMemo.TextSize = new System.Drawing.Size(53, 14);
            // 
            // ItemForStreet
            // 
            this.ItemForStreet.Control = this.StreetTextEdit;
            this.ItemForStreet.CustomizationFormText = "Street";
            this.ItemForStreet.Location = new System.Drawing.Point(0, 30);
            this.ItemForStreet.Name = "ItemForStreet";
            this.ItemForStreet.Size = new System.Drawing.Size(416, 30);
            this.ItemForStreet.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.ItemForStreet.Text = "Street";
            this.ItemForStreet.TextSize = new System.Drawing.Size(53, 14);
            // 
            // ItemForCity
            // 
            this.ItemForCity.Control = this.CityTextEdit;
            this.ItemForCity.CustomizationFormText = "City";
            this.ItemForCity.Location = new System.Drawing.Point(185, 60);
            this.ItemForCity.Name = "ItemForCity";
            this.ItemForCity.Size = new System.Drawing.Size(231, 30);
            this.ItemForCity.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.ItemForCity.Text = "City";
            this.ItemForCity.TextSize = new System.Drawing.Size(53, 14);
            // 
            // ItemForEn_First
            // 
            this.ItemForEn_First.Control = this.En_FirstTextEdit;
            this.ItemForEn_First.CustomizationFormText = "FristName";
            this.ItemForEn_First.Location = new System.Drawing.Point(416, 0);
            this.ItemForEn_First.Name = "ItemForEn_First";
            this.ItemForEn_First.Size = new System.Drawing.Size(203, 30);
            this.ItemForEn_First.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.ItemForEn_First.Text = "FristName";
            this.ItemForEn_First.TextSize = new System.Drawing.Size(53, 14);
            // 
            // ItemForHome
            // 
            this.ItemForHome.Control = this.HomeTextEdit;
            this.ItemForHome.CustomizationFormText = "Home";
            this.ItemForHome.Location = new System.Drawing.Point(416, 30);
            this.ItemForHome.Name = "ItemForHome";
            this.ItemForHome.Size = new System.Drawing.Size(203, 30);
            this.ItemForHome.Spacing = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.ItemForHome.Text = "Home";
            this.ItemForHome.TextSize = new System.Drawing.Size(53, 14);
            // 
            // EditDonatorFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 258);
            this.Controls.Add(this.dataLayoutControl1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "EditDonatorFrm";
            this.Text = "Edit Donator";
            ((System.ComponentModel.ISupportInitialize)(this.donateMemberBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NameTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IdSpinEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AddressidSpinEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MemberidSpinEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.En_FirstTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.En_LastTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StreetTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CityTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StateTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ZipcodeTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HomeTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MemoTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForAddressid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForMemberid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForEn_Last)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForZipcode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForState)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForMemo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForStreet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForCity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForEn_First)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForHome)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource donateMemberBindingSource;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        internal System.Windows.Forms.ToolStripButton tb_Close;
        internal System.Windows.Forms.ToolStripButton tb_Save;
        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private DevExpress.XtraEditors.TextEdit NameTextEdit;
        private DevExpress.XtraEditors.SpinEdit IdSpinEdit;
        private DevExpress.XtraEditors.SpinEdit AddressidSpinEdit;
        private DevExpress.XtraEditors.SpinEdit MemberidSpinEdit;
        private DevExpress.XtraEditors.TextEdit En_FirstTextEdit;
        private DevExpress.XtraEditors.TextEdit En_LastTextEdit;
        private DevExpress.XtraEditors.TextEdit StreetTextEdit;
        private DevExpress.XtraEditors.TextEdit CityTextEdit;
        private DevExpress.XtraEditors.TextEdit StateTextEdit;
        private DevExpress.XtraEditors.TextEdit ZipcodeTextEdit;
        private DevExpress.XtraEditors.TextEdit HomeTextEdit;
        private DevExpress.XtraLayout.LayoutControlItem ItemForId;
        private DevExpress.XtraLayout.LayoutControlItem ItemForAddressid;
        private DevExpress.XtraLayout.LayoutControlItem ItemForMemberid;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem ItemForName;
        private DevExpress.XtraLayout.LayoutControlItem ItemForEn_Last;
        private DevExpress.XtraLayout.LayoutControlItem ItemForZipcode;
        private DevExpress.XtraLayout.LayoutControlItem ItemForState;
        private DevExpress.XtraLayout.LayoutControlItem ItemForMemo;
        private DevExpress.XtraLayout.LayoutControlItem ItemForStreet;
        private DevExpress.XtraLayout.LayoutControlItem ItemForCity;
        private DevExpress.XtraLayout.LayoutControlItem ItemForEn_First;
        private DevExpress.XtraLayout.LayoutControlItem ItemForHome;
        private DevExpress.XtraEditors.MemoEdit MemoTextEdit;
    }
}