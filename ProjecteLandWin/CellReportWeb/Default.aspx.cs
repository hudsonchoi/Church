﻿using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Dothan.Library;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["CellCode"] == null)
                Response.Redirect("Login.aspx");
            Session["currentObject"] = null;
            BindData();
        }
    }
    private void BindData()
    {
        
        int id = int.Parse(Session["CellCode"].ToString());
        DataList1.DataSource = RptCellList.GetList(id,DateTime.Now.AddMonths(-3).ToString(),DateTime.Now.ToString());
        DataList1.DataBind();
    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        Session["CellCode"] = null;
        Response.Redirect("Login.aspx");
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("ChangePassword.aspx");
    }
    protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("ReportEdit.aspx");
    }
}
