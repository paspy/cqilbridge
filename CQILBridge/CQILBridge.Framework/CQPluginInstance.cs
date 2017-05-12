using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Reflection;

namespace CQILBridge.Framework {
    /// <summary>
    /// 
    /// </summary>
    public static class CQPluginInstance {
        [NonSerialized]
        private static object __syncRoot = null;
        private static ICQApp Instance = null;

        /// <summary>
        /// 
        /// </summary>
        public static string BridgeName;
        static CQPluginInstance() {
            Interlocked.CompareExchange<object>(ref __syncRoot, new object(), null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static ICQApp GetInstance() {
            lock (__syncRoot) {
                if (Instance == null) {
                    string appFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CSharpApps");
                    if (!Directory.Exists(appFolder)) {
                        Directory.CreateDirectory(appFolder);
                        throw new DirectoryNotFoundException("Folder CSharpApps Not Found.");
                    }
                    foreach (string appFile in Directory.GetFiles(appFolder, "*.dll")) {
                        string appName = Path.GetFileNameWithoutExtension(appFile);
                        //try {
                            Assembly assembly = Assembly.Load(File.ReadAllBytes(appFile));
                            foreach (Type type in assembly.GetTypes()) {
                                if (!type.IsClass || type.IsNotPublic) {
                                    continue;
                                }
                                Type[] tempInterfaces = type.GetInterfaces();

                                if (tempInterfaces.Select(x => x.Name).Contains("ICQApp")) {
                                    object appObj = Activator.CreateInstance(type);
                                    var tmpAppName = ((ICQApp)appObj).AppName;
                                    if (tmpAppName.StartsWith(BridgeName)) {
                                        Instance = (ICQApp)appObj;
                                        return Instance;
                                    }
                                }
                            }

                        //} catch (Exception) {
                        //    throw;
                        //}
                    }
                }
                return Instance;
            }
        }

    }
}
