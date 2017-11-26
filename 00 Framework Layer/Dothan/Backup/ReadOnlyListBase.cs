using System;
using System.ComponentModel;
using Dothan.Properties;

namespace Dothan
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix")]
    [Serializable()]
    public abstract class ReadOnlyListBase<T, C> :
      Core.ReadOnlyBindingList<C>, Dothan.Core.IReadOnlyCollection,
      ICloneable
      where T : ReadOnlyListBase<T, C>
    {

        #region Constructors

        protected ReadOnlyListBase()
        {

        }

        #endregion

        #region ICloneable

        object ICloneable.Clone()
        {
            return GetClone();
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual object GetClone()
        {
            return Core.ObjCloner.Clone(this);
        }


        public virtual T Clone()
        {
            return (T)GetClone();
        }

        #endregion

        #region Data Access

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "criteria")]
        private void DataPortal_Create(object criteria)
        {
            throw new NotSupportedException(Resources.CreateNotSupportedException);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", MessageId = "Member")]
        protected virtual void DataPortal_Fetch(object criteria)
        {
            throw new NotSupportedException(Resources.FetchNotSupportedException);
        }

        private void DataPortal_Update()
        {
            throw new NotSupportedException(Resources.UpdateNotSupportedException);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "criteria")]
        private void DataPortal_Delete(object criteria)
        {
            throw new NotSupportedException(Resources.DeleteNotSupportedException);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", MessageId = "Member")]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void DataPortal_OndataPortalInvoke(DataPortalEventArgs e)
        {

        }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", MessageId = "Member")]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void DataPortal_OnDataPortalInvokeComplete(DataPortalEventArgs e)
        {

        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", MessageId = "Member")]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void DataPortal_OnDataPortalException(DataPortalEventArgs e, Exception ex)
        {

        }

        #endregion
    }
}
