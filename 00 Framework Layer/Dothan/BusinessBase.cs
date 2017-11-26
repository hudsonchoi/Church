using System;
using Dothan.Properties;

namespace Dothan
{
    [Serializable()]
    public abstract class BusinessBase<T> : Core.BusinessBase where T : BusinessBase<T>
    {

        #region Object ID Value

        protected abstract object GetIdValue();

        #endregion

        #region System.Object Overrides

        public override bool Equals(object obj)
        {
            if (obj is T)
            {
                object id = GetIdValue();
                if (id == null)
                    throw new ArgumentException(Resources.GetIdValueCantBeNull);
                return ((T)obj).GetIdValue().Equals(id);
            }
            else
                return false;
        }
        public override int GetHashCode()
        {
            object id = GetIdValue();
            if (id == null)
                throw new ArgumentException(Resources.GetIdValueCantBeNull);
            return id.GetHashCode();
        }

  
        public override string ToString()
        {
            object id = GetIdValue();
            if (id == null)
                throw new ArgumentException(Resources.GetIdValueCantBeNull);
            return id.ToString();
        }

        #endregion

        #region Clone

      
        public virtual T Clone()
        {
            return (T)GetClone();
        }

        #endregion

        #region Data Access

        public virtual T Save()
        {
            if (this.IsChild)
                throw new NotSupportedException(Resources.NoSaveChildException);
            if (EditLevel > 0)
                throw new Validation.ValidationException(Resources.NoSaveEditingException);
            if (!IsValid)
                throw new Validation.ValidationException(Resources.NoSaveInvalidException);
            if (IsDirty)
                return (T)DataPortal.Update(this);
            else
                return (T)this;
        }

        public T Save(bool forceUpdate)
        {
            if (forceUpdate && IsNew)
            {             
                MarkOld();
                MarkDirty(true);
            }
            return this.Save();
        }

        #endregion

    }
}
