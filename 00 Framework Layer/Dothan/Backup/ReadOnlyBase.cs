using System;
using System.Reflection;
using System.ComponentModel;
using Dothan.Properties;

namespace Dothan
{
    [Serializable()]
    public abstract class ReadOnlyBase<T> : ICloneable, Core.IReadOnlyObj
      where T : ReadOnlyBase<T>
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

        #region Constructors

        protected ReadOnlyBase()
        {
            AddAuthorizationRules();
        }

        #endregion

        #region Authorization

        [NotUndoable()]
        private Security.AuthorizationRules _authorizationRules =  new Security.AuthorizationRules();

        protected virtual void AddAuthorizationRules()
        {

        }

        protected Security.AuthorizationRules AuthorizationRules
        {
            get { return _authorizationRules; }
        }

       
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
        public bool CanReadProperty(bool throwOnFalse)
        {
            string propertyName =
              new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name.Substring(4);
            bool result = CanReadProperty(propertyName);
            if (throwOnFalse && result == false)
                throw new System.Security.SecurityException(
                  string.Format("{0} ({1})",
                  Resources.PropertyGetNotAllowed, propertyName));
            return result;
        }

        public bool CanReadProperty(string propertyName, bool throwOnFalse)
        {
            bool result = CanReadProperty(propertyName);
            if (throwOnFalse && result == false)
                throw new System.Security.SecurityException(
                  string.Format("{0} ({1})",
                  Resources.PropertyGetNotAllowed, propertyName));
            return result;
        }

        public bool CanReadProperty()
        {
            string propertyName =
              new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name.Substring(4);
            return CanReadProperty(propertyName);
        }


        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public virtual bool CanReadProperty(string propertyName)
        {
            bool result = true;
            if (AuthorizationRules.HasReadAllowedRoles(propertyName))
            {
                if (!AuthorizationRules.IsReadAllowed(propertyName))
                    result = false;
            }
            else if (AuthorizationRules.HasReadDeniedRoles(propertyName))
            {
                
                if (AuthorizationRules.IsReadDenied(propertyName))
                    result = false;
            }
            return result;
        }

        #endregion

        #region IClonable

        object ICloneable.Clone()
        {
            return GetClone();
        }


        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public virtual object GetClone()
        {
            return Core.ObjCloner.Clone(this);
        }

        public T Clone()
        {
            return (T)GetClone();
        }
        #endregion

        #region Data Access

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "criteria")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        private void DataPortal_Create(object criteria)
        {
            throw new NotSupportedException(Resources.CreateNotSupportedException);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", MessageId = "Member")]
        protected virtual void DataPortal_Fetch(object criteria)
        {
            throw new NotSupportedException(Resources.FetchNotSupportedException);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        private void DataPortal_Update()
        {
            throw new NotSupportedException(Resources.UpdateNotSupportedException);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "criteria")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        private void DataPortal_Delete(object criteria)
        {
            throw new NotSupportedException(Resources.DeleteNotSupportedException);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", MessageId = "Member")]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void DataPortal_OnDataPortalInvoke(DataPortalEventArgs e)
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
