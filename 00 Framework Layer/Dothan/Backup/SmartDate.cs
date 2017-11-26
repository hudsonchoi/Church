using System;
using Dothan.Properties;

namespace Dothan
{
    [Serializable()]
    public struct SmartDate : IComparable
    {
        private DateTime _date;
        private bool _initialized;
        private bool _emptyIsMax;
        private string _format;

        #region Constructors

        public SmartDate(bool emptyIsMin)
        {
            _emptyIsMax = !emptyIsMin;
            _format = null;
            _initialized = false;

            _date = DateTime.MinValue;
            if (!_emptyIsMax)
                Date = DateTime.MinValue;
            else
                Date = DateTime.MaxValue;
        }

        public SmartDate(DateTime value)
        {
            _emptyIsMax = false;
            _format = null;
            _initialized = false;
            _date = DateTime.MinValue;
            Date = value;
        }

        public SmartDate(DateTime value, bool emptyIsMin)
        {
            _emptyIsMax = !emptyIsMin;
            _format = null;
            _initialized = false;
            _date = DateTime.MinValue;
            Date = value;
        }


        public SmartDate(string value)
        {
            _emptyIsMax = false;
            _format = null;
            _initialized = true;
            _date = DateTime.MinValue;
            this.Text = value;
        }


        public SmartDate(string value, bool emptyIsMin)
        {
            _emptyIsMax = !emptyIsMin;
            _format = null;
            _initialized = true;
            _date = DateTime.MinValue;
            this.Text = value;
        }

        #endregion

        #region Text Support


        public string FormatString
        {
            get
            {
                if (_format == null)
                    _format = "MM/dd/yyyy";
                return _format;
            }
            set
            {
                _format = value;
            }
        }


        public string Text
        {
            get { return DateToString(this.Date, FormatString, !_emptyIsMax); }
            set { this.Date = StringToDate(value, !_emptyIsMax); }
        }

        #endregion

        #region Date Support


        public DateTime Date
        {
            get
            {
                if (!_initialized)
                {
                    _date = DateTime.MinValue;
                    _initialized = true;
                }
                return _date;
            }
            set
            {
                _date = value;
                _initialized = true;
            }
        }

        #endregion

        #region System.Object overrides


        public override string ToString()
        {
            return this.Text;
        }


        public override bool Equals(object obj)
        {
            if (obj is SmartDate)
            {
                SmartDate tmp = (SmartDate)obj;
                if (this.IsEmpty && tmp.IsEmpty)
                    return true;
                else
                    return this.Date.Equals(tmp.Date);
            }
            else if (obj is DateTime)
                return this.Date.Equals((DateTime)obj);
            else if (obj is string)
                return (this.CompareTo(obj.ToString()) == 0);
            else
                return false;
        }


        public override int GetHashCode()
        {
            return this.Date.GetHashCode();
        }

        #endregion

        #region DBValue


        public object DBValue
        {
            get
            {
                if (this.IsEmpty)
                    return DBNull.Value;
                else
                    return this.Date;
            }
        }

        #endregion

        #region Empty Dates

        public bool IsEmpty
        {
            get
            {
                if (!_emptyIsMax)
                    return this.Date.Equals(DateTime.MinValue);
                else
                    return this.Date.Equals(DateTime.MaxValue);
            }
        }


        public bool EmptyIsMin
        {
            get { return !_emptyIsMax; }
        }

        #endregion

        #region Conversion Functions


        public static SmartDate Parse(string value)
        {
            return new SmartDate(value);
        }


        public static SmartDate Parse(string value, bool emptyIsMin)
        {
            return new SmartDate(value, emptyIsMin);
        }


        public static DateTime StringToDate(string value)
        {
            return StringToDate(value, true);
        }

        public static DateTime StringToDate(string value, bool emptyIsMin)
        {
            DateTime tmp;
            if (String.IsNullOrEmpty(value))
            {
                if (emptyIsMin)
                    return DateTime.MinValue;
                else
                    return DateTime.MaxValue;
            }
            else if (DateTime.TryParse(value, out tmp))
                return tmp;
            else
            {
                string ldate = value.Trim().ToLower();
                if (ldate == Resources.SmartDateT ||
                    ldate == Resources.SmartDateToday ||
                    ldate == ".")
                    return DateTime.Now;
                if (ldate == Resources.SmartDateY ||
                    ldate == Resources.SmartDateYesterday ||
                    ldate == "-")
                    return DateTime.Now.AddDays(-1);
                if (ldate == Resources.SmartDateTom ||
                    ldate == Resources.SmartDateTomorrow ||
                    ldate == "+")
                    return DateTime.Now.AddDays(1);
                throw new ArgumentException(Resources.StringToDateException);
            }
        }


