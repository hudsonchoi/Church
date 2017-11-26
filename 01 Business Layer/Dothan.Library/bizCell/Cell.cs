using System;
using System.Data;
using System.Data.SqlClient;
using Dothan;
using Dothan.Data;


namespace Dothan.Library.bizCell
{


    [Serializable()]
    public class Cell : BusinessBase<Cell>
    {
        #region Business

        private int _code;
        private bool _codeSet;
        private string _name = string.Empty;
        private SmartDate _createDate = new SmartDate(false);
        private int _parerntCode;
        private int _assigned;
        private string _leader= string.Empty;
        private string _status = string.Empty;
        private string _username = string.Empty;
        private byte[] _lastchanged = new byte[8];

        [System.ComponentModel.DataObjectField(true, true)]
        public int Code
        {
            get
            {
                if (!_codeSet)
                {
                    _codeSet = true;
                    Cells parent = (Cells)this.Parent;
                    int max = 0;
                    foreach (Cell item in parent)
                    {
                        if (item.Code > max)
                            max = item.Code;
                    }
                    _code = max + 1;
                }
                return _code;
            }
        }
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                CanWriteProperty(true);
                if (value == null) value = string.Empty;
                if (_name != value)
                {
                    _name = value;
                    PropertyHasChanged();
                }
            }
        }
        public string CreateDate { get { return _createDate.Text; } }
     
        public int ParentCode
        {
            get
            {
                return _parerntCode;
            }
            set
            {
                CanWriteProperty(true);
                if (!_parerntCode.Equals(value))
                {
                    _parerntCode = value;
                    PropertyHasChanged();
                }
            }
        }
        public string Status
        {
            get
            {
                return _status;
            }
        }
        public int Assigned
        {
            get
            {
                return _assigned;
            }
        }
        public string Leader { get { return _leader; } }

        protected override object GetIdValue()
        {
            return _code;
        }
        public override string ToString()
        {
            return _name;
        }
        #endregion

        protected override void AddBusinessRules()
        {
            ValidationRules.AddRule(Dothan.Validation.CommonRules.StringRequired, "Name");
        }

  
        internal static Cell Get(SafeDataReader dr)
        {
            return new Cell(dr);
        }

        internal static Cell New()
        {
            return new Cell();
        }

        private Cell()
        {
            MarkAsChild();
            _parerntCode = 0;
            _status = "C";
            ValidationRules.CheckRules();
            _username = Dothan.ApplicationContext.User.Identity.Name;
        }

        private Cell(SafeDataReader dr)
        {
            MarkAsChild();
            _codeSet = true;
            _code = dr.GetInt32("code");
            _parerntCode = dr.GetInt32("parent_code");
            _name = dr.GetString("name");
            _createDate = dr.GetSmartDate("create_date");
            _assigned = dr.GetInt32("assigned");
            _leader = dr.GetString("leader");
            _status = dr.GetString("row_status");
            _username = Dothan.ApplicationContext.User.Identity.Name;
            dr.GetBytes("lastchanged", 0, _lastchanged, 0, 8);
            MarkOld();
        }

        internal void Insert(SqlConnection cn)
        {
            if (!this.IsDirty) return;
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "app_cell.cell_insert";
                cm.Parameters.AddWithValue("@name", _name);          
                cm.Parameters.AddWithValue("@parent_code", _parerntCode);
                cm.Parameters.AddWithValue("@username", _username);
                cm.Parameters.Add("@newid" , SqlDbType.Int).Direction = ParameterDirection.Output;
                cm.Parameters.Add("@newlastchanged" , SqlDbType.Timestamp).Direction = ParameterDirection.Output;
                cm.ExecuteNonQuery();
                _code = (int)cm.Parameters["@newid"].Value;
                _lastchanged = (byte[])cm.Parameters["@newlastchanged"].Value;
                MarkOld();
            }
        }

        internal void Update(SqlConnection cn)
        {
            if (!this.IsDirty) return;
            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "app_cell.cell_update";
                cm.Parameters.AddWithValue("@name", _name);
                cm.Parameters.AddWithValue("@code", _code);
                cm.Parameters.AddWithValue("@parentcode", _parerntCode);
                cm.Parameters.AddWithValue("@username", _username);
                cm.Parameters.AddWithValue("@lastchanged", _lastchanged);                
                cm.Parameters.Add("@newlastchanged" , SqlDbType.Timestamp).Direction = ParameterDirection.Output;
                cm.ExecuteNonQuery();
                _lastchanged = (byte[])cm.Parameters["@newlastchanged"].Value;
            }
        }

        internal void DeleteSelf(SqlConnection cn)
        {
            if (!this.IsDirty) return;
            if (this.IsNew) return;
            DeleteCell(cn, _code, _username);
            MarkNew();
        }


        internal static void DeleteCell(SqlConnection cn, int code, string username)
        {

            using (SqlCommand cm = cn.CreateCommand())
            {
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = "app_cell.cell_delete";
                cm.Parameters.AddWithValue("@code", code);
                cm.Parameters.AddWithValue("@username", username);
                cm.ExecuteNonQuery();
            }
        }
    }
}

