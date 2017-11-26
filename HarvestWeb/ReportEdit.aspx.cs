using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Linq;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Reflection;
using _entity = Dothan.Library;

public partial class ReportEdit : System.Web.UI.Page
{

    private _entity.bizCell.CellReportDetails _details = null;
    private _entity.bizCell.CellReport _header;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            Session["header"] = null;
            Session["detail"] = null;

            if (Session["CellCode"] == null)
                Response.Redirect("Login.aspx");

            PageInit();
        }
        else 
        {
            LoadData();
        }
        
    }
    #region PageProcess

    protected void PageInit()
    {
        LoadData();
        ShowHeader();
        ShowDetail();
    }

    private void LoadData()
    {
        _header = GetRptCell();
        _details = GetRptCellMember();
    }

    private void ShowHeader()
    {

        if (_header.IsNew)
        {
            var members = (from list in _details
                           where list.RoleLevel == 1
                           select new { list.MemberName }).FirstOrDefault();

            if (members != null)
                _header.Level1 = members.MemberName;

            var members2 = (from list in _details
                            where list.RoleLevel == 2
                            select new { list.MemberName }).FirstOrDefault();

            if (members2 != null)
                _header.Level2 = members2.MemberName;
        }
        this.txtrequest.Text = _header.Request;
        this.txtprayer.Text = _header.Prayer;
        this.txtleader.Text = _header.Leader;
        this.txtmemo.Text = _header.Memo;
        this.txtLocation.Text = _header.CellPlace;
        this.TextBox1.Text = _header.CellDate;
        this.txtnewmember.Text = _header.NewMember;
        this.txtLocation.Text = _header.CellPlace;
        this.txtattfamily.Text = _header.AttendFamily.ToString();
        this.Label1.Text = _header.Level1;
        this.Label2.Text = _header.Level2;

    }

    protected void ShowDetail()
    {
        ListView1.DataSource = from b in _details orderby b.ID ascending select b;
        ListView1.DataBind();

    }
   
    private void UpdateHeader()
    {
        _header.Memo = this.txtmemo.Text;
        _header.Leader = this.txtleader.Text;
        _header.NewMember = this.txtnewmember.Text;
        _header.CellDate =this.TextBox1.Text;
        _header.CellPlace =this.txtLocation.Text;
        _header.Prayer = this.txtprayer.Text;
        _header.Request = this.txtrequest.Text;
        _header.AttendFamily = int.Parse(this.txtattfamily.Text);
        _header.UserName = Session["CreateBy"].ToString();
    }
    private void UpdateDetail()
    {
        foreach(ListViewDataItem dataItem in ListView1.Items)
        {
            int id = int.Parse(ListView1.DataKeys[dataItem.DataItemIndex].Value.ToString());
            _entity.bizCell.CellReportDetail info = _details.GetRow(id);
            if(info != null)
            {
                info.Attendence = ((CheckBox)dataItem.FindControl("txt_attendence")).Checked;
                info.Memo = ((TextBox)dataItem.FindControl("txt_memo")).Text;
                info.Reason =((TextBox)dataItem.FindControl("txt_reason")).Text;
            }
        }
    }


    //protected void BulkEditGridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    //{

    //    _entity.bizCell.CellReportDetails memberlist = GetRptCellMember();
    //    if (memberlist.Count > e.RowIndex)
    //    {
    //        int no = this.BulkEditGridView1.GetNewValue<int>(e.RowIndex, 0);
    //        _entity.bizCell.CellReportDetail info = memberlist.GetRow(no);

    //        if (info != null)
    //        {
    //            info.Attendence = this.BulkEditGridView1.GetNewValue<bool>(e.RowIndex, 2); 
    //            info.Reason = this.BulkEditGridView1.GetNewValue<string>(e.RowIndex, "txtReson");
    //            info.Memo = this.BulkEditGridView1.GetNewValue<string>(e.RowIndex, "txtMemo");
    //            Session["currentObject"] = memberlist;

    //        }
    //    }

    //}
    #endregion

    private _entity.bizCell.CellReport GetRptCell()
    {
        object businessObject = Session["header"];
        if (businessObject == null || !(businessObject is _entity.bizCell.CellReport))
        {
            try
            {

                if (Request.QueryString["ReportID"] != null)
                {
                    int id = int.Parse(Request.QueryString["ReportID"].ToString());
                    businessObject = _entity.bizCell.CellReport.Get(id);
                    Session["header"] = businessObject;
                }
                else
                {
                    int id = int.Parse(Session["CellCode"].ToString());
                    businessObject = _entity.bizCell.CellReport.New(id);
                    Session["header"] = businessObject;
                }
            }
            catch (System.Security.SecurityException)
            {
                Response.Redirect("Default.aspx");
            }

        }
        return (_entity.bizCell.CellReport)businessObject;
       

    }

    private _entity.bizCell.CellReportDetails GetRptCellMember()
    {
        object businessObject = Session["detail"];
        if (businessObject == null || !(businessObject is _entity.bizCell.CellReportDetails))
        {
            try
            {
               
                if (Request.QueryString["ReportID"] != null)
                {
                    int id = int.Parse(Request.QueryString["ReportID"].ToString());
                    businessObject = _entity.bizCell.CellReportDetails.Get(id, false);
                    Session["detail"] = businessObject;
                }
                else
                {
                    int id = int.Parse(Session["CellCode"].ToString());
                    businessObject = _entity.bizCell.CellReportDetails.Get(id,true);
                    Session["detail"] = businessObject;
                }
            }
            catch (System.Security.SecurityException)
            {
                Response.Redirect("Default.aspx");
            }

        }
        return (_entity.bizCell.CellReportDetails)businessObject;
    }

    protected void btn_save_Click(object sender, ImageClickEventArgs e)
    {


        UpdateHeader();
        _entity.bizCell.CellReport temp = _header.Clone();
        temp.ApplyEdit();
        _header = temp.Save();

        _details.ParentCode = _header.Id;

        UpdateDetail();

        _entity.bizCell.CellReportDetails temp2 = _details.Clone();
        temp2.ApplyEdit();

        _details = temp2.Save();
        ShowClientMessage("Save Successfully");
        Response.Redirect("Default.aspx");
    }

    public virtual void ShowClientMessage(string message)
    {
        ScriptManager.RegisterClientScriptBlock(this, GetType(), "_client_script_alter_", string.Format("$.messagebox.show('{0}');", message), true);
    }
 
}
