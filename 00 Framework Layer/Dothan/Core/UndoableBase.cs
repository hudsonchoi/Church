using System;
using System.Collections;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.ComponentModel;


namespace Dothan.Core
{
    [Serializable()]
    public abstract class UndoableBase : Dothan.Core.BindableBase, Dothan.Core.IUndoableObj
    {
        [NotUndoable()]
        private Stack<byte[]> _stateStack = new Stack<byte[]>();

        protected UndoableBase()
        {

        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        protected int EditLevel
        {
            get { return _stateStack.Count; }
        }

        void IUndoableObj.CopyState()
        {
            CopyState();
        }

        void IUndoableObj.UndoChanges()
        {
            UndoChanges();
        }

        void IUndoableObj.AcceptChanges()
        {
            AcceptChanges();
        }

     
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void CopyStateComplete()
        {
        }

       
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected internal void CopyState()
        {
            Type currentType = this.GetType();
            HybridDictionary state = new HybridDictionary();
            FieldInfo[] fields;
            string fieldName;

            do
            {
               
                fields = currentType.GetFields(
                    BindingFlags.NonPublic |
                    BindingFlags.Instance |
                    BindingFlags.Public);

                foreach (FieldInfo field in fields)
                {
                   
                    if (field.DeclaringType == currentType)
                    {
                       
                        if (!NotUndoableField(field))
                        {
                            
                            object value = field.GetValue(this);

                            if (typeof(Dothan.Core.IUndoableObj).IsAssignableFrom(field.FieldType))
                            {
                               
                                if (value != null)
                                {
                                   
                                    ((Core.IUndoableObj)value).CopyState();
                                }
                            }
                            else
                            {
                                fieldName = field.DeclaringType.Name + "!" + field.Name;
                                state.Add(fieldName, value);
                            }
                        }
                    }
                }
                currentType = currentType.BaseType;
            } while (currentType != typeof(UndoableBase));

           
            using (MemoryStream buffer = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(buffer, state);
                _stateStack.Push(buffer.ToArray());
            }
            CopyStateComplete();
        }

     
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void UndoChangesComplete()
        {
        }
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected internal void UndoChanges()
        {
            
            if (EditLevel > 0)
            {
                HybridDictionary state;
                using (MemoryStream buffer = new MemoryStream(_stateStack.Pop()))
                {
                    buffer.Position = 0;
                    BinaryFormatter formatter = new BinaryFormatter();
                    state = (HybridDictionary)formatter.Deserialize(buffer);
                }

                Type currentType = this.GetType();
                FieldInfo[] fields;
                string fieldName;

                do
                {
                   
                    fields = currentType.GetFields(
                        BindingFlags.NonPublic |
                        BindingFlags.Instance |
                        BindingFlags.Public);
                    foreach (FieldInfo field in fields)
                    {
                        if (field.DeclaringType == currentType)
                        {
                            
                            if (!NotUndoableField(field))
                            {
                                
                                object value = field.GetValue(this);

                                if (typeof(Dothan.Core.IUndoableObj).IsAssignableFrom(field.FieldType))
                                {
                                    
                                    if (value != null)
                                    {
                                        
                                        ((Core.IUndoableObj)value).UndoChanges();
                                    }
                                }
                                else
                                {
                                    
                                    fieldName = field.DeclaringType.Name + "!" + field.Name;
                                    field.SetValue(this, state[fieldName]);
                                }
                            }
                        }
                    }
                    currentType = currentType.BaseType;
                } while (currentType != typeof(UndoableBase));
            }
            UndoChangesComplete();
        }

        
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void AcceptChangesComplete()
        {
        }

       
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected internal void AcceptChanges()
        {
            if (EditLevel > 0)
            {
                _stateStack.Pop();
                Type currentType = this.GetType();
                FieldInfo[] fields;

                do
                {
                    
                    fields = currentType.GetFields(
                        BindingFlags.NonPublic |
                        BindingFlags.Instance |
                        BindingFlags.Public);
                    foreach (FieldInfo field in fields)
                    {
                        if (!NotUndoableField(field))
                        {
                            if (typeof(Dothan.Core.IUndoableObj).IsAssignableFrom(field.FieldType))
                            {
                                object value = field.GetValue(this);
                               
                                if (value != null)
                                {
                                    ((Core.IUndoableObj)value).AcceptChanges();
                                }
                            }
                        }
                    }
                    currentType = currentType.BaseType;
                } while (currentType != typeof(UndoableBase));
            }
            AcceptChangesComplete();
        }

        #region Helper Functions

        private static bool NotUndoableField(FieldInfo field)
        {
            return Attribute.IsDefined(field, typeof(NotUndoableAttribute));
        }

        #endregion

    }
}
