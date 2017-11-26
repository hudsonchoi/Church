using System;
using System.Data;
using System.Data.SqlClient;
using Dothan;
using Dothan.Data;
using Dothan.Library.Properties;

namespace Dothan.Library.bizDonate
{
    [Serializable()]
    public class Donate : BusinessBase<Donate>
    {
        private int _id; 
        private bool _idset =   false ;
        private int _donateid;
        private decimal _amount;
        private int _paidtype;
        private int _memberid;
        private int _donatecode;
        private SmartDate _regdate;
        private string _memo = string.Empty;
        private byte[] _lastchanged = new byte[8];
        private string _username;
        private string _name = string.Empty;
      

        [System.ComponentModel.DataObjectField(true, true)]
        public int ID
        {
            get
            {
              
                if (!_idset)
                {
                    // generate a default id value
                    _idset = true;
                    Donates parent = (Donates)this.Parent;
                    int max = 0;
                    foreach (Donate item in parent)
                    {
                        if (item.ID > max)
                            max = item.ID;
                    }
                    _id = max + 1;
                }
                return _id;
            }
        }

        public int DonateId
        {
             get
            {
                return _donateid;
            }
        }

        public string MemberId
        {
            get { 
                if (_memberid.Equals(0))
                    return "Unassinged";
                else
                    return _memberid.ToString();
            }
        }
        public string Name
        {
            get
            {
                return _name;
            }
        }
        public decimal Amount
        {
            get
            {
                return _amount;
            }
            set
            {
                CanWriteProperty(true);
                if (!_amount.Equals(value))
                {
                    _amount = value;
                    PropertyHasChanged();
                }
            }
        }
        public int PaidType
        {
            get
            {
                return _paidtype;
            }
            set
            {
                CanWriteProperty(true);
                if (!_paidtype.Equals(value))
                {
                    _paidtype = value;
                    PropertyHasChanged();
                }
            }

        }
        public int DonateType
        {
            get
            {
              
                return _donatecode;
            }
            set
            {
                CanWriteProperty(true);
                if (!_donatecode.Equals(value))
                {
                    _donatecode = value;
                    PropertyHasChanged();
                }
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
                CanWriteProperty(true);
                if (value == null) value = string.Empty;
                if (_memo != value)
                {
                    _memo = value;
                    PropertyHasChanged();
                }
            }
        }
        protected override object GetIdValue()
        {
            return _id;
        }

        internal static Donate New(DonateMemberInfo member,decimal amount ,int paidtype)
        {
            return new Donate(member, amount, paidtype);
        }
        internal static Donate Get(SafeDataReader dr)
        {
            return new Donate(dr);
        }
        private Donate(DonateMemberInfo member, decimal amount, int paidtype)
        {
            MarkAsChild();
            _donateid = member.ID;
            _name = member.Ko_name;
            _memberid = member.MemberID;
            _amount = amount;
            _paidtype = paidtype;
            _username = (Dothan.ApplicationContext.User as Dothan.Library.Security.PTPrincipal).UserName;
            
        }
        private Donate(SafeDataReader dr)
        {
            MarkAsChild();
            _donateid = dr.GetInt32("donate_id");
            _name = dr.GetString("name");
            _memberid = dr.GetInt32("memberid");
            _id = dr.GetInt32("no");
            _paidtype = Convert.ToInt32(dr.GetByte("pay_code"));
            _amount = dr.GetDecimal("amount");
            _donatecode = dr.GetInt32("donate_code");
            _regdate = dr.GetSmartDate("donate_date",_regdate.EmptyIsMin);
            _username = (Dothan.ApplicationContext.User as Dothan.Library.Security.PTPrincipal).UserName;
            dr.GetBytes("lastchanged", 0, _lastchanged, 0, 8);
            _idset = true;
            MarkOld();
        }
         private Donate() 
        {
            MarkAsChild();
        }
         internal void Insert(SqlCommand cm, DonateBook book)
         {
             if (!this.IsDirty) return;


             cm.Parameters.Clear();

             cm.CommandType = CommandType.StoredProcedure;
             cm.CommandText = "[app_donate].[donate_insert]";
             cm.Parameters.AddWithValue("@donateid", _donateid);
             cm.Parameters.AddWithValue("@amount", _amount);
             cm.Parameters.AddWithValue("@donatecode", book.DonateType);
             cm.Parameters.AddWithValue("@paycode", _paidtype);
             cm.Parameters.AddWithValue("@memo", _memo);
             cm.Parameters.AddWithValue("@book_id", book.Id);
             cm.Parameters.AddWithValue("@regdate", book.RegDate);
             cm.Parameters.AddWithValue("@username", _username);
             cm.Parameters.Add("@newid", SqlDbType.Int).Direction = ParameterDirection.Output;
             cm.Parameters.Add("@newlastchanged", SqlDbType.Timestamp).Direction = ParameterDirection.Output;
             cm.ExecuteNonQuery();
             _id = (int)cm.Parameters["@newid"].Value;
             _lastchanged = (byte[])cm.Parameters["@newlastchanged"].Value;

             MarkOld();

         }

         internal void Update(SqlCommand cm, DonateBook books)
         {
             if (!this.IsDirty) return;


             cm.Parameters.Clear();
             cm.CommandType = CommandType.StoredProcedure;
             cm.CommandText = "[app_donate].[donate_update]";
             cm.Parameters.AddWithValue("@id", _id);
             cm.Parameters.AddWithValue("@amount", _amount);
             cm.Parameters.AddWithValue("@paycode", _paidtype);
             cm.Parameters.AddWithValue("@memo", _memo);
             cm.Parameters.AddWithValue("@donateCode", books.DonateType);
             cm.Parameters.AddWithValue("@username", _username);
             cm.Parameters.AddWithValue("@lastchanged", _lastchanged);
             cm.Parameters.Add("@newlastchanged", SqlDbType.Timestamp).Direction = ParameterDirection.Output;
             cm.ExecuteNonQuery();
             _lastchanged = (byte[])cm.Parameters["@newlastchanged"].Value;

         }
         internal void DeleteSelf(SqlCommand cm, DonateBook books)
         {
             if (!this.IsDirty) return;

             if (this.IsNew) return;

             Delete(cm, _id,_username);
             MarkNew();
         }

         internal static void Delete(SqlCommand cm, int id, string username)
         {

             cm.Parameters.Clear();
             cm.CommandType = CommandType.StoredProcedure;
             cm.CommandText = "[app_donate].[donate_delete]";
             cm.Parameters.AddWithValue("@id", id);
             cm.Parameters.AddWithValue("@username", username);
             cm.ExecuteNonQuery();

         }
    }
}
