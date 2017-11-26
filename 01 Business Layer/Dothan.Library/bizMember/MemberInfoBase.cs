using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dothan;
using Dothan.Data;
using Dothan.Library.Properties;

namespace Dothan.Library
{
    [Serializable()]
    public class MemberInfoBase
    {
        public int MemberId { get; set; }
        public string Ko_Name { get; set; }
        public string En_Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public string Home { get; set; }
        public string Cell { get; set; }
        public string Sex { get; set; }
        public string Married { get; set; }
        public int Age { get; set; }
        public string BirthDay { get; set; }
        public string Spouse { get; set; }
        public string FamilyName { get; set; }
        public int FamilyCode { get; set; }
        public string RelationShip { get; set; }
        public string RegDate { get; set; }
        public string Baptism { get; set; }
        public string Baptism_year { get; set; }
        public string SubDivision { get; set; }
        public string Job { get; set; }
        public string CellName { get; set; }
        public int SpouseID { get; set; }
        public string Active { get; set; }
        public int Family { get; set; }
        public int StatusCode { get; set; }
       
        public MemberInfoBase() {}

        public static MemberInfoBase Get(SafeDataReader dr)
        {
            return new MemberInfoBase(dr);
        }
        public static MemberInfoBase Get(Dothan.Library.bizMember.MemberInfo info)
        {
            return new MemberInfoBase(info);
        }
        private MemberInfoBase(Dothan.Library.bizMember.MemberInfo info)
        {
            Active = info.Active;
            Address = info.Address;
            Age = info.Age;
            Baptism = info.Baptism;
            Baptism_year = info.Baptism_year;
            BirthDay = info.BirthDay;
            Cell = info.Cell;
            CellName = info.CellName;
            City = info.City;
            Email = info.Email;
            En_Name = info.En_Name;
            FamilyCode = info.FamilyCode;
            FamilyName = info.FamilyName;
            Home = info.Home;
            Job = info.Job;
            Ko_Name = info.Ko_Name;
            Married = info.Married;
            MemberId = info.MemberId;
            RegDate = info.RegDate;
            RelationShip = info.RelationShip;
            Sex = info.Sex;
            Spouse = info.Spouse;
            State = info.State;
            StatusCode = info.StatusCode;
            SubDivision = info.SubDivision;
            Zipcode = info.Zipcode;
        }
        private  MemberInfoBase(SafeDataReader dr)
        {
            MemberId = dr.GetInt32("memberid");
            Ko_Name = string.Format("{0}{1}", dr.GetString("last_name"), dr.GetString("first_name"));
            En_Name = string.Format("{0} {1}", dr.GetString("en_first_name"), dr.GetString("en_last_name"));

           Email = dr.GetString("email");
           Address = dr.GetString("address");
           City = dr.GetString("city");
           State = dr.GetString("statecode");
            Zipcode = dr.GetString("zipcode");
            Home = dr.GetString("home");
            Age = dr.GetInt32("age");
            FamilyName = dr.GetString("family_name");
            BirthDay = dr.GetSmartDate("birthday").Text;
            Sex = dr.GetBoolean("sex")? Resources.Male.ToString() : Resources.Female.ToString() ;
            Married = dr.GetBoolean("married") ? Resources.Married : Resources.Single;
            RelationShip = dr.GetString("relationship");
            Spouse = dr.GetString("spousename");
            Job = dr.GetString("job");
            Cell = dr.GetString("cell");
            CellName = dr.GetString("cellname");
            RegDate = dr.GetSmartDate("regdate").Text;
            Baptism = dr.GetString("BaptismName");
            Baptism_year = dr.GetSmartDate("baptism_year").Text;
            SubDivision = dr.GetString("SubDivisionName");
            FamilyCode = dr.GetInt32("family_code");
            StatusCode = dr.GetInt32("StatusCode");
            Active = dr.GetBoolean("active") ? Resources.Active : Resources.InActive;
        }
    }
}
