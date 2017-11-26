using System;
using System.ComponentModel;
using System.Reflection;

namespace Dothan.Core
{
    [Serializable()]
    public abstract class BindableBase : System.ComponentModel.INotifyPropertyChanged
    {
        [NonSerialized()]
        private PropertyChangedEventHandler _nonSerializableHandlers;
        private PropertyChangedEventHandler _serializableHandlers;

        protected BindableBase()
        {

        }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design","CA1062:ValidateArgumentsOfPublicMethods")]
        public event PropertyChangedEventHandler PropertyChanged
        {
            add
            {
                if (value.Method.IsPublic &&
                   (value.Method.DeclaringType.IsSerializable ||
                    value.Method.IsStatic))
                    _serializableHandlers = (PropertyChangedEventHandler)
                      System.Delegate.Combine(_serializableHandlers, value);
                else
                    _nonSerializableHandlers = (PropertyChangedEventHandler)
                      System.Delegate.Combine(_nonSerializableHandlers, value);
            }
            remove
            {
                if (value.Method.IsPublic &&
                   (value.Method.DeclaringType.IsSerializable ||
                    value.Method.IsStatic))
                    _serializableHandlers = (PropertyChangedEventHandler)
                      System.Delegate.Remove(_serializableHandlers, value);
                else
                    _nonSerializableHandlers = (PropertyChangedEventHandler)
                      System.Delegate.Remove(_nonSerializableHandlers, value);
            }
        }
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnIsDirtyChanged()
        {
            OnUnknownPropertyChanged();
        }
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnUnknownPropertyChanged()
        {
            PropertyInfo[] properties =
              this.GetType().GetProperties(
              BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo item in properties)
                OnPropertyChanged(item.Name);
        }
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler nonSerializableHandlers =
              _nonSerializableHandlers;
            if (nonSerializableHandlers != null)
                nonSerializableHandlers.Invoke(this,
                  new PropertyChangedEventArgs(propertyName));
            PropertyChangedEventHandler serializableHandlers =
              _serializableHandlers;
            if (serializableHandlers != null)
                serializableHandlers.Invoke(this,
                  new PropertyChangedEventArgs(propertyName));
        }
    }
}