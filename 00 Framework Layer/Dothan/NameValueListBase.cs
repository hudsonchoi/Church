using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.ComponentModel;
using Dothan.Properties;

namespace Dothan
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix")]
    [Serializable()]
    public abstract class NameValueListBase<K, V> :
      Core.ReadOnlyBindingList<NameValueListBase<K, V>.NameValuePair>,
      ICloneable, Core.IBusinessObj
    {

        #region Core Implementation


        public V Value(K key)
        {
            foreach (NameValuePair item in this)
                if (item.Key.Equals(key))
                    return item.Value;
            return default(V);
        }


        public K Key(V value)
        {
            foreach (NameValuePair item in this)
                if (item.Value.Equals(value))
                    return item.Key;
            return default(K);
        }

        public bool ContainsKey(K key)
        {
            foreach (NameValuePair item in this)
                if (item.Key.Equals(key))
                    return true;
            return false;
        }


        public bool ContainsValue(V value)
        {
            foreach (NameValuePair item in this)
                if (item.Value.Equals(value))
                    return true;
            return false;
        }

        #endregion

        #region Constructors

        protected NameValueListBase()
        {

        }

        #endregion

        #region NameValuePair class

        /// <summary>
        /// Contains a key and value pair.
        /// </summary>
        [Serializable()]
        public class NameValuePair
        {
            private K _key;
            private V _value;

            /// <summary>
            /// The Key or Name value.
            /// </summary>
            public K Key
            {
                get { return _key; }
            }

            /// <summary>
            /// The Value corresponding to the key/name.
            /// </summary>
            public V Value
            {
                get { return _value; }
            }

            public NameValuePair(K key, V value)
            {
                _key = key;
                _value = value;
            }
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

        public NameValueListBase<K, V> Clone()
        {
            return (NameValueListBase<K, V>)GetClone();
        }

        #endregion

        #region Criteria

        [Serializable()]
        protected class Criteria : CriteriaBase
        {
            public Criteria(Type collectionType)
                : base(collectionType)
            { }
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
