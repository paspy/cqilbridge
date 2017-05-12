using System;
using System.Security;
using System.Collections.Generic;
using System.Text;

using CQILBridge.Framework.Data;
using CQILBridge.Framework.Utility;

namespace CQILBridge.Framework {
    /// <summary>
    /// Official supported CoolQ APIs
    /// </summary>
    public static class CQ {

        private static int _cqauthcode = -1;
        private static string _appName = string.Empty;
        /// <inheritdoc />
        public static void SetAuthCode(int authCode) { _cqauthcode = authCode; }

        /// <inheritdoc />
        public static string Cookies => CQAPI.CQ_getCookies(_cqauthcode);

        /// <inheritdoc />
        public static SecureString SecureCookies {
            get {
                var sc = new SecureString();
                foreach (var c in CQAPI.CQ_getCookies(_cqauthcode)) {
                    sc.AppendChar(c);
                }
                sc.MakeReadOnly();
                return sc;
            }
        }

        /// <inheritdoc />
        public static int CsrfToken => CQAPI.CQ_getCsrfToken(_cqauthcode);

        /// <inheritdoc />
        public static string AppDirectory => CQAPI.CQ_getAppDirectory(_cqauthcode);

        /// <inheritdoc />
        public static string NickName => CQAPI.CQ_getLoginNick(_cqauthcode);

        /// <inheritdoc />
        public static long Number => CQAPI.CQ_getLoginQQ(_cqauthcode);

        /// <inheritdoc />
        public static void SendPrivateMessage(long qq, string message)
            => CQAPI.CQ_sendPrivateMsg(_cqauthcode, qq, message);

        /// <inheritdoc />
        public static void SendGroupMessage(long groupId, string message)
            => CQAPI.CQ_sendGroupMsg(_cqauthcode, groupId, message);

        /// <inheritdoc />
        public static void SendDiscussGroupMessage(long dicussGroupId, string message)
            => CQAPI.CQ_sendDiscussMsg(_cqauthcode, dicussGroupId, message);

        /// <inheritdoc />
        public static void Log(CQLogLevel level, string message)
            => CQAPI.CQ_addLog(_cqauthcode, (int)level, level.ToString(), message);

        /// <inheritdoc />
        public static void Log(CQLogLevel level, string message, string category)
            => CQAPI.CQ_addLog(_cqauthcode, (int)level, category, message);

