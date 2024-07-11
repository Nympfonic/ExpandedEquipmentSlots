using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Arys.EES.Helpers;

internal static class ReflectionHelper
{
    internal static T GetField<T>(this object obj, string name, IDictionary<string, MemberInfo> reflectionCache = null)
    {
        if (reflectionCache != null && reflectionCache.ContainsKey(name))
        {
            return (T)(reflectionCache[name] as FieldInfo).GetValue(obj);
        }

        Type type = obj.GetType();
        FieldInfo field = AccessTools.Field(type, name);

        reflectionCache?.Add(name, field);

        return (T)field.GetValue(obj);
    }

    internal static void SetField<T>(this object obj, string name, T value, IDictionary<string, MemberInfo> reflectionCache = null)
    {
        if (reflectionCache != null && reflectionCache.ContainsKey(name))
        {
            (reflectionCache[name] as FieldInfo).SetValue(obj, value);
            return;
        }

        Type type = obj.GetType();
        FieldInfo field = AccessTools.Field(type, name);

        reflectionCache?.Add(name, field);

        field.SetValue(obj, value);
    }

    internal static void CopyFieldsTo<T>(this T obj, T obj2)
    {
        List<FieldInfo> fields = AccessTools.GetDeclaredFields(typeof(T));

        foreach (var field in fields)
        {
#if DEBUG
            EESPlugin.LogSource.LogWarning($"Copying field {field.Name}'s value from {obj} to {obj2}");
#endif
            var valueToCopy = field.GetValue(obj);
            field.SetValue(obj2, valueToCopy);
        }
    }
}
