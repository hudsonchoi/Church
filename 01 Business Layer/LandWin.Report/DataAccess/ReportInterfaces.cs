using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LandWin.Report.DataAccess
{
    public interface IDonateSheet<T>
    {
        T GetDonateSheet(string DonateSheetList);
    }
    public interface IDonateSumByTypes<T>
    {
        T GetDonateSumByTypes(string start, string end);
    }
    public interface IDonateWeekly<T>
    {
        T GetDonateWeekly(string start, string end,int code);
    }
    public interface IAddressLabel<T>
    {
        T GetAddressLabelMember(string memberlist);
        T GetAddressLabelFamily(string memberlist);
    }

    public interface IMemberAddrssLabel<T>
    {
        T GetMemberAddrssLabel(string memberlist);
    }

    public interface IAddressBook<T>
    {
        T GetFamilyAddressBook(string memberlist);
        T GetMemberAddressBook(string memberlist);
    }
  

    public interface ICellReport<T>
    {
        T GetCellReportDetail(string reportlist);
    }

    public interface ICellMemberByFamily<T>
    {
        T GetCellMemberByFamily(string memberlist);
    }
    public interface IMemberWithPic<T>
    {
        T GetMemberWithPic(string memberlist);
    }
    public interface IMemberByFamily<T>
    {
        T GetMemberByFamily(string memberlist);
    }
    public interface IVisitReport<T>
    {
        T GetVisitReport(string list);
    }
    public interface IStatusReport<T>
    {
        T GetStatusReport(string list);
    }
    public interface IMemberDonate<T>
    {
        T GetMemberDonate(int list, int year , bool family);
    }
    public interface IMemberCard<T>
    {
        T GetMemberCard(string list);
    }
    public interface IStatusFamily<T>
    {
        T GetStatusFamily(string list);
    }
    public interface IMemberVisit<T>
    {
        T GetMemberVisit(string list);
    }
    public interface IMemberDetails<T>
    {
        T GetMemberDetails(string list);
    }
    public interface IFamilyList<T>
    {
        T GetFamilyList(string list);
    }
}
