using System;
using System.Data;
using System.Data.SqlClient;
using Dothan;
using Dothan.Data;

namespace Dothan.Library.bizDonate
{
    [Serializable()]
    public class Donates : BusinessListBase<Donates, Donate>
    {
        public void AssignTo(DonateMemberInfo info, decimal amount, int paidtype , string memo)
        {

            Donate item = Donate.New(info, amount, paidtype );
            item.Memo = memo;
            int index = this.Count;
            this.Insert(index,item);
        }


        internal  decimal TotalCheckAmt()
        {
            decimal total = 0;
            foreach (Donate item in this)
            {
                if (item.PaidType == 0)
                    total += item.Amount;
            }

            return total;
        }
        internal int TotalCheckCount()
        {
            int total = 0;
            foreach (Donate item in this)
            {
                if (item.PaidType == 0)
                    total++;
            }

            return total;
        }
        protected void ToChangeDonateType(int donateTypeId)
        {
            foreach (Donate item in this)
            {
                item.DonateType = donateTypeId;
            }
        }
        public void Remove(int id)
        {
            foreach (Donate item in this)
            {
                if (item.ID.Equals(id))
                {
                    Remove(item);
                    break;
                }
            }
        }

        internal static Donates New()
        {
            return new Donates();
        }
        internal static Donates Get(SafeDataReader dr)
        {
            return new Donates(dr);
        }

        private Donates()
        {
            MarkAsChild();
        }

        private Donates(SafeDataReader dr)
        {
            RaiseListChangedEvents = false;
            while (dr.Read())
                this.Add(Donate.Get(dr));
            RaiseListChangedEvents = true;
        }

        internal void Update(SqlCommand cm, DonateBook parent)
        {
            RaiseListChangedEvents = false;
            foreach (Donate item in DeletedList)
                item.DeleteSelf(cm, parent);
            DeletedList.Clear();

            foreach (Donate item in this)
            {
                if (item.IsNew)
                    item.Insert(cm, parent);
                else
                    item.Update(cm, parent);
            }
            RaiseListChangedEvents = true;
        }
    }
}
