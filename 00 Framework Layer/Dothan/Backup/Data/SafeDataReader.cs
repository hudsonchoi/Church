using System;
using System.Data;

namespace Dothan.Data
{
    public class SafeDataReader : IDataReader
    {
        private IDataReader _dataReader;

     
        protected IDataReader DataReader
        {
            get { return _dataReader; }
        }

        public SafeDataReader(IDataReader dataReader)
        {
            _dataReader = dataReader;
        }

        public string GetString(string name)
        {
            return GetString(_dataReader.GetOrdinal(name));
        }

   
        public virtual string GetString(int i)
        {
            if (_dataReader.IsDBNull(i))
                return string.Empty;
            else
                return _dataReader.GetString(i);
        }


      
        public object GetValue(string name)
        {
            return GetValue(_dataReader.GetOrdinal(name));
        }

        public virtual object GetValue(int i)
        {
            if (_dataReader.IsDBNull(i))
                return null;
            else
                return _dataReader.GetValue(i);
        }

       
        public int GetInt32(string name)
        {
            return GetInt32(_dataReader.GetOrdinal(name));
        }

        public virtual int GetInt32(int i)
        {
            if (_dataReader.IsDBNull(i))
                return 0;
            else
                return _dataReader.GetInt32(i);
        }

        public double GetDouble(string name)
        {
            return GetDouble(_dataReader.GetOrdinal(name));
        }

       
        public virtual double GetDouble(int i)
        {
            if (_dataReader.IsDBNull(i))
                return 0;
            else
                return _dataReader.GetDouble(i);
        }

        public Dothan.SmartDate GetSmartDate(string name)
        {
            return GetSmartDate(_dataReader.GetOrdinal(name), true);
        }

        
        public virtual Dothan.SmartDate GetSmartDate(int i)
        {
            return GetSmartDate(i, true);
        }


        public Dothan.SmartDate GetSmartDate(string name, bool minIsEmpty)
        {
            return GetSmartDate(_dataReader.GetOrdinal(name), minIsEmpty);
        }

        public virtual Dothan.SmartDate GetSmartDate(
          int i, bool minIsEmpty)
        {
            if (_dataReader.IsDBNull(i))
                return new Dothan.SmartDate(minIsEmpty);
            else
                return new Dothan.SmartDate(
                  _dataReader.GetDateTime(i), minIsEmpty);
        }

      
        public System.Guid GetGuid(string name)
        {
            return GetGuid(_dataReader.GetOrdinal(name));
        }

        
        public virtual System.Guid GetGuid(int i)
        {
            if (_dataReader.IsDBNull(i))
                return Guid.Empty;
            else
                return _dataReader.GetGuid(i);
        }

  
        public bool Read()
        {
            return _dataReader.Read();
        }

      
        public bool NextResult()
        {
            return _dataReader.NextResult();
        }

        public void Close()
        {
            _dataReader.Close();
        }

        public int Depth
        {
            get
            {
                return _dataReader.Depth;
            }
        }

        public int FieldCount
        {
            get
            {
                return _dataReader.FieldCount;
            }
        }


        public bool GetBoolean(string name)
        {
            return GetBoolean(_dataReader.GetOrdinal(name));
        }

        public virtual bool GetBoolean(int i)
        {
            if (_dataReader.IsDBNull(i))
                return false;
            else
                return _dataReader.GetBoolean(i);
        }

    
        public byte GetByte(string name)
        {
            return GetByte(_dataReader.GetOrdinal(name));
        }

        public virtual byte GetByte(int i)
        {
            if (_dataReader.IsDBNull(i))
                return 0;
            else
                return _dataReader.GetByte(i);
        }