        /// <inheritdoc />
        public static GroupMemberInfo GetGroupMemberInfo(long groupId, long qq) {
            try {
                var data = CQAPI.CQ_getGroupMemberInfoV2(_cqauthcode, groupId, qq, 0);
                var memberBytes = Convert.FromBase64String(data);
                var info = new GroupMemberInfo();
                var groupNumberBytes = new byte[8];

                Array.Copy(memberBytes, 0, groupNumberBytes, 0, 8);
                Array.Reverse(groupNumberBytes);
                info.GroupId = BitConverter.ToInt64(groupNumberBytes, 0);

                var qqNumberBytes = new byte[8];
                Array.Copy(memberBytes, 8, qqNumberBytes, 0, 8);
                Array.Reverse(qqNumberBytes);
                info.Number = BitConverter.ToInt64(qqNumberBytes, 0);

                var nameLengthBytes = new byte[2];
                Array.Copy(memberBytes, 16, nameLengthBytes, 0, 2);
                Array.Reverse(nameLengthBytes);
                var nameLength = BitConverter.ToInt16(nameLengthBytes, 0);

                var nameBytes = new byte[nameLength];
                Array.Copy(memberBytes, 18, nameBytes, 0, nameLength);
                info.NickName = Encoding.Default.GetString(nameBytes);

                var cardLengthBytes = new byte[2];
                Array.Copy(memberBytes, 18 + nameLength, cardLengthBytes, 0, 2);
                Array.Reverse(cardLengthBytes);
                var cardLength = BitConverter.ToInt16(cardLengthBytes, 0);

                var cardBytes = new byte[cardLength];
                Array.Copy(memberBytes, 20 + nameLength, cardBytes, 0, cardLength);
                info.InGroupName = Encoding.Default.GetString(cardBytes);

                var genderBytes = new byte[4];
                Array.Copy(memberBytes, 20 + nameLength + cardLength, genderBytes, 0, 4);
                Array.Reverse(genderBytes);
                info.Gender = BitConverter.ToInt32(genderBytes, 0) == 0 ? "男" : " 女";

                var ageBytes = new byte[4];
                Array.Copy(memberBytes, 24 + nameLength + cardLength, ageBytes, 0, 4);
                Array.Reverse(ageBytes);
                info.Age = BitConverter.ToInt32(ageBytes, 0);

                var areaLengthBytes = new byte[2];
                Array.Copy(memberBytes, 28 + nameLength + cardLength, areaLengthBytes, 0, 2);
                Array.Reverse(areaLengthBytes);
                var areaLength = BitConverter.ToInt16(areaLengthBytes, 0);

                var areaBytes = new byte[areaLength];
                Array.Copy(memberBytes, 30 + nameLength + cardLength, areaBytes, 0, areaLength);
                info.Area = Encoding.Default.GetString(areaBytes);

                var addGroupTimesBytes = new byte[4];
                Array.Copy(memberBytes, 30 + nameLength + cardLength + areaLength, addGroupTimesBytes, 0, 4);
                Array.Reverse(addGroupTimesBytes);
                info.JoinTime =
                    new DateTime(1970, 1, 1, 0, 0, 0).ToLocalTime()
                        .AddSeconds(BitConverter.ToInt32(addGroupTimesBytes, 0));

                var lastSpeakTimesBytes = new byte[4];
                Array.Copy(memberBytes, 34 + nameLength + cardLength + areaLength, lastSpeakTimesBytes, 0, 4);
                Array.Reverse(lastSpeakTimesBytes);
                info.LastSpeakingTime =
                    new DateTime(1970, 1, 1, 0, 0, 0).ToLocalTime()
                        .AddSeconds(BitConverter.ToInt32(lastSpeakTimesBytes, 0));

                var levelNameLengthBytes = new byte[2];
                Array.Copy(memberBytes, 38 + nameLength + cardLength + areaLength, levelNameLengthBytes, 0, 2);
                Array.Reverse(levelNameLengthBytes);
                var levelNameLength = BitConverter.ToInt16(levelNameLengthBytes, 0);

                var levelNameBytes = new byte[levelNameLength];
                Array.Copy(memberBytes, 40 + nameLength + cardLength + areaLength, levelNameBytes, 0, levelNameLength);
                info.Level = Encoding.Default.GetString(levelNameBytes);

                var authorBytes = new byte[4];
                Array.Copy(memberBytes, 40 + nameLength + cardLength + areaLength + levelNameLength, authorBytes, 0, 4);
                Array.Reverse(authorBytes);
                var authority = BitConverter.ToInt32(authorBytes, 0);
                info.Authority = authority.ToString();

                var badBytes = new byte[4];
                Array.Copy(memberBytes, 44 + nameLength + cardLength + areaLength + levelNameLength, badBytes, 0, 4);
                Array.Reverse(badBytes);
                info.HasBadRecord = BitConverter.ToInt32(badBytes, 0) == 1;

                var titleLengthBytes = new byte[2];
                Array.Copy(memberBytes, 48 + nameLength + cardLength + areaLength + levelNameLength, titleLengthBytes, 0,
                    2);
                Array.Reverse(titleLengthBytes);
                var titleLength = BitConverter.ToInt16(titleLengthBytes, 0);

                var titleBytes = new byte[titleLength];
                Array.Copy(memberBytes, 50 + nameLength + cardLength + areaLength + levelNameLength, titleBytes, 0,
                    titleLength);
                info.Title = Encoding.Default.GetString(titleBytes);

                var titleExpireBytes = new byte[4];
                Array.Copy(memberBytes, 50 + nameLength + cardLength + areaLength + levelNameLength + titleLength,
                    titleExpireBytes, 0, 4);
                Array.Reverse(titleExpireBytes);
                info.TitleExpirationTime = BitConverter.ToInt32(titleExpireBytes, 0);

                var modifyCardBytes = new byte[4];
                Array.Copy(memberBytes, 54 + nameLength + cardLength + areaLength + levelNameLength + titleLength,
                    titleExpireBytes, 0, 4);
                Array.Reverse(titleExpireBytes);
                info.CanModifyInGroupName = BitConverter.ToInt32(modifyCardBytes, 0) == 1;
                return info;
            } catch (Exception) {
                //无法获取到群成员信息，直接返回null
                return null;
            }
        }

        

