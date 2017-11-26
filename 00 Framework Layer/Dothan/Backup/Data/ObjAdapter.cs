
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.ComponentModel;
using System.Reflection;
using Dothan.Properties;


namespace Dothan.Data
{
    public class ObjAdapter
    {
        public void Fill(DataSet ds, object source)
        {
            string className = source.GetType().Name;
            Fill(ds, className, source);
        }

        
        public void Fill(DataSet ds, string tableName, object source)
        {
            DataTable dt;
            bool exists;

            dt = ds.Tables[tableName];
            exists = (dt != null);

            if (!exists)
                dt = new DataTable(tableName);

            Fill(dt, source);

            if (!exists)
                ds.Tables.Add(dt);
        }

        public void Fill(DataTable dt, object source)
        {
            if (source == null)
                throw new ArgumentException(Resources.NothingNotValid);

            
            List<string> columns = GetColumns(source);
            if (columns.Count < 1) return;

          
            foreach (string column in columns)
                if (!dt.Columns.Contains(column))
                    dt.Columns.Add(column);

            
            CopyData(dt, GetIList(source), columns);
        }

        #region DataCopyIList

        private IList GetIList(object source)
        {
            if (source is IListSource)
                return ((IListSource)source).GetList();
            else if (source is IList)
                return source as IList;
            else
            {
                ArrayList col = new ArrayList();
                col.Add(source);
                return col;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
        private void CopyData(
          DataTable dt, IList ds, List<string> columns)
        {
            
            dt.BeginLoadData();
            for (int index = 0; index < ds.Count; index++)
            {
                DataRow dr = dt.NewRow();
                foreach (string column in columns)
                {
                    try
                    {
                        dr[column] = GetField(ds[index], column);
                    }
                    catch (Exception ex)
                    {
                        dr[column] = ex.Message;
                    }
                }
                dt.Rows.Add(dr);
            }
            dt.EndLoadData();
        }

        #endregion

        #region GetColumns

        private List<string> GetColumns(object source)
        {
            List<string> result;
            
            object innerSource;
            IListSource iListSource = source as IListSource;
            if (iListSource != null)
                innerSource = iListSource.GetList();
            else
                innerSource = source;

            DataView dataView = innerSource as DataView;
            if (dataView != null)
                result = ScanDataView(dataView);
            else
            {
               
                IEnumerable iEnumerable = innerSource as IEnumerable;
                if (iEnumerable != null)
                {
                    Type childType = Utilities.GetChildItemType(
                      innerSource.GetType());
                    result = ScanObject(childType);
                }
                else
                {
                   
                    result = ScanObject(innerSource.GetType());
                }
            }
            return result;
        }

        private List<string> ScanDataView(DataView ds)
        {
            List<string> result = new List<string>();
            for (int field = 0; field < ds.Table.Columns.Count; field++)
                result.Add(ds.Table.Columns[field].ColumnName);
            return result;
        }

        private List<string> ScanObject(Type sourceType)
        {
            List<string> result = new List<string>();

            if (sourceType != null)
            {
               
                PropertyInfo[] props = sourceType.GetProperties();
                if (props.Length >= 0)
                    for (int column = 0; column < props.Length; column++)
                        if (props[column].CanRead)
                            result.Add(props[column].Name);

               
                FieldInfo[] fields = sourceType.GetFields();
                if (fields.Length >= 0)
                    for (int column = 0; column < fields.Length; column++)
                        result.Add(fields[column].Name);
            }
            return result;
        }

        #endregion

        #region GetField

        private static string GetField(object obj, string fieldName)
        {
            string result;
            DataRowView dataRowView = obj as DataRowView;
            if (dataRowView != null)
            {
                result = dataRowView[fieldName].ToString();
            }
            else if (obj is ValueType && obj.GetType().IsPrimitive)
            {
                
                result = obj.ToString();
            }
            else
            {
                string tmp = obj as string;
                if (tmp != null)
                {
                   
                    result = (string)obj;
                }
                else
                {
                   
                    try
                    {
                        Type sourceType = obj.GetType();

                        PropertyInfo prop = sourceType.GetProperty(fieldName);

                        if ((prop == null) || (!prop.CanRead))
                        {
                            
                            FieldInfo field = sourceType.GetField(fieldName);
                            if (field == null)
                            {
                              
                                throw new DataException(
                                  Resources.NoSuchValueExistsException +
                                  " " + fieldName);
                            }
                            else
                            {
                               
                                result = field.GetValue(obj).ToString();
                            }
                        }
                        else
                        {
                            
                            result = prop.GetValue(obj, null).ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new DataException(
                          Resources.ErrorReadingValueException +
                          " " + fieldName, ex);
                    }
                }
            }
            return result;
        }

        #endregion

    }

}
