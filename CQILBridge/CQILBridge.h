// CQILBridge.h

#pragma once
using namespace System;

namespace CQILBridge {

	class ILAdapter;

	class ILBridge {
	private:
		ILAdapter* m_adapter;

	public:
		ILBridge();
		~ILBridge();

		int32_t Initialize(int32_t authCode);
		int32_t Exit();

		int32_t Enabled();
		int32_t Disabled();
		int32_t PrivateMessageEvent(int32_t subType, int32_t sendTime, int64_t fromQQ, const char *msg, int32_t font);
		int32_t GroupMessageEvent(int32_t subType, int32_t sendTime, int64_t fromGroup, int64_t fromQQ, const char *fromAnonymous, const char *msg, int32_t font);
		int32_t DiscussMessageEvent(int32_t subType, int32_t sendTime, int64_t fromDiscuss, int64_t fromQQ, const char *msg, int32_t font);
		int32_t GroupAdminEvent(int32_t subType, int32_t sendTime, int64_t fromGroup, int64_t beingOperateQQ);
		int32_t GroupMemberIncreaseEvent(int32_t subType, int32_t sendTime, int64_t fromGroup, int64_t fromQQ, int64_t beingOperateQQ);
		int32_t GroupMemberDecreaseEvent(int32_t subType, int32_t sendTime, int64_t fromGroup, int64_t fromQQ, int64_t beingOperateQQ);
		int32_t FriendAddEvent(int32_t subType, int32_t sendTime, int64_t fromQQ);
		int32_t RequestAddFriendEvent(int32_t subType, int32_t sendTime, int64_t fromQQ, const char *msg, const char *responseFlag);
		int32_t RequestAddGroupEvent(int32_t subType, int32_t sendTime, int64_t fromGroup, int64_t fromQQ, const char *msg, const char *responseFlag);
		int32_t GroupUploadEvent(int32_t subType, int32_t sendTime, int64_t fromGroup, int64_t fromQQ, const char *file);
		int32_t SettingPanelEvent();
	};
}
