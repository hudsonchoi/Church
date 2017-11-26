using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using _entity = Dothan.Library;
using LandWin.Properties;

namespace LandWin.Tools
{
    public partial class FamilyAddFrm : Form
    {
        private int _memberid;
        private int _familycode;
        public FamilyAddFrm(int familycode)
        {
            InitializeComponent();

            this.subdivisionListBindingSource.DataSource = _entity.bizCommon.SubdivisionList.Get(false);
            _entity.bizCommon.TypeList relastioship =  _entity.bizCommon.TypeList.Get("relationship", false);
            this.typeListBindingSource.DataSource = from list in relastioship
                                                    where list.Key != 0
                                                    select list;
            _familycode = familycode;
         
            btnSearch.Click += new EventHandler(btnfind_Click);
            btnApply.Click += new EventHandler(btnApply_Click);
        }
        private void btnClose(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnApply_Click(object sender, EventArgs e)
        {
            if (this.gridView1 == null || this.gridView1.SelectedRowsCount == 0 )
            {
                MessageBox.Show(Properties.Resources.No_SelectedRow);
                return;
            }
            if (this.ddlRelationship.EditValue == null)
            {
                MessageBox.Show(Properties.Resources.No_SelectedRow);
                this.ddlRelationship.Focus();
                return;
            }

            _entity.bizMember.MemberInfo info = this.gridView1.GetRow(this.gridView1.GetSelectedRows()[0]) as _entity.bizMember.MemberInfo;
            if (info.FamilyCode == info.MemberId)
            {
                _entity.bizMember.FamilyList family = _entity.bizMember.FamilyList.GetList(info.MemberId);

                if (family.Count != 1)
                {
                    MessageBox.Show(Properties.Resources.Error_AddFamilyOwner);
                    return;
                }
            }
            
                DialogResult result = MessageBox.Show(Resources.ChangeFamilyQue, "Important Message", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {

                    try
                    {
                        Shared.SqlDataList itemParams = new Shared.SqlDataList();
                        System.Security.Principal.IPrincipal user = Dothan.ApplicationContext.User;
                        //Dictionary<int, int> relationship = new Dictionary<int, int>();
                        //relationship.Add(info.MemberId, (int)ddlRelationship.EditValue);
                        itemParams.Add(new Dictionary<string, object> { { "memberid", info.MemberId }, { "relastionship", ddlRelationship.EditValue } });

                        _entity.bizMember.Member.ToChangeFamilyCode(_familycode, itemParams.ToXml(), user.Identity.Name);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    catch (Dothan.DataPortalException ex)
                    {
                        if (ex.BusinessException is System.Data.SqlClient.SqlException)
                        {
                            Shared.Utility.ErrorLogging(Properties.Resources.ErrorMessage_SqlException, ex.BusinessException.ToString(), "Error");

                        }
                        else
                        {
                            Shared.Utility.ErrorLogging(Properties.Resources.ErrorMessage_General, ex.BusinessException.ToString(), "Error");

                        }
                    }
                    catch (Exception ex)
                    {
                        Shared.Utility.ErrorLogging(Properties.Resources.ErrorMessage_General, ex.ToString(), "Error");
                    }

                }
            
        }
        private void btnfind_Click(object sender, EventArgs e)
        {
            try
            {
               
                this.memberListBindingSource.DataSource = _entity.bizMember.MemberList.Get(this.txtKoName.Text,  ddlSubDivision.EditValue == null ? 0 :(int)ddlSubDivision.EditValue);
                this.gridView1.RefreshData();
                this.gridView1.BestFitColumns();
            }
            catch
            { }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
