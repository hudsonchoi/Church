using System;
using System.Data;
using System.Data.SqlClient;
using Dothan;
using Dothan.Data;
using Dothan.Library.Properties;

namespace Dothan.Library
{
    [Serializable()]
    public class VisitContent : BusinessBase<VisitContent>
    {
        private int _id;
        private int _memberid;
        private int _visittype;
        private SmartDate _visitdate;
        private string _pastor = string.Empty;
        private string _pastor = string.Empty;
        private string _attendent = string.Empty;
        private string _content = string.Empty;
        private string _recorder = string.Empty;
        private string _bible = string.Empty;
        private string _song = string.Empty;
        private string _firstname = string.Empty;
        private string _lastname = string.Empty;
        private string _div;


        [System.ComponentModel.DataObjectField(true, true)]
        public int ID
        {
            get
            {
                CanReadProperty(true);
                return _id;
            }
        }
        public int MemberId
        {
            get
            {
                CanReadProperty(true);
                return _memberid;
            }
        }
        public int VisitType
        {
            get
            {
                CanReadProperty(true);
                return _visittype;
            }
            set
            {
                CanWriteProperty(true);
                if (!_visittype.Equals(value))
                {
                    _visittype = value;
                    PropertyHasChanged();
                }
            }
        }
        public string Visitdate
        {
            get
            {
                CanReadProperty(true);
                return _visitdate.Text;
            }
            set
            {
                CanWriteProperty(true);
                if (value == null) value = string.Empty;
                if (_visitdate != value)
                {
                    _visitdate.Text = value;
                    PropertyHasChanged();
                }
            }
        }
        public string Pastor
        {
            get
            {
                CanReadProperty(true);
                return _pastor;
            }
            set
            {
                CanWriteProperty(true);
                if (value == null) value = string.Empty;
                if (_pastor != value)
                {
                    _pastor = value;
                    PropertyHasChanged();
                }
            }
        }
        public string Attendent
        {
            get
            {
                CanReadProperty(true);
                return _attendent;
            }
            set
            {
                CanWriteProperty(true);
                if (value == null) value = string.Empty;
                if (_attendent != value)
                {
                    _attendent = value;
                    PropertyHasChanged();
                }
            }
        }
        public string Content
        {
            get
            {
                CanReadProperty(true);
                return _content;
            }
            set
            {
                CanWriteProperty(true);
                if (value == null) value = string.Empty;
                if (_content != value)
                {
                    _content = value;
                    PropertyHasChanged();
                }
            }
        }
        public string Recorder
        {
            get
            {
                CanReadProperty(true);
                return _recorder;
            }
            set
            {
                CanWriteProperty(true);
                if (value == null) value = string.Empty;
                if (_recorder != value)
                {
                    _recorder = value;
                    PropertyHasChanged();
                }
            }
        }
        public string Bible
        {
            get
            {
                CanReadProperty(true);
                return _bible;
            }
            set
            {
                CanWriteProperty(true);
                if (value == null) value = string.Empty;
                if (_bible != value)
                {
                    _bible = value;
                    PropertyHasChanged();
                }
            }
        }
        public string Song
        {
            get
            {
                CanReadProperty(true);
                return _song;
            }
            set
            {
                CanWriteProperty(true);
                if (value == null) value = string.Empty;
                if (_song != value)
                {
                    _song = value;
                    PropertyHasChanged();
                }
            }
        }


    }

}