using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Reflection;
using _entity = Dothan.Library.bizCell;

public partial class ReportEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["currentObject"] = null;
            Session["currentObject1"] = null;
            this.ViewState["BulkEdit"] = null;
            if (Session["CellCode"] == null)
                Response.Redirect("Login.aspx");
            Session["currentObject"] = null;

            if (Request.QueryString["ReportID"] != null)
            {
                RefreshGrid();
                RefreshButtons(false);
            }
            else
            {
                this.BulkEditGridView1.BulkEdit = true;
                RefreshGrid();
                RefreshButtons(true);
            }
  
        }
    }
    #region PageProcess

    private void RefreshGrid()
    {
        RptCell result = GetRptCell();
        this.txtrequest.Text = result.Request;
        this.txtprayer.Text = result.Prayer;
        this.txtleader.Text = result.Leader;
        this.txtmemo.Text = result.Memo;
        this.txtLocation.Text = result.CellPlace;
        this.TextBox1.Text = result.CellDate;
   //     this.txtattendence.Text = result.AttendMemo;
        this.txtnewmember.Text = result.NewMember;
        this.txtLocation.Text = result.CellPlace;
        this.txtattfamily.Text = result.AttendFamily.ToString();
        this.BulkEditGridView1.DataSource = DataAccessLayer.Instance.GetEntities<MemberEntity>(GetRptCellMember());
        this.BulkEditGridView1.DataBind();
        GetRptCellObject();
    }

 
    private void RefreshButtons(bool editMode)
    {
        if (editMode)
        {
            this.btn_edit.Visible = false;
            this.btn_edit2.Visible = false;
            this.btn_save.Visible = true;
            this.btn_save2.Visible = true;
  //          this.txtattendence.ReadOnly = false;
            this.txtattfamily.ReadOnly = false;
            this.txtleader.ReadOnly = false;
            this.txtLocation.ReadOnly = false;
            this.txtmemo.ReadOnly = false;
            this.txtnewmember.ReadOnly = false;
            this.txtprayer.ReadOnly = false;
            this.txtrequest.ReadOnly = false; 
            
        }
        else
        {
            this.btn_edit.Visible = true;
            this.btn_edit2.Visible = true;
            this.btn_save.Visible = false;
            this.btn_save2.Visible = false;
   //         this.txtattendence.ReadOnly = true;
           this.txtattfamily.ReadOnly = true;
            this.txtleader.ReadOnly = true;
            this.txtLocation.ReadOnly = true;
            this.txtmemo.ReadOnly = true;
            this.txtnewmember.ReadOnly = true;
            this.txtprayer.ReadOnly = true;
            this.txtrequest.ReadOnly = true;
        }
    }


    private void SaveData()
    {

        RptCell result = GetRptCell();
        RptCellMembers memberlist = GetRptCellMember();
        memberlist.SetRegdate(result.RegDate);
        memberlist.SetReportID(result.Id);
        Session["currentObject"] = memberlist.Save();
        Response.Redirect("Default.aspx");
        
    }
    protected void BulkEditGridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
       
        RptCellMembers memberlist = GetRptCellMember();
        if (memberlist.Count > e.RowIndex)
        {
            int no = this.BulkEditGridView1.GetNewValue<int>(e.RowIndex, 0);
            RptCellMember info = memberlist.GetItem(no);

            if (info != null)
            {
                info.Attendence = this.BulkEditGridView1.GetNewValue<bool>(e.RowIndex, 2); ;
                info.Reson = this.BulkEditGridView1.GetNewValue<string>(e.RowIndex, "txtReson");
                info.Memo = this.BulkEditGridView1.GetNewValue<string>(e.RowIndex, "txtMemo");
                memberlist.Replace(info);
                Session["currentObject"] = memberlist;

            }
        }
  
    }
    #endregion

    private void GetRptCellObject()
    {
        _entity.CellReport obj2 = GetRptCellMember();
        foreach ( info in obj2)
        {
            if (info.Levels.Equals(1))
                Label1.Text = info.MemberName;
            else if (info.Levels.Equals(2))
                Label2.Text = info.MemberName;
        }
        
    }

    private _entity.CellReport GetRptCell()
    {
        object businessObject = Session["currentObject1"];
        if (businessObject == null || !(businessObject is _entity.CellReport))
        {
            try
            {

                if (Request.QueryString["ReportID"] != null)
                {
                    int id = int.Parse(Request.QueryString["ReportID"].ToString());
                    businessObject = _entity.CellReport.Get(id);
                    Session["currentObject1"] = businessObject;
                }
                else
                {
                    int id = int.Parse(Session["CellCode"].ToString());
                    businessObject = _entity.CellReport.New(id);
                    Session["currentObject1"] = businessObject;
                }
            }
            catch (System.Security.SecurityException)
            {
                Response.Redirect("Default.aspx");
            }

        }
        return (_entity.CellReport)businessObject;
       

    }
   
    private _entity.CellReportDetails GetRptCellMember()
    {
        object businessObject = Session["currentObject"];
        if (businessObject == null || !(businessObject is _entity.CellReportDetails))
        {
            try
            {
               
                if (Request.QueryString["ReportID"] != null)
                {
                    int id = int.Parse(Request.QueryString["ReportID"].ToString());
                    businessObject = _entity.CellReportDetails.Get(id, false);
                    Session["currentObject"] = businessObject;
                }
                else
                {
                    int id = int.Parse(Session["CellCode"].ToString());
                    businessObject = _entity.CellReportDetails.Get(id, true);
                    Session["currentObject"] = businessObject;
                }
            }
            catch (System.Security.SecurityException)
            {
                Response.Redirect("Default.aspx");
            }

        }
        return (_entity.CellReportDetails)businessObject;
    }

    protected void btn_save_Click(object sender, ImageClickEventArgs e)
    {
        _entity.CellReport result = GetRptCell();
        result.Memo = this.Text;
        result.Leader = this.txtleader.Text;
        result.NewMember = this.txtnewmember.Text;
        result.CellDate =this.TextBox1.Text;
        result.CellPlace =this.txtLocation.Text;
        result.Prayer = this.txtprayer.Text;
        result.Request = this.txtrequest.Text;
        result.AttendFamily = int.Parse(this.txtattfamily.Text);
//        result.AttendMemo = this.txtattendence.Text;
        Session["currentObject1"] = result.Save();
        this.BulkEditGridView1.BulkEdit = true;
        RefreshGrid();

        this.BulkEditGridView1.BulkUpdate();

        this.BulkEditGridView1.BulkEdit = false;

        RefreshGrid();
        SaveData();
    }
    protected void btn_edit_Click(object sender, ImageClickEventArgs e)
    {
        this.BulkEditGridView1.BulkEdit = true;
        RefreshGrid();
        RefreshButtons(true);
    }
}
