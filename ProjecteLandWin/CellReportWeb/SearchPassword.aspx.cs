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
            string passowrd =  _entity.bizCell.CellReport.SearchPasswordCellUser(txtEmail.Text,txtBirth.Text);
            if (!string.IsNullOrEmpty(passowrd))
            {

                StringBuilder str = new StringBuilder();
                str.Append("A request was made to send you your email and password. Your details are as follows:<br/>Login email      :").Append(txtemail.Text);
                str.Append("<br> Password : ").Append(passowrd);
                MailMessage msgMail = new MailMessage();

                msgMail.To = txtEmail.Text;
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
    /*private string SearchPassword()
    {
        string _password = string.Empty;
        using (SqlConnection cn = new SqlConnection(Database.ConnectionString))
        {
            cn.Open();
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "GetCellUserPassword";
                cm.Parameters.AddWithValue("@email", txtemail.Text);
                cm.Parameters.AddWithValue("@birthdate",(DateTime)TextBox1.Text);
                using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                {
                    if (dr.Read() != null)
                    {
                        _password = dr.GetString("password");
                    }
                }

            }
        }
        return _password; 
    }*/
}
