using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace CodeIn60Seconds_List_Ext
{
    
    public interface IPlugin { void Invoke(params object[] param); }//1
   
    public interface ISpeech : IPlugin { } //2
    internal class Program
    {
        //3
        public static ISpeech Speech { get; set; }  = Wrapper.Get<ISpeech>();
        private static void Main()
        {
            while (true)
            {
                Speech.Invoke(Console.ReadLine()); //4
            }
        }
    }
    public abstract class DelegateHandler //5
    {
        protected Delegate Delegate { get; set; }
        public void Invoke(params object[] param)
        {
            if (Delegate?.Method.GetParameters().Length == param.Length)
                Delegate?.DynamicInvoke(param);
        }
    }
    //7
    public static class Wrapper
    {
        //9
        public static T Get<T>() where T : class, IPlugin
        {
            var fileSystemInfos = new DirectoryInfo("..//..//..//").GetFiles($"Lib*.dll", SearchOption.AllDirectories);
            return 
                typeof(T).CreateInstance<T>(AppDomain.CurrentDomain.GetAssemblies()) ??
                typeof(T).CreateInstance<T>(fileSystemInfos.Select(s => Assembly.LoadFrom(s.FullName)));
        }
        //8
        private static T CreateInstance<T>(this Type interfaceType, IEnumerable<Assembly> assemblies) where T : class, IPlugin
        {
            var concreteClass = assemblies.SelectMany(s => s?.GetExportedTypes())
                .FirstOrDefault(s => s.GetInterface(interfaceType.Name) != null);
            return concreteClass != null ? (T)Activator.CreateInstance(concreteClass) : null;
        }
    }
   
}