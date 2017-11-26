using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Dothan.Report;
using LandWin.Report.DataSet;
using LandWin.Report.DataAccess;

namespace LandWin.Report.Business
{
    public class bzAddressBook : BaseBusinessObject, IAddressBook<dsAddressBook>
    {
        public dsAddressBook GetFamilyAddressBook(string memberlist)
        {
            dsAddressBook ds = new dsAddressBook();
            ds = new daMemberReport().GetFamilyAddressBook(memberlist);
            return ds;
        }


        public dsAddressBook GetMemberAddressBook(string memberlist)
        {
            dsAddressBook ds = new dsAddressBook();
            ds = new daMemberReport().GetMemberAddressBook(memberlist);
            return ds;
        }
    }
}
