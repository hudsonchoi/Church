using System;

using System.Web;

using System.Web.Configuration; 


public partial class errorpage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        throw (new ArgumentNullException());

    }
}
