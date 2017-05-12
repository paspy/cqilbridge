using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQILBridge.Framework {
    /// <summary>
    /// Response events
    /// </summary>
    public enum EventResponseType {
        /// <summary>
        /// Ignore message
        /// </summary>
        Ignore = 0,

        /// <summary>
        /// Block message
        /// </summary>
        Block = 1
    }
}
