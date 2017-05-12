using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace CQILBridge.Framework {
    internal sealed class CQAPI {

        [DllImport("CQP.dll", CallingConvention = CallingConvention.StdCall, BestFitMapping = false)]
        public static extern int CQ_sendPrivateMsg(int authCode, long QQid,
            [MarshalAs(UnmanagedType.LPStr)] [In] string message);

        [DllImport("CQP.dll", CallingConvention = CallingConvention.StdCall, BestFitMapping = false)]
        public static extern int CQ_sendGroupMsg(int authCode, long groupId,
            [MarshalAs(UnmanagedType.LPStr)] [In] string message);

        [DllImport("CQP.dll", CallingConvention = CallingConvention.StdCall, BestFitMapping = false)]
        public static extern int CQ_sendDiscussMsg(int authCode, long discussId,
            [MarshalAs(UnmanagedType.LPStr)] [In] string message);

        [DllImport("CQP.dll", CallingConvention = CallingConvention.StdCall, BestFitMapping = false)]
        public static extern int CQ_sendLike(int authCode, long QQid);

        [DllImport("CQP.dll", CallingConvention = CallingConvention.StdCall, BestFitMapping = false)]
        public static extern int CQ_setGroupKick(int authCode, long groupId, long QQid, int rejectAddRequest);

        [DllImport("CQP.dll", CallingConvention = CallingConvention.StdCall, BestFitMapping = false)]
        public static extern int CQ_setGroupBan(int authCode, long groupId, long QQid, long duration);

        [DllImport("CQP.dll", CallingConvention = CallingConvention.StdCall, BestFitMapping = false)]
        public static extern int CQ_setGroupAdmin(int authCode, long groupId, long QQid, int setAdmin);

        [DllImport("CQP.dll", CallingConvention = CallingConvention.StdCall, BestFitMapping = false)]
        public static extern int CQ_setGroupWholeBan(int authCode, long groupId, int enableban);

        [DllImport("CQP.dll", CallingConvention = CallingConvention.StdCall, BestFitMapping = false)]
        public static extern int CQ_setGroupAnonymousBan(int authCode, long groupId,
            [MarshalAs(UnmanagedType.LPStr)] [In] string anonymous, long duration);

        [DllImport("CQP.dll", CallingConvention = CallingConvention.StdCall, BestFitMapping = false)]
        public static extern int CQ_setGroupAnonymous(int authCode, long groupId, int enableAnomymous);

        [DllImport("CQP.dll", CallingConvention = CallingConvention.StdCall, BestFitMapping = false)]
        public static extern int CQ_setGroupCard(int authCode, long groupId, long QQid,
            [MarshalAs(UnmanagedType.LPStr)] [In] string newCard);

        [DllImport("CQP.dll", CallingConvention = CallingConvention.StdCall, BestFitMapping = false)]
        public static extern int CQ_setGroupLeave(int authCode, long groupId, int isdismissed);

        [DllImport("CQP.dll", CallingConvention = CallingConvention.StdCall, BestFitMapping = false)]
        public static extern int CQ_setGroupSpecialTitle(int authCode, long groupId, long QQid,
            [MarshalAs(UnmanagedType.LPStr)] [In] string newTitle, long duration);

        [DllImport("CQP.dll", CallingConvention = CallingConvention.StdCall, BestFitMapping = false)]
        public static extern int CQ_setDiscussLeave(int authCode, long discussGroupId);

        [DllImport("CQP.dll", CallingConvention = CallingConvention.StdCall, BestFitMapping = false)]
        public static extern int CQ_setFriendAddRequest(int authCode,
            [MarshalAs(UnmanagedType.LPStr)] [In] string responseFlag, int responseOperation,
            [MarshalAs(UnmanagedType.LPStr)] [In] string remark);

        [DllImport("CQP.dll", CallingConvention = CallingConvention.StdCall, BestFitMapping = false)]
        public static extern int CQ_setGroupAddRequestV2(int authCode,
            [MarshalAs(UnmanagedType.LPStr)] [In] string responseFlag, int requestType, int responseOperation,
            [MarshalAs(UnmanagedType.LPStr)] [In] string reason);

        [DllImport("CQP.dll", CallingConvention = CallingConvention.StdCall, BestFitMapping = false)]
        public static extern string CQ_getGroupMemberInfoV2(int authCode, long groupId, long QQid, int nocache);

        [DllImport("CQP.dll")]
        public static extern string CQ_getGroupMemberList(int authCode, long groupId);

        [DllImport("CQP.dll", CallingConvention = CallingConvention.StdCall, BestFitMapping = false)]
        public static extern int CQ_addLog(int authCode, int priority,
            [MarshalAs(UnmanagedType.LPStr)] [In] string category,
            [MarshalAs(UnmanagedType.LPStr)] [In] string content);

        [DllImport("CQP.dll", CallingConvention = CallingConvention.StdCall, BestFitMapping = false)]
        public static extern string CQ_getCookies(int authCode);

        [DllImport("CQP.dll", CallingConvention = CallingConvention.StdCall, BestFitMapping = false)]
        public static extern int CQ_getCsrfToken(int authCode);

        [DllImport("CQP.dll", CallingConvention = CallingConvention.StdCall, BestFitMapping = false)]
        public static extern long CQ_getLoginQQ(int authCode);

        [DllImport("CQP.dll", CallingConvention = CallingConvention.StdCall, BestFitMapping = false)]
        public static extern string CQ_getLoginNick(int authCode);

        [DllImport("CQP.dll", CallingConvention = CallingConvention.StdCall, BestFitMapping = false)]
        public static extern string CQ_getAppDirectory(int authCode);

    }
}
