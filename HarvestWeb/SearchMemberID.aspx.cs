using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dothan.Library;
using System.Text;
using System.Web.Mail;
using System.Data;
using System.Data.SqlClient;
using Dothan;
using _entity = Dothan.Library;

public partial class SearchMemberID : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        string message;
        try
        {
            SmartDate birth = SmartDate.Parse(tb_birth.Text);
 
            int memberid = _entity.bizMember.Member.ToSearchMemberID(this.tb_name.Text, this.tb_birth.Text);

            if (memberid.Equals(0))
            {
                message = string.Format("입력하신 교인은<br/> 찾을 수가 없습니다.");
            }
            else
            {
                message = string.Format("{0} 님의 교인번호는<br/> {1} 입니다.", tb_name.Text, memberid.ToString());
            }
            string str = System.Web.HttpUtility.UrlEncode(message);
            divFields.Visible = false;
            lblResult.Text = message;
            divResult.Visible = true;
            //StringBuilder sb = new StringBuilder();
            //sb.Append("<script>");
            //sb.Append("window.open('default2.aspx?Message=").Append(str).Append("', '','toolbar=1,scrollbars=1,location=1,statusbar=1,menubar=1,resizable=1,width=385,height=135');");
            //sb.Append("</scri");
            //sb.Append("pt>");

            //Page.RegisterStartupScript("test", sb.ToString());
        }
        catch
        {
            message = string.Format("입력하신 교인은<br/> 찾을 수가 없습니다.");
            string str = System.Web.HttpUtility.UrlEncode(message);
            divFields.Visible = false;
            lblResult.Text = message;
            divResult.Visible = true;
            //Response.Redirect("SearchMemberID.aspx");

        }

    }
  
 
}
