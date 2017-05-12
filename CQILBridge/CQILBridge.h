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

		int32_t ILBridge::Initialize(int32_t authCode);

		void ILBridge::Exit();

		int32_t ILBridge::Enabled();
		int32_t ILBridge::Disabled();

		int32_t ILBridge::ProcessPrivateMessageEvent(int32_t subType, int32_t sendTime, int64_t fromQQ, const char *msg, int32_t font);
		int32_t ILBridge::ProcessGroupMessageEvent(int32_t subType, int32_t sendTime, int64_t fromGroup, int64_t fromQQ, const char *fromAnonymous, const char *msg, int32_t font);
		int32_t ILBridge::ProcessDiscussMessageEvent(int32_t subType, int32_t sendTime, int64_t fromDiscuss, int64_t fromQQ, const char *msg, int32_t font);
		int32_t ILBridge::ProcessGroupAdminEvent(int32_t subType, int32_t sendTime, int64_t fromGroup, int64_t beingOperateQQ);
		int32_t ILBridge::ProcessGroupMemberIncreaseEvent(int32_t subType, int32_t sendTime, int64_t fromGroup, int64_t fromQQ, int64_t beingOperateQQ);
		int32_t ILBridge::ProcessGroupMemberDecreaseEvent(int32_t subType, int32_t sendTime, int64_t fromGroup, int64_t fromQQ, int64_t beingOperateQQ);
		int32_t ILBridge::ProcessFriendAddEvent(int32_t subType, int32_t sendTime, int64_t fromQQ);
		int32_t ILBridge::ProcessRequestAddFriendEvent(int32_t subType, int32_t sendTime, int64_t fromQQ, const char *msg, const char *responseFlag);
		int32_t ILBridge::ProcessRequestAddGroupEvent(int32_t subType, int32_t sendTime, int64_t fromGroup, int64_t fromQQ, const char *msg, const char *responseFlag);
		int32_t ILBridge::ProcessGroupUploadEvent(int32_t subType, int32_t sendTime, int64_t fromGroup, int64_t fromQQ, const char *file);

		int32_t ILBridge::ProcessPanelEvent();
	};
}
