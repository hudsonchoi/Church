﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.ComponentModel;
using Dothan.Properties;

namespace Dothan.Data
{
    public static class DataMapper
    { 
        
    #region Map from IDictionary


    public static void Map(System.Collections.IDictionary source, object target)
    {
      Map(source, target, false);
    }

    
    public static void Map(System.Collections.IDictionary source, object target, params string[] ignoreList)
    {
      Map(source, target, false, ignoreList);
    }

  
    public static void Map(
      System.Collections.IDictionary source, 
      object target, bool suppressExceptions, 
      params string[] ignoreList)
    {
      List<string> ignore = new List<string>(ignoreList);
      foreach (string propertyName in source.Keys)
      {
        if (!ignore.Contains(propertyName))
        {
          try
          {
            SetValue(target, propertyName, source[propertyName]);
          }
          catch (Exception ex)
          {
            if (!suppressExceptions)
              throw new ArgumentException(
                String.Format("{0} ({1})", 
                Resources.PropertyCopyFailed, propertyName), ex);
          }
        }
      }
    }

    #endregion

    #region Map from Object


    public static void Map(object source, object target)
    {
      Map(source, target, false);
    }


    public static void Map(object source, object target, params string[] ignoreList)
    {
      Map(source, target, false, ignoreList);
    }

  
    public static void Map(
      object source, object target, 
      bool suppressExceptions, 
      params string[] ignoreList)
    {
      List<string> ignore = new List<string>(ignoreList);
      PropertyInfo[] sourceProperties =
        GetSourceProperties(source.GetType());
      foreach (PropertyInfo sourceProperty in sourceProperties)
      {
        string propertyName = sourceProperty.Name;
        if (!ignore.Contains(propertyName))
        {
          try
          {
            SetValue(
              target, propertyName, 
              sourceProperty.GetValue(source, null));
          }
          catch (Exception ex)
          {
            if (!suppressExceptions)
              throw new ArgumentException(
                String.Format("{0} ({1})", 
                Resources.PropertyCopyFailed, propertyName), ex);
          }
        }
      }
    }

    private static PropertyInfo[] GetSourceProperties(Type sourceType)
    {
      List<PropertyInfo> result = new List<PropertyInfo>();
      PropertyDescriptorCollection props =
        TypeDescriptor.GetProperties(sourceType);
      foreach (PropertyDescriptor item in props)
        if (item.IsBrowsable)
          result.Add(sourceType.GetProperty(item.Name));
      return result.ToArray();
    }

    #endregion

    private static void SetValue(
      object target, string propertyName, object value)
    {
      PropertyInfo propertyInfo =
        target.GetType().GetProperty(propertyName);
      if (value == null)
        propertyInfo.SetValue(target, value, null);
      else
      {
        Type pType =
          Utilities.GetPropertyType(propertyInfo.PropertyType);
        if (pType.Equals(value.GetType()))
        {
          // types match, just copy value
          propertyInfo.SetValue(target, value, null);
        }
        else
        {
          // types don't match, try to coerce
          if (pType.Equals(typeof(Guid)))
            propertyInfo.SetValue(
              target, new Guid(value.ToString()), null);
          else
            propertyInfo.SetValue(
              target, Convert.ChangeType(value, pType), null);
        }
      }
    }
  }
}
