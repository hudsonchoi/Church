using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using _entity = Dothan.Library;
using System.Text;
using System.Web.Mail;
using System.Data;
using System.Data.SqlClient; 




public partial class SearchPassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            string passowrd = _entity.bizCell.CellReport.SearchPasswordCellUser(txtemail.Text, TextBox1.Text);
            if (!string.IsNullOrEmpty(passowrd))
            {

                StringBuilder str = new StringBuilder();
                str.Append("A request was made to send you your email and password. Your details are as follows:<br/>Login email      :").Append(txtemail.Text);
                str.Append("<br> Password : ").Append(passowrd);
                MailMessage msgMail = new MailMessage();

                msgMail.To = txtemail.Text;
                msgMail.Cc = "webmaster@sleeper.Dev.AlfaSierraPapa.Com";
                msgMail.From = "njchodaedesign@gmail.com";
                msgMail.Subject = "Request Password";

                msgMail.BodyFormat = MailFormat.Html;

                msgMail.Body = str.ToString(); ;

                SmtpMail.Send(msgMail);

            

                Label1.Text = "Message Sent";


            }
        }
        catch (Exception ex)
        {
            Label1.Text = "일치하는 회원정보가 없습니다.";
        }


    }

}
