using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Dothan.Properties;

namespace Dothan
{
    internal static class MethodCaller
    {
  
        public static object CallMethodIfImplemented(object obj, string method, params object[] parameters)
        {
            MethodInfo info = GetMethod(obj.GetType(), method, parameters);
            if (info != null)
                return CallMethod(obj, info, parameters);
            else
                return null;
        }

    
        public static object CallMethod(object obj, string method, params object[] parameters)
        {
            MethodInfo info = GetMethod(obj.GetType(), method, parameters);
            if (info == null)
                throw new NotImplementedException(method + " " + Resources.MethodNotImplemented);
            return CallMethod(obj, info, parameters);
        }


        public static object CallMethod(object obj, MethodInfo info, params object[] parameters)
        {
            // call a private method on the object
            object result;
            try
            {
                result = info.Invoke(obj, parameters);
            }
            catch (Exception e)
            {
                throw new Dothan.Server.CallMethodException(info.Name + " " + Resources.MethodCallFailed, e.InnerException);
            }
            return result;
        }

        public static MethodInfo GetMethod(Type objectType, string method, params object[] parameters)
        {
            BindingFlags flags =
              BindingFlags.FlattenHierarchy |
              BindingFlags.Instance |
              BindingFlags.Public |
              BindingFlags.NonPublic;

            MethodInfo result = null;

            // try to find a strongly typed match
            if (parameters.Length > 0)
            {
                // put all param types into a list of Type
                bool paramsAllNothing = true;
                List<Type> types = new List<Type>();
                foreach (object item in parameters)
                {
                    if (item == null)
                        types.Add(typeof(object));
                    else
                    {
                        types.Add(item.GetType());
                        paramsAllNothing = false;
                    }
                }

                if (paramsAllNothing)
                {
                   
                    BindingFlags oneLevelFlags = BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
                    Type[] typesArray = types.ToArray();

                
                    Type currentType = objectType;
                    do
                    {
                        MethodInfo info = currentType.GetMethod(method, oneLevelFlags);
                        if (info != null)
                        {
                            if (info.GetParameters().Length == parameters.Length)
                            {
                                // got a match so use it
                                result = info;
                                break;
                            }
                        }
                        currentType = currentType.BaseType;
                    } while (currentType != null);
                }
                else
                {
                   
                    result = objectType.GetMethod(method, flags, null,CallingConventions.Any, types.ToArray(), null);
                }
            }

          
            if (result == null)
            {
                try
                { result = objectType.GetMethod(method, flags); }
                catch (AmbiguousMatchException)
                {
                    MethodInfo[] methods = objectType.GetMethods();
                    foreach (MethodInfo m in methods)
                        if (m.Name == method && m.GetParameters().Length == parameters.Length)
                        {
                            result = m;
                            break;
                        }
                    if (result == null)
                        throw;
                }
            }
            return result;
        }

     
        public static Type GetObjectType(object criteria)
        {
            if (criteria.GetType().IsSubclassOf(typeof(CriteriaBase)))
            {
                return ((CriteriaBase)criteria).ObjectType;
            }
            else
            {
            
                return criteria.GetType().DeclaringType;
            }
        }
    }
}
