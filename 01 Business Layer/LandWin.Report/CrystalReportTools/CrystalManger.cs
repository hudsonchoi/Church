using System;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Data;
using System.Windows.Forms;
using System.Collections;
using CrystalDecisions.Windows.Forms;

namespace LandWin.Report.CrystalReportTools
{

    public class CrystalManager
    {
        public enum ExportTypes
        {
            PDF = 1,
            MSWord = 2,
            MSExcel = 3,
            HTML = 4

        }

        private static string _printName;
        private static int _copies;
        private static bool _pagerange;
        private static int _startpage;
        private static int _endpage;
        private static bool _collate;
        private static bool _allpage;

        public string PrintName
        {
            get { return _printName; }
            set { _printName = value; }
        }

        public int Copies
        {
            get { return _copies; }
            set { _copies = value; }
        }
        public bool PageRange
        {
            get { return _pagerange; }
            set { _pagerange = value; }
        }
        public int StartPage
        {
            get { return _startpage; }
            set { _startpage = value; }
        }
        public int EndPage
        {
            get { return _endpage; }
            set { _endpage = value; }
        }

        public bool Collate
        {
            get { return _collate; }
            set { _collate = value; }
        }
        public bool AllPages
        {
            get { return _allpage; }
            set { _allpage = value; }
        }

        public CrystalManager()
        {
            this.Copies = 1;
            this.StartPage = 0;
            this.EndPage = 0;
            this.PrintName = "";
            this.PageRange = false;
            this.AllPages = true;
            this.Collate = true;
        }
        public void SetData(System.Data.DataSet ds, ReportDocument rpt_doc)
        {
            foreach (Table tb in rpt_doc.Database.Tables)
                tb.SetDataSource(ds.Tables[tb.Name.ToString()]);
        }

        public ReportDocument PushReportData(System.Data.DataSet ds, ReportDocument rpt_doc)
        {
            this.SetData(ds, rpt_doc);

            foreach (ReportDocument sub_rpt_doc in rpt_doc.Subreports)
                this.SetData(ds, sub_rpt_doc);
            return rpt_doc;
        }
        public void SetReportInfo(ReportDocument rpt_doc, ReportInfo rpt_info)
        {
            dsReportInfo dsReport = new dsReportInfo();
            dsReportInfo.tbReportInfoRow row = dsReport.tbReportInfo.NewtbReportInfoRow();

            row.FtrDataSource = rpt_info.FtrDataSource;
            row.FtrFootNotes = rpt_info.FtrFootNotes;
            row.FtrRunBy = rpt_info.FtrRunBy;
            row.FtrVersion = rpt_info.FtrVersion;
            row.HdrCompany = rpt_info.HdrCompany;
            row.HdrReportTitle = rpt_info.HdrReportTitle;
            row.HdrSubTitle1 = rpt_info.HdrSubTitle1;
            row.HdrSubTitle2 = rpt_info.HdrSubTitle2;
            row.UserID = rpt_info.UserID;
            dsReport.tbReportInfo.AddtbReportInfoRow(row);

            this.PushReportData(dsReport, rpt_doc);
        }

        public CrystalViewer PreviewReport(ReportDocument oReport, string cTitle, System.Data.DataSet DsReportData)
        {

            this.PushReportData(DsReportData, oReport);

            return this.PreviewReport(oReport, cTitle);

        }
        public CrystalViewer PreviewReport(ReportDocument oReport, string cTitle)
        {
            CrystalViewer oViewer = new CrystalViewer();
            oViewer.crViewer.ReportSource = oReport;
            oViewer.crViewer.Zoom(100);
            oViewer.Text = cTitle;
            oViewer.ShowDialog();

            return oViewer;
        }

        public void PrintReport(ReportDocument oReport)
        {
            oReport.PrintOptions.PrinterName = this.PrintName;


            oReport.PrintToPrinter(this.Copies, this.Collate, this.StartPage, this.EndPage);

        }
        public void ExportReport(ReportDocument oReport, string cFileName, ExportTypes oExportTypes)
        {
            this.ExportReport(oReport, cFileName, oExportTypes, 0, 0);
        }





        public void ExportReport(ReportDocument oReport, string cFileName, ExportTypes oExportTypes, int nFirstPage, int nLastPage)
        {
            ExportOptions oExportOptions = new ExportOptions();
            PdfRtfWordFormatOptions oFormatOptions = ExportOptions.CreatePdfRtfWordFormatOptions();
            DiskFileDestinationOptions oDestinationOptions = ExportOptions.CreateDiskFileDestinationOptions();

            switch (oExportTypes)
            {
                case ExportTypes.PDF:
                case ExportTypes.MSWord:
                    oExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                    PdfRtfWordFormatOptions oPDFFormatOptions = ExportOptions.CreatePdfRtfWordFormatOptions();

                    if (nFirstPage > 0 && nLastPage > 0)
                    {
                        oPDFFormatOptions.FirstPageNumber = nFirstPage;
                        oPDFFormatOptions.LastPageNumber = nLastPage;
                        oPDFFormatOptions.UsePageRange = true;
                    }
                    oExportOptions.ExportFormatOptions = oPDFFormatOptions;
                    break;

                case ExportTypes.MSExcel:
                    oExportOptions.ExportFormatType = ExportFormatType.Excel;
                    ExcelFormatOptions oExcelFormatOptions = ExportOptions.CreateExcelFormatOptions();

                    if (nFirstPage > 0 && nLastPage > 0)
                    {
                        oExcelFormatOptions.FirstPageNumber = nFirstPage;
                        oExcelFormatOptions.LastPageNumber = nLastPage;
                        oExcelFormatOptions.UsePageRange = true;
                    }
                    oExcelFormatOptions.ExcelUseConstantColumnWidth = false;
                    oExportOptions.ExportFormatOptions = oExcelFormatOptions;
                    break;
                case ExportTypes.HTML:
                    oExportOptions.ExportFormatType = ExportFormatType.HTML40;
                    HTMLFormatOptions oHTMLFormatOptions = ExportOptions.CreateHTMLFormatOptions();
                    if (nFirstPage > 0 && nLastPage > 0)
                    {
                        oHTMLFormatOptions.FirstPageNumber = nFirstPage;
                        oHTMLFormatOptions.LastPageNumber = nLastPage;
                        oHTMLFormatOptions.UsePageRange = true;
                    }
                    // can set additional HTML export options here

                    oExportOptions.ExportFormatOptions = oHTMLFormatOptions;
                    break;
            }


            oDestinationOptions.DiskFileName = cFileName;
            oExportOptions.ExportDestinationOptions = oDestinationOptions;
            oExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;

            oReport.Export(oExportOptions);



        }
    }
}
