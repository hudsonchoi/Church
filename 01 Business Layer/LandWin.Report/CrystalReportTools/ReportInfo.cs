using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LandWin.Report.CrystalReportTools
{
    public class ReportInfo
    {

        private string _FtrDataSource;
        public string FtrDataSource
        {
            get { return _FtrDataSource; }
            set { _FtrDataSource = value; }
        }


        private string _FtrFootNotes;
        public string FtrFootNotes
        {
            get { return _FtrFootNotes; }
            set { _FtrFootNotes = value; }
        }

        private string _FtrRunBy;
        public string FtrRunBy
        {
            get { return _FtrRunBy; }
            set { _FtrRunBy = value; }
        }

        private string _FtrVersion;
        public string FtrVersion
        {
            get { return _FtrVersion; }
            set { _FtrVersion = value; }
        }

        private string _HdrCompany;
        public string HdrCompany
        {
            get { return _HdrCompany; }
            set { _HdrCompany = value; }
        }

        private string _HdrReportTitle;
        public string HdrReportTitle
        {
            get { return _HdrReportTitle; }
            set { _HdrReportTitle = value; }
        }

        private string _HdrSubTitle1;
        public string HdrSubTitle1
        {
            get { return _HdrSubTitle1; }
            set { _HdrSubTitle1 = value; }
        }

        private string _HdrSubTitle2;
        public string HdrSubTitle2
        {
            get { return _HdrSubTitle2; }
            set { _HdrSubTitle2 = value; }
        }

        private string _UserID;
        public string UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }

    }
}