        public static string DateToString(DateTime value, string formatString)
        {
            return DateToString(value, formatString, true);
        }


        public static string DateToString(DateTime value, string formatString, bool emptyIsMin)
        {
            if (emptyIsMin && value == DateTime.MinValue)
                return string.Empty;
            else if (!emptyIsMin && value == DateTime.MaxValue)
                return string.Empty;
            else
                return string.Format("{0:" + formatString + "}", value);
        }

        #endregion

        #region Manipulation Functions


        public int CompareTo(SmartDate value)
        {
            if (this.IsEmpty && value.IsEmpty)
                return 0;
            else
                return _date.CompareTo(value.Date);
        }


        int IComparable.CompareTo(object value)
        {
            if (value is SmartDate)
                return CompareTo((SmartDate)value);
            else
                throw new ArgumentException(Resources.ValueNotSmartDateException);
        }


        public int CompareTo(string value)
        {
            return this.Date.CompareTo(StringToDate(value, !_emptyIsMax));
        }


        public int CompareTo(DateTime value)
        {
            return this.Date.CompareTo(value);
        }

      
        public DateTime Add(TimeSpan value)
        {
            if (IsEmpty)
                return this.Date;
            else
                return this.Date.Add(value);
        }

      
        public DateTime Subtract(TimeSpan value)
        {
            if (IsEmpty)
                return this.Date;
            else
                return this.Date.Subtract(value);
        }

       
        public TimeSpan Subtract(DateTime value)
        {
            if (IsEmpty)
                return TimeSpan.Zero;
            else
                return this.Date.Subtract(value);
        }

        #endregion

        #region Operators

        public static bool operator ==(SmartDate obj1, SmartDate obj2)
        {
            return obj1.Equals(obj2);
        }

        public static bool operator !=(SmartDate obj1, SmartDate obj2)
        {
            return !obj1.Equals(obj2);
        }

        public static bool operator ==(SmartDate obj1, DateTime obj2)
        {
            return obj1.Equals(obj2);
        }

        public static bool operator !=(SmartDate obj1, DateTime obj2)
        {
            return !obj1.Equals(obj2);
        }

        public static bool operator ==(SmartDate obj1, string obj2)
        {
            return obj1.Equals(obj2);
        }

        public static bool operator !=(SmartDate obj1, string obj2)
        {
            return !obj1.Equals(obj2);
        }

        public static SmartDate operator +(SmartDate start, TimeSpan span)
        {
            return new SmartDate(start.Add(span), start.EmptyIsMin);
        }

        public static SmartDate operator -(SmartDate start, TimeSpan span)
        {
            return new SmartDate(start.Subtract(span), start.EmptyIsMin);
        }

        public static TimeSpan operator -(SmartDate start, SmartDate finish)
        {
            return start.Subtract(finish.Date);
        }

        public static bool operator >(SmartDate obj1, SmartDate obj2)
        {
            return obj1.CompareTo(obj2) > 0;
        }

        public static bool operator <(SmartDate obj1, SmartDate obj2)
        {
            return obj1.CompareTo(obj2) < 0;
        }

        public static bool operator >(SmartDate obj1, DateTime obj2)
        {
            return obj1.CompareTo(obj2) > 0;
        }

        public static bool operator <(SmartDate obj1, DateTime obj2)
        {
            return obj1.CompareTo(obj2) < 0;
        }

        public static bool operator >(SmartDate obj1, string obj2)
        {
            return obj1.CompareTo(obj2) > 0;
        }

        public static bool operator <(SmartDate obj1, string obj2)
        {
            return obj1.CompareTo(obj2) < 0;
        }

        public static bool operator >=(SmartDate obj1, SmartDate obj2)
        {
            return obj1.CompareTo(obj2) >= 0;
        }

        public static bool operator <=(SmartDate obj1, SmartDate obj2)
        {
            return obj1.CompareTo(obj2) <= 0;
        }

        public static bool operator >=(SmartDate obj1, DateTime obj2)
        {
            return obj1.CompareTo(obj2) >= 0;
        }

        public static bool operator <=(SmartDate obj1, DateTime obj2)
        {
            return obj1.CompareTo(obj2) <= 0;
        }

        public static bool operator >=(SmartDate obj1, string obj2)
        {
            return obj1.CompareTo(obj2) >= 0;
        }

        public static bool operator <=(SmartDate obj1, string obj2)
        {
            return obj1.CompareTo(obj2) < 0;
        }

        #endregion
    }
}
