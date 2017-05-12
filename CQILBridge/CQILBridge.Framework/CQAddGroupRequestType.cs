using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQILBridge.Framework {

    /// <summary>
    /// 指示酷Q加群请求类型。
    /// </summary>
    public enum CQAddGroupRequestType {
        /// <summary>
        /// 表示请求类型未指定。
        /// </summary>
        None = 0,

        /// <summary>
        /// 表示一般的加群请求。
        /// </summary>
        Normal = 1,

        /// <summary>
        /// 表示此请求是邀请加群请求。
        /// </summary>
        Invtiation = 2
    }
}