        /// <inheritdoc />
        public static void SendLike(long qq, int count = 1) => CQAPI.CQ_sendLike(_cqauthcode, qq);

        /// <inheritdoc />
        public static void ProcessAddFriendRequest(string responseMark, CQRequestResult result, string remark = "")
            => CQAPI.CQ_setFriendAddRequest(_cqauthcode, responseMark, (int)result, remark);

        /// <inheritdoc />
        public static void KickFromGroup(long groupId, long qq, bool rejectAddGroupRequest)
            => CQAPI.CQ_setGroupKick(_cqauthcode, groupId, qq, rejectAddGroupRequest ? 1 : 0);

        /// <inheritdoc />
        public static void Ban(long groupId, long qq, TimeSpan durationSec)
            => CQAPI.CQ_setGroupBan(_cqauthcode, groupId, qq, (long)Math.Floor(durationSec.TotalSeconds));

        /// <inheritdoc />
        public static void Ban(long groupId, long qq, int duration) => CQAPI.CQ_setGroupBan(_cqauthcode, groupId, qq, duration);

        /// <inheritdoc />
        public static void RemoveBanned(long groupId, long qq) => Ban(groupId, qq, 0);

        /// <inheritdoc />
        public static void SetAsAdmin(long groupId, long qq) => CQAPI.CQ_setGroupAdmin(_cqauthcode, groupId, qq, 1);

        /// <inheritdoc />
        public static void RevokeAdmin(long groupId, long qq) => CQAPI.CQ_setGroupAdmin(_cqauthcode, groupId, qq, 0);

        /// <inheritdoc />
        public static void BanAll(long groupId) => CQAPI.CQ_setGroupWholeBan(_cqauthcode, groupId, 1);

        /// <inheritdoc />
        public static void RemoveBannedAll(long groupId) => CQAPI.CQ_setGroupWholeBan(_cqauthcode, groupId, 0);

        /// <inheritdoc />
        public static void BanAnonymous(long groupId, string anonymous, TimeSpan duration)
            => CQAPI.CQ_setGroupAnonymousBan(_cqauthcode, groupId, anonymous, (long)Math.Floor(duration.TotalSeconds));

        /// <inheritdoc />
        public static void BanAnonymous(long groupId, string anonymous, long duration)
           => CQAPI.CQ_setGroupAnonymousBan(_cqauthcode, groupId, anonymous, duration);

        /// <inheritdoc />
        public static void EnableAnonymousChat(long groupId) => CQAPI.CQ_setGroupAnonymous(_cqauthcode, groupId, 1);

        /// <inheritdoc />
        public static void DisableAnonymousChat(long groupId) => CQAPI.CQ_setGroupAnonymous(_cqauthcode, groupId, 0);

        /// <inheritdoc />
        public static void SetGroupCard(long groupId, long qq, string newCard) => CQAPI.CQ_setGroupCard(_cqauthcode, groupId, qq, newCard);

        /// <inheritdoc />
        public static void QuitTheGroup(long groupId) => CQAPI.CQ_setGroupLeave(_cqauthcode, groupId, 0);

