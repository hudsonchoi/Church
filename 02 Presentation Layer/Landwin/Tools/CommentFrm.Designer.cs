namespace LandWin.Tools
{
    partial class CommentFrm
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
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.IdSpinEdit = new DevExpress.XtraEditors.SpinEdit();
            this.commentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ContextMemoEdit = new DevExpress.XtraEditors.MemoEdit();
            this.RegdateTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.LastUpdatedTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.UsernameTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.MemberTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.ItemForId = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.ItemForContext = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForMember = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForRegdate = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForLastUpdated = new DevExpress.XtraLayout.LayoutControlItem();
            this.ItemForUsername = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).BeginInit();
            this.dataLayoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IdSpinEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.commentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ContextMemoEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RegdateTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LastUpdatedTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UsernameTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MemberTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForContext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForMember)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForRegdate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForLastUpdated)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForUsername)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataLayoutControl1
            // 
            this.dataLayoutControl1.Controls.Add(this.btnCancel);
            this.dataLayoutControl1.Controls.Add(this.btnSave);
            this.dataLayoutControl1.Controls.Add(this.IdSpinEdit);
            this.dataLayoutControl1.Controls.Add(this.ContextMemoEdit);
            this.dataLayoutControl1.Controls.Add(this.RegdateTextEdit);
            this.dataLayoutControl1.Controls.Add(this.LastUpdatedTextEdit);
            this.dataLayoutControl1.Controls.Add(this.UsernameTextEdit);
            this.dataLayoutControl1.Controls.Add(this.MemberTextEdit);
            this.dataLayoutControl1.DataSource = this.commentBindingSource;
            this.dataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataLayoutControl1.HiddenItems.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.ItemForId});
            this.dataLayoutControl1.Location = new System.Drawing.Point(0, 0);
            this.dataLayoutControl1.Name = "dataLayoutControl1";
            this.dataLayoutControl1.Root = this.layoutControlGroup1;
            this.dataLayoutControl1.Size = new System.Drawing.Size(530, 264);
            this.dataLayoutControl1.TabIndex = 0;
            this.dataLayoutControl1.Text = "dataLayoutControl1";
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.Image = global::LandWin.Properties.Resources.BindingNavigatorDeleteItem;
            this.btnCancel.Location = new System.Drawing.Point(396, 228);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 22);
            this.btnCancel.StyleController = this.dataLayoutControl1;
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.Image = global::LandWin.Properties.Resources.Save;
            this.btnSave.Location = new System.Drawing.Point(269, 228);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(119, 22);
            this.btnSave.StyleController = this.dataLayoutControl1;
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // IdSpinEdit
            // 
            this.IdSpinEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.commentBindingSource, "Id", true));
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
            // commentBindingSource
            // 
            this.commentBindingSource.DataSource = typeof(Dothan.Library.bizMember.Comment);
            // 
            // ContextMemoEdit
            // 
            this.ContextMemoEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.commentBindingSource, "Context", true));
            this.ContextMemoEdit.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.commentBindingSource, "Context", true));
            this.ContextMemoEdit.Location = new System.Drawing.Point(88, 74);
            this.ContextMemoEdit.Name = "ContextMemoEdit";
            this.ContextMemoEdit.Properties.Appearance.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ContextMemoEdit.Properties.Appearance.Options.UseFont = true;
            this.ContextMemoEdit.Size = new System.Drawing.Size(428, 146);
            this.ContextMemoEdit.StyleController = this.dataLayoutControl1;
            this.ContextMemoEdit.TabIndex = 5;
            // 
            // RegdateTextEdit
            // 
            this.RegdateTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.commentBindingSource, "Regdate", true));
            this.RegdateTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.commentBindingSource, "Regdate", true));
            this.RegdateTextEdit.Location = new System.Drawing.Point(342, 14);
            this.RegdateTextEdit.Name = "RegdateTextEdit";
            this.RegdateTextEdit.Properties.Appearance.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegdateTextEdit.Properties.Appearance.Options.UseFont = true;
            this.RegdateTextEdit.Properties.ReadOnly = true;
            this.RegdateTextEdit.Size = new System.Drawing.Size(174, 22);
            this.RegdateTextEdit.StyleController = this.dataLayoutControl1;
            this.RegdateTextEdit.TabIndex = 6;
            // 
            // LastUpdatedTextEdit
            // 
            this.LastUpdatedTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.commentBindingSource, "LastUpdated", true));
            this.LastUpdatedTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.commentBindingSource, "LastUpdated", true));
            this.LastUpdatedTextEdit.Location = new System.Drawing.Point(342, 44);
            this.LastUpdatedTextEdit.Name = "LastUpdatedTextEdit";
            this.LastUpdatedTextEdit.Properties.Appearance.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LastUpdatedTextEdit.Properties.Appearance.Options.UseFont = true;
            this.LastUpdatedTextEdit.Properties.ReadOnly = true;
            this.LastUpdatedTextEdit.Size = new System.Drawing.Size(174, 22);
            this.LastUpdatedTextEdit.StyleController = this.dataLayoutControl1;
            this.LastUpdatedTextEdit.TabIndex = 7;
            // 
            // UsernameTextEdit
            // 
            this.UsernameTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.commentBindingSource, "Username", true));
            this.UsernameTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.commentBindingSource, "Username", true));
            this.UsernameTextEdit.Location = new System.Drawing.Point(88, 44);
            this.UsernameTextEdit.Name = "UsernameTextEdit";
            this.UsernameTextEdit.Properties.Appearance.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameTextEdit.Properties.Appearance.Options.UseFont = true;
            this.UsernameTextEdit.Properties.ReadOnly = true;
            this.UsernameTextEdit.Size = new System.Drawing.Size(172, 22);
            this.UsernameTextEdit.StyleController = this.dataLayoutControl1;
            this.UsernameTextEdit.TabIndex = 8;
            // 
            // MemberTextEdit
            // 
            this.MemberTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.commentBindingSource, "Member", true));
            this.MemberTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.commentBindingSource, "Member", true));
            this.MemberTextEdit.Location = new System.Drawing.Point(88, 14);
            this.MemberTextEdit.Name = "MemberTextEdit";
            this.MemberTextEdit.Properties.Appearance.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MemberTextEdit.Properties.Appearance.Options.UseFont = true;
            this.MemberTextEdit.Properties.ReadOnly = true;
            this.MemberTextEdit.Size = new System.Drawing.Size(172, 22);
            this.MemberTextEdit.StyleController = this.dataLayoutControl1;
            this.MemberTextEdit.TabIndex = 9;
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
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2,
            this.emptySpaceItem1,
            this.layoutControlItem1,
            this.layoutControlItem2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(530, 264);
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
            this.ItemForContext,
            this.ItemForMember,
            this.ItemForRegdate,
            this.ItemForLastUpdated,
            this.ItemForUsername});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "autoGeneratedGroup0";
            this.layoutControlGroup2.Size = new System.Drawing.Size(510, 214);
            this.layoutControlGroup2.Text = "autoGeneratedGroup0";
            // 
            // ItemForContext
            // 
            this.ItemForContext.AppearanceItemCaption.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItemForContext.AppearanceItemCaption.Options.UseFont = true;
            this.ItemForContext.Control = this.ContextMemoEdit;
            this.ItemForContext.CustomizationFormText = "Context";
            this.ItemForContext.Location = new System.Drawing.Point(0, 60);
            this.ItemForContext.Name = "ItemForContext";
            this.ItemForContext.Size = new System.Drawing.Size(510, 154);
            this.ItemForContext.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.ItemForContext.Text = "비고사항";
            this.ItemForContext.TextSize = new System.Drawing.Size(70, 15);
            // 
            // ItemForMember
            // 
            this.ItemForMember.AppearanceItemCaption.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItemForMember.AppearanceItemCaption.Options.UseFont = true;
            this.ItemForMember.Control = this.MemberTextEdit;
            this.ItemForMember.CustomizationFormText = "Member";
            this.ItemForMember.Location = new System.Drawing.Point(0, 0);
            this.ItemForMember.Name = "ItemForMember";
            this.ItemForMember.Size = new System.Drawing.Size(254, 30);
            this.ItemForMember.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.ItemForMember.Text = "교인이름";
            this.ItemForMember.TextSize = new System.Drawing.Size(70, 15);
            // 
            // ItemForRegdate
            // 
            this.ItemForRegdate.AppearanceItemCaption.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItemForRegdate.AppearanceItemCaption.Options.UseFont = true;
            this.ItemForRegdate.Control = this.RegdateTextEdit;
            this.ItemForRegdate.CustomizationFormText = "Regdate";
            this.ItemForRegdate.Location = new System.Drawing.Point(254, 0);
            this.ItemForRegdate.Name = "ItemForRegdate";
            this.ItemForRegdate.Size = new System.Drawing.Size(256, 30);
            this.ItemForRegdate.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.ItemForRegdate.Text = "작성날짜";
            this.ItemForRegdate.TextSize = new System.Drawing.Size(70, 15);
            // 
            // ItemForLastUpdated
            // 
            this.ItemForLastUpdated.AppearanceItemCaption.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItemForLastUpdated.AppearanceItemCaption.Options.UseFont = true;
            this.ItemForLastUpdated.Control = this.LastUpdatedTextEdit;
            this.ItemForLastUpdated.CustomizationFormText = "Last Updated";
            this.ItemForLastUpdated.Location = new System.Drawing.Point(254, 30);
            this.ItemForLastUpdated.Name = "ItemForLastUpdated";
            this.ItemForLastUpdated.Size = new System.Drawing.Size(256, 30);
            this.ItemForLastUpdated.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.ItemForLastUpdated.Text = "Last Updated";
            this.ItemForLastUpdated.TextSize = new System.Drawing.Size(70, 15);
            // 
            // ItemForUsername
            // 
            this.ItemForUsername.AppearanceItemCaption.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ItemForUsername.AppearanceItemCaption.Options.UseFont = true;
            this.ItemForUsername.Control = this.UsernameTextEdit;
            this.ItemForUsername.CustomizationFormText = "Username";
            this.ItemForUsername.Location = new System.Drawing.Point(0, 30);
            this.ItemForUsername.Name = "ItemForUsername";
            this.ItemForUsername.Size = new System.Drawing.Size(254, 30);
            this.ItemForUsername.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.ItemForUsername.Text = "작성자";
            this.ItemForUsername.TextSize = new System.Drawing.Size(70, 15);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 214);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(255, 30);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.btnSave;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(255, 214);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(127, 30);
            this.layoutControlItem1.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnCancel;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(382, 214);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(128, 30);
            this.layoutControlItem2.Spacing = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // CommentFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 264);
            this.Controls.Add(this.dataLayoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CommentFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "비고사항";
            ((System.ComponentModel.ISupportInitialize)(this.dataLayoutControl1)).EndInit();
            this.dataLayoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.IdSpinEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.commentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ContextMemoEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RegdateTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LastUpdatedTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UsernameTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MemberTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForContext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForMember)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForRegdate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForLastUpdated)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ItemForUsername)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraDataLayout.DataLayoutControl dataLayoutControl1;
        private System.Windows.Forms.BindingSource commentBindingSource;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.SpinEdit IdSpinEdit;
        private DevExpress.XtraEditors.MemoEdit ContextMemoEdit;
        private DevExpress.XtraEditors.TextEdit RegdateTextEdit;
        private DevExpress.XtraEditors.TextEdit LastUpdatedTextEdit;
        private DevExpress.XtraEditors.TextEdit UsernameTextEdit;
        private DevExpress.XtraEditors.TextEdit MemberTextEdit;
        private DevExpress.XtraLayout.LayoutControlItem ItemForId;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem ItemForContext;
        private DevExpress.XtraLayout.LayoutControlItem ItemForRegdate;
        private DevExpress.XtraLayout.LayoutControlItem ItemForLastUpdated;
        private DevExpress.XtraLayout.LayoutControlItem ItemForUsername;
        private DevExpress.XtraLayout.LayoutControlItem ItemForMember;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
    }
}