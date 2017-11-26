using System;
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
using _entity = Dothan.Library;

public partial class ChangePassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Dothan.ApplicationContext.User = (System.Security.Principal.IPrincipal)HttpContext.Current.Session["DothanPrincipal"];
        if (!IsPostBack)
        {
            // this.Label1.Text = HttpContext.Current.Session["UserName"].ToString();
        }
    }


    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            _entity.bizCell.CellReport.ChangePasswordCellUser(HttpContext.Current.Session["UserName"].ToString(), txtoldpwd.Text, txtpwd.Text);
            Response.Redirect("Default.aspx");
        }

        catch
        {
            this.Label1.Text = "비밀번호가 일치하지 않습니다.";

        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
}
