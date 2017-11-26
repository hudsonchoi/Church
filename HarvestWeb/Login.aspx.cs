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
using Dothan.Library.Security;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.Cookies["UName"] != null)
                txtUserid.Text = Request.Cookies["UName"].Value;
            if (Request.Cookies["PWD"] != null)
                txtpwd.Attributes.Add("value", Request.Cookies["PWD"].Value);
            if (Request.Cookies["UName"] != null && Request.Cookies["PWD"] != null)
                CheckBox1.Checked = true;
        }
    }
  
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        bool result = CRPrincipal.Login(txtUserid.Text, txtpwd.Text);
        if (result)
        {
            HttpContext.Current.Session["DothanPrincipal"] = Dothan.ApplicationContext.User;
            HttpContext.Current.Session["UserName"] = txtUserid.Text;
            HttpContext.Current.Session["CellCode"] = Dothan.ApplicationContext.User.Identity;
            HttpContext.Current.Session["CreateBy"] = Dothan.ApplicationContext.User.Identity.Name;
            if (this.CheckBox1.Checked == true)
            {
                Response.Cookies["UName"].Value = txtUserid.Text;
                Response.Cookies["PWD"].Value = txtpwd.Text;
                Response.Cookies["UName"].Expires = DateTime.Now.AddMonths(2);
                Response.Cookies["PWD"].Expires = DateTime.Now.AddMonths(2);
            }
            else
            {
                Response.Cookies["UName"].Expires = DateTime.Now.AddMonths(-1);
                Response.Cookies["PWD"].Expires = DateTime.Now.AddMonths(-1); 

            }
            Response.Redirect("Default.aspx");
        }
        else
        {
            Response.Cookies["UName"].Expires = DateTime.Now.AddMonths(-1);
            Response.Cookies["PWD"].Expires = DateTime.Now.AddMonths(-1); 
            this.txtUserid.Text = "";
            this.txtpwd.Text = "";
            this.Label1.Text = "일치하는 회원정보가 없습니다.";
           
        }
    }
}
