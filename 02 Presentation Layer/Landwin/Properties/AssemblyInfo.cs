using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("LandWin")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("J Internate Soluctions")]
[assembly: AssemblyProduct("LandWin")]
[assembly: AssemblyCopyright("Copyright ©  2010")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("935d1c6e-847b-4d85-b043-6022b2fd3e1a")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]

[assembly: AssemblyVersion("3.3.6")]
// 1/16/2019
// * Bugfix - Adding a new member to a cell breaks
[assembly: AssemblyFileVersion("3.3.6")]

//[assembly: AssemblyVersion("3.3.5")]
// 9/1/2018
// * Change the FTP server from 192.168.1.240 to 192.168.9.3
//[assembly: AssemblyFileVersion("3.3.5")]

//[assembly: AssemblyVersion("3.3.4")]
// 1/12/2018
// * Change the location of recipient address in the charitable donation receipt letter Rpt_DonateReceipt.rpt
// * Show the memo data at the donate detail section Donate.cs
// * Do not use house holder's last name for spouse last name in the donate receipt app_report.member_donate
//[assembly: AssemblyFileVersion("3.3.4")]

//[assembly: AssemblyVersion("3.3.3")]
// 3/13/2017
// * Bugfix: Update visit record
// * Add 'Delete' to the visit part
//[assembly: AssemblyFileVersion("3.3.3")]

//[assembly: AssemblyVersion("3.3.2")]
//// 2/26/2017
//// * Update xls cell report
//[assembly: AssemblyFileVersion("3.3.2")]

//[assembly: AssemblyVersion("3.3.1")]
// 12/28/2016
// * Enabled auto update
//[assembly: AssemblyFileVersion("3.3.1")]

//[assembly: AssemblyVersion("3.3.0")]
// 11/27/2016
// * Add 'Export to Excel' to cell report detail
//[assembly: AssemblyFileVersion("3.3.0")]

//[assembly: AssemblyVersion("3.2.9")]
// 8/21/2016
// * Added 'Status' to cell family report
//[assembly: AssemblyFileVersion("3.2.9")]

//[assembly: AssemblyVersion("3.2.8")]
// 2/15/2016
// * Replaced the DevExpress password field in user admin to be compatible with Windows 10
// * Block all sections except the member admin for those don't have any permission for the new member department to use
//[assembly: AssemblyFileVersion("3.2.8")]

//[assembly: AssemblyVersion("3.2.7")]
// 2/7/2016
// * Version up due to failure in auto installation 
//[assembly: AssemblyFileVersion("3.2.7")]

//[assembly: AssemblyVersion("3.2.6")]
//// 2/7/2016
//// * LandWin.Tools.MemeberInfoFrm.cs: Spawn the same user popup if and only if there is a same name member 
//[assembly: AssemblyFileVersion("3.2.6")]

//[assembly: AssemblyVersion("3.2.5")]
// 1/24/2016
// * Added the attendance edit within tool at user manager for batch update
//[assembly: AssemblyFileVersion("3.2.5")]

//[assembly: AssemblyVersion("3.2.4")]
// 12/27/2015
// * (app_cell.report_list) Add 'Memo' field to the cell report
//[assembly: AssemblyFileVersion("3.2.4")]

//[assembly: AssemblyVersion("3.2.3")]
// 12/20/2015
// * Adjust the ratio of treasurer sign image
//[assembly: AssemblyFileVersion("3.2.3")]

//[assembly: AssemblyVersion("3.2.2")]
// 12/20/2015
// * Include cellname in fellowship list
//[assembly: AssemblyFileVersion("3.2.2")]

//[assembly: AssemblyVersion("3.2.1")]
// 11/15/2015
// * Replaced the ftp and db password textboxes from a DevExpress control to a Windows control to allow login w/ Windows 10
//[assembly: AssemblyFileVersion("3.2.1")]

//[assembly: AssemblyVersion("3.2.0")]
// 8/26/2015
// * Replaced the password textbox from a DevExpress control to a Windows control to allow login w/ Windows 10
//   - LoginFrm.cs
// * Debugged photo not showing up when print members by family
//   - Shared\ReprotManager.cs   
//[assembly: AssemblyFileVersion("3.2.0")]

//[assembly: AssemblyVersion("3.1.0")]
// * Debugged DonateReport.cs $50 field using $10 data
//   DonateReport.cs
// * Update the donate list to reflect the donate type change right away
//   Donate.Report.cs
// * Make both 'Save' buttons save the donate type change by releasing focus
//   Donate.Report.cs
//
// * Added the feature to allow the member to take more than one role in cell
// 
// Dothan.Libary.bizCell.CellMember.cs
// Modules\CellPart.cs, CellPart.Designer.cs and CellPart.resx
//
// CreateMember_Role.sql
// [app_cell].[cell_member_get].sql
// [app_cell].[cell_member_role_insert].sql
// [app_cell].[cell_member_role_update].sql
// [dbo].[GetRolesByMemberID].sql
// [dbo].[splitstring].sql
//[assembly: AssemblyFileVersion("3.1.0")]

//[assembly: AssemblyVersion("3.0.1.1")]
//// * Enter key to login: LoginFrm.cs, LoginFrm.design.cs and LoginFrm.resx
//// * Debugging FTP: Shared\FtpApi.cs
//[assembly: AssemblyFileVersion("3.0.1.1")]

//[assembly: AssemblyVersion("3.0.1.0")]
//// Added the version number at the window title
//[assembly: AssemblyFileVersion("3.0.1.0")]
//[assembly: AssemblyVersion("3.0.0.0")]
//[assembly: AssemblyFileVersion("3.0.0.0")]