        /// <inheritdoc />
        public static void QuitAndDismissTheGroup(long groupId) => CQAPI.CQ_setGroupLeave(_cqauthcode, groupId, 1);

        /// <inheritdoc />
        public static void SetGroupTitle(long groupId, long qq, string newTitle)
            => CQAPI.CQ_setGroupSpecialTitle(_cqauthcode, groupId, qq, newTitle, -1);

        /// <inheritdoc />
        public static void SetGroupTitle(long groupId, long qq, string newTitle, long duration)
            => CQAPI.CQ_setGroupSpecialTitle(_cqauthcode, groupId, qq, newTitle, duration);

        /// <inheritdoc />
        public static void QuitTheDiscussGroup(long discussGroupId) => CQAPI.CQ_setDiscussLeave(_cqauthcode, discussGroupId);


        /// <inheritdoc />
        public static void ProcessAddGroupRequest(string responseMark, CQAddGroupRequestType resquestType, CQRequestResult operation, string reason)
            => CQAPI.CQ_setGroupAddRequestV2(_cqauthcode, responseMark, (int)resquestType, (int)operation, reason);

        /// <inheritdoc />
        public static List<GroupMemberInfo> GetGroupMemberList(long groupId) {
            lock (__syncRoot) {
                List<GroupMemberInfo> lst = new List<GroupMemberInfo>();
                try {
                    var lstString = CQAPI.CQ_getGroupMemberList(_cqauthcode, groupId);
                    if (string.IsNullOrEmpty(lstString) || !ConvertStrToGroupMembersList(lstString, ref lst)) {
                        return null;
                    }
                    Log(CQLogLevel.Debug, "Get Group Member List For: " + groupId.ToString());
                } catch (Exception e) {
                    Log(CQLogLevel.Error, string.Format("GetGroupMemberList({0}): {1}", groupId, e.Message));
                }
                return lst;
            }
        }

        /// <summary> </summary>
        private static bool ConvertStrToGroupMembersList(string source, ref List<GroupMemberInfo> lsGm) {
            Unpack u = new Unpack();
            if (source == string.Empty)
                return false;
            var data = Convert.FromBase64String(source);
            if (data == null || data.Length < 10)
                return false;
            u.SetData(data);

            var count = u.GetInt();
            for (int i = 0; i < count; i++) {
                if (u.Len() <= 0)
                    return false;
                GroupMemberInfo gm = new GroupMemberInfo();
                if (!ConvertAnsiHexToGroupMembers(u.GetToken(), ref gm))
                    return false;
                lsGm.Add(gm);
            }
            return true;
        }

        /// <summary> </summary>
        private static bool ConvertAnsiHexToGroupMembers(byte[] source, ref GroupMemberInfo gm) {
            if (source == null || source.Length < 40)
                return false;
            Unpack u = new Unpack();
            u.SetData(source);
            gm.GroupId = u.GetLong();
            gm.Number = u.GetLong();
            gm.NickName = u.GetLenStr();
            gm.InGroupName = u.GetLenStr();
            gm.Gender = u.GetInt() == 0 ? "男" : "女";
            gm.Age = u.GetInt();
            gm.Area = u.GetLenStr();
            gm.JoinTime = new DateTime(1970, 1, 1, 0, 0, 0).ToLocalTime().AddSeconds(u.GetInt());
            gm.LastSpeakingTime = new DateTime(1970, 1, 1, 0, 0, 0).ToLocalTime().AddSeconds(u.GetInt());
            gm.Level = u.GetLenStr();
            gm.Authority = u.GetInt().ToString();
            gm.HasBadRecord = (u.GetInt() == 1);
            gm.Title = u.GetLenStr();
            gm.TitleExpirationTime = u.GetInt();
            gm.IsInGroupNameModifiable = (u.GetInt() == 1);
            return true;
        }

        [NonSerialized]
        private static object __syncRoot = new object();

    }
}
