using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace LibPlugin
{
    //public static class Wrapper
    //{
    //    public static T Get<T>() where T : class, IPlugin
    //    {
    //        var interfaceType = typeof(T);
    //        var concreteType = 
    //            AppDomain.CurrentDomain
    //                .GetAssemblies()
    //                .SelectMany(s => s.GetExportedTypes())
    //                .FirstOrDefault(s => s.GetInterface(interfaceType.Name) != null) ?? 
    //                 new DirectoryInfo("..//..//..//")
    //                 .GetFileSystemInfos($"Lib{interfaceType.FullName?.Substring(interfaceType.FullName.IndexOf(".", StringComparison.Ordinal) + 2)}.dll", SearchOption.AllDirectories)
    //                 .SelectMany(s => Assembly.LoadFrom(s.FullName).GetExportedTypes())
    //                 .FirstOrDefault(s => s.GetInterface(interfaceType.Name) != null);
    //        return concreteType != null ? (T)Activator.CreateInstance(concreteType) : null;
    //    }
    //}
}