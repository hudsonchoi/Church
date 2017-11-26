using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using _entity = Dothan.Library;
using LandWin.Properties;

namespace LandWin.Tools
{
    public partial class ChangeFamilyOwnerFrm : Form
    {
        private int _index;
        private int _familycode;
        private _entity.bizMember.FamilyList _list;

        public ChangeFamilyOwnerFrm(_entity.bizMember.FamilyList list, _entity.bizMember.Member member)
        {
            InitializeComponent();
            _familycode = member.MemberID;
            _list = list;
            this.txtMemberName.Text = member.KoName;
            this.txtMemberID.Text = member.MemberID.ToString();
             _entity.bizCommon.TypeList relationship = _entity.bizCommon.TypeList.Get("relationship",false);
            this.typeListBindingSource.DataSource = from info in relationship
                                                    where info.Key != 0
                                                    select info;
            this.familyListBindingSource.DataSource = from item in list
                                                      where item.MemberId != member.MemberID
                                                      select item;

        
           
        }

        private void Tb_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.Column.Name == "gridColumn1" && e.IsGetData)
            {
                _entity.bizMember.FamilyInfo info = gridView1.GetRow(e.RowHandle) as _entity.bizMember.FamilyInfo;

                e.Value = info.RelationShipCode == 0 ? 1 : info.RelationShipCode;
            }
        }

        private void Tb_Apply_Click(object sender, EventArgs e)
        {

           // ValidateValue();
            DialogResult result = MessageBox.Show("세대주를 변경하시겠습니까?", "Important Message", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    Shared.SqlDataList itemParams = new Shared.SqlDataList();
                    itemParams.Add(new Dictionary<string, object> { { "memberid", _familycode }, { "relastionship", 0 } });
                      
                    for (int i = 0; i < gridView1.DataRowCount; i++)
                    {

                        _entity.bizMember.FamilyInfo info = gridView1.GetRow(i) as _entity.bizMember.FamilyInfo;

                        if (gridView1.GetRowCellValue(i, gridColumn1) == null || (int)gridView1.GetRowCellValue(i, gridColumn1) == 0)
                        {
                            throw new ArgumentNullException();
                        }
                        itemParams.Add(new Dictionary<string, object> { { "memberid", info.MemberId }, { "relastionship", gridView1.GetRowCellValue(i, gridColumn1) } });
                       
                    }
                    
                    _entity.bizMember.Member.ToChangeFamilyCode(_familycode,itemParams.ToXml() , Dothan.ApplicationContext.User.Identity.Name);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Dothan.DataPortalException ex)
                {
                    MessageBox.Show(ex.BusinessException.ToString(),
                      "Error saving", MessageBoxButtons.OK,
                      MessageBoxIcon.Exclamation);
                }
                catch (Exception ex)
                {
                    if (ex is ArgumentNullException)
                    {
                        MessageBox.Show("Please Select a Relationship",
                          "Error Validation", MessageBoxButtons.OK,
                          MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        MessageBox.Show(ex.ToString(),
                          "Error Saving", MessageBoxButtons.OK,
                          MessageBoxIcon.Exclamation);
                    }
                }
              
                
            }
        }

       
    

       
    }
}
