using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQILBridge.Framework;

namespace CQILBridge.Plugins.Demo {
    public class MyCQApp : CQAppAbstract {

        /// <summary>
        /// App Name
        /// </summary>
        public override string AppName => "org.paspy.cqilbridge.demo";

        /// <summary>
        /// Plugin initialize event
        /// </summary>
        public override int Initialize() {
            
            return 0;
        }

        /// <summary>
        /// CoolQ exit event
        /// </summary>
        public override int Exit() {

            return 0;
        }

        /// <summary>
        /// Plugin enabled event
        /// </summary>
        public override int Enabled() {

            return 0;
        }

        /// <summary>
        /// Plugin disabled event
        /// </summary>
        public override int Disabled() {

            return 0;
        }

        /// <summary>
        /// 打开设置窗口。
        /// </summary>
        public override void OpenSettingPanel() {

        }

        /// <summary>
        /// Type=21 私聊消息。
        /// </summary>
        /// <param name="subType">子类型，11/来自好友 1/来自在线状态 2/来自群 3/来自讨论组。</param>
        /// <param name="sendTime">发送时间(时间戳)。</param>
        /// <param name="fromQQ">来源QQ。</param>
        /// <param name="msg">消息内容。</param>
        /// <param name="font">字体。</param>
        public override EventResponseType PrivateMessage(int subType, int sendTime, long fromQQ, string msg, int font) {
            CQ.SendPrivateMessage(fromQQ, msg);
            return EventResponseType.Ignore;
        }

        /// <summary>
        /// Type=2 群消息。
        /// </summary>
        /// <param name="subType">子类型，目前固定为1。</param>
        /// <param name="sendTime">发送时间(时间戳)。</param>
        /// <param name="fromGroup">来源群号。</param>
        /// <param name="fromQQ">来源QQ。</param>
        /// <param name="fromAnonymous">来源匿名者。</param>
        /// <param name="msg">消息内容。</param>
        /// <param name="font">字体。</param>
        public override EventResponseType GroupMessage(int subType, int sendTime, long fromGroup, long fromQQ, string fromAnonymous, string msg, int font) {

            return EventResponseType.Ignore;
        }

        /// <summary>
        /// Type=4 讨论组消息。
        /// </summary>
        /// <param name="subType">子类型，目前固定为1。</param>
        /// <param name="sendTime">发送时间(时间戳)。</param>
        /// <param name="fromDiscuss">来源讨论组。</param>
        /// <param name="fromQQ">来源QQ。</param>
        /// <param name="msg">消息内容。</param>
        /// <param name="font">字体。</param>
        public override EventResponseType DiscussMessage(int subType, int sendTime, long fromDiscuss, long fromQQ, string msg, int font) {

            return EventResponseType.Ignore;
        }

        /// <summary>
        /// Type=11 群文件上传事件。
        /// </summary>
        /// <param name="subType">子类型，目前固定为1。</param>
        /// <param name="sendTime">发送时间(时间戳)。</param>
        /// <param name="fromGroup">来源群号。</param>
        /// <param name="fromQQ">来源QQ。</param>
        /// <param name="file">上传文件信息。</param>
        public override EventResponseType GroupUpload(int subType, int sendTime, long fromGroup, long fromQQ, string file) {

            return EventResponseType.Ignore;
        }

        /// <summary>
        /// Type=101 群事件-管理员变动。
        /// </summary>
        /// <param name="subType">子类型，1/被取消管理员 2/被设置管理员。</param>
        /// <param name="sendTime">发送时间(时间戳)。</param>
        /// <param name="fromGroup">来源群号。</param>
        /// <param name="beingOperateQQ">被操作QQ。</param>
        public override EventResponseType GroupAdmin(int subType, int sendTime, long fromGroup, long beingOperateQQ) {

            return EventResponseType.Ignore;
        }

        /// <summary>
        /// Type=103 群事件-群成员增加。
        /// </summary>
        /// <param name="subType">子类型，1/管理员已同意 2/管理员邀请。</param>
        /// <param name="sendTime">发送时间(时间戳)。</param>
        /// <param name="fromGroup">来源群。</param>
        /// <param name="fromQQ">来源QQ。</param>
        /// <param name="beingOperateQQ">被操作QQ。</param>
        public override EventResponseType GroupMemberIncrease(int subType, int sendTime, long fromGroup, long fromQQ, long beingOperateQQ) {

            return EventResponseType.Ignore;
        }

        /// <summary>
        /// Type=102 群事件-群成员减少。
        /// </summary>
        /// <param name="subType">子类型，1/群员离开 2/群员被踢 3/自己(即登录号)被踢。</param>
        /// <param name="sendTime">发送时间(时间戳)。</param>
        /// <param name="fromGroup">来源群。</param>
        /// <param name="fromQQ">来源QQ。</param>
        /// <param name="beingOperateQQ">被操作QQ。</param>
        public override EventResponseType GroupMemberDecrease(int subType, int sendTime, long fromGroup, long fromQQ, long beingOperateQQ) {

            return EventResponseType.Ignore;
        }

        /// <summary>
        /// Type=201 好友事件-好友已添加。
        /// </summary>
        /// <param name="subType">子类型，目前固定为1。</param>
        /// <param name="sendTime">发送时间(时间戳)。</param>
        /// <param name="fromQQ">来源QQ。</param>
        public override EventResponseType FriendAdded(int subType, int sendTime, long fromQQ) {

            return EventResponseType.Ignore;
        }

        /// <summary>
        /// Type=301 请求-好友添加。
        /// </summary>
        /// <param name="subType">子类型，目前固定为1。</param>
        /// <param name="sendTime">发送时间(时间戳)。</param>
        /// <param name="fromQQ">来源QQ。</param>
        /// <param name="msg">附言。</param>
        /// <param name="responseFlag">反馈标识(处理请求用)。</param>
        public override EventResponseType RequestAddFriend(int subType, int sendTime, long fromQQ, string msg, string responseFlag) {

            return EventResponseType.Ignore;
        }

        /// <summary>
        /// Type=302 请求-群添加。
        /// </summary>
        /// <param name="subType">子类型，目前固定为1。</param>
        /// <param name="sendTime">发送时间(时间戳)。</param>
        /// <param name="fromGroup">来源群号。</param>
        /// <param name="fromQQ">来源QQ。</param>
        /// <param name="msg">附言。</param>
        /// <param name="responseFlag">反馈标识(处理请求用)。</param>
        public override EventResponseType RequestAddGroup(int subType, int sendTime, long fromGroup, long fromQQ, string msg, string responseFlag) {

            return EventResponseType.Ignore;
        }

    }
}
