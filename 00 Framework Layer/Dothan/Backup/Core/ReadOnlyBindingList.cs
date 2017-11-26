using System;
using Dothan.Properties;

namespace Dothan.Core
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix")]
    [Serializable()]
    public abstract class ReadOnlyBindingList<C> :
      System.ComponentModel.BindingList<C>, Core.IBusinessObj
    {
        private bool _isReadOnly = true;

        public bool IsReadOnly
        {
            get { return _isReadOnly; }
            protected set { _isReadOnly = value; }
        }

        protected ReadOnlyBindingList()
        {
            AllowEdit = false;
            AllowRemove = false;
            AllowNew = false;
        }

        protected override void ClearItems()
        {
            if (!IsReadOnly)
            {
                bool oldValue = AllowRemove;
                AllowRemove = true;
                base.ClearItems();
                AllowRemove = oldValue;
            }
            else
                throw new NotSupportedException(Resources.ClearInvalidException);
        }

   
        protected override object AddNewCore()
        {
            if (!IsReadOnly)
                return base.AddNewCore();
            else
                throw new NotSupportedException(Resources.InsertInvalidException);
        }

        protected override void InsertItem(int index, C item)
        {
            if (!IsReadOnly)
                base.InsertItem(index, item);
            else
                throw new NotSupportedException(Resources.InsertInvalidException);
        }

        
        protected override void RemoveItem(int index)
        {
            if (!IsReadOnly)
            {
                bool oldValue = AllowRemove;
                AllowRemove = true;
                base.RemoveItem(index);
                AllowRemove = oldValue;
            }
            else
                throw new NotSupportedException(Resources.RemoveInvalidException);
        }


        protected override void SetItem(int index, C item)
        {
            if (!IsReadOnly)
                base.SetItem(index, item);
            else
                throw new NotSupportedException(Resources.ChangeInvalidException);
        }
    }
}
