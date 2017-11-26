using System;
using System.Data;
using System.Configuration;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;


/// <summary>
/// Summary description for MemberEntity
/// </summary>
public class MemberEntity
{
    private int _no;
    private string _membername;
    private string _reason;
    private string _memo;
    private bool _attendance;


    public int No
    {
        get
        {
            return _no;
        }

        set
        {
            _no= value;
        }
    }
    public string MemberName
    {
        get
        {
            return _membername;
        }

        set
        {
            _membername = value;
        }
    }
    public string Reason
    {
        get
        {
            return _reason;
        }

        set
        {
            _reason = value;
        }
    }
    public string Memo
    {
        get
        {
            return _memo;
        }

        set
        {
            _memo = value;
        }
    }
    public bool Attendance
    {
        get
        {
            return _attendance;
        }

        set
        {
            _attendance = value;
        }
    }
}
