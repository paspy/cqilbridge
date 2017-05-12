using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQILBridge.Framework {
    public enum CQRequestResult {
        /// <summary>
        /// 此请求暂未处理。
        /// </summary>
        None = 0,
        /// <summary>
        /// 通过请求。
        /// </summary>
        Allow = 1,
        /// <summary>
        /// 拒绝请求。
        /// </summary>
        Deny = 2
    }
}