        public Int64 GetBytes(string name, Int64 fieldOffset,
          byte[] buffer, int bufferoffset, int length)
        {
            return GetBytes(_dataReader.GetOrdinal(name), fieldOffset, buffer, bufferoffset, length);
        }

        
        public virtual Int64 GetBytes(int i, Int64 fieldOffset,
          byte[] buffer, int bufferoffset, int length)
        {
            if (_dataReader.IsDBNull(i))
                return 0;
            else
                return _dataReader.GetBytes(i, fieldOffset, buffer, bufferoffset, length);
        }

       
        public char GetChar(string name)
        {
            return GetChar(_dataReader.GetOrdinal(name));
        }

      
        public virtual char GetChar(int i)
        {
            if (_dataReader.IsDBNull(i))
                return char.MinValue;
            else
            {
                char[] myChar = new char[1];
                _dataReader.GetChars(i, 0, myChar, 0, 1);
                return myChar[0];
            }
        }

        
        public Int64 GetChars(string name, Int64 fieldoffset,
          char[] buffer, int bufferoffset, int length)
        {
            return GetChars(_dataReader.GetOrdinal(name), fieldoffset, buffer, bufferoffset, length);
        }

        
        public virtual Int64 GetChars(int i, Int64 fieldoffset,
          char[] buffer, int bufferoffset, int length)
        {
            if (_dataReader.IsDBNull(i))
                return 0;
            else
                return _dataReader.GetChars(i, fieldoffset, buffer, bufferoffset, length);
        }

   
        public IDataReader GetData(string name)
        {
            return GetData(_dataReader.GetOrdinal(name));
        }

     
        public virtual IDataReader GetData(int i)
        {
            return _dataReader.GetData(i);
        }

      
        public string GetDataTypeName(string name)
        {
            return GetDataTypeName(_dataReader.GetOrdinal(name));
        }

        public virtual string GetDataTypeName(int i)
        {
            return _dataReader.GetDataTypeName(i);
        }

        public virtual DateTime GetDateTime(string name)
        {
            return GetDateTime(_dataReader.GetOrdinal(name));
        }

        
        public virtual DateTime GetDateTime(int i)
        {
            if (_dataReader.IsDBNull(i))
                return DateTime.MinValue;
            else
                return _dataReader.GetDateTime(i);
        }

        
        public decimal GetDecimal(string name)
        {
            return GetDecimal(_dataReader.GetOrdinal(name));
        }

        
        public virtual decimal GetDecimal(int i)
        {
            if (_dataReader.IsDBNull(i))
                return 0;
            else
                return _dataReader.GetDecimal(i);
        }

        
        public Type GetFieldType(string name)
        {
            return GetFieldType(_dataReader.GetOrdinal(name));
        }

       
        public virtual Type GetFieldType(int i)
        {
            return _dataReader.GetFieldType(i);
        }

        
        public float GetFloat(string name)
        {
            return GetFloat(_dataReader.GetOrdinal(name));
        }

        public virtual float GetFloat(int i)
        {
            if (_dataReader.IsDBNull(i))
                return 0;
            else
                return _dataReader.GetFloat(i);
        }

        
        public short GetInt16(string name)
        {
            return GetInt16(_dataReader.GetOrdinal(name));
        }

        
        public virtual short GetInt16(int i)
        {
            if (_dataReader.IsDBNull(i))
                return 0;
            else
                return _dataReader.GetInt16(i);
        }

       
        public Int64 GetInt64(string name)
        {
            return GetInt64(_dataReader.GetOrdinal(name));
        }

      
        public virtual Int64 GetInt64(int i)
        {
            if (_dataReader.IsDBNull(i))
                return 0;
            else
                return _dataReader.GetInt64(i);
        }

    
        public virtual string GetName(int i)
        {
            return _dataReader.GetName(i);
        }

    
        public int GetOrdinal(string name)
        {
            return _dataReader.GetOrdinal(name);
        }

   
        public DataTable GetSchemaTable()
        {
            return _dataReader.GetSchemaTable();
        }


     
        public int GetValues(object[] values)
        {
            return _dataReader.GetValues(values);
        }

        public bool IsClosed
        {
            get
            {
                return _dataReader.IsClosed;
            }
        }

   
        public virtual bool IsDBNull(int i)
        {
            return _dataReader.IsDBNull(i);
        }

       
        public object this[string name]
        {
            get
            {
                object val = _dataReader[name];
                if (DBNull.Value.Equals(val))
                    return null;
                else
                    return val;
            }
        }

      
        public virtual object this[int i]
        {
            get
            {
                if (_dataReader.IsDBNull(i))
                    return null;
                else
                    return _dataReader[i];
            }
        }
      
        public int RecordsAffected
        {
            get
            {
                return _dataReader.RecordsAffected;
            }
        }

        #region IDisposable Support

        private bool _disposedValue; 

     
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    
                    _dataReader.Dispose();
                }

               
            }
            _disposedValue = true;
        }

        // This code added by Visual Basic to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
