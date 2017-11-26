using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.MobileControls;
using System.Collections.Generic;
using System.Reflection;
using _entity = Dothan.Library;

/// <summary>
/// Summary description for DataAccessLayer
/// </summary>
public class DataAccessLayer
{
    private static DataAccessLayer _instance;

    public static DataAccessLayer Instance
    {
        get
        {
            if (_instance == null)
                _instance = new DataAccessLayer();

            return _instance;
        }
    }

    public DataAccessLayer()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public List<T> GetEntities<T>(_entity.bizCell.CellReportDetails list)
    {
        List<T> entities = new List<T>();

       

            PropertyInfo[] properties = typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public);

           foreach (_entity.bizCell.CellReportDetail info in list)
           {  
                T entity = Activator.CreateInstance<T>();

                foreach (PropertyInfo property in properties)
                {
                    switch (property.Name)
                    {
                        case "No":
                            object value = ConvertValue(info.ID, property.PropertyType);
                            property.SetValue(entity, value, null);
                            break;
                        case "MemberName":
                            value = ConvertValue(string.Format("{0}({1})  ({2})",info.MemberName,info.Sex,info.Cellphone), property.PropertyType);
                            property.SetValue(entity, value, null);
                            break;
                        case "Reason":
                             value = ConvertValue(info.Reason, property.PropertyType);
                            property.SetValue(entity, value, null);
                            break;
                        case "Memo":
                             value = ConvertValue(info.Memo, property.PropertyType);
                            property.SetValue(entity, value, null);
                            break;
                        case "Attendance":
                            value = ConvertValue(info.Attendence, property.PropertyType);
                            property.SetValue(entity, value, null);
                            break;
                         
                    }

                  
                }

                entities.Add(entity);
            }
      

        return entities;
    }

    private object ConvertValue(object value, Type type)
    {
        object retVal = null;

        if (value != null)
        {
            if (type == typeof(string))
            {
                retVal = Convert.ToString(value);
            }
            else if (type == typeof(int))
            {
                retVal = Convert.ToInt32(value);
            }
            else if (type == typeof(double))
            {
                retVal = Convert.ToDouble(value);
            }
            else if (type == typeof(bool))
            {
                retVal = Convert.ToBoolean(value);
            }
            else if (type == typeof(DateTime))
            {
                retVal = Convert.ToDateTime(value);
            }
        }

        return retVal;
    }
}
