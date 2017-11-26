using System;
using System.Reflection;
using System.ComponentModel;
using System.Runtime.Serialization;
using Dothan.Properties;

namespace Dothan.Core
{
    [Serializable()]
    public abstract class BusinessBase : Dothan.Core.UndoableBase, System.ComponentModel.IEditableObject,System.ComponentModel.IDataErrorInfo,
        ICloneable
    {
        #region Constructors

        protected BusinessBase()
        {
            AddBusinessRules();
            AddAuthorizationRules();
        }

        #endregion

        #region IsNew, IsDeleted, IsDirty, IsSavable

        private bool _isNew = true;
        private bool _isDeleted;
        private bool _isDirty = true;

        [Browsable(false)]
        public bool IsNew
        {
            get { return _isNew; }
        }

        [Browsable(false)]
        public bool IsDeleted
        {
            get { return _isDeleted; }
        }

        [Browsable(false)]
        public virtual bool IsDirty
        {
            get { return _isDirty; }
        }

        protected virtual void MarkNew()
        {
            _isNew = true;
            _isDeleted = false;
            MarkDirty();
        }
        protected virtual void MarkOld()
        {
            _isNew = false;
            MarkClean();
        }
        protected void MarkDeleted()
        {
            _isDeleted = true;
            MarkDirty();
        }
        protected void MarkDirty()
        {
            MarkDirty(false);
        }
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected void MarkDirty(bool suppressEvent)
        {
            _isDirty = true;
            if (!suppressEvent)
                OnUnknownPropertyChanged();
        }

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
        protected void PropertyHasChanged()
        {
            string propertyName =
              new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name.Substring(4);
            PropertyHasChanged(propertyName);
        }

        protected virtual void PropertyHasChanged(string propertyName)
        {
            ValidationRules.CheckRules(propertyName);
            MarkDirty(true);
            OnPropertyChanged(propertyName);
        }
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected void MarkClean()
        {
            _isDirty = false;
            OnUnknownPropertyChanged();
        }
        [Browsable(false)]
        public virtual bool IsSavable
        {
            get { return (IsDirty && IsValid); }
        }

        #endregion

        #region Authorization

        [NotUndoable()]
        private Security.AuthorizationRules _authorizationRules;
        protected virtual void AddAuthorizationRules()
        {

        }
        protected Security.AuthorizationRules AuthorizationRules
        {
            get
            {
                if (_authorizationRules == null)
                    _authorizationRules = new Security.AuthorizationRules();
                return _authorizationRules;
            }
        }
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
        public bool CanReadProperty(bool throwOnFalse)
        {
            string propertyName = new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name.Substring(4);
            bool result = CanReadProperty(propertyName);
            if (throwOnFalse && result == false)
                throw new System.Security.SecurityException(
                  String.Format("{0} ({1})",
                  Resources.PropertyGetNotAllowed, propertyName));
            return result;
        }
        public bool CanReadProperty(string propertyName, bool throwOnFalse)
        {
            bool result = CanReadProperty(propertyName);
            if (throwOnFalse && result == false)
                throw new System.Security.SecurityException(
                  String.Format("{0} ({1})",
                  Resources.PropertyGetNotAllowed, propertyName));
            return result;
        }
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
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

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
        public bool CanWriteProperty(bool throwOnFalse)
        {
            string propertyName = new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name.Substring(4);
            bool result = CanWriteProperty(propertyName);
            if (throwOnFalse && result == false)
                throw new System.Security.SecurityException(
                  String.Format("{0} ({1})", Resources.PropertySetNotAllowed, propertyName));
            return result;
        }

        public bool CanWriteProperty(string propertyName, bool throwOnFalse)
        {
            bool result = CanWriteProperty(propertyName);
            if (throwOnFalse && result == false)
                throw new System.Security.SecurityException(
                  String.Format("{0} ({1})", Resources.PropertySetNotAllowed, propertyName));
            return result;
        }

        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
        public bool CanWriteProperty()
        {
            string propertyName = new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name.Substring(4);
            return CanWriteProperty(propertyName);
        }
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public virtual bool CanWriteProperty(string propertyName)
        {
            bool result = true;
            if (AuthorizationRules.GetRolesForProperty(
              propertyName, Dothan.Security.AccessType.WriteAllowed).Length > 0)
            {
                if (!AuthorizationRules.IsWriteAllowed(propertyName))
                    result = false;
            }
            else if (AuthorizationRules.GetRolesForProperty(
              propertyName, Dothan.Security.AccessType.WriteDenied).Length > 0)
            {
               
                if (AuthorizationRules.IsWriteDenied(propertyName))
                    result = false;
            }
            return result;
        }

        #endregion

        #region Parent/Child link

        [NotUndoable()]
        [NonSerialized()]
        private Core.IEditableCollection _parent;

     
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected Core.IEditableCollection Parent
        {
            get { return _parent; }
        }

        internal void SetParent(Core.IEditableCollection parent)
        {
            if (!IsChild)
                throw new InvalidOperationException(Resources.ParentSetException);
            _parent = parent;
        }

        #endregion

        #region System.ComponentModel.IEditableObject

        [NotUndoable()]
        private bool _bindingEdit;
        private bool _neverCommitted = true;

        void System.ComponentModel.IEditableObject.BeginEdit()
        {
            if (!_bindingEdit)
                BeginEdit();
        }

    
        void System.ComponentModel.IEditableObject.CancelEdit()
        {
            if (_bindingEdit)
            {
                CancelEdit();
                if (IsNew && _neverCommitted && EditLevel <= EditLevelAdded)
                {
                    if (Parent != null)
                        Parent.RemoveChild(this);
                }
            }
        }

   
        void System.ComponentModel.IEditableObject.EndEdit()
        {
            if (_bindingEdit)
                ApplyEdit();
        }

        #endregion

        #region Begin/Cancel/ApplyEdit

        public void BeginEdit()
        {
            _bindingEdit = true;
            CopyState();
        }

        
        public void CancelEdit()
        {
            UndoChanges();
        }

       
        protected override void UndoChangesComplete()
        {
            _bindingEdit = false;
            ValidationRules.SetTarget(this);
            AddBusinessRules();
            OnUnknownPropertyChanged();
            base.UndoChangesComplete();
        }

      
        public void ApplyEdit()
        {
            _bindingEdit = false;
            _neverCommitted = false;
            AcceptChanges();
        }

        #endregion

        #region IsChild

        [NotUndoable()]
        private bool _isChild;

       
        protected internal bool IsChild
        {
            get { return _isChild; }
        }

        protected void MarkAsChild()
        {
            _isChild = true;
        }

        #endregion

        #region Delete

        public void Delete()
        {
            if (this.IsChild)
                throw new NotSupportedException(Resources.ChildDeleteException);

            MarkDeleted();
        }

      
        internal void DeleteChild()
        {
            if (!this.IsChild)
                throw new NotSupportedException(Resources.NoDeleteRootException);

            MarkDeleted();
        }

        #endregion

        #region Edit Level Tracking (child only)

        
        private int _editLevelAdded;

        internal int EditLevelAdded
        {
            get { return _editLevelAdded; }
            set { _editLevelAdded = value; }
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
            return ObjCloner.Clone(this);
        }

        #endregion

        #region ValidationRules, IsValid

        private Validation.ValidationRules _validationRules;

        protected Validation.ValidationRules ValidationRules
        {
            get
            {
                if (_validationRules == null)
                    _validationRules = new Dothan.Validation.ValidationRules(this);
                return _validationRules;
            }
        }

       
        protected virtual void AddBusinessRules()
        {

        }

        [Browsable(false)]
        public virtual bool IsValid
        {
            get { return ValidationRules.IsValid; }
        }


        
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public virtual Validation.BrokenRulesCollection BrokenRulesCollection
        {
            get { return ValidationRules.GetBrokenRules(); }
        }

        #endregion

        #region Data Access

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", MessageId = "Member")]
        protected virtual void DataPortal_Create(object criteria)
        {
            throw new NotSupportedException(Resources.CreateNotSupportedException);
        }

        
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", MessageId = "Member")]
        protected virtual void DataPortal_Fetch(object criteria)
        {
            throw new NotSupportedException(Resources.FetchNotSupportedException);
        }

       
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", MessageId = "Member")]
        protected virtual void DataPortal_Insert()
        {
            throw new NotSupportedException(Resources.InsertNotSupportedException);
        }

       
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", MessageId = "Member")]
        protected virtual void DataPortal_Update()
        {
            throw new NotSupportedException(Resources.UpdateNotSupportedException);
        }

      
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", MessageId = "Member")]
        protected virtual void DataPortal_DeleteSelf()
        {
            throw new NotSupportedException(Resources.DeleteNotSupportedException);
        }

      
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores", MessageId = "Member")]
        protected virtual void DataPortal_Delete(object criteria)
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

        #region IDataErrorInfo

        string IDataErrorInfo.Error
        {
            get
            {
                if (!IsValid)
                    return ValidationRules.GetBrokenRules().ToString();
                else
                    return String.Empty;
            }
        }

        string IDataErrorInfo.this[string columnName]
        {
            get
            {
                string result = string.Empty;
                if (!IsValid)
                {
                    Validation.BrokenRule rule =
                      ValidationRules.GetBrokenRules().GetFirstBrokenRule(columnName);
                    if (rule != null)
                        result = rule.Description;
                }
                return result;
            }
        }

        #endregion

        #region Serialization Notification

        [OnDeserialized()]
        private void OnDeserializedHandler(StreamingContext context)
        {
            ValidationRules.SetTarget(this);
            AddBusinessRules();
            OnDeserialized(context);
        }

      
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnDeserialized(StreamingContext context)
        {
            
        }

        #endregion
    }
}
