using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQILBridge.Framework {
    /// <summary>
    /// 插件程序集属性接口。
    /// </summary>
    internal interface ICQApp {
        /// <summary>
        /// 程序集路径。
        /// </summary>
        string AppPath { get; }

        /// <summary>
        /// 打开设置窗口。
        /// </summary>
        void OpenSettingPanel();
    }

}
