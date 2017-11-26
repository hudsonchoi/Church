using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Dothan.Properties;


namespace Dothan
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix")]
    [Serializable()]
    public abstract class BusinessListBase<T, C> : System.ComponentModel.BindingList<C>,
        Core.IEditableCollection, ICloneable
        where T : BusinessListBase<T, C>
        where C : Core.BusinessBase
    {
        #region Constructors

        protected BusinessListBase()
        {

        }

        #endregion

        #region IsDirty, IsValid

       
        public bool IsDirty
        {
            get
            {
             
                if (DeletedList.Count > 0) return true;              
                foreach (C child in this)
                    if (child.IsDirty)
                        return true;
                return false;
            }
        }

   
        public virtual bool IsValid
        {
            get
            {          
                foreach (C child in this)
                    if (!child.IsValid)
                        return false;
                return true;
            }
        }

        #endregion

        #region Begin/Cancel/ApplyEdit

        public void BeginEdit()
        {
            if (this.IsChild)
                throw new NotSupportedException(Resources.NoBeginEditChildException);

            CopyState();
        }

        public void CancelEdit()
        {
            if (this.IsChild)
                throw new NotSupportedException(Resources.NoCancelEditChildException);

            UndoChanges();
        }


        public void ApplyEdit()
        {
            if (this.IsChild)
                throw new NotSupportedException(Resources.NoApplyEditChildException);

            AcceptChanges();
        }

        #endregion

        #region N-level undo

        void Core.IUndoableObj.CopyState()
        {
            CopyState();
        }

        void Core.IUndoableObj.UndoChanges()
        {
            UndoChanges();
        }

        void Core.IUndoableObj.AcceptChanges()
        {
            AcceptChanges();
        }

        private void CopyState()
        {
            // we are going a level deeper in editing
            _editLevel += 1;

            // cascade the call to all child objects
            foreach (C child in this)
                child.CopyState();

            // cascade the call to all deleted child objects
            foreach (C child in DeletedList)
                child.CopyState();
        }

        private void UndoChanges()
        {
            C child;

            // we are coming up one edit level
            _editLevel -= 1;
            if (_editLevel < 0) _editLevel = 0;

            // Cancel edit on all current items
            for (int index = Count - 1; index >= 0; index--)
            {
                child = this[index];
                child.UndoChanges();
                // if item is below its point of addition, remove
                if (child.EditLevelAdded > _editLevel)
                    RemoveAt(index);
            }

            // cancel edit on all deleted items
            for (int index = DeletedList.Count - 1; index >= 0; index--)
            {
                child = DeletedList[index];
                child.UndoChanges();
                if (child.EditLevelAdded > _editLevel)
                {
                    // if item is below its point of addition, remove
                    DeletedList.RemoveAt(index);
                }
                else
                {
                    // if item is no longer deleted move back to main list
                    if (!child.IsDeleted) UnDeleteChild(child);
                }
            }
        }

        private void AcceptChanges()
        {
            // we are coming up one edit level
            _editLevel -= 1;
            if (_editLevel < 0) _editLevel = 0;

            // cascade the call to all child objects
            foreach (C child in this)
            {
                child.AcceptChanges();
                // if item is below its point of addition, lower point of addition
                if (child.EditLevelAdded > _editLevel) child.EditLevelAdded = _editLevel;
            }

            // cascade the call to all deleted child objects
            for (int index = DeletedList.Count - 1; index >= 0; index--)
            {
                C child = DeletedList[index];
                child.AcceptChanges();
                // if item is below its point of addition, remove
                if (child.EditLevelAdded > _editLevel)
                    DeletedList.RemoveAt(index);
            }
        }

        #endregion

        #region Delete and Undelete child

        private List<C> _deletedList;

      
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected List<C> DeletedList
        {
            get
            {
                if (_deletedList == null)
                    _deletedList = new List<C>();
                return _deletedList;
            }
        }

        private void DeleteChild(C child)
        {
            // mark the object as deleted
            child.DeleteChild();
            // and add it to the deleted collection for storage
            DeletedList.Add(child);
        }

        private void UnDeleteChild(C child)
        {
            int saveLevel = child.EditLevelAdded;
            Add(child);
            child.EditLevelAdded = saveLevel;
            DeletedList.Remove(child);
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public bool ContainsDeleted(C item)
        {
            return DeletedList.Contains(item);
        }

        #endregion

        #region Insert, Remove, Clear

  
        void Core.IEditableCollection.RemoveChild(Dothan.Core.BusinessBase child)
        {
            Remove((C)child);
        }

      
        protected override void InsertItem(int index, C item)
        {
           
            item.EditLevelAdded = _editLevel;
            item.SetParent(this);
            base.InsertItem(index, item);
        }

        protected override void RemoveItem(int index)
        {          
            C child = this[index];
            DeleteChild(child);
            child.PropertyChanged -= new PropertyChangedEventHandler(Child_PropertyChanged);
            base.RemoveItem(index);
        }

       
        protected override void ClearItems()
        {
            while (base.Count > 0) RemoveItem(0);
            base.ClearItems();
        }

    
        protected override void SetItem(int index, C item)
        {
            RemoveItem(index);
            base.SetItem(index, item);
        }

        #endregion

        #region Edit level tracking

       
        private int _editLevel;

        #endregion

        #region IsChild

        [NotUndoable()]
        private bool _isChild = false;

      
        protected bool IsChild
        {
            get { return _isChild; }
        }

        protected void MarkAsChild()
        {
            _isChild = true;
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

        public T Clone()
        {
            return (T)GetClone();
        }

        #endregion

        #region Cascade Child events

        private void Child_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            for (int index = 0; index < Count; index++)
            {
                if (ReferenceEquals(this[index], sender))
                {
                    OnListChanged(new ListChangedEventArgs(ListChangedType.ItemChanged, index));
                    return;
                }
            }
        }

        #endregion

        #region Serialization Notification

        [OnDeserialized()]
        private void OnDeserializedHandler(StreamingContext context)
        {
            foreach (Core.BusinessBase child in this)
            {
                child.SetParent(this);
                child.PropertyChanged += new PropertyChangedEventHandler(Child_PropertyChanged);
            }
            foreach (Core.BusinessBase child in DeletedList)
                child.SetParent(this);
            OnDeserialized(context);
        }

      
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnDeserialized(StreamingContext context)
        {
        }

        #endregion

        #region Data Access

        
        public virtual T Save()
        {
            if (this.IsChild)
                throw new NotSupportedException(Resources.NoSaveChildException);

            if (_editLevel > 0)
                throw new Validation.ValidationException(Resources.NoSaveEditingException);

            if (!IsValid)
                throw new Validation.ValidationException(Resources.NoSaveInvalidException);

            if (IsDirty)
                return (T)DataPortal.Update(this);
            else
                return (T)this;
        }

        
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
        protected virtual void DataPortal_Update()
        {
            throw new NotSupportedException(Resources.UpdateNotSupportedException);
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
    }
}
