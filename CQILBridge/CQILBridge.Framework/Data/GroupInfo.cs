using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQILBridge.Framework.Data {
    /// <summary>
    /// 表示一个群的信息。
    /// </summary>
    public sealed class GroupInfo {
        /// <summary>
        /// 群号
        /// </summary>
        /// <returns><see cref="long"/></returns>
        public long Number { get; set; }

        /// <summary>
        /// 群名
        /// </summary>
        /// <returns><see cref="string"/></returns>
        public string Name { get; set; }

        /// <summary>
        /// 群主QQ号
        /// </summary>
        /// <returns><see cref="long"/></returns>
        public long Owner { get; set; }

    }
}
